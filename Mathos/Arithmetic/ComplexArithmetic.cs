using System;
using System.Globalization;
using System.Numerics;

namespace Mathos.Arithmetic
{
    /// <summary>
    /// 
    /// </summary>
    public static class ComplexArithmetic
    {
        /// <summary>
        /// </summary>
        /// <param name="z"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static Complex[] RootsOf(Complex z, int n)
        {
            var roots = new Complex[n];

            for (var i = 0; i < n; i++)
                roots[i] = RootOf(z, n, i + 1);

            return roots;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="z"></param>
        /// <param name="n"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static Complex RootOf(Complex z, int n, int index)
        {
            if (n < index)
                throw new ArgumentOutOfRangeException();

            var magnitude = z.Magnitude;
            
            if (Math.Abs(magnitude) < 1)
                return 0;

            var rootMagnitude = Math.Pow(magnitude, 1.0 / n);
            var phase = z.Phase;

            var newPhase = phase / n + Math.PI * 2 * (index - 1) / n;

            return Complex.FromPolarCoordinates(rootMagnitude, newPhase);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="z"></param>
        /// <returns></returns>
        public static double MagnitudeSqr(Complex z)
        {
            return z.Real * z.Real + z.Imaginary * z.Imaginary;
        }

        /// <summary>
        /// </summary>
        /// <param name="z"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static Complex[] Roots(this Complex z, int n)
        {
            return RootsOf(z, n);
        }

        /// <summary>
        /// </summary>
        /// <param name="z"></param>
        /// <param name="n"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static Complex Root(this Complex z, int n, int index)
        {
            return RootOf(z, n, index);
        }

        // more accurate alternatives

        /// <summary>
        /// 
        /// </summary>
        /// <param name="z"></param>
        /// <returns></returns>
        public static Complex Sqrt(Complex z)
        {
            var x = z.Real;
            var y = z.Imaginary;
            var w = 0.0;

            var xAbs = Math.Abs(x);
            var yAbs = Math.Abs(y);

            if (Math.Abs(x - y) > 0)
            {
                double r;

                if (xAbs >= yAbs)
                {
                    r = y / x;
                    w = Math.Sqrt(xAbs) *
                        Math.Sqrt(
                        (1 + Math.Sqrt(1 + r * r))
                        / 2);
                }
                else
                {
                    r = x / y;
                    w = Math.Sqrt(yAbs) *
                        Math.Sqrt(
                        (Math.Abs(r) + Math.Sqrt(1 + r * r))
                        / 2);
                }
            }

            if (Math.Abs(w) < 1)
                return Complex.Zero;
            if (x >= 0)
                return new Complex(w, y/(2*w));

            return y >= 0 ? new Complex(yAbs/(2*w), w) : new Complex(yAbs/(2*w), -w);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="z1"></param>
        /// <param name="z2"></param>
        /// <returns></returns>
        public static Complex Multiply(Complex z1, Complex z2)
        {
            var a = z1.Real; 
            var b = z1.Imaginary;
            var c = z2.Real; 
            var d = z2.Imaginary;

            var re = a * c - b * d;
            var ime = (a + b) * (c + d) - a * c - b * d;

            return new Complex(re, ime);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="z"></param>
        /// <returns></returns>
        public static Complex Sqr(this Complex z)
        {
            return z * z;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="z"></param>
        /// <returns></returns>
        public static Complex Cube(this Complex z)
        {
            return z * z * z;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="z"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static Complex PowInt(Complex z, int n)
        {
            var result = Complex.One;

            if (n == 0)
                return result;

            if (n < 0)
            {
                n = -n;
                z = Complex.Reciprocal(z);
            }

            do
            {
                if ((n & 1) != 0)
                    result = Multiply(result, z);

                n >>= 1;
                z *= z;
            } while (n > 0);

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="z"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static Complex Pow(this Complex z, int n)
        {
            return PowInt(z, n);
        }

        /// <summary>
        /// </summary>
        /// <param name="strcomplex"></param>
        /// <returns></returns>
        public static Complex FromString(string strcomplex)
        {
            var factor = 1;

            double realPart = 0;
            double imaginaryPart = 0;
            char[] seperator = { };

            if (strcomplex.IndexOf('+') > 0)
            {
                char[] seperator1 = {'+', 'i'};

                seperator = seperator1;
            }
            else if (strcomplex.IndexOf('-') > 0)
            {
                char[] seperator2 = {'-', 'i'};

                seperator = seperator2;
                factor = -1;
            }

            var outStr = strcomplex.Split(seperator);
            var isImaginaryPart = strcomplex.Contains("i");

            outStr[0] = outStr[0].Replace("i", "");

            if ((outStr.Length == 1) && !isImaginaryPart || outStr.Length > 2)
                double.TryParse(outStr[0], out realPart);
            if (isImaginaryPart)
                double.TryParse(outStr[(outStr.Length == 1) ? 0 : 1], out imaginaryPart);

            imaginaryPart *= factor;

            return new Complex(realPart, imaginaryPart);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static double Modulus(this Complex c)
        {
            return Math.Abs(c.Real) >= Math.Abs(c.Imaginary)
                ? Math.Abs(c.Real)*Math.Sqrt(1 + Math.Pow(c.Imaginary/c.Real, 2))
                : Math.Abs(c.Imaginary)*Math.Sqrt(1 + Math.Pow(c.Real/c.Imaginary, 2));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static double Argument(this Complex c)
        {
            return Math.Abs(c.Real) < 1 && Math.Abs(c.Imaginary) < 1 ? 0 : Math.Atan2(c.Imaginary, c.Real);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strcomplex"></param>
        /// <returns></returns>
        public static Complex ToComplex(this string strcomplex)
        {
            return FromString(strcomplex);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static string Abi(this Complex c)
        {
            var outString = "";

            if (c.Real > 0)
            {
                outString = c.Real.ToString(CultureInfo.InvariantCulture);

                if (c.Imaginary > 0)
                    outString += "+";
            }

            if (Math.Abs(c.Imaginary) > 0)
                outString += c.Imaginary + "i";

            return outString;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="z1"></param>
        /// <param name="z2"></param>
        /// <param name="delta"></param>
        /// <returns></returns>
        public static bool ApproximatelyEquals(this Complex z1, Complex z2, double delta = 0.0)
        {
            var r = z1.Real.ApproximatelyEquals(z2.Real, delta);
            var i = z1.Imaginary.ApproximatelyEquals(z2.Imaginary, delta);

            return r && i;
        }
    }
}
