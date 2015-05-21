using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Mathos.Arithmetic
{
    namespace Numbers
    {
        //the old Sum class was moved to PreCalculus
        /// <summary>
        /// 
        /// </summary>
        public class Check
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="num"></param>
            /// <returns></returns>
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
                return (Get.Mod(num, 2) == 0);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="num"></param>
            /// <returns></returns>
            public static bool IsOdd(long num)
            {
                return (Get.Mod(num, 2) == 1);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="num"></param>
            /// <returns></returns>
            public static bool IsPrime(long num)
            {
                if (Get.ListOfCommonPrimeNumbers.Contains((int)num)) // first of all, we check
                    return true;                                     // if the prime is already
                // in the list

                if ((num % 2) == 0) //even numbers>2 are not prime (2 is included in the common prime numbers)
                    return false; 

                var sqrtNum = (long)Math.Sqrt(num); // optimizing so that we do not 
                
                for (long i = 2; i <= sqrtNum; i++) //   need to calculate the sqrt on each iteration
                {
                    if ((num % i) == 0)
                    {
                        return false; // not a prime
                    }
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
                return (Get.Gdc(numA, numB) == 1);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public class Get
        {
            /// <summary>
            /// Generates a custom list, which contains numbers that follow the custom rule.
            /// </summary>
            /// <param name="rule">You custom rule that the numbers should follow. (e.g. Check.IsPrime)</param>
            /// <returns></returns>
            public static IEnumerable<long> CustomList(Func<long, bool> rule)
            {
                return CustomList(0, long.MaxValue, rule);
            }
            /// <summary>
            /// Generates a custom list, which contains numbers that follow the custom rule.
            /// </summary>
            /// <param name="to">The number to end with</param>
            /// <param name="rule">You custom rule that the numbers should follow. (e.g. Check.IsPrime)</param>
            /// <returns></returns>
            public static IEnumerable<long> CustomList(long to, Func<long, bool> rule)
            {
                return CustomList(0, to, rule);
            }
            /// <summary>
            /// Generates a custom list, which contains numbers that follow the custom rule.
            /// </summary>
            /// <param name="from">The number to start with</param>
            /// <param name="to">The number to end with</param>
            /// <param name="rule">You custom rule that the numbers should follow</param>
            /// <returns></returns>
            public static IEnumerable<long> CustomList(long from, long to, Func<long, bool> rule)
            {
                //var numbers = Enumerable.Range(start, end - start).ToList();
                //return numbers.Where(rule).ToList();

                for (var i = from; i < to; i++)
                {
                    if (rule(i))
                    {
                        yield return i;
                    }
                }
            }

            /// <summary>
            /// Calculates factorial of a number.
            /// </summary>
            /// <param name="n">Enter the number to calculate the factorial of.</param>
            /// <returns></returns>
            public static long Factorial(long n)
            {
                if (n == 1 || n == 0)
                    return 1;
                
                return n * Factorial(n - 1);
            }

            ///<summary>
            ///Calculates factorials for big numbers
            ///</summary>
            ///<param name="n">Enter the number to calculate the factorial of.</param>
            ///<returns>Returns Single dimentional array containing the result</returns>
            public static int[] FactorialBig(long n)
            {
                const int maxsize = 6000;
                var numArr = new int[maxsize];			// Approximately , size of array depends on size of factorial.
                int rem = 0, count;		//rem use to save remainder of division(Carry Number).
                int i;

                for (i = 0; i < maxsize; i++)
                    numArr[i] = 0;		//set all array on NULL.

                i = maxsize - 1;				//start from end of array.
                numArr[maxsize - 1] = 1;

                for (count = 2; count <= n; count++)//calculates the large number resulting from the factorial operation
                {
                    while (i > 0)
                    {
                        var total = numArr[i] * count + rem;		//rem use to save remainder of division(Carry Number).
                        
                        rem = 0;
                        
                        if (total > 9)
                        {
                            numArr[i] = total % 10;
                            rem = total / 10;
                        }
                        else
                            numArr[i] = total;
                        i--;
                    }
                    rem = 0;
                    i = maxsize - 1;
                }

                i = -1;
                /*
                 * array generated from this algorithm will have the units-place-digit in the last index of the array,
                 * the tens-place-digit in the second last index of the array and so on.
                 * So we now have unnecessary set of zeros in the beginning few indexes of the array, have to get rid of them.
                 * Thats the purpose of the code below.
                 */
                while (numArr[++i] == 0)//
                { }// i = the first non zero digit where the actual number starts
                
                var j = i;
                var newArr = new int[maxsize - i];// create new array of the right size
                
                while (j != maxsize)
                {
                    newArr[j - i] = numArr[j];//C# is not my first language so if there is a one line code for this please replace it with this
                    j++;
                }

                return newArr;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="n"></param>
            /// <returns></returns>
            public static BigInteger FactorialBigInteger(long n)
            {
                var start = 2;
                var numTwo = 0;
                
                BigInteger fact = 1;

                if ((n%2) == 0)
                    start = 1;

                for (BigInteger i = start; i < n; i = i + 2)
                {
                    var j = i * (i + 1);
  
                    while ((j % 2) == 0)
                    {
                        numTwo++;
                        j >>= 1;
                    }

                    fact *= j;
                }

                fact <<= numTwo;
                
                return fact;
            }

            /// <summary>
            /// Calculates the factorials of the specified numbers.
            /// </summary>
            /// <param name="numbers">The numbers to sum the factorials.</param>
            /// <returns></returns>
            public static long Factorial(List<long> numbers)
            {
                return numbers.Sum(num => Factorial(num));
            }

            /// <summary>
            /// Contains a list of common prime numbers, http://oeis.org/A000040.
            /// </summary>
            public static int[] ListOfCommonPrimeNumbers = { 2, 3, 5, 7, 11, 13, 17, 19, 
                                                          23, 29, 31, 37, 41, 43, 47, 
                                                          53, 59, 61, 67, 71, 73, 79, 
                                                          83, 89, 97, 101, 103, 107, 
                                                          109, 113, 127, 131, 137, 
                                                          139, 149, 151, 157, 163, 
                                                          167, 173, 179, 181, 191, 
                                                          193, 197, 199, 211, 223, 
                                                          227, 229, 233, 239, 241, 
                                                          251, 257, 263, 269, 271 };

            /// <summary>
            /// Caclulates the Greatest common divisor
            /// </summary>
            /// <param name="numA">The first number</param>
            /// <param name="numB">The second number</param>
            /// <returns></returns>
            public static long Gdc(long numA, long numB)
            {
                while (numB > 0)
                {
                    var rem = numA % numB;
                    
                    numA = numB;
                    numB = rem;
                }

                return numA;
            }
            /// <summary>
            /// Caclulates Least common multiple
            /// </summary>
            /// <param name="numA">The first number</param>
            /// <param name="numB">The second number</param>
            /// <returns></returns>
            public static long Lcm(long numA, long numB)
            {
                return Convert.ToPositive(numA * numB) / Gdc(numA, numB);
            }
            /// <summary>
            /// Calculates modulo
            /// </summary>
            /// <param name="numA">The first number</param>
            /// <param name="numB">The second number</param>
            /// <returns></returns>
            public static long Mod(long numA, long numB)
            {
                return numA - numB * (numA / numB);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="num"></param>
            /// <returns></returns>
            public static IEnumerable<long> Factors(long num)
            {
                var max = (long)Math.Sqrt(num);
                
                for (long i = 2; i <= max; i++)
                {
                    if ((num%i) != 0) continue;
                    
                    if (Check.IsPrime(i))
                        yield return i;
                    else
                    {
                        var tmpI = i;

                        foreach (var factor in Factors(i).Where(factor => Check.IsPrime(tmpI)))
                        {
                            yield return i;
                        }
                    }
                }
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="x"></param>
            /// <param name="power"></param>
            /// <returns></returns>
            public static long IntPower(int x, short power)
            {
                // from http://stackoverflow.com/questions/383587/how-do-you-do-integer-exponentiation-in-c
                switch (power)
                {
                    case 0:
                        return 1;
                    case 1:
                        return x;
                }
                // ----------------------
                var n = 15;
                
                while ((power <<= 1) >= 0) n--;

                long tmp = x;
                while (--n > 0)
                    tmp = tmp * tmp *
                         (((power <<= 1) < 0) ? x : 1);
                return tmp;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public class Convert
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="num"></param>
            /// <returns></returns>
            public static long ToPositive(long num)
            {
                if (Check.IsNegative(num))
                    return num*-1;

                return num;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="num"></param>
            /// <returns></returns>
            public static long ToNegative(long num)
            {
                if (Check.IsPositive(num))
                    return num*-1;

                return num;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public interface INaturalNumber
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public interface IInteger : INaturalNumber
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public interface IRationalNumber : IInteger
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public interface IIRationalNumber
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public interface IRealNumber : IRationalNumber, IIRationalNumber
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public interface IImaginary
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public interface IComplex : IRealNumber, IImaginary
        {
        }
    }
}
