using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web.UI;
using Mathos.Arithmetic.Numbers;
using Mathos.Converter;
using Mathos.Parser;
using Mathos.Statistics;
using Convert = System.Convert;

namespace ProjectWebsite
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var parser = new MathParser();
            var resultA = "";

            #region LoadFuncs
            parser.LocalFunctions.Add("isprime", x =>
            {
                if (x[0]%1 == 0) // check if it's an integer
                    return Check.IsPrime((long) x[0]) ? 1 : 0;

                throw new ArgumentException("The input is not an integer");
            });

            parser.LocalFunctions.Add("isodd", x =>
            {
                if (x[0]%1 == 0) // check if it's an integer
                    return Check.IsOdd((long) x[0]) ? 1 : 0;

                throw new ArgumentException("The input is not an integer");
            });

            parser.LocalFunctions.Add("iseven", x =>
            {
                if (x[0]%1 == 0) // check if it's an integer
                    return Check.IsEven((long) x[0]) ? 1 : 0;

                throw new ArgumentException("The input is not an integer");
            });

            parser.LocalFunctions.Add("iscoprime", x =>
            {
                if (x[0]%1 == 0) // check if it's an integer
                    return Check.IsCoprime((long) x[0], (long) x[1]) ? 1 : 0;
                
                throw new ArgumentException("The input is not an integer");
            });

            parser.LocalFunctions.Add("gdc", x =>
            {
                if (x[0]%1 == 0) // check if it's an integer
                    return Get.Gdc((long) x[0], (long) x[1]);

                throw new ArgumentException("The input is not an integer");
            });

            parser.LocalFunctions.Add("lcm", x =>
            {
                if (x[0]%1 == 0) // check if it's an integer
                    return Get.Lcm((long) x[0], (long) x[1]);

                throw new ArgumentException("The input is not an integer");
            });

            parser.LocalFunctions.Add("mod", x =>
            {
                if (x[0]%1 == 0) // check if it's an integer
                    return Get.Mod((long) x[0], (long) x[1]);

                throw new ArgumentException("The input is not an integer");
            });

            parser.LocalFunctions.Add("mean", x => x.Sum() / x.Length);

            parser.LocalFunctions.Add("bindec", x =>
            {
                var returnvalue = Converter.From(Base.Base2, x[0].ToString(parser.CultureInfo)).To(Base.Base10);

                resultA += @"<table style='border:1px solid green;margin:3px;float:left;'><tr><th>Binary</th><th>Decimal</th></tr>
                                <tr><td>" + x[0].ToString(parser.CultureInfo) + @"</td><td>" + returnvalue +
                           @"</td></tr></table><div style='clear:both;'></div>";

                return Convert.ToDecimal(returnvalue);
            });

            parser.LocalFunctions.Add("decbin", x =>
            {
                var returnvalue = Converter.From(Base.Base10, x[0].ToString(CultureInfo.InvariantCulture)).To(Base.Base2);
                
                resultA += @"<table style='border:1px solid green;margin:3px;float:left;'><tr><th>Decimal</th><th>Binary</th></tr>
                                 <tr><td>" + x[0].ToString(CultureInfo.InvariantCulture) + @"</td><td>" + returnvalue + @"</td></tr></table><div style='clear:both;'></div>";

                return Convert.ToDecimal(returnvalue);
            });

            var isStart = false;
            var list = new List<decimal>();

            //const bool isDone = false;
            
            parser.LocalFunctions.Add("table", x =>
            {
                // remake this method, so that the the parser.LocalVariables["x"] < parser.LocalVariables["table_max"]
                // is in front of everything. then, we can reuse  the newWindow check code
                GC.Collect();
                
                if (x.Length < 3)
                {
                    resultA += "Error: the function requires 3 parameters.";
                
                    return 0;
                }

                if (x.Length == 4)
                {
                    if (x[3] <= 0)
                    {
                        resultA += "Error: the step cannot be zero.";
                    
                        return 0;
                    }
                }

                if (isStart == false)
                {
                    parser.LocalVariables["x"] = x[1];
        
                    isStart = true;
                    resultA += "<table style='border:1px solid green;margin:3px;float:left;'><tr><th>x</th><th>f(x)</th></tr>";
                }

                if (parser.LocalVariables["x"] <= x[2])
                {
                    parser.Parse(Request["expression"]);

                    resultA += "<tr><td>" +parser.LocalVariables["x"] + "</td><td>"  + x[0] + "</td></tr>";
                    
                    list.Add(x[0]);

                    parser.LocalVariables["x"] += x.Length == 3 ? 1 : x[3];
                   
                    //parser.Parse(Request["expression"]);
                    //parser.LocalVariables["x"] += x.Length == 3 ? 1 : x[3];
                }
                else
                {
                    //IsDone = true;
                    
                    resultA += @"</table>
<table style='border:1px solid green;margin:3px;float:right;'><tr><th>Sum</th><th>Mean</th><th>Median</th></tr>
<tr><td>" + (double)list.SumOfListElements() + @"</td><td>" + (double)list.Mean() + @"</td><td>" + (double)list.Median() + @"</td></tr>
</table>
<br />
<br />
<br />
<a href='?expression=" + Request["expression"].Replace("table", "sum") + @"' style='margin:3px;float:right;'>(sum)</a><br />
<br />
<a href='?expression=seq()' style='margin:3px;float:right;'>(more)</a>
<div style='clear:both;'></div>";
                   
                    isStart = false;

                    return 1;
                }

             
                return 1;
            });

            parser.LocalFunctions.Add("sum", x =>
            {
                // remake this method, so that the the parser.LocalVariables["x"] < parser.LocalVariables["table_max"]
                // is in front of everything. then, we can reuse  the newWindow check code
                GC.Collect();

                if (x.Length < 3)
                {
                    resultA += "Error: the function requires 3 parameters.";
                    return 0;
                }

                if (x.Length == 4)
                {
                    if (x[3] <= 0)
                    {
                        resultA += "Error: the step cannot be zero.";
                
                        return 0;
                    }
                
                }
                if (isStart == false)
                {
                    parser.LocalVariables["x"] = x[1];

                    isStart = true;
                    resultA += "<table style='border:1px solid green;margin:3px;float:left;'><tr><th>x</th><th>f(x)</th></tr>";
                }

                if (parser.LocalVariables["x"] <= x[2])
                {
                    list.Add(x[0]);

                    resultA += "<tr><td>" + parser.LocalVariables["x"] + "</td><td>" + list.SumOfListElements() + "</td></tr>";

                    parser.LocalVariables["x"] += x.Length == 3 ? 1 : x[3];

                    parser.Parse(Request["expression"]);
                    parser.LocalVariables["x"] += x.Length == 3 ? 1 : x[3];

                }
                else
                {
                    //IsDone = true;

                    resultA += @"</table>
<table style='border:1px solid green;margin:3px;float:right;'><tr><th>Sum</th><th>Mean</th><th>Median</th></tr>
<tr><td>" + (double)list.SumOfListElements() + @"</td><td>" + (double)list.Mean() + @"</td><td>" + (double)list.Median() + @"</td></tr>
</table>
<br />
<br />
<br />
<a href='?expression="+ Request["expression"].Replace("sum","table")+ @"' style='margin:3px;float:right;'>(table)</a><br />
<br />
<a href='?expression=seq()' style='margin:3px;float:right;'>(more)</a>
<div style='clear:both;'></div>";

                    isStart = false;
                    return 1;
                }


                return 1;
            });

            decimal upper = 0;
            decimal lower = 0;

            var isUpper = false;
            var isLower = false;
            var isParserDone = false;
            var isParserDone2 = false;

            const decimal h = 0.00000001M; // 0.00000000001M;
            
            parser.LocalFunctions.Add("d", x =>
            {
                // remake this method, so that the the parser.LocalVariables["x"] < parser.LocalVariables["table_max"]
                // is in front of everything. then, we can reuse  the newWindow check code
                GC.Collect();

                if (x[0]==0 && x.Length < 2)
                {
                    resultA += "Error: Please enter a function. The derivative is calculated with respect to x, i.e. d/dx(f(x)).";
                    return 0;
                }

                if (x.Length < 2)
                {
                    resultA += "Error: Please provide me with an x coordinate.";
                    return 0;
                }

                if (!isUpper)
                {
                    
                    parser.LocalVariables["x"] = x[1] + h;

                    if (!isParserDone)
                    {
                        isParserDone = true;
                        parser.Parse(Request["expression"]);
                        isParserDone = false;
                        
                    }

                    if (isParserDone)
                    {
                        isUpper = true;
                        upper = x[0];
                    }

                    //IsParserDone = false;
                }

                if (!isLower && isUpper && isParserDone == false )
                {
                    //lower = x[0];
                    parser.LocalVariables["x"] = x[1];

                    if (!isParserDone2)
                    {
                        isParserDone2 = true;
                       
                        parser.Parse(Request["expression"]);
                        isParserDone2 = false;
                        //IsUpper = true;
                       
                    }

                    if (isParserDone2)
                    {
                        isLower = true;
                        lower = x[0];
                    }
                }

                //check the no. of times this is executed.
                if (isLower && isUpper && !isParserDone2)
                    return Math.Round((upper - lower)/h);

                return 0;
            });

            parser.LocalFunctions.Add("seq", x =>
            {
                resultA += "This function is currently under development.";
            
                //under development.
                
                return 0;
            });

            #endregion

            #region LoadVariables
            var ci = Thread.CurrentThread.CurrentCulture;

            var monthNo = ci.Calendar.GetMonth(DateTime.Today);
            var weekNo = ci.Calendar.GetWeekOfYear(DateTime.Today,
                                                     ci.DateTimeFormat.CalendarWeekRule,
                                                     ci.DateTimeFormat.FirstDayOfWeek
                                                     );

            var dayNo = ci.Calendar.GetDayOfYear(DateTime.Today);
            
            parser.LocalVariables.Add("month", monthNo);
            parser.LocalVariables.Add("week", weekNo);
            parser.LocalVariables.Add("day", dayNo);
            
            #endregion

            #region LoadOperators

            parser.OperatorList.Add("$");
            parser.OperatorList.Add("isnot");
            parser.OperatorList.Add("and");
            parser.OperatorList.Add("or");
      

            parser.OperatorAction.Add("isnot", (x, y) => (x != y) ? 1 : 0);
            parser.OperatorAction.Add("and", (x, y) => (x == 1 && y == 1) ? 1 : 0);
            parser.OperatorAction.Add("or", (x, y) => (x == 1 || y == 1) ? 1 : 0);
            parser.OperatorAction.Add("$", (x, y) =>
            {
                if (x%1 != 0 || y%1 != 0)
                    throw new ArgumentException("The input is not an integer");

                var returnValue = (long)x ^ (long)y;

                resultA += @"<table style='border:1px solid green;margin:3px;float:left;'><tr><th>Decimal</th><th>Binary</th></tr>
<tr><td style='text-align:center'>" + x.ToString(CultureInfo.InvariantCulture) + @"</td><td style='text-align:right'>" + Converter.From(Base.Base10, x.ToString(CultureInfo.InvariantCulture)).To(Base.Base2) + @"</td></tr>
<tr><td style='text-align:center'>" + y.ToString(CultureInfo.InvariantCulture) + @"</td><td style='text-align:right'>" + Converter.From(Base.Base10, y.ToString(CultureInfo.InvariantCulture)).To(Base.Base2) + @"</td></tr>
<tr><td style='text-align:center'>" + returnValue.ToString() + @"</td><td style='text-align:right'>" + Converter.From(Base.Base10, returnValue.ToString()).To(Base.Base2) + @"</td></tr>
</table><div style='clear:both;'></div>";

                return returnValue;
            });

            //parser.OperatorAction["^"] = delegate(decimal x, decimal y)
            //{
            //    decimal returnValue = 1;
            //    if (y == 0)
            //    {
            //        returnValue = 1;
            //    }
            //    else if (y == 1)
            //    {
            //        returnValue = x;
            //    }
            //    else if (y > 1)
            //    {
            //        for (int i = 0; i < y; i++)
            //        {
            //            returnValue *= x;
            //        }
            //    }
            //    else if (y < 0)
            //    {
            //        for (int i = 0; i > y; i--)
            //        {
            //            returnValue *= 1/x;
            //        }
            //    }
            //    return returnValue;
            //};
          

            parser.LocalFunctions.Add("if", x =>
            {
                if (x[0] == 1)
                    return x[1];

                return x.Length == 3 ? x[2] : 0;
            });

            #endregion

            if (Request["expression"] == null)
                return;

            text.Value = Request["expression"];
            parser.LocalVariables.Add("x", 0);

            try
            {
                result.Style.Add("border", "1px solid blue");
                result.InnerHtml += "Result: " + parser.Parse(Request["expression"]).ToString(parser.CultureInfo);
                result.InnerHtml +="<br />" +resultA;
            }
            catch( Exception ex)
            {
                result.InnerHtml = ex.Message;
            }
        }
    }
}