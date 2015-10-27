using System;
using System.Diagnostics;
using System.Web.UI;
using Mathos.Arithmetic;
using Mathos.Parser;
using Mathos.Statistics;

namespace Laboratory.Module
{
    public partial class Uncertainty : Page
    {
        private readonly MathParser _parser = new MathParser();

        protected void Page_Load(object sender, EventArgs e)
        {
            _parser.OperatorAction["^"] = Pow;
            _parser.LocalVariables.Add("x", 0);

            _parser.LocalFunctions.Add("ln", x => DecimalArithmetic.Ln(x[0], 2000));
        }

        protected void CalculateButton_Click(object sender, EventArgs e)
        {
            if (functionInput.Text == "")
                return;

            try
            {
                var watch = new Stopwatch();
                watch.Start();

                TableOutput.InnerText =
                    UncertainNumber.ConvertArrayToTsvString(
                        UncertainNumber.AutoFormat(UncertainNumber.CustomFunction(Func, tableInput.InnerText)));

                watch.Stop();
                ElapsedTimeLabel.Text = string.Format("Elapsed time: {0} ms", watch.Elapsed.TotalMilliseconds);
            }
            catch
            {
                TableOutput.InnerText = "Something went wrong. Check so that you've entered the function correctly.";
            }
        }

        public decimal Func(decimal x)
        {
            _parser.LocalVariables["x"] = x;

            return _parser.ProgrammaticallyParse(functionInput.Text);
        }

        public decimal Pow(decimal x, decimal exp)
        {
            //double[] fact = { 1, 1, 2, 6, 24, 120, 720, 5040, 40320, 362880, 3628800, 39916800, 479001600, 6227020800, 87178291200, 1307674368000, 20922789888000, 355687428096000, 6402373705728000, 121645100408832000, 2432902008176640000, 51090942171709440000d, 1124000727777607680000d };

            // still developing this
            if (exp == 0)
                return 1;
            if (exp == 1)
                return x;
            if ((exp - decimal.Floor(exp)) != 0)
            {
                //for (int i = 0; i < 19; i++)
                //{
                //    decimal nom = System.Convert.ToDecimal( pow( exp * (decimal)Math.Log((double)x), i)); // (decimal)(Math.Pow((double)exp,i)*  Math.Pow( (double)exp * Math.Log(Math.Abs((double)x)),i));
                //    val += nom / (decimal)fact[i];
                //}

                return Convert.ToDecimal(Math.Exp((double) exp*Math.Log((double) x)));
            }

            decimal val = 1;

            for (var i = 0; i < exp; i++)
                val *= x;

            return val;
        }
    }
}