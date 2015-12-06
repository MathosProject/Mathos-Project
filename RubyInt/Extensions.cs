using System.Globalization;
using Mathos.Arithmetic.Fractions;
using Mathos.Parser;

using Mathos.Calculus;
using System;

using System.IO;
using IronRuby.Builtins;

using System.Collections.ObjectModel;

using System.Linq;
using Mathos;

[assembly: CLSCompliant(true)]
namespace RubyInt
{
    public class Extension
    {
        private readonly MathParser _parser = new MathParser();

        public string Exec(string expr = "")
        {
            return _parser.ProgrammaticallyParse(expr).ToString(CultureInfo.InvariantCulture);
        }

        public double Int(string expr, double lowerLimit, double upperLimit)
        {
            var expression = _parser.GetTokens(expr);

            return IntegralCalculus.Integrate(x => Eval(expression, x), lowerLimit, upperLimit);
        }

        public double Int(Func<double, double> func, double lowerLimit, double upperLimit)
        {
            return IntegralCalculus.Integrate(func, lowerLimit, upperLimit);
        }

        public double Eval(string function, double x, string varName = "x")
        {
            return Eval(_parser.GetTokens(function), x, varName);
        }

        public double Eval(ReadOnlyCollection<string> function, double x, string varName = "x")
        {
            _parser.LocalVariables[varName] = (decimal)x;

            return Convert.ToDouble(_parser.Parse(function));
        }

        public long[] Fact(long number)
        {
            return Mathos.Arithmetic.Numbers.Get.Factors(number).ToArray();
        }

        public void Save(object objectToSave, string fileName)
        {
            if (Path.GetExtension(fileName) == "")
                fileName += ".dat";

            fileName = "Saves/" + fileName;

            var sw = new StreamWriter(fileName);

            sw.Write(objectToSave);
            sw.Close();
        }

        public MutableString Load(string fileName)
        {
            if (Path.GetExtension(fileName) == "")
                fileName += ".dat";

            fileName = "Saves/" + fileName;

            var sr = new StreamReader(fileName);
            var returnObject = MutableString.CreateMutable(sr.ReadToEnd(), RubyEncoding.UTF8);
            
            sr.Close();

            return returnObject;
        }

        // for testing purposes:
        public double Time (Action action, int iterations = 1000)
        {
            return BenchmarkUtil.Benchmark(action, iterations);
        }

        public string ToSternBrocot(object fraction, bool continious =false, int b = 50)
        {
            if (fraction.GetType() == typeof (MutableString) &&
                ((MutableString) fraction).ConvertToString().Contains("/"))
                return new Fraction(((MutableString) fraction).ConvertToString()).ToSternBrocotSystem();

            return Fraction.ToSternBrocotSystem(Convert.ToDecimal(fraction), continious, b);
        }

        public string FromSternBrocot(object fraction)
        {
            var fract = new Fraction();

            if (fraction.GetType() == typeof (MutableString) &&
                (((MutableString) fraction).ConvertToString().ToUpper().Contains("L") ||
                 ((MutableString) fraction).ConvertToString().ToUpper().Contains("R")))
                fract = Fraction.FromSternBrocotSystem(((MutableString) fraction).ConvertToString());

            return fract.ToString();
        }

        public string ToCondensedSternBrocot(string fraction)
        {
            return Fraction.ToCondensedSternBrocotSystem(fraction);
        }
    }
}
