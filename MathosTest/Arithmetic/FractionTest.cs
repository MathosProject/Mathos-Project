using System;
using System.Collections.Generic;
using System.Diagnostics;
using Mathos;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MathosTest.Arithmetic
{
    [TestClass]
    public class TestOfFractions
    {
        #region Helper Methods

        public List<int> Factor(int number)
        {
            var factors = new List<int>();
            var max = (int) Math.Sqrt(number);

            for (var factor = 1; factor <= max; ++factor)
            {
                //test from 1 to the square root, or the int below it, inclusive.
                if (number%factor != 0)
                    continue;

                factors.Add(factor);

                if (factor != number/factor)
                    factors.Add(number/factor); // Don't add the square root twice! - Thanks Jon
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

            Assert.AreEqual(new Fraction(-2, 8), a);
            Assert.AreEqual(new Fraction(-2, 3), new Fraction(2, -3));
            Assert.AreEqual(new Fraction(-2, -3), new Fraction(2, 3));
        }

        [TestMethod]
        public void ComplexFractionConstructor()
        {
            var complex1 = new Fraction(new Fraction(3, 2), new Fraction(2, 5));
            var complex2 = new Fraction(3, 2)/new Fraction(2, 5);

            Assert.IsTrue(complex1 == complex2);
        }

        [TestMethod]
        public void TestEqualityOfFractions()
        {
            var fractA = new Fraction(21, 7);

            Fraction fractB = "21/7";
            Fraction fractC = 3;

            Assert.AreEqual(fractA, fractB);
            Assert.AreEqual(fractA, fractC);
            Assert.AreEqual(fractB, fractC);
        }

        #endregion

        #region Arithmetic

        [TestMethod]
        public void AddingWholeNumbersToFractions()
        {
            Assert.AreEqual(2 + new Fraction(2, 9), "20/9");
        }

        [TestMethod]
        public void AddingFractionsWithDifferentDenominators()
        {
            Assert.AreEqual(new Fraction("1/4") + new Fraction("2/8"), new Fraction(6, 12));
            Assert.AreEqual(2 + new Fraction(2, 9), "20/9");
            Assert.AreNotEqual("2" + "2/9", "20/9"); // you need to have at least one definition of Fraction
        }

        [TestMethod]
        public void AddingFractionsWithCommonDenominator()
        {
            var fractA = new Fraction(2, 3);
            var fractB = new Fraction(5, 3);

            Assert.IsTrue(fractA + fractB == new Fraction(7, 3));

            var fractC = new Fraction(3, 5);
            var fractD = new Fraction(1, 4);

            Assert.IsTrue(fractC + fractD == new Fraction(17, 20));
        }


        [TestMethod]
        public void TestAdditionOfMultipleFractions()
        {
            Fraction fractA = "2/7";
            Fraction fractB = "7/9";
            Fraction fractC = "3/5";

            Assert.AreEqual(fractA + fractB + fractC, "524/315");
        }

        [TestMethod]
        public void TestMultiplicationOfFractions() // division as well 
        {
            Fraction fractA = "3/62";
            Fraction fractB = "5/54";

            Assert.AreEqual("5/1116"/fractA, fractB);
        }

        [TestMethod]
        public void TestDivisionOfFractions()
        {
            Fraction fractA = "5/1116";
            Fraction fractB = "3/62";

            Assert.AreEqual(fractA/fractB, "5/54");
        }

        [TestMethod]
        public void TestSubtraction()
        {
            Fraction fractA = "6/8";
            Fraction fractB = "2/8";
            var result = fractA - fractB;

            Assert.AreEqual(result, "1/2");

            Debug.WriteLine("FractA: {0}, and FractB: {1}", fractA, fractB);
            Debug.WriteLine((fractA - fractB).ToString());
            Debug.WriteLine((fractB - fractA).ToString());
        }

        #endregion

        [TestMethod]
        public void ConvertToLR()
        {
            var fract = new Fraction(3, 2);
            var output = fract.ToSternBrocotSystem();

            Assert.AreEqual(output, "RL");
        }

        [TestMethod]
        public void ConvertFromLR()
        {
            const string output = "LRRL";

            var fract = Fraction.FromSternBrocotSystem(output);

            Assert.AreEqual(fract, new Fraction("5/7"));
        }

        [TestMethod]
        public void ApproximateFraction()
        {
            var approx = Fraction.ToSternBrocotSystem(3.5M);

            Assert.AreEqual(approx, "RRRLRLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLL");
        }

        [TestMethod]
        public void ApproximateFractionContinious()
        {
            var approx = Fraction.ToSternBrocotSystem(3.9M, true);

            Assert.AreEqual(approx, "RRR");

            var approx2 = Fraction.ToSternBrocotSystem(3.7M, true);

            Assert.AreEqual(approx2, "RRRLRRRL");
        }

        [TestMethod]
        public void ToCondensedFormTest()
        {
            const string fracInSb = "LRRRLLLRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRR";

            var condensed = Fraction.ToCondensedSternBrocotSystem(fracInSb);

            Assert.AreEqual(condensed, "L(1)R(3)L(3)R(37)");
        }
    }
}
