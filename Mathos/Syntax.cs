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
            /// Check if "num" is positive
            /// </summary>
            /// <param name="num"></param>
            /// <returns></returns>
            public static bool IsPositive(this short num)
            {
                return Check.IsPositive(num);
            }

            /// <summary>
            /// Check if "num" is positive
            /// </summary>
            /// <param name="num"></param>
            /// <returns></returns>
            public static bool IsPositive(this int num)
            {
                return Check.IsPositive(num);
            }

            /// <summary>
            /// Check if "num" is positive
            /// </summary>
            /// <param name="num"></param>
            /// <returns></returns>
            public static bool IsPositive(this long num)
            {
                return Check.IsPositive(num);
            }

            #endregion

            #region IsNegative

            /// <summary>
            /// Check if "num" is negative
            /// </summary>
            /// <param name="num"></param>
            /// <returns></returns>
            public static bool IsNegative(this short num)
            {
                return Check.IsNegative(num);
            }

            /// <summary>
            /// Check if "num" is negative
            /// </summary>
            /// <param name="num"></param>
            /// <returns></returns>
            public static bool IsNegative(this int num)
            {
                return Check.IsNegative(num);
            }

            /// <summary>
            /// Check if "num" is negative
            /// </summary>
            /// <param name="num"></param>
            /// <returns></returns>
            public static bool IsNegative(this long num)
            {
                return Check.IsNegative(num);
            }

            #endregion

            #region IsDivisible

            /// <summary>
            /// Check if "num" is divisible by "divisibleBy"
            /// </summary>
            /// <param name="num"></param>
            /// <param name="divisibleBy"></param>
            /// <returns></returns>
            public static bool IsDivisible(this short num, short divisibleBy)
            {
                return Check.IsDivisible(num, divisibleBy);
            }

            /// <summary>
            /// Check if "num" is divisible by "divisibleBy"
            /// </summary>
            /// <param name="num"></param>
            /// <param name="divisibleBy"></param>
            /// <returns></returns>
            public static bool IsDivisible(this int num, int divisibleBy)
            {
                return Check.IsDivisible(num, divisibleBy);
            }

            /// <summary>
            /// Check if "num" is divisible by "divisibleBy"
            /// </summary>
            /// <param name="num"></param>
            /// <param name="divisibleBy"></param>
            /// <returns></returns>
            public static bool IsDivisible(this long num, long divisibleBy)
            {
                return Check.IsDivisible(num, divisibleBy);
            }

            #endregion

            #region IsEven

            /// <summary>
            /// Check if "num" is even
            /// </summary>
            /// <param name="num"></param>
            /// <returns></returns>
            public static bool IsEven(this short num)
            {
                return Check.IsEven(num);
            }

            /// <summary>
            /// Check if "num" is even
            /// </summary>
            /// <param name="num"></param>
            /// <returns></returns>
            public static bool IsEven(this int num)
            {
                return Check.IsEven(num);
            }

            /// <summary>
            /// Check if "num" is even
            /// </summary>
            /// <param name="num"></param>
            /// <returns></returns>
            public static bool IsEven(this long num)
            {
                return Check.IsEven(num);
            }

            #endregion

            #region IsOdd
            
            /// <summary>
            /// Check if "num" is odd
            /// </summary>
            /// <param name="num"></param>
            /// <returns></returns>
            public static bool IsOdd(this short num)
            {
                return Check.IsOdd(num);
            }

            /// <summary>
            /// Check if "num" is odd
            /// </summary>
            /// <param name="num"></param>
            /// <returns></returns>
            public static bool IsOdd(this int num)
            {
                return Check.IsOdd(num);
            }

            /// <summary>
            /// Check if "num" is odd
            /// </summary>
            /// <param name="num"></param>
            /// <returns></returns>
            public static bool IsOdd(this long num)
            {
                return Check.IsOdd(num);
            }

            #endregion

            #region Prime Checking
            
            /// <summary>
            /// Check if "num" is a prime
            /// </summary>
            /// <param name="num"></param>
            /// <returns></returns>
            public static bool IsPrime(this short num)
            {
                return Check.IsPrime(num);
            }

            /// <summary>
            /// Check if "num" is a prime
            /// </summary>
            /// <param name="num"></param>
            /// <returns></returns>
            public static bool IsPrime(this int num)
            {
                return Check.IsPrime(num);
            }

            /// <summary>
            /// Check if "num" is a prime
            /// </summary>
            /// <param name="num"></param>
            /// <returns></returns>
            public static bool IsPrime(this long num)
            {
                return Check.IsPrime(num);
            }

            #endregion

            #region IsCoprime

            /// <summary>
            /// Check if "num" is a coprime
            /// </summary>
            /// <param name="num"></param>
            /// <param name="divisibleBy"></param>
            /// <returns></returns>
            public static bool IsCoprime(this short num, short divisibleBy)
            {
                return Check.IsCoprime(num, divisibleBy);
            }

            /// <summary>
            /// Check if "num" is a coprime
            /// </summary>
            /// <param name="num"></param>
            /// <param name="divisibleBy"></param>
            /// <returns></returns>
            public static bool IsCoprime(this int num, int divisibleBy)
            {
                return Check.IsCoprime(num, divisibleBy);
            }

            /// <summary>
            /// Check if "num" is a coprime
            /// </summary>
            /// <param name="num"></param>
            /// <param name="divisibleBy"></param>
            /// <returns></returns>
            public static bool IsCoprime(this long num, long divisibleBy)
            {
                return Check.IsCoprime(num, divisibleBy);
            }

            #endregion

            #region ToPositive

            /// <summary>
            /// Convert "num" to a positive number
            /// </summary>
            /// <param name="num"></param>
            /// <returns></returns>
            public static long ToPositive(this short num)
            {
                return Arithmetic.Numbers.Convert.ToPositive(num);
            }

            /// <summary>
            /// Convert "num" to a positive number
            /// </summary>
            /// <param name="num"></param>
            /// <returns></returns>
            public static long ToPositive(this int num)
            {
                return Arithmetic.Numbers.Convert.ToPositive(num);
            }

            /// <summary>
            /// Convert "num" to a positive number
            /// </summary>
            /// <param name="num"></param>
            /// <returns></returns>
            public static long ToPositive(this long num)
            {
                return Arithmetic.Numbers.Convert.ToPositive(num);
            }

            #endregion ToPositive

            #region ToNegative

            /// <summary>
            /// Convert "num" to a negative number
            /// </summary>
            /// <param name="num"></param>
            /// <returns></returns>
            public static long ToNegative(this short num)
            {
                return Arithmetic.Numbers.Convert.ToNegative(num);
            }
            
            /// <summary>
            /// Convert "num" to a negative number
            /// </summary>
            /// <param name="num"></param>
            /// <returns></returns>
            public static long ToNegative(this int num)
            {
                return Arithmetic.Numbers.Convert.ToNegative(num);
            }

            /// <summary>
            /// Convert "num" to a negative number
            /// </summary>
            /// <param name="num"></param>
            /// <returns></returns>
            public static long ToNegative(this long num)
            {
                return Arithmetic.Numbers.Convert.ToNegative(num);
            }

            #endregion
        }
    }
}
