using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mathos.Arithmetic.ComplexNumbers;
using Mathos.Arithmetic.Fractions;
namespace MathosTest
{
    [TestClass]
    public class TestofcomplexNumbers
    {
        const double EPS = 1e-6;
        private bool AreApproximatelyEqual(double d1, double d2)
        {
            return Math.Abs(d1 - d2) < EPS;
        }

        private bool IsApproximatelyZero(double d)
        {
            return Math.Abs(d) < EPS;
        }



        private bool AreApproximatelyEqual(ComplexNumber complex1, ComplexNumber complex2)
        {
            return AreApproximatelyEqual(complex1.RealPart, complex2.RealPart) &&
                AreApproximatelyEqual(complex1.ImaginaryPart, complex2.ImaginaryPart);
        }

        [TestMethod]
        public void ComplexNumberConstructorsWithNonZeroValuedParameters()
        {
            ComplexNumber CompA = new ComplexNumber(21, 7);
            ComplexNumber CompB = new ComplexNumber("21+7i");
            Assert.IsTrue(CompA == CompB);

            ComplexNumber CompC = new ComplexNumber(21, -7);
            ComplexNumber CompD = new ComplexNumber("21-7i");
            Assert.IsTrue(CompC == CompD);
        }

        [TestMethod]
        public void ComplexNumberConstructorsWithZeroValuedParameters()
        {
            // This fails
            ComplexNumber CompE = new ComplexNumber(21, 0);
            ComplexNumber CompF = new ComplexNumber("21");
            //Assert.IsTrue(CompE == CompF);


            // This fails, am I wrong to assume CompG should pass (0, 21) not (0, 20)?
            //ComplexNumber CompG = new ComplexNumber(0, 21);
            //ComplexNumber CompH = new ComplexNumber("21i");
            //Assert.IsTrue(CompG == CompH);
        }

        [TestMethod]
        public void TestEqualityOfComplexNos()
        {
            //obvious
            ComplexNumber CompA = new ComplexNumber(21, 7);
            ComplexNumber CompB = new ComplexNumber("21+7i");
            Assert.IsTrue(CompA == CompB);

            ComplexNumber CompC = new ComplexNumber(21, -7);
            ComplexNumber CompD = new ComplexNumber("21-7i");
            Assert.IsTrue(CompC == CompD);

            ComplexNumber CompE = new ComplexNumber(21, 0);
            ComplexNumber CompF = new ComplexNumber("21");
            Assert.IsTrue(CompE == CompF);

            ComplexNumber CompG = new ComplexNumber(0, 20);
            ComplexNumber CompH = new ComplexNumber("20i");
            Assert.IsTrue(CompG == CompH);
            Assert.IsTrue(CompG == "20i");

        }

        [TestMethod]
        public void TestAdditionOfComplexNos()
        {
            //obvious
            ComplexNumber CompA = new ComplexNumber(21, 7);
            ComplexNumber CompB = new ComplexNumber("21-7i");
            ComplexNumber CompX = CompA + CompB;
            Assert.IsTrue(CompX == new ComplexNumber(42, 0));

            //obvious
            ComplexNumber CompC = new ComplexNumber(21);
            ComplexNumber CompD = new ComplexNumber("21-7i");
            ComplexNumber CompY = CompC + CompD;
            Assert.IsTrue(CompY == new ComplexNumber(42, -7));

        }

        [TestMethod]
        public void TestSubtractionOfComplexNos()
        {
            //obvious
            ComplexNumber CompA = new ComplexNumber(21, 7);
            ComplexNumber CompB = new ComplexNumber("21-7i");
            ComplexNumber CompX = CompA - CompB;
            Assert.IsTrue(CompX == new ComplexNumber(0, 14));

            //obvious
            ComplexNumber CompC = new ComplexNumber(21);
            ComplexNumber CompD = new ComplexNumber("21-7i");
            ComplexNumber CompY = CompC - CompD;
            Assert.IsTrue(CompY == new ComplexNumber(0, 7));

        }

        [TestMethod]
        public void TestMultiplicationOfComplexNos()
        {
            //obvious
            ComplexNumber CompA = new ComplexNumber(21, 7);
            ComplexNumber CompB = new ComplexNumber("21-7i");
            ComplexNumber CompX = CompA * CompB;
            Assert.IsTrue(CompX == new ComplexNumber(21 * 21 - 7 * -7, 21 * 7 + 21 * -7));

        }
        [TestMethod]
        public void TestComplexNosToString()
        {
            ComplexNumber CompA = new ComplexNumber(21, 7);
            ComplexNumber CompB = new ComplexNumber("21+7i");
            Assert.IsTrue(CompA.ToString() == "21+7i");
            Assert.IsTrue(CompB.ToString() == "21+7i");

            ComplexNumber CompC = new ComplexNumber(21, -7);
            ComplexNumber CompD = new ComplexNumber("21-7i");
            Assert.IsTrue(CompC.ToString() == "21-7i");
            Assert.IsTrue(CompD.ToString() == "21-7i");

            ComplexNumber CompE = new ComplexNumber(21, 0);
            Assert.IsTrue(CompE.ToString() == "21");

            ComplexNumber CompG = new ComplexNumber(0, 20);
            Assert.IsTrue(CompG.ToString() == "20i");
        }
        [TestMethod]
        public void TestComplexFractionFromString()
        {
            ComplexNumber CompA = new ComplexNumber(new Fraction(2, 3), new Fraction(4, 5));
            ComplexNumber CompB = new ComplexNumber("2/3+(4/5)i");

            //Assert.AreEqual(CompA,CompB);
        }

        [TestMethod]
        public void TestComplexNumberOperationSqrt()
        {
            ComplexNumber CompA = ComplexOperation.Sqrt(-4);
            ComplexNumber CompB = ComplexOperation.Sqrt(new ComplexNumber(0, 1));

            ComplexNumber expectedB = ComplexNumber.FromPolar(1,Math.PI/4);

            Assert.IsTrue(
                IsApproximatelyZero(ComplexOperation.Sqrt(0).RealPart));

            Assert.IsTrue(
                IsApproximatelyZero(ComplexOperation.Sqrt(0).ImaginaryPart));

            Assert.IsTrue(
                AreApproximatelyEqual(CompA, new ComplexNumber(0, 2))
                );
            Assert.IsTrue(
                AreApproximatelyEqual(CompB,
                expectedB
                ));
            Assert.IsTrue(
                AreApproximatelyEqual(ComplexOperation.Sqrt(2.5),
                Math.Sqrt(2.5)
                ));
        }

        //[TestMethod]
        //public void Test_Roots()
        //{
        //    ComplexNumber[] rootsOf4 = { 2D, -2D };
        //    ComplexNumber[] rootsOfMinus4 = { 2.0 * ComplexNumber.I, -2.0 * ComplexNumber.I };

        //    ComplexNumber z = ComplexNumber.FromPolar(16, Math.PI / 4);
        //    ComplexNumber[] rootsOfz = {
        //                                 new ComplexNumber(1.961570561,0.3901806440),
        //                                 new ComplexNumber(-0.3901806440,1.961570561),
        //                                 new ComplexNumber (-1.961570561,0.3901806440),
        //                                 new ComplexNumber(-0.3901806440,-1.961570561)
        //                             };

        //    ComplexNumber[] aRootsOf4 = ComplexOperation.Roots(4, 2);
        //    ComplexNumber[] aRootsOfMinus4 = ComplexOperation.Roots(-4, 2);
        //    ComplexNumber[] aRootsOfz = ComplexOperation.Roots(z, 4);


        //    Assert.AreEqual(rootsOf4.Length, aRootsOf4.Length);
        //    for (int i = 0; i < rootsOf4.Length; i++)
        //    {
        //        Assert.IsTrue(AreApproximatelyEqual(rootsOf4[i], aRootsOf4[i]));
        //    }
            
        //    Assert.AreEqual(rootsOfMinus4.Length, aRootsOfMinus4.Length);
        //    for (int i = 0; i < rootsOfMinus4.Length; i++)
        //    {
        //        Assert.IsTrue(AreApproximatelyEqual(rootsOfMinus4[i], aRootsOfMinus4[i]));
        //    }

        //    Assert.AreEqual(rootsOfz.Length, aRootsOfz.Length);
        //    for (int i = 0; i < rootsOfz.Length; i++)
        //    {
        //        Assert.IsTrue(AreApproximatelyEqual(rootsOfz[i], aRootsOfz[i]));
        //    }

        //}

        [TestMethod]
        public void TestPolar()
        {
            ComplexNumber z1 = new ComplexNumber(1, 1);
            ComplexNumber minus4 = new ComplexNumber(-4);
            ComplexNumber z = ComplexNumber.FromPolar(16, Math.PI / 4);

            Assert.IsTrue(AreApproximatelyEqual(Math.Pow(z1.Modulus, 2),
                2));
            Assert.IsTrue(AreApproximatelyEqual(Math.PI / 4, z1.Argument));

            ComplexNumber z2 = ComplexNumber.FromPolar(Math.Sqrt(2),
                Math.PI / 4);

            Assert.IsTrue(AreApproximatelyEqual(z1, z2));

            Assert.IsTrue(AreApproximatelyEqual(minus4.Argument, Math.PI));

            Assert.IsTrue(AreApproximatelyEqual(z.Modulus, 16.0));
            Assert.IsTrue(AreApproximatelyEqual(z.Argument, Math.PI / 4));

            ComplexNumber z4 = new ComplexNumber(-1,1);
            Assert.IsTrue(AreApproximatelyEqual(z4.Argument, 3 * Math.PI / 4.0));

            ComplexNumber z5 = new ComplexNumber(-1, -1);
            Assert.IsTrue(AreApproximatelyEqual(z5.Argument, -3 * Math.PI / 4.0));

        }
        [TestMethod]
        public void TestLog()
        {
            ComplexNumber e = Math.E;
            ComplexNumber i = new ComplexNumber(0, 1);
            ComplexNumber logMinus4 = ComplexOperation.Log(-4);

            Assert.IsTrue(
                AreApproximatelyEqual(ComplexOperation.Log(e), 1)
                );
            Assert.IsTrue(
                AreApproximatelyEqual(ComplexOperation.Log(i),
                    new ComplexNumber(0, Math.PI / 2)
                    )
                    );

            Assert.IsTrue(
                AreApproximatelyEqual(logMinus4,
                new ComplexNumber(2 * Math.Log(2), Math.PI)));
        }
        [TestMethod]
        public void TestExp()
        {
            ComplexNumber zero = 0;
            ComplexNumber z = new ComplexNumber(0, Math.PI / 2);

            Assert.IsTrue(
                AreApproximatelyEqual(ComplexOperation.Exp(zero),
                1));
            Assert.IsTrue(
                AreApproximatelyEqual(ComplexOperation.Exp(z),
                new ComplexNumber(0, 1)
                ));
        }
        [TestMethod]
        public void TestPow()
        {
            ComplexNumber i = new ComplexNumber(0, 1);
            Assert.IsTrue(
                AreApproximatelyEqual(ComplexOperation.Pow(i, i),
                Math.Exp(-Math.PI/2)));

            Assert.IsTrue(
                AreApproximatelyEqual(ComplexOperation.Pow(i,2),-1)
                );

            Assert.IsTrue(
                AreApproximatelyEqual(ComplexOperation.Pow(2.3,1.4),
                Math.Pow(2.3,1.4)));
            ComplexNumber sqrt = ComplexOperation.Pow(-4, 0.5);
            Assert.IsTrue(
                AreApproximatelyEqual(sqrt,
                new ComplexNumber(0, 2)));
        }

    }
}
