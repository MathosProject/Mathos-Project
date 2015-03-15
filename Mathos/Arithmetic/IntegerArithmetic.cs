using System;

namespace Mathos.Arithmetic
{
    /// <summary>
    /// 
    /// </summary>
    public static class IntegerArithmetic
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static int Sqrt(int number)
        {
            var res = 0;
            var bit = 1 << 14;
            
            while (bit > number)
            {
                bit >>= 2;
            }

            while (bit!=0)
            {
                if (number>=res+bit)
                {
                    number -= res + bit;
                    res = (res >> 1) + bit;
                }
                else
                {
                    res >>= 1;
                }

                bit >>= 2;
            }

            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static long Sqr(this int x)
        {
            if (x <= MathematicalConstants.MaxIntSqrt)
                return x * x;
            
            return Math.BigMul(x, x);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        /// <exception cref="OverflowException"></exception>
        public static long Sqr(this long x)
        {
            if (x <= MathematicalConstants.MaxLongSqrt)
                return x * x;
            
            throw new OverflowException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int Pow(this int x, uint n)
        {
            var result = 1;

            if (n == 0)
                return result;
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
        /// <param name="n"></param>
        /// <returns></returns>
        public static double Pow(this int x, int n)
        {
            return n < 0 ? (Convert.ToDouble(x)).Pow(n) : x.Pow(Convert.ToUInt32(n));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static long Pow(this long x, uint n)
        {
            long result = 1;

            if (n == 0)
                return result;
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
        /// <param name="n"></param>
        /// <returns></returns>
        public static double Pow(this long x, int n)
        {
            return n < 0 ? (Convert.ToDouble(x)).Pow(n) : x.Pow(Convert.ToUInt32(n));
        }
    }
}
