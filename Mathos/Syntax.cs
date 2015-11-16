using Mathos.Arithmetic.Numbers;

namespace Mathos
{
    namespace Syntax
    {
        /// <summary>
        /// The purpose of this class is to provide the users with some basic
        /// functions that are available for instance in Arithmetics.Numbers.
        /// This means that instead of writing out the namespace.class.method,
        /// we can simply focus on the variable, e.g. int32, and type less code
        /// 
        /// EXAMPLE:
        ///     int a = 3;
        ///     Assert.IsTrue(a.IsPrime());
        /// 
        ///     instead of
        ///     
        ///     Mathos.Arithmetics.Numbers.Check.IsPrime(a);
        /// </summary>
        public static class SyntaxExtension
        {
            #region IsPositive

            /// <summary>
            /// Check if <paramref name="num"/> is positive.
            /// </summary>
            /// <param name="num">The number to check.</param>
            /// <returns>True if <paramref name="num"/> is positive.</returns>
            public static bool IsPositive(this short num)
            {
                return Check.IsPositive(num);
            }

            /// <summary>
            /// Check if <paramref name="num"/> is positive.
            /// </summary>
            /// <param name="num">The number to check</param>
            /// <returns>True if <paramref name="num"/> is positive.</returns>
            public static bool IsPositive(this int num)
            {
                return Check.IsPositive(num);
            }

            /// <summary>
            /// Check if <paramref name="num"/> is positive.
            /// </summary>
            /// <param name="num">The number to check</param>
            /// <returns>True if <paramref name="num"/> is positive.</returns>
            public static bool IsPositive(this long num)
            {
                return Check.IsPositive(num);
            }

            #endregion

            #region IsNegative

            /// <summary>
            /// Check if <paramref name="num"/> is negative.
            /// </summary>
            /// <param name="num">The number to check.</param>
            /// <returns>True if <paramref name="num"/> is negative.</returns>
            public static bool IsNegative(this short num)
            {
                return Check.IsNegative(num);
            }

            /// <summary>
            /// Check if <paramref name="num"/> is negative.
            /// </summary>
            /// <param name="num">The number to check.</param>
            /// <returns>True if <paramref name="num"/> is negative.</returns>
            public static bool IsNegative(this int num)
            {
                return Check.IsNegative(num);
            }

            /// <summary>
            /// Check if <paramref name="num"/> is negative.
            /// </summary>
            /// <param name="num">The number to check.</param>
            /// <returns>True if <paramref name="num"/> is negative.</returns>
            public static bool IsNegative(this long num)
            {
                return Check.IsNegative(num);
            }

            #endregion

            #region IsDivisible

            /// <summary>
            /// Check if <paramref name="num"/> is divisible by <paramref name="divisibleBy"/>.
            /// </summary>
            /// <param name="num">The divisor.</param>
            /// <param name="divisibleBy">The dividend.</param>
            /// <returns>True if <paramref name="num"/> is divisible by <paramref name="divisibleBy"/>.</returns>
            public static bool IsDivisible(this short num, short divisibleBy)
            {
                return Check.IsDivisible(num, divisibleBy);
            }

            /// <summary>
            /// Check if <paramref name="num"/> is divisible by <paramref name="divisibleBy"/>.
            /// </summary>
            /// <param name="num">The divisor.</param>
            /// <param name="divisibleBy">The dividend.</param>
            /// <returns>True if <paramref name="num"/> is divisible by <paramref name="divisibleBy"/>.</returns>
            public static bool IsDivisible(this int num, int divisibleBy)
            {
                return Check.IsDivisible(num, divisibleBy);
            }

            /// <summary>
            /// Check if <paramref name="num"/> is divisible by <paramref name="divisibleBy"/>.
            /// </summary>
            /// <param name="num">The divisor.</param>
            /// <param name="divisibleBy">The dividend.</param>
            /// <returns>True if <paramref name="num"/> is divisible by <paramref name="divisibleBy"/>.</returns>
            public static bool IsDivisible(this long num, long divisibleBy)
            {
                return Check.IsDivisible(num, divisibleBy);
            }

            #endregion

            #region IsEven

            /// <summary>
            /// Check if <paramref name="num"/> is even.
            /// </summary>
            /// <param name="num">The number to check.</param>
            /// <returns>True if <paramref name="num"/> is even.</returns>
            public static bool IsEven(this short num)
            {
                return Check.IsEven(num);
            }

            /// <summary>
            /// Check if <paramref name="num"/> is even.
            /// </summary>
            /// <param name="num">The number to check.</param>
            /// <returns>True if <paramref name="num"/> is even.</returns>
            public static bool IsEven(this int num)
            {
                return Check.IsEven(num);
            }

            /// <summary>
            /// Check if <paramref name="num"/> is even.
            /// </summary>
            /// <param name="num">The number to check.</param>
            /// <returns>True if <paramref name="num"/> is even.</returns>
            public static bool IsEven(this long num)
            {
                return Check.IsEven(num);
            }

            #endregion

            #region IsOdd
            
            /// <summary>
            /// Check if <paramref name="num"/> is odd.
            /// </summary>
            /// <param name="num">The number to check.</param>
            /// <returns>True if <paramref name="num"/> is odd.</returns>
            public static bool IsOdd(this short num)
            {
                return Check.IsOdd(num);
            }

            /// <summary>
            /// Check if <paramref name="num"/> is odd.
            /// </summary>
            /// <param name="num">The number to check.</param>
            /// <returns>True if <paramref name="num"/> is odd.</returns>
            public static bool IsOdd(this int num)
            {
                return Check.IsOdd(num);
            }

            /// <summary>
            /// Check if <paramref name="num"/> is odd.
            /// </summary>
            /// <param name="num">The number to check.</param>
            /// <returns>True if <paramref name="num"/> is odd.</returns>
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
            /// <returns>True if <paramref name="num"/> is a prime number.</returns>
            public static bool IsPrime(this short num)
            {
                return Check.IsPrime(num);
            }

            /// <summary>
            /// Check if <paramref name="num"/> is a prime number.
            /// </summary>
            /// <param name="num">The number to check.</param>
            /// <returns>True if <paramref name="num"/> is a prime number.</returns>
            public static bool IsPrime(this int num)
            {
                return Check.IsPrime(num);
            }

            /// <summary>
            /// Check if <paramref name="num"/> is a prime number.
            /// </summary>
            /// <param name="num">The number to check.</param>
            /// <returns>True if <paramref name="num"/> is a prime number.</returns>
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
            /// <returns>True if <paramref name="num"/> is a coprime with <paramref name="divisibleBy"/>.</returns>
            public static bool IsCoprime(this short num, short divisibleBy)
            {
                return Check.IsCoprime(num, divisibleBy);
            }

            /// <summary>
            /// Check if <paramref name="num"/> is a coprime.
            /// </summary>
            /// <param name="num">The first number to check.</param>
            /// <param name="divisibleBy">The second number to check.</param>
            /// <returns>True if <paramref name="num"/> is a coprime with <paramref name="divisibleBy"/>.</returns>
            public static bool IsCoprime(this int num, int divisibleBy)
            {
                return Check.IsCoprime(num, divisibleBy);
            }

            /// <summary>
            /// Check if <paramref name="num"/> is a coprime.
            /// </summary>
            /// <param name="num">The first number to check.</param>
            /// <param name="divisibleBy">The second number to check.</param>
            /// <returns>True if <paramref name="num"/> is a coprime with <paramref name="divisibleBy"/>.</returns>
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
            /// <returns><paramref name="num"/> converted to a positive number.</returns>
            public static long ToPositive(this short num)
            {
                return Convert.ToPositive(num);
            }

            /// <summary>
            /// Convert <paramref name="num"/> to a positive number.
            /// </summary>
            /// <param name="num">The number to convert.</param>
            /// <returns><paramref name="num"/> converted to a positive number.</returns>
            public static long ToPositive(this int num)
            {
                return Convert.ToPositive(num);
            }

            /// <summary>
            /// Convert <paramref name="num"/> to a positive number.
            /// </summary>
            /// <param name="num">The number to convert.</param>
            /// <returns><paramref name="num"/> converted to a positive number.</returns>
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
            /// <returns><paramref name="num"/> converted to a negative number.</returns>
            public static long ToNegative(this short num)
            {
                return Convert.ToNegative(num);
            }

            /// <summary>
            /// Convert <paramref name="num"/> to a negative number.
            /// </summary>
            /// <param name="num">The number to convert.</param>
            /// <returns><paramref name="num"/> converted to a negative number.</returns>
            public static long ToNegative(this int num)
            {
                return Convert.ToNegative(num);
            }

            /// <summary>
            /// Convert <paramref name="num"/> to a negative number.
            /// </summary>
            /// <param name="num">The number to convert.</param>
            /// <returns><paramref name="num"/> converted to a negative number.</returns>
            public static long ToNegative(this long num)
            {
                return Convert.ToNegative(num);
            }

            #endregion
        }
    }
}
