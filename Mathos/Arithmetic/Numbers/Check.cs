using System;
using System.Linq;

namespace Mathos.Arithmetic.Numbers
{
    /// <summary>
    /// Helpful checks for numbers.
    /// </summary>
    public class Check
    {
        /// <summary>
        /// Check if <paramref name="num"/> is positive.
        /// </summary>
        /// <param name="num">The number to check.</param>
        /// <returns>True if <paramref name="num"/> is positive; false otherwise.</returns>
        public static bool IsPositive(long num)
        {
            return num > 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static bool IsNegative(long num)
        {
            return num < 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numA"></param>
        /// <param name="divisibleBy"></param>
        /// <returns></returns>
        public static bool IsDivisible(long numA, long divisibleBy)
        {
            return numA % divisibleBy == 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static bool IsEven(long num)
        {
            return (num & 1) == 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static bool IsOdd(long num)
        {
            if (num < 0)
                return num % 2 != 0;

            return (num & 1) == 1;
        }

        /// <summary>
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static bool IsPrime(long num)
        {
            if (Get.ListOfCommonPrimeNumbers.Contains((int)num)) // first of all, we check
                return true;                                     // if the prime is already
            // in the list

            if (num % 2 == 0) //even numbers>2 are not prime (2 is included in the common prime numbers)
                return false; 

            var sqrtNum = (long)Math.Sqrt(num); // optimizing so that we do not 
            // need to calculate the sqrt on each iteration
            for (long i = 2; i <= sqrtNum; i++)
            {
                if (num%i == 0)
                    return false; // not a prime
            }

            return true; // a prime
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numA"></param>
        /// <param name="numB"></param>
        /// <returns></returns>
        public static bool IsCoprime(long numA, long numB)
        {
            return Get.Gcd(numA, numB) == 1;
        }
    }
}