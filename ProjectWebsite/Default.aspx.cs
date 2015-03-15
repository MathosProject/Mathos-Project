using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using Mathos.Converter;
using Mathos.Parser;
using Mathos.Arithmetic.Numbers;
using Mathos.Statistics;

namespace ProjectWebsite
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MathParser parser = new MathParser();
            string resultA = "";

            #region LoadFuncs
            parser.LocalFunctions.Add("isprime", x =>
            {
                if (x[0] % 1 == 0) // check if it's an integer
                {
                    return Check.IsPrime((long)x[0]) == true ? 1 : 0;
                }
                else
                {
                    throw new ArgumentException("The input is not an integer");
                }
            });

            parser.LocalFunctions.Add("isodd", x =>
            {
                if (x[0] % 1 == 0) // check if it's an integer
                {
                    return Check.IsOdd((long)x[0]) == true ? 1 : 0;
                }
                else
                {
                    throw new ArgumentException("The input is not an integer");
                }
            });

            parser.LocalFunctions.Add("iseven", x =>
            {
                if (x[0] % 1 == 0) // check if it's an integer
                {
                    return Check.IsEven((long)x[0]) == true ? 1 : 0;
                }
                else
                {
                    throw new ArgumentException("The input is not an integer");
                }
            });

            parser.LocalFunctions.Add("iscoprime", x =>
            {
                if (x[0] % 1 == 0) // check if it's an integer
                {
                    return Check.IsCoprime((long)x[0], (long)x[1]) == true ? 1 : 0;
                }
                else
                {
                    throw new ArgumentException("The input is not an integer");
                }
            });

            parser.LocalFunctions.Add("gdc", x =>
            {
                if (x[0] % 1 == 0) // check if it's an integer
                {
                    return Get.Gdc((long)x[0], (long)x[1]);
                }
                else
                {
                    throw new ArgumentException("The input is not an integer");
                }
            });
            parser.LocalFunctions.Add("lcm", x =>
            {
                if (x[0] % 1 == 0) // check if it's an integer
                {
                    return Get.Lcm((long)x[0], (long)x[1]);
                }
                else
                {
                    throw new ArgumentException("The input is not an integer");
                }
            });
            parser.LocalFunctions.Add("mod", x =>
            {
                if (x[0] % 1 == 0) // check if it's an integer
                {
                    return Get.Mod((long)x[0], (long)x[1]);
                }
                else
                {
                    throw new ArgumentException("The input is not an integer");
                }
            });

            parser.LocalFunctions.Add("mean", x =>
            {
                decimal result = 0;
                for (int i = 0; i < x.Length; i++)
                {
                    result += x[i];
                }
                return result / x.Length;
            });

            parser.LocalFunctions.Add("bindec", x =>
                {
                    string returnvalue = Converter.From(Base.Base2, x[0].ToString(parser.CULTURE_INFO)).To(Base.Base10);
                    resultA += @"<table style='border:1px solid green;margin:3px;float:left;'><tr><th>Binary</th><th>Decimal</th></tr>
                                 <tr><td>" + x[0].ToString(parser.CULTURE_INFO) + @"</td><td>" + returnvalue + @"</td></tr></table><div style='clear:both;'></div>";

                    return System.Convert.ToDecimal(returnvalue);
                });
            parser.LocalFunctions.Add("decbin", x =>
            {
                string returnvalue = Converter.From(Base.Base10, x[0].ToString()).To(Base.Base2);
                resultA += @"<table style='border:1px solid green;margin:3px;float:left;'><tr><th>Decimal</th><th>Binary</th></tr>
                                 <tr><td>" + x[0].ToString() + @"</td><td>" + returnvalue + @"</td></tr></table><div style='clear:both;'></div>";

                return System.Convert.ToDecimal(returnvalue);
            });

            bool IsDone = false;
            bool IsStart = false;
            
            List<decimal> list = new List<decimal>();
            decimal sum = 0;
            long n = 0;
            parser.LocalFunctions.Add("table", x =>
            {
                // remake this method, so that the the parser.LocalVariables["x"] < parser.LocalVariables["table_max"]
                // is in front of everything. then, we can reuse  the newWindow check code
                System.GC.Collect();
                
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
                if (IsDone == false && IsStart == false)
                {
                    parser.LocalVariables["x"] = x[1];
        
                    IsStart = true;
                    resultA += "<table style='border:1px solid green;margin:3px;float:left;'><tr><th>x</th><th>f(x)</th></tr>";
                }

                if (parser.LocalVariables["x"] <= x[2] && IsDone == false)
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
<tr><td>" + (double)StatisticalProcedures.SumOfListElements(list) + @"</td><td>" + (double)StatisticalProcedures.Mean(list) + @"</td><td>" + (double)StatisticalProcedures.Median(list) + @"</td></tr>
</table>
<br />
<br />
<br />
<a href='?expression=" + Request["expression"].Replace("table", "sum") + @"' style='margin:3px;float:right;'>(sum)</a><br />
<br />
<a href='?expression=seq()' style='margin:3px;float:right;'>(more)</a>
<div style='clear:both;'></div>";
                   
                    IsStart = false;
                    return 1;
                }

             
                return 1;
            });


            parser.LocalFunctions.Add("sum", x =>
            {
                // remake this method, so that the the parser.LocalVariables["x"] < parser.LocalVariables["table_max"]
                // is in front of everything. then, we can reuse  the newWindow check code
                System.GC.Collect();

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
                if (IsDone == false && IsStart == false)
                {
                    parser.LocalVariables["x"] = x[1];

                    IsStart = true;
                    resultA += "<table style='border:1px solid green;margin:3px;float:left;'><tr><th>x</th><th>f(x)</th></tr>";
                }

                if (parser.LocalVariables["x"] <= x[2] && IsDone == false)
                {
                    list.Add(x[0]);

                    resultA += "<tr><td>" + parser.LocalVariables["x"] + "</td><td>" + StatisticalProcedures.SumOfListElements(list) + "</td></tr>";
                    

                    parser.LocalVariables["x"] += x.Length == 3 ? 1 : x[3];

                    parser.Parse(Request["expression"]);
                    parser.LocalVariables["x"] += x.Length == 3 ? 1 : x[3];

                }
                else
                {
                    //IsDone = true;

                    resultA += @"</table>
<table style='border:1px solid green;margin:3px;float:right;'><tr><th>Sum</th><th>Mean</th><th>Median</th></tr>
<tr><td>" + (double)StatisticalProcedures.SumOfListElements(list) + @"</td><td>" + (double)StatisticalProcedures.Mean(list) + @"</td><td>" + (double)StatisticalProcedures.Median(list) + @"</td></tr>
</table>
<br />
<br />
<br />
<a href='?expression="+ Request["expression"].Replace("sum","table")+ @"' style='margin:3px;float:right;'>(table)</a><br />
<br />
<a href='?expression=seq()' style='margin:3px;float:right;'>(more)</a>
<div style='clear:both;'></div>";

                    IsStart = false;
                    return 1;
                }


                return 1;
            });

            decimal upper = 0;
            bool IsUpper = false;
            decimal lower = 0;
            bool IsLower = false;
            bool IsParserDone = false;
            bool IsParserDone2 = false;
            decimal h = 0.00000001M;// 0.00000000001M;
            parser.LocalFunctions.Add("d", x =>
            {
                // remake this method, so that the the parser.LocalVariables["x"] < parser.LocalVariables["table_max"]
                // is in front of everything. then, we can reuse  the newWindow check code
                System.GC.Collect();

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
                if (!IsUpper)
                {
                    
                    parser.LocalVariables["x"] = x[1] + h;
                    if (!IsParserDone)
                    {
                        IsParserDone = true;
                        parser.Parse(Request["expression"]);
                        IsParserDone = false;
                        
                    }
                    if (IsParserDone)
                    {
                        IsUpper = true;
                        upper = x[0];
                    }
                    //IsParserDone = false;
                }

                if (!IsLower && IsUpper && IsParserDone == false )
                {
                    //lower = x[0];
                    parser.LocalVariables["x"] = x[1];
                    if (!IsParserDone2)
                    {
                        IsParserDone2 = true;
                       
                        parser.Parse(Request["expression"]);
                        IsParserDone2 = false;
                        //IsUpper = true;
                       
                    }

                    if (IsParserDone2)
                    {
                        IsLower = true;
                        lower = x[0];
                    }
                    
                }

                //check the no. of times this is executed.
                if (IsLower && IsUpper && !IsParserDone2 )
                {
                    return Math.Round((upper - lower) / h);
                }
                else
                {
                    return 0;
                }

            });


            parser.LocalFunctions.Add("seq", x =>
                {
                    resultA += "This function is currently under development.";
                    //under development.
                    return 0;
                });
            #endregion

            #region LoadVariables
System.Globalization.CultureInfo ci = System.Threading.Thread.CurrentThread.CurrentCulture;

            Int32 monthNo = ci.Calendar.GetMonth(DateTime.Today);
            Int32 weekNo = ci.Calendar.GetWeekOfYear(DateTime.Today,
                                                     ci.DateTimeFormat.CalendarWeekRule,
                                                     ci.DateTimeFormat.FirstDayOfWeek
                                                     );

Int32 dayNo = ci.Calendar.GetDayOfYear(DateTime.Today);
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
                if (x % 1 == 0 && y % 1 == 0)
                {
                    long returnValue = (long)x ^ (long)y;
                    resultA += @"<table style='border:1px solid green;margin:3px;float:left;'><tr><th>Decimal</th><th>Binary</th></tr>
<tr><td style='text-align:center'>" + x.ToString() + @"</td><td style='text-align:right'>" + Converter.From(Base.Base10, x.ToString()).To(Base.Base2) + @"</td></tr>
<tr><td style='text-align:center'>" + y.ToString() + @"</td><td style='text-align:right'>" + Converter.From(Base.Base10, y.ToString()).To(Base.Base2) + @"</td></tr>
<tr><td style='text-align:center'>" + returnValue.ToString() + @"</td><td style='text-align:right'>" + Converter.From(Base.Base10, returnValue.ToString()).To(Base.Base2) + @"</td></tr>
</table><div style='clear:both;'></div>";
                    return returnValue;
                }
                else
                {
                    throw new ArgumentException("The input is not an integer");
                }
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
                {
                    return x[1];
                }
                else
                {
                    if (x.Length == 3)
                    {
                        return x[2];
                    }
                    else
                    {
                        return 0;
                    }
                }
            });
            #endregion

            if (Request["expression"] != null)
            {
                text.Value = Request["expression"];
                parser.LocalVariables.Add("x", 0);
                try
                {
                    result.Style.Add("border", "1px solid blue");
                    result.InnerHtml += "Result: " + parser.Parse(Request["expression"]).ToString(parser.CULTURE_INFO);
                    result.InnerHtml +="<br />" +resultA;
                    
                    

                }
                catch( Exception ex)
                {
                    result.InnerHtml = ex.Message .ToString();
                }
            }
            
        }

    }
}