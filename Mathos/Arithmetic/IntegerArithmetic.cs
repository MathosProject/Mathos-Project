using System;

namespace Mathos.Arithmetic
{
    /// <summary>
    /// Provides methods for performing common arithmetic operations on <see cref="int"/>.
    /// </summary>
    public static class IntegerArithmetic
    {
        /// <summary>
        /// Get the square root of <paramref name="number"/>.
        /// </summary>
        /// <param name="number">The number to get the square root of.</param>
        /// <returns>The square root of <paramref name="number"/>.</returns>
        public static int Sqrt(int number)
        {
            var res = 0;
            var bit = 1 << 14;

            while (bit > number)
                bit >>= 2;

            while (bit != 0)
            {
                if (number >= res + bit)
                {
                    number -= res + bit;
                    res = (res >> 1) + bit;
                }
                else
                    res >>= 1;

                bit >>= 2;
            }

            return res;
        }

        /// <summary>
        /// Get the square of <paramref name="x"/>.
        /// </summary>
        /// <param name="x">The number to square.</param>
        /// <returns>The square of <paramref name="x"/>.</returns>
        public static long Sqr(this int x)
        {
            return x <= Constants.MaxIntSqrt ? x*x : Math.BigMul(x, x);
        }

        /// <summary>
        /// Get the square of <paramref name="x"/>.
        /// </summary>
        /// <param name="x">The number to square.</param>
        /// <returns>The square of <paramref name="x"/>.</returns>
        /// <exception cref="OverflowException"><paramref name="x"/> is greater than <see cref="Constants.MaxLongSqrt"/>.</exception>
        public static long Sqr(this long x)
        {
            if (x <= Constants.MaxLongSqrt)
                return x * x;
            
            throw new OverflowException();
        }

        /// <summary>
        /// Raise <paramref name="x"/> to the power of <paramref name="n"/>.
        /// </summary>
        /// <param name="x">The number to raise.</param>
        /// <param name="n">The power to raise to.</param>
        /// <returns><paramref name="x"/> to the power of <paramref name="n"/>.</returns>
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
        /// Raise <paramref name="x"/> to the power of <paramref name="n"/>.
        /// </summary>
        /// <param name="x">The number to raise.</param>
        /// <param name="n">The power to raise to.</param>
        /// <returns><paramref name="x"/> to the power of <paramref name="n"/>.</returns>
        public static double Pow(this int x, int n)
        {
            return n < 0 ? Convert.ToDouble(x).Pow(n) : x.Pow(Convert.ToUInt32(n));
        }

        /// <summary>
        /// Raise <paramref name="x"/> to the power of <paramref name="n"/>.
        /// </summary>
        /// <param name="x">The number to raise.</param>
        /// <param name="n">The power to raise to.</param>
        /// <returns><paramref name="x"/> to the power of <paramref name="n"/>.</returns>
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
        /// Raise <paramref name="x"/> to the power of <paramref name="n"/>.
        /// </summary>
        /// <param name="x">The number to raise.</param>
        /// <param name="n">The power to raise to.</param>
        /// <returns><paramref name="x"/> to the power of <paramref name="n"/>.</returns>
        public static double Pow(this long x, int n)
        {
            return n < 0 ? Convert.ToDouble(x).Pow(n) : x.Pow(Convert.ToUInt32(n));
        }
    }
}
