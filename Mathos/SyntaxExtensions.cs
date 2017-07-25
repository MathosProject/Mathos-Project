using Mathos.Arithmetic.Numbers;

namespace Mathos.Syntax
{
    /// <summary>
    /// Provides extension methods to help with ease-of-typing.
    /// </summary>
    public static class SyntaxExtensions
    {
        #region IsPositive

        /// <summary>
        /// Check if <paramref name="num"/> is positive.
        /// </summary>
        /// <param name="num">The number to check.</param>
        /// <returns>True if <paramref name="num"/> is positive; false otherwise.</returns>
        public static bool IsPositive(this byte num)
        {
            return num > 0;
        }

        /// <summary>
        /// Check if <paramref name="num"/> is positive.
        /// </summary>
        /// <param name="num">The number to check.</param>
        /// <returns>True if <paramref name="num"/> is positive; false otherwise.</returns>
        public static bool IsPositive(this short num)
        {
            return num > 0;
        }

        /// <summary>
        /// Check if <paramref name="num"/> is positive.
        /// </summary>
        /// <param name="num">The number to check</param>
        /// <returns>True if <paramref name="num"/> is positive; false otherwise.</returns>
        public static bool IsPositive(this int num)
        {
            return num > 0;
        }

        /// <summary>
        /// Check if <paramref name="num"/> is positive.
        /// </summary>
        /// <param name="num">The number to check</param>
        /// <returns>True if <paramref name="num"/> is positive; false otherwise.</returns>
        public static bool IsPositive(this long num)
        {
            return num > 0;
        }

        #endregion

        #region IsNegative
        
        /// <summary>
        /// Check if <paramref name="num"/> is negative.
        /// </summary>
        /// <param name="num">The number to check.</param>
        /// <returns>True if <paramref name="num"/> is negative; false otherwise.</returns>
        public static bool IsNegative(this short num)
        {
            return num < 0;
        }

        /// <summary>
        /// Check if <paramref name="num"/> is negative.
        /// </summary>
        /// <param name="num">The number to check.</param>
        /// <returns>True if <paramref name="num"/> is negative; false otherwise.</returns>
        public static bool IsNegative(this int num)
        {
            return num < 0;
        }

        /// <summary>
        /// Check if <paramref name="num"/> is negative.
        /// </summary>
        /// <param name="num">The number to check.</param>
        /// <returns>True if <paramref name="num"/> is negative; false otherwise.</returns>
        public static bool IsNegative(this long num)
        {
            return num < 0;
        }

        #endregion

        #region IsDivisible

        /// <summary>
        /// Check if <paramref name="num"/> is divisible by <paramref name="divisibleBy"/>.
        /// </summary>
        /// <param name="num">The divisor.</param>
        /// <param name="divisibleBy">The dividend.</param>
        /// <returns>True if <paramref name="num"/> is divisible by <paramref name="divisibleBy"/>; false otherwise.</returns>
        public static bool IsDivisible(this byte num, byte divisibleBy)
        {
            return num % divisibleBy == 0;
        }

        /// <summary>
        /// Check if <paramref name="num"/> is divisible by <paramref name="divisibleBy"/>.
        /// </summary>
        /// <param name="num">The divisor.</param>
        /// <param name="divisibleBy">The dividend.</param>
        /// <returns>True if <paramref name="num"/> is divisible by <paramref name="divisibleBy"/>; false otherwise.</returns>
        public static bool IsDivisible(this short num, short divisibleBy)
        {
            return num % divisibleBy == 0;
        }

        /// <summary>
        /// Check if <paramref name="num"/> is divisible by <paramref name="divisibleBy"/>.
        /// </summary>
        /// <param name="num">The divisor.</param>
        /// <param name="divisibleBy">The dividend.</param>
        /// <returns>True if <paramref name="num"/> is divisible by <paramref name="divisibleBy"/>; false otherwise.</returns>
        public static bool IsDivisible(this int num, int divisibleBy)
        {
            return num % divisibleBy == 0;
        }

        /// <summary>
        /// Check if <paramref name="num"/> is divisible by <paramref name="divisibleBy"/>.
        /// </summary>
        /// <param name="num">The divisor.</param>
        /// <param name="divisibleBy">The dividend.</param>
        /// <returns>True if <paramref name="num"/> is divisible by <paramref name="divisibleBy"/>; false otherwise.</returns>
        public static bool IsDivisible(this long num, long divisibleBy)
        {
            return num % divisibleBy == 0;
        }

        #endregion

        #region IsEven

        /// <summary>
        /// Check if <paramref name="num"/> is even.
        /// </summary>
        /// <param name="num">The number to check.</param>
        /// <returns>True if <paramref name="num"/> is even; false otherwise.</returns>
        public static bool IsEven(this byte num)
        {
            return num % 2 == 0;
        }

        /// <summary>
        /// Check if <paramref name="num"/> is even.
        /// </summary>
        /// <param name="num">The number to check.</param>
        /// <returns>True if <paramref name="num"/> is even; false otherwise.</returns>
        public static bool IsEven(this short num)
        {
            return num % 2 == 0;
        }

        /// <summary>
        /// Check if <paramref name="num"/> is even.
        /// </summary>
        /// <param name="num">The number to check.</param>
        /// <returns>True if <paramref name="num"/> is even; false otherwise.</returns>
        public static bool IsEven(this int num)
        {
            return num % 2 == 0;
        }

        /// <summary>
        /// Check if <paramref name="num"/> is even.
        /// </summary>
        /// <param name="num">The number to check.</param>
        /// <returns>True if <paramref name="num"/> is even; false otherwise.</returns>
        public static bool IsEven(this long num)
        {
            return num % 2 == 0;
        }

        #endregion

        #region IsOdd

        /// <summary>
        /// Check if <paramref name="num"/> is odd.
        /// </summary>
        /// <param name="num">The number to check.</param>
        /// <returns>True if <paramref name="num"/> is odd; false otherwise.</returns>
        public static bool IsOdd(this byte num)
        {
            return num % 1 == 1;
        }

        /// <summary>
        /// Check if <paramref name="num"/> is odd.
        /// </summary>
        /// <param name="num">The number to check.</param>
        /// <returns>True if <paramref name="num"/> is odd; false otherwise.</returns>
        public static bool IsOdd(this short num)
        {
            return Check.IsOdd(num);
        }

        /// <summary>
        /// Check if <paramref name="num"/> is odd.
        /// </summary>
        /// <param name="num">The number to check.</param>
        /// <returns>True if <paramref name="num"/> is odd; false otherwise.</returns>
        public static bool IsOdd(this int num)
        {
            return Check.IsOdd(num);
        }

        /// <summary>
        /// Check if <paramref name="num"/> is odd.
        /// </summary>
        /// <param name="num">The number to check.</param>
        /// <returns>True if <paramref name="num"/> is odd; false otherwise.</returns>
        public static bool IsOdd(this long num)
        {
            return Check.IsOdd(num);
        }

        #endregion

        #region Prime Checking

        /// <summary>
        /// Check if <paramref name="num"/> is a prime number.
        /// </summary>
        /// <param name="num">The number to check.</param>
        /// <returns>True if <paramref name="num"/> is a prime number; false otherwise.</returns>
        public static bool IsPrime(this byte num)
        {
            return Check.IsPrime(num);
        }

        /// <summary>
        /// Check if <paramref name="num"/> is a prime number.
        /// </summary>
        /// <param name="num">The number to check.</param>
        /// <returns>True if <paramref name="num"/> is a prime number; false otherwise.</returns>
        public static bool IsPrime(this short num)
        {
            return Check.IsPrime(num);
        }

        /// <summary>
        /// Check if <paramref name="num"/> is a prime number.
        /// </summary>
        /// <param name="num">The number to check.</param>
        /// <returns>True if <paramref name="num"/> is a prime number; false otherwise.</returns>
        public static bool IsPrime(this int num)
        {
            return Check.IsPrime(num);
        }

        /// <summary>
        /// Check if <paramref name="num"/> is a prime number.
        /// </summary>
        /// <param name="num">The number to check.</param>
        /// <returns>True if <paramref name="num"/> is a prime number; false otherwise.</returns>
        public static bool IsPrime(this long num)
        {
            return Check.IsPrime(num);
        }

        #endregion

        #region IsCoprime

        /// <summary>
        /// Check if <paramref name="num"/> is a coprime.
        /// </summary>
        /// <param name="num">The first number to check.</param>
        /// <param name="divisibleBy">The second number to check.</param>
        /// <returns>True if <paramref name="num"/> is a coprime with <paramref name="divisibleBy"/>; false otherwise.</returns>
        public static bool IsCoprime(this byte num, byte divisibleBy)
        {
            return Check.IsCoprime(num, divisibleBy);
        }

        /// <summary>
        /// Check if <paramref name="num"/> is a coprime.
        /// </summary>
        /// <param name="num">The first number to check.</param>
        /// <param name="divisibleBy">The second number to check.</param>
        /// <returns>True if <paramref name="num"/> is a coprime with <paramref name="divisibleBy"/>; false otherwise.</returns>
        public static bool IsCoprime(this short num, short divisibleBy)
        {
            return Check.IsCoprime(num, divisibleBy);
        }

        /// <summary>
        /// Check if <paramref name="num"/> is a coprime.
        /// </summary>
        /// <param name="num">The first number to check.</param>
        /// <param name="divisibleBy">The second number to check.</param>
        /// <returns>True if <paramref name="num"/> is a coprime with <paramref name="divisibleBy"/>; false otherwise.</returns>
        public static bool IsCoprime(this int num, int divisibleBy)
        {
            return Check.IsCoprime(num, divisibleBy);
        }

        /// <summary>
        /// Check if <paramref name="num"/> is a coprime.
        /// </summary>
        /// <param name="num">The first number to check.</param>
        /// <param name="divisibleBy">The second number to check.</param>
        /// <returns>True if <paramref name="num"/> is a coprime with <paramref name="divisibleBy"/>; false otherwise.</returns>
        public static bool IsCoprime(this long num, long divisibleBy)
        {
            return Check.IsCoprime(num, divisibleBy);
        }

        #endregion

        #region ToPositive

        /// <summary>
        /// Convert <paramref name="num"/> to a positive number.
        /// </summary>
        /// <param name="num">The number to convert.</param>
        /// <returns><paramref name="num"/> converted to a positive number; false otherwise.</returns>
        public static long ToPositive(this short num)
        {
            return Convert.ToPositive(num);
        }

        /// <summary>
        /// Convert <paramref name="num"/> to a positive number.
        /// </summary>
        /// <param name="num">The number to convert.</param>
        /// <returns><paramref name="num"/> converted to a positive number; false otherwise.</returns>
        public static long ToPositive(this int num)
        {
            return Convert.ToPositive(num);
        }

        /// <summary>
        /// Convert <paramref name="num"/> to a positive number.
        /// </summary>
        /// <param name="num">The number to convert.</param>
        /// <returns><paramref name="num"/> converted to a positive number; false otherwise.</returns>
        public static long ToPositive(this long num)
        {
            return Convert.ToPositive(num);
        }

        #endregion ToPositive

        #region ToNegative

        /// <summary>
        /// Convert <paramref name="num"/> to a negative number.
        /// </summary>
        /// <param name="num">The number to convert.</param>
        /// <returns><paramref name="num"/> converted to a negative number; false otherwise.</returns>
        public static long ToNegative(this short num)
        {
            return Convert.ToNegative(num);
        }

        /// <summary>
        /// Convert <paramref name="num"/> to a negative number.
        /// </summary>
        /// <param name="num">The number to convert.</param>
        /// <returns><paramref name="num"/> converted to a negative number; false otherwise.</returns>
        public static long ToNegative(this int num)
        {
            return Convert.ToNegative(num);
        }

        /// <summary>
        /// Convert <paramref name="num"/> to a negative number.
        /// </summary>
        /// <param name="num">The number to convert.</param>
        /// <returns><paramref name="num"/> converted to a negative number; false otherwise.</returns>
        public static long ToNegative(this long num)
        {
            return Convert.ToNegative(num);
        }

        #endregion
    }
}
