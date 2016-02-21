using System;
using System.Numerics;
using Mathos.Arithmetic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MathosTest
{
    [TestClass]
    public class TestofcomplexNumbers
    {
        const double EPS = 1e-6;

        private static bool AreApproximatelyEqual(double d1, double d2)
        {
            return Math.Abs(d1 - d2) < EPS;
        }

        private static bool IsApproximatelyZero(double d)
        {
            return Math.Abs(d) < EPS;
        }
        
        private static bool AreApproximatelyEqual(Complex complex1, Complex complex2)
        {
            return AreApproximatelyEqual(complex1.Real, complex2.Real) &&
                   AreApproximatelyEqual(complex1.Imaginary, complex2.Imaginary);
        }

        [TestMethod]
        public void ComplexNumberConstructorsWithNonZeroValuedParameters()
        {
            var compA = new Complex(21, 7);
            var compB = ComplexArithmetic.FromString("21+7i");

            Assert.IsTrue(compA == compB);

            var compC = new Complex(21, -7);
            var compD = ComplexArithmetic.FromString("21-7i");

            Assert.IsTrue(compC == compD);
        }
        
        [TestMethod]
        public void ComplexNumberConstructorsWithZeroValuedParameters()
        {
            var compE = new Complex(21, 0);
            var compF = ComplexArithmetic.FromString("21");

            Assert.IsTrue(compE == compF);
        }

        [TestMethod]
        public void TestEqualityOfComplexNos()
        {
            var compA = new Complex(21, 7);
            var compB = "21+7i".ToComplex();

            Assert.IsTrue(compA == compB);

            var compC = new Complex(21, -7);
            var compD = "21-7i".ToComplex();

            Assert.IsTrue(compC == compD);

            var compE = new Complex(21, 0);
            var compF = "21".ToComplex();

            Assert.IsTrue(compE == compF);

            var compG = new Complex(0, 20);
            var compH = "20i".ToComplex();

            Assert.IsTrue(compG == compH);
            Assert.IsTrue(compG.Abi() == "20i");
        }

        [TestMethod]
        public void TestAdditionOfComplexNos()
        {
            var compA = new Complex(21, 7);
            var compB = "21-7i".ToComplex();
            var compX = compA + compB;

            Assert.IsTrue(compX == new Complex(42, 0));
            
            var compC = new Complex(21, 0);
            var compD = "21-7i".ToComplex();
            var compY = compC + compD;

            Assert.IsTrue(compY == new Complex(42, -7));
        }

        [TestMethod]
        public void TestSubtractionOfComplexNos()
        {
            var compA = new Complex(21, 7);
            var compB = "21-7i".ToComplex();
            var compX = compA - compB;

            Assert.IsTrue(compX == new Complex(0, 14));
            
            var compC = new Complex(21, 0);
            var compD = "21-7i".ToComplex();
            var compY = compC - compD;

            Assert.IsTrue(compY == new Complex(0, 7));
        }

        [TestMethod]
        public void TestMultiplicationOfComplexNos()
        {
            var compA = new Complex(21, 7);
            var compB = "21-7i".ToComplex();
            var compX = compA * compB;

            Assert.IsTrue(compX == new Complex(21 * 21 - 7 * -7, 21 * 7 + 21 * -7));
        }

        [TestMethod]
        public void TestComplexNosToString()
        {
            var compA = new Complex(21, 7);
            var compB = "21+7i".ToComplex();

            Assert.IsTrue(compA.Abi() == "21+7i");
            Assert.IsTrue(compB.Abi() == "21+7i");

            var compC = new Complex(21, -7);
            var compD = "21-7i".ToComplex();

            Assert.IsTrue(compC.Abi() == "21-7i");
            Assert.IsTrue(compD.Abi() == "21-7i");

            var compE = new Complex(21, 0);

            Assert.IsTrue(compE.Abi() == "21");

            var compG = new Complex(0, 20);

            Assert.IsTrue(compG.Abi() == "20i");
        }

        [TestMethod]
        public void TestComplexFractionFromString()
        {
            // TODO: ToComplex isn't working correctly.
            /*var compA = new Complex(new Fraction(2, 3).ToDouble(), new Fraction(4, 5).ToDouble());
            var compB = "2/3+(4/5)i".ToComplex();

            Assert.AreEqual(compA, compB);*/
        }

        [TestMethod]
        public void TestComplexNumberOperationSqrt()
        {
            var compA = Complex.Sqrt(-4);
            var compB = Complex.Sqrt(new Complex(0, 1));
            var expectedB = Complex.FromPolarCoordinates(1,Math.PI/4);

            Assert.IsTrue(
                IsApproximatelyZero(Complex.Sqrt(0).Real));
            Assert.IsTrue(
                IsApproximatelyZero(Complex.Sqrt(0).Imaginary));
            Assert.IsTrue(
                AreApproximatelyEqual(compA, new Complex(0, 2)));
            Assert.IsTrue(
                AreApproximatelyEqual(compB,
                expectedB));
            Assert.IsTrue(
                AreApproximatelyEqual(Complex.Sqrt(2.5),
                Math.Sqrt(2.5)));
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
            var z1 = new Complex(1, 1);
            var minus4 = new Complex(-4, 0);
            var z = Complex.FromPolarCoordinates(16, Math.PI / 4);

            Assert.IsTrue(AreApproximatelyEqual(Math.Pow(z1.Modulus(), 2), 2));
            Assert.IsTrue(AreApproximatelyEqual(Math.PI / 4, z1.Argument()));

            var z2 = Complex.FromPolarCoordinates(Math.Sqrt(2), Math.PI / 4);

            Assert.IsTrue(AreApproximatelyEqual(z1, z2));
            Assert.IsTrue(AreApproximatelyEqual(minus4.Argument(), Math.PI));
            Assert.IsTrue(AreApproximatelyEqual(z.Modulus(), 16.0));
            Assert.IsTrue(AreApproximatelyEqual(z.Argument(), Math.PI / 4));

            var z4 = new Complex(-1,1);

            Assert.IsTrue(AreApproximatelyEqual(z4.Argument(), 3 * Math.PI / 4.0));

            var z5 = new Complex(-1, -1);

            Assert.IsTrue(AreApproximatelyEqual(z5.Argument(), -3 * Math.PI / 4.0));
        }

        [TestMethod]
        public void TestLog()
        {
            Complex e = Math.E;

            var i = new Complex(0, 1);
            var logMinus4 = Complex.Log(-4);

            Assert.IsTrue(AreApproximatelyEqual(Complex.Log(e), 1));
            Assert.IsTrue(AreApproximatelyEqual(Complex.Log(i), new Complex(0, Math.PI/2)));
            Assert.IsTrue(AreApproximatelyEqual(logMinus4, new Complex(2*Math.Log(2), Math.PI)));
        }

        [TestMethod]
        public void TestExp()
        {
            Complex zero = 0;

            var z = new Complex(0, Math.PI / 2);

            Assert.IsTrue(AreApproximatelyEqual(Complex.Exp(zero), 1));
            Assert.IsTrue(AreApproximatelyEqual(Complex.Exp(z), new Complex(0, 1)));
        }
        
        [TestMethod]
        public void TestPow()
        {
            var i = new Complex(0, 1);

            Assert.IsTrue(AreApproximatelyEqual(Complex.Pow(i, i), Math.Exp(-Math.PI/2)));
            Assert.IsTrue(AreApproximatelyEqual(Complex.Pow(i,2),-1));
            Assert.IsTrue(AreApproximatelyEqual(Complex.Pow(2.3,1.4), Math.Pow(2.3,1.4)));

            var sqrt = Complex.Pow(-4, 0.5);

            Assert.IsTrue(AreApproximatelyEqual(sqrt, new Complex(0, 2)));
        }
    }
}
