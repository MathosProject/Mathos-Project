using System;

using Mathos.Arithmetic;

namespace Mathos.Calculus
{
    // Missing functions in Math class
    // functions of real variable
    public static partial class Elementary
    {      
        // check : http://www.johndcook.com/csharp_log_one_plus_x.html
        /// <summary>
        /// calculates log(1 + x)
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static double LogOfOnePlusX(double x)
        {
            if (x <= -1.0)
                return double.NaN;

            var z = Math.Abs(x);
            var y = 1 + x;

            if (z > 0.75)
                return Math.Log(y);

            if (z > 1e-4)
                return x*Math.Log(y)/(y - 1.0);
                    // method used by GSL and recommended when x is not too small (Although GSL is using it for any value of x)

            if (z > 1e-16)
                return (-0.5*x + 1.0)*x; // Taylor expansion used;

            return x; // x is too small 
        }

        /// <summary>
        /// calculates EXP(X) - 1
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static double ExpOfXMinusOne(double x)
        {
            var z = Math.Abs(x);

            if (z > 1e-5)
                return Math.Exp(x) - 1.0;

            if (z > 1e-16)
                return x + 0.5*x*x;

            return x;
        }

        /// <summary>
        /// x * 2 ^ n
        /// </summary>
        /// <param name="x"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static double TimesTwoTo(double x, int n)
        {
            return x * DoubleArithmetic.PowInt(2.0, n);
        }

        /// <summary>
        /// x => f * 2^n
        /// </summary>
        /// <param name="x"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static double Decompose(double x, out int n)
        {
            if (Math.Abs(x) < 1)
            {
                n = 0;
                
                return 0.0;
            }
            
            var ex = Math.Ceiling(Math.Log(Math.Abs(x)) / MathematicalConstants.LnOfTwo);
            var ei = Convert.ToInt32(ex);
            var f = TimesTwoTo(x, -ei);

            while (Math.Abs(f) >= 1.0)
            {
                ei++;
                f /= 2;
            }

            while (Math.Abs(f) < 0.5)
            {
                ei--;
                f *= 2.0;
            }

            n = ei;
            
            return f;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static double LogPlusOne(this double x)
        {
            return LogOfOnePlusX(x);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static double ExpMinusOne(this double x)
        {
            return ExpOfXMinusOne(x);
        }
    }
}
