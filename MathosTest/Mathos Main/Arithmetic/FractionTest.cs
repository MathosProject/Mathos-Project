using System;
using System.Collections.Generic;
using System.Diagnostics;
using Mathos.Arithmetic.Fractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MathosTest
{
    [TestClass]
    public class TestOfFractions
    {

         #region Helper Methods

        public List<int> Factor(int number)
        {
            List<int> factors = new List<int>();
            int max = (int)Math.Sqrt(number);  //round down
            for (int factor = 1; factor <= max; ++factor)
            { //test from 1 to the square root, or the int below it, inclusive.
                if (number % factor == 0)
                {
                    factors.Add(factor);
                    if (factor != number / factor)
                    { // Don't add the square root twice!  Thanks Jon
                        factors.Add(number / factor);
                    }
                }
            }
            return factors;
        }
 
        #endregion
        #region Equality Tests

         [TestMethod]
         public void Comparison()
         {
             Assert.IsTrue(new Fraction(1, 2) >= new Fraction(1, 3));
             Assert.IsTrue("1/2" < new Fraction(2, 3));
         }

         [TestMethod]
         public void FractionCheckerTest()
         {
             Fraction a = "2/-8";
             Assert.IsTrue(new Fraction(-2, 8) == a);

             Assert.IsTrue(new Fraction(-2, 3) == new Fraction(2, -3));
             Assert.IsTrue(new Fraction(-2, -3) == new Fraction(2, 3));
         }

         [TestMethod]
         public void ComplexFractionConstructor()
         {
             Fraction complex1 = new Fraction(new Fraction(3, 2), new Fraction(2, 5));
             Fraction complex2 = new Fraction(3, 2) / new Fraction(2, 5);
             Assert.IsTrue(complex1 == complex2);
         }

         [TestMethod]
         public void TestEqualityOfFractions()
         {
             //obvious
             Fraction fractA = new Fraction(21, 7);
             Fraction fractB = "21/7";
             Fraction fractC = 3;

             Assert.IsTrue(fractA == fractB);
             Assert.IsTrue(fractA == fractC);
             Assert.IsTrue(fractB == fractC);
         }
        #endregion

         #region Arithmetic
         [TestMethod]
         public void AddingWholeNumbersToFractions()
         {
             Assert.IsTrue(2 + new Fraction(2, 9) == "20/9");
         }

         [TestMethod]
         public void AddingFractionsWithDifferentDenominators()
         {
             Assert.IsTrue(new Fraction("1/4") + new Fraction("2/8") == new Fraction(6, 12));
             Assert.IsTrue(2 + new Fraction(2, 9) == "20/9");

             Assert.IsFalse("2" + "2/9" == "20/9"); // you need to haveat least one definition of Fraction
         }
         [TestMethod]
        public void AddingFractionsWithCommonDenominator()
        {
            Fraction fractA = new Fraction(2, 3);
            Fraction fractB = new Fraction(5, 3);
            Assert.IsTrue(fractA + fractB == new Fraction(7, 3));


            Fraction fractC = new Fraction(3, 5);
            Fraction fractD = new Fraction(1, 4);
            Assert.IsTrue(fractC + fractD == new Fraction(17, 20));
        }



        [TestMethod]
        public void TestAdditionOfMultipleFractions()
        {
            Fraction fractA = "2/7";
            Fraction fractB = "7/9";
            Fraction fractC = "3/5";

            //Debug.WriteLine(fractA + fractB + fractC);

            Assert.IsTrue(fractA + fractB + fractC == "524/315");
        }

        [TestMethod]
        public void TestMultiplicationOfFractions() // division as well 
        {
            Fraction fractA = "3/62";
            Fraction fractB = "5/54";
            Fraction result = fractA * fractB;

            Assert.IsTrue("5/1116" / fractA == fractB);

        }
        [TestMethod]
        public void TestDivisionOfFractions()
        {
            Fraction fractA = "5/1116";
            Fraction fractB = "3/62";
            Assert.IsTrue(fractA / fractB == "5/54");
        }
        [TestMethod]
        public void TestSubtraction()
        {
            Fraction fractA = "6/8";
            Fraction fractB = "2/8";

            Fraction result = fractA - fractB;
            Assert.IsTrue(result == "1/2");
            Debug.WriteLine(string.Format("FractA: {0}, and FractB: {1}",fractA.ToString (),fractB.ToString ()));
            Debug.WriteLine((fractA - fractB).ToString ());
            Debug.WriteLine((fractB - fractA).ToString ());
        }
#endregion
        [TestMethod]
        public void PrimeTest()
        {
            Fraction fractA = "-2/4";
            Debug.WriteLine("A simplified version of {0} is {1}",fractA.ToString(), fractA.Simplify ().ToString () );
            Debug.WriteLine(String.Format("The max value of a Int64/long variable is {0}",long.MaxValue));
            //for (int i= 0; i < 1000; i++)
            //{
            //    Debug.WriteLine(String.Format ("Number {0} is a prime: {1}",i,Check.IsPrime (i)));
            //}
        }

        [TestMethod]
        public void ComplexFractionTest()
        {
            // basic definition of a complex fraction
            Fraction complex1 = new Fraction(new Fraction(3, 2), new Fraction(2, 5));
            Fraction complex2 = new Fraction("3/4","2/6");

            // but under the hood, we are actually doing following
            Fraction complex3 = new Fraction(3, 2) / new Fraction(2, 5);
        }

        [TestMethod]
        public void DecimalToFractionConversion()
        {
            //decimal number = 8.08M;

            //Fraction fract = (Fraction)number;

        }

        [TestMethod]
        public void ConvertToLR()
        {
            string output = "";

            var fract = new Fraction(3, 2);

            output = fract.ToSternBrocotSystem();

            Assert.AreEqual(output, "RL");

        }

        [TestMethod]
        public void ConvertFromLR()
        {
            string output = "LRRL";

            var fract = Fraction.FromSternBrocotSystem(output);

            Assert.AreEqual(fract, new Fraction("5/7"));
            //var fract = new Mathos.Arithmetic.Fractions.Fraction(3, 2);
        }

        [TestMethod]
        public void ApproximateFraction()
        {
            var approx = Fraction.ToSternBrocotSystem(3.5M,false, 50);
            Assert.AreEqual(approx, "RRRLRLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLL");

        }
        [TestMethod]
        public void ApproximateFractionContinious()
        {
            var approx = Fraction.ToSternBrocotSystem(3.9M, true, 50);

            Assert.AreEqual(approx, "RRR");

            var approx2 = Fraction.ToSternBrocotSystem(3.7M, true, 50);

            Assert.AreEqual(approx2, "RRRLRRRL");
        }

        [TestMethod]
        public void ToCondensedFormTest()
        {
            string fracInSB = "LRRRLLLRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRR";

            string condensed = Fraction.ToCondensedSternBrocotSystem(fracInSB);

            Assert.AreEqual(condensed, "L(1)R(3)L(3)R(37)");
        }


    }
}
