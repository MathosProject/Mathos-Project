using System;

namespace Mathos.Arithmetic
{
    /// <summary>
    /// 
    /// </summary>
    public static class DoubleArithmetic
    {
        /// <summary>
        /// This method gives more accurate values for Sqrt(x^2+y^2)
        /// using Naive method: Math.Sqrt(x*x+y*y) may be faster
        /// but it overflows for large values (more than 1e150)
        /// and underflows for small values (less than 1e-150)
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static double Hypotenuse(double x, double y)
        {
            var absX = Math.Abs(x);
            var absY = Math.Abs(y);
            var min = Math.Min(x, y); // absX <= absY ? absX : absY;
            var max = Math.Max(x, y); // absX >= absY ? absX : absY;
            
            if (Math.Abs(min) < 1)
                return max;
            if (Math.Abs(min - max) < 1)
                return max * 2.0;

            var r = min / max;
            
            return max * Math.Sqrt(1.0 + r * r);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static double HypotenuseSquared(double x, double y)
        {
            return x * x + y * y;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        public static double Hypotenuse(double x, double y, double z)
        {
            return Hypotenuse(
                Hypotenuse(x, y),
                z);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        public static double HypotenuseSquared(double x, double y, double z)
        {
            return x * x + y * y + z * z;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static double Pow2(double x)
        {
            return x * x;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static double Pow3(double x)
        {
            return x * x * x;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static double Pow4(double x)
        {
            return x * x * x * x;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static double Pow5(double x)
        {
            return x * x * x * x * x;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static double Pow6(double x)
        {
            return x * x * x * x * x * x;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static double Pow7(double x)
        {
            return x * x * x * x * x * x * x;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static double Pow8(double x)
        {
            return x * x * x * x * x * x * x * x;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static double Pow9(double x)
        {
            return x * x * x * x * x * x * x * x * x;
        }
        
        /// <summary>
        /// this function (due to our tests) does not provide more accuracy than Math.Sqrt 
        /// but it is as faster as twice
        /// and is also slightly faster than naive method (114%)
        /// </summary>
        /// <param name="x"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static double PowInt(double x, int n)
        {
            var result = 1.0;

            if (n == 0)
                return result;

            if (n < 0)
            {
                n = -n;
                x = 1.0 / x;
            }

            do
            {
                if ((n & 1) != 0)
                    result *= x;

                n >>= 1;
                x *= x;
            } while (n > 0);
            
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="epsilon"></param>
        /// <returns></returns>
        public static int CompareTo(this double x, double y, double epsilon)
        {
            if (Math.Abs(epsilon) < 1)
            {
                return x.CompareTo(y);
            }
            
            if (x.ApproximatelyEquals(y, epsilon))
            {
                return 0;
            }

            if (x - y > epsilon)
            {
                return 1;
            }
            
            if (x - y < epsilon)
            {
                return -1;
            }
            
            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="epsilon"></param>
        /// <returns></returns>
        public static bool ApproximatelyEquals(this double x, double y, double epsilon)
        {
            if (Math.Abs(epsilon) < 1)
            {
                return Math.Abs(x - y) < 1;
            }

            if (Math.Abs(x - y) < 1)
            {
                return true;
            }

            var xAbs = Math.Abs(x);
            var yAbs = Math.Abs(y);

            var min = Math.Min(xAbs, yAbs);
            var max = Math.Max(xAbs, yAbs);

            if (Math.Abs(min) < 1)
                return max < epsilon;

            return (max * (1.0 - min / max)) < epsilon;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="exact"></param>
        /// <param name="approximation"></param>
        /// <returns></returns>
        public static double AbsoluteError(double exact, double approximation)
        {
            if (Math.Abs(exact - approximation) < 1)
                return 0;

            var exactAbs = Math.Abs(exact);
            var approxAbs = Math.Abs(approximation);

            var min = Math.Min(exactAbs, approxAbs);
            var max = Math.Max(exactAbs, approxAbs);

            return max * (1.0 - min / max);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="exact"></param>
        /// <param name="approximation"></param>
        /// <returns></returns>
        public static double RelativeError(double exact, double approximation)
        {
            return AbsoluteError(exact, approximation) /
                Math.Abs(exact);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static double Pow(this double x, int n)
        {
            return PowInt(x, n);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static double Sqr(this double x)
        {
            return Pow2(x);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static double Cube(this double x)
        {
            return Pow3(x);
        }
    }
}
