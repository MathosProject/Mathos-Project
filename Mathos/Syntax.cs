/* 
 * The purpose of this class is to provide the users with some basic
 * functions that are available for instance in Arithmetics.Numbers.
 * This means that instead of writing out the namespace.class.method,
 * we can simply focus on the variable, e.g. int32, and type less code
 * EX: int a = 3; Assert.IsTrue(a.IsPrime()); instead of
 * EX: Mathos.Arithmetics.Numbers.Check.IsPrime(a);
 * 
 * Do not forget to add Mathos.Syntax as a reference, before you continue
 * using this amazing feature of Mathos Project!
 */
using System;
using Mathos.Arithmetic.Numbers;

namespace Mathos
{
    namespace Syntax
    {
        /// <summary>
        /// EXTEND THIS METHOD!!!
        /// </summary>
        public static class SyntaxExtension
        {
            // IsPositive
            /// <summary>
            /// Check if "num" is positive
            /// </summary>
            /// <param name="num"></param>
            /// <returns></returns>
            public static bool IsPositive(this Int16 num)
            {
                return Check.IsPositive(num);
            }

            /// <summary>
            /// Check if "num" is positive
            /// </summary>
            /// <param name="num"></param>
            /// <returns></returns>
            public static bool IsPositive(this Int32 num)
            {
                return Check.IsPositive(num);
            }

            /// <summary>
            /// Check if "num" is positive
            /// </summary>
            /// <param name="num"></param>
            /// <returns></returns>
            public static bool IsPositive(this Int64 num)
            {
                return Check.IsPositive(num);
            }

            // IsNegative
            /// <summary>
            /// Check if "num" is negative
            /// </summary>
            /// <param name="num"></param>
            /// <returns></returns>
            public static bool IsNegative(this Int16 num)
            {
                return Check.IsNegative(num);
            }

            /// <summary>
            /// Check if "num" is negative
            /// </summary>
            /// <param name="num"></param>
            /// <returns></returns>
            public static bool IsNegative(this Int32 num)
            {
                return Check.IsNegative(num);
            }

            /// <summary>
            /// Check if "num" is negative
            /// </summary>
            /// <param name="num"></param>
            /// <returns></returns>
            public static bool IsNegative(this Int64 num)
            {
                return Check.IsNegative(num);
            }

            //IsDivisible
            /// <summary>
            /// Check if "num" is divisible by "divisibleBy"
            /// </summary>
            /// <param name="num"></param>
            /// <param name="divisibleBy"></param>
            /// <returns></returns>
            public static bool IsDivisible(this Int16 num, Int16 divisibleBy)
            {
                return Check.IsDivisible(num, divisibleBy);
            }

            /// <summary>
            /// Check if "num" is divisible by "divisibleBy"
            /// </summary>
            /// <param name="num"></param>
            /// <param name="divisibleBy"></param>
            /// <returns></returns>
            public static bool IsDivisible(this Int32 num, Int32 divisibleBy)
            {
                return Check.IsDivisible(num, divisibleBy);
            }

            /// <summary>
            /// Check if "num" is divisible by "divisibleBy"
            /// </summary>
            /// <param name="num"></param>
            /// <param name="divisibleBy"></param>
            /// <returns></returns>
            public static bool IsDivisible(this Int64 num, Int64 divisibleBy)
            {
                return Check.IsDivisible(num, divisibleBy);
            }

            //IsEven
            /// <summary>
            /// Check if "num" is even
            /// </summary>
            /// <param name="num"></param>
            /// <returns></returns>
            public static bool IsEven(this Int16 num)
            {
                return Check.IsEven(num);
            }

            /// <summary>
            /// Check if "num" is even
            /// </summary>
            /// <param name="num"></param>
            /// <returns></returns>
            public static bool IsEven(this Int32 num)
            {
                return Check.IsEven(num);
            }

            /// <summary>
            /// Check if "num" is even
            /// </summary>
            /// <param name="num"></param>
            /// <returns></returns>
            public static bool IsEven(this Int64 num)
            {
                return Check.IsEven(num);
            }

            //IsOdd
            /// <summary>
            /// Check if "num" is odd
            /// </summary>
            /// <param name="num"></param>
            /// <returns></returns>
            public static bool IsOdd(this Int16 num)
            {
                return Check.IsOdd(num);
            }

            /// <summary>
            /// Check if "num" is odd
            /// </summary>
            /// <param name="num"></param>
            /// <returns></returns>
            public static bool IsOdd(this Int32 num)
            {
                return Check.IsOdd(num);
            }

            /// <summary>
            /// Check if "num" is odd
            /// </summary>
            /// <param name="num"></param>
            /// <returns></returns>
            public static bool IsOdd(this Int64 num)
            {
                return Check.IsOdd(num);
            }

            //prime checking
            /// <summary>
            /// Check if "num" is a prime
            /// </summary>
            /// <param name="num"></param>
            /// <returns></returns>
            public static bool IsPrime(this Int16 num)
            {
                return Check.IsPrime(num);
            }

            /// <summary>
            /// Check if "num" is a prime
            /// </summary>
            /// <param name="num"></param>
            /// <returns></returns>
            public static bool IsPrime(this Int32 num)
            {
                return Check.IsPrime(num);
            }

            /// <summary>
            /// Check if "num" is a prime
            /// </summary>
            /// <param name="num"></param>
            /// <returns></returns>
            public static bool IsPrime(this Int64 num)
            {
                return Check.IsPrime(num);
            }

            //IsCoprime
            /// <summary>
            /// Check if "num" is a coprime
            /// </summary>
            /// <param name="num"></param>
            /// <param name="divisibleBy"></param>
            /// <returns></returns>
            public static bool IsCoprime(this Int16 num, Int16 divisibleBy)
            {
                return Check.IsCoprime(num, divisibleBy);
            }

            /// <summary>
            /// Check if "num" is a coprime
            /// </summary>
            /// <param name="num"></param>
            /// <param name="divisibleBy"></param>
            /// <returns></returns>
            public static bool IsCoprime(this Int32 num, Int32 divisibleBy)
            {
                return Check.IsCoprime(num, divisibleBy);
            }

            /// <summary>
            /// Check if "num" is a coprime
            /// </summary>
            /// <param name="num"></param>
            /// <param name="divisibleBy"></param>
            /// <returns></returns>
            public static bool IsCoprime(this Int64 num, Int64 divisibleBy)
            {
                return Check.IsCoprime(num, divisibleBy);
            }

            //ToPositive
            /// <summary>
            /// Convert "num" to a positive number
            /// </summary>
            /// <param name="num"></param>
            /// <returns></returns>
            public static long ToPositive(this Int16 num)
            {
                return Arithmetic.Numbers.Convert.ToPositive(num);
            }

            /// <summary>
            /// Convert "num" to a positive number
            /// </summary>
            /// <param name="num"></param>
            /// <returns></returns>
            public static long ToPositive(this Int32 num)
            {
                return Arithmetic.Numbers.Convert.ToPositive(num);
            }

            /// <summary>
            /// Convert "num" to a positive number
            /// </summary>
            /// <param name="num"></param>
            /// <returns></returns>
            public static long ToPositive(this Int64 num)
            {
                return Arithmetic.Numbers.Convert.ToPositive(num);
            }

            //ToNegative
            /// <summary>
            /// Convert "num" to a negative number
            /// </summary>
            /// <param name="num"></param>
            /// <returns></returns>
            public static long ToNegative(this Int16 num)
            {
                return Arithmetic.Numbers.Convert.ToNegative(num);
            }
            
            /// <summary>
            /// Convert "num" to a negative number
            /// </summary>
            /// <param name="num"></param>
            /// <returns></returns>
            public static long ToNegative(this Int32 num)
            {
                return Arithmetic.Numbers.Convert.ToNegative(num);
            }

            /// <summary>
            /// Convert "num" to a negative number
            /// </summary>
            /// <param name="num"></param>
            /// <returns></returns>
            public static long ToNegative(this Int64 num)
            {
                return Arithmetic.Numbers.Convert.ToNegative(num);
            }
        }
    }
}
