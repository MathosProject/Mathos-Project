using System;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Web.UI;
using Mathos.Calculus;
using Mathos.Parser;

namespace Laboratory.Module
{
    public partial class IntegralApproximation : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void CalculateButton_Click(object sender, EventArgs e)
        {
            Calculate();
        }

        private void Calculate()
        {
            try
            {
                var watch = new Stopwatch();

                double lowerBound;
                if (!double.TryParse(LowerBoundText.Text, NumberStyles.Any, CultureInfo.CurrentCulture, out lowerBound))
                {
                    lowerBound = 0;
                }

                double upperBound;
                if (!double.TryParse(UpperBoundText.Text, NumberStyles.Any, CultureInfo.CurrentCulture, out upperBound))
                {
                    upperBound = 0;
                }

                double numberOfIntervals;
                if (
                    !double.TryParse(NumberOfIntervalsText.Text, NumberStyles.Any, CultureInfo.CurrentCulture,
                        out numberOfIntervals))
                {
                    numberOfIntervals = 0;
                }

                // Rectangle method

                watch.Start();

                var rectangleMethodResult = Integrate(
                    ExpressionText.Text,
                    lowerBound,
                    upperBound,
                    IntegralCalculus.IntegrationAlgorithm.RectangleMethod,
                    numberOfIntervals);

                watch.Stop();

                var rectangleMethodTime = watch.ElapsedMilliseconds;

                // Trapezoidal rule

                watch.Start();

                var trapezoidalRuleResult = Integrate(
                    ExpressionText.Text,
                    lowerBound,
                    upperBound,
                    IntegralCalculus.IntegrationAlgorithm.TrapezoidalRule,
                    numberOfIntervals);

                watch.Stop();

                var trapezoidalRuleTime = watch.ElapsedMilliseconds;

                // Simpsons rule

                watch.Start();

                var simpsonsRuleResult = Integrate(
                    ExpressionText.Text,
                    lowerBound,
                    upperBound,
                    IntegralCalculus.IntegrationAlgorithm.SimpsonsRule,
                    numberOfIntervals);

                watch.Stop();

                var simpsonsRuleTime = watch.ElapsedMilliseconds;


                // Show results

                RectangleMethodResultLabel.Text = rectangleMethodResult.ToString("F10", CultureInfo.CurrentCulture);
                RectangleMethodTimeLabel.Text = rectangleMethodTime.ToString(CultureInfo.CurrentCulture);

                TrapezoidalRuleResultLabel.Text = trapezoidalRuleResult.ToString("F10", CultureInfo.CurrentCulture);
                TrapezoidalRuleTimeLabel.Text = trapezoidalRuleTime.ToString(CultureInfo.CurrentCulture);

                SimpsonsRuleResultLabel.Text = simpsonsRuleResult.ToString("F10", CultureInfo.CurrentCulture);
                SimpsonsRuleTimeLabel.Text = simpsonsRuleTime.ToString(CultureInfo.CurrentCulture);
            }
            catch (Exception)
            {
                var errorMsg = new StringBuilder();

                errorMsg.AppendLine("Something went wrong. Please check that:");
                errorMsg.AppendLine();
                errorMsg.AppendLine(" - lower/upper bounds contain only integers.");
                errorMsg.AppendLine(" - function is in form of '3x', 'x^2', etc.");
                errorMsg.AppendLine(" - no. of intervals is an integer.");
                errorMsg.AppendLine(" - make sure all fields are filled with numbers.");

                ErrorLabel.Text = errorMsg.ToString();

                RectangleMethodResultLabel.Text = "0";
                RectangleMethodTimeLabel.Text = "0";
            }
        }

        private double Integrate(
            string expression,
            double lowerLimit,
            double upperLimit,
            IntegralCalculus.IntegrationAlgorithm integrationAlgorithm,
            double numberOfIntervals = 100000)
        {
            Func<double, double> function = x => EvaluateExpression(expression, x);

            var result = IntegralCalculus.Integrate(
                function,
                lowerLimit,
                upperLimit,
                integrationAlgorithm,
                numberOfIntervals);


            return result;
        }

        private static double EvaluateExpression(string expression, double x)
        {
            var parser = new MathParser {LocalVariables = {["x"] = (decimal) x}};

            var result = parser.ProgrammaticallyParse(expression);

            return (double) result;
        }


        private decimal IntegrateUsingRectangleMethod(
            string expression,
            decimal lowerLimit,
            decimal upperLimit,
            decimal numberOfIntervals = 100000)
        {
            decimal sum = 0;
            var parser = new MathParser();
            var sizeOfInterval = ((upperLimit - lowerLimit)/numberOfIntervals);

            for (var i = 0; i < numberOfIntervals; i++)
            {
                parser.LocalVariables["x"] = lowerLimit + sizeOfInterval*i;
                sum += parser.ProgrammaticallyParse(expression)*sizeOfInterval;
            }

            var result = sum;

            return result;
        }

        private decimal IntegrateUsingTrapezoidalRule(
            string expression,
            decimal lowerLimit,
            decimal upperLimit,
            decimal numberOfIntervals = 100000)
        {
            var parser = new MathParser();
            var sizeOfInterval = ((upperLimit - lowerLimit)/numberOfIntervals);

            parser.LocalVariables["x"] = lowerLimit;
            var sum = parser.ProgrammaticallyParse(expression);

            parser.LocalVariables["x"] = upperLimit;
            sum += parser.ProgrammaticallyParse(expression);

            for (var i = 1; i < numberOfIntervals; i++)
            {
                parser.LocalVariables["x"] = lowerLimit + i*sizeOfInterval;
                sum += parser.ProgrammaticallyParse(expression)*2;
            }

            var result = sum*sizeOfInterval/2;

            return result;
        }

        private decimal IntegrateUsingSimpsonsRule(
            string expression,
            decimal lowerLimit,
            decimal upperLimit,
            decimal numberOfIntervals = 100000)
        {
            var parser = new MathParser();
            var sizeOfInterval = ((upperLimit - lowerLimit)/numberOfIntervals);

            parser.LocalVariables["x"] = lowerLimit;

            var sum = parser.ProgrammaticallyParse(expression);

            for (var i = 1; i < numberOfIntervals; i += 2)
            {
                parser.LocalVariables["x"] = lowerLimit + sizeOfInterval*i;
                sum += 4*parser.ProgrammaticallyParse(expression);
            }

            for (var i = 2; i < numberOfIntervals - 1; i += 2)
            {
                parser.LocalVariables["x"] = lowerLimit + sizeOfInterval*i;
                sum += 2*parser.ProgrammaticallyParse(expression);
            }

            parser.LocalVariables["x"] = upperLimit;
            sum += parser.ProgrammaticallyParse(expression);

            var result = sum*sizeOfInterval/3;

            return result;
        }
    }
}