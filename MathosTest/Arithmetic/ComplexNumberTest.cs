using System;
using System.Numerics;
using Mathos.Arithmetic;
using Mathos.Arithmetic.Fractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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



        private bool AreApproximatelyEqual(Complex complex1, Complex complex2)
        {
            return AreApproximatelyEqual(complex1.Real, complex2.Real) &&
                AreApproximatelyEqual(complex1.Imaginary, complex2.Imaginary);
        }

        [TestMethod]
        public void ComplexNumberConstructorsWithNonZeroValuedParameters()
        {
            Complex CompA = new Complex(21, 7);
            Complex CompB = ComplexArithmetic.FromString("21+7i");
            Assert.IsTrue(CompA == CompB);

            Complex CompC = new Complex(21, -7);
            Complex CompD = ComplexArithmetic.FromString("21-7i");
            Assert.IsTrue(CompC == CompD);
        }

        [TestMethod]
        public void ComplexNumberConstructorsWithZeroValuedParameters()
        {
            // This fails
            Complex CompE = new Complex(21, 0);
            Complex CompF = ComplexArithmetic.FromString("21");
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
            Complex CompA = new Complex(21, 7);
            Complex CompB = "21+7i".ToComplex();
            Assert.IsTrue(CompA == CompB);

            Complex CompC = new Complex(21, -7);
            Complex CompD = "21-7i".ToComplex();
            Assert.IsTrue(CompC == CompD);

            Complex CompE = new Complex(21, 0);
            Complex CompF = "21".ToComplex();
            Assert.IsTrue(CompE == CompF);

            Complex CompG = new Complex(0, 20);
            Complex CompH = "20i".ToComplex();
            Assert.IsTrue(CompG == CompH);
            Assert.IsTrue(CompG.Abi() == "20i");

        }

        [TestMethod]
        public void TestAdditionOfComplexNos()
        {
            //obvious
            Complex CompA = new Complex(21, 7);
            Complex CompB = "21-7i".ToComplex();
            Complex CompX = CompA + CompB;
            Assert.IsTrue(CompX == new Complex(42, 0));

            //obvious
            Complex CompC = new Complex(21, 0);
            Complex CompD = "21-7i".ToComplex();
            Complex CompY = CompC + CompD;
            Assert.IsTrue(CompY == new Complex(42, -7));

        }

        [TestMethod]
        public void TestSubtractionOfComplexNos()
        {
            //obvious
            Complex CompA = new Complex(21, 7);
            Complex CompB = "21-7i".ToComplex();
            Complex CompX = CompA - CompB;
            Assert.IsTrue(CompX == new Complex(0, 14));

            //obvious
            Complex CompC = new Complex(21, 0);
            Complex CompD = "21-7i".ToComplex();
            Complex CompY = CompC - CompD;
            Assert.IsTrue(CompY == new Complex(0, 7));

        }

        [TestMethod]
        public void TestMultiplicationOfComplexNos()
        {
            //obvious
            Complex CompA = new Complex(21, 7);
            Complex CompB = "21-7i".ToComplex();
            Complex CompX = CompA * CompB;
            Assert.IsTrue(CompX == new Complex(21 * 21 - 7 * -7, 21 * 7 + 21 * -7));

        }
        [TestMethod]
        public void TestComplexNosToString()
        {
            Complex CompA = new Complex(21, 7);
            Complex CompB = "21+7i".ToComplex();
            Assert.IsTrue(CompA.Abi() == "21+7i");
            Assert.IsTrue(CompB.Abi() == "21+7i");

            Complex CompC = new Complex(21, -7);
            Complex CompD = "21-7i".ToComplex();
            Assert.IsTrue(CompC.Abi() == "21-7i");
            Assert.IsTrue(CompD.Abi() == "21-7i");

            Complex CompE = new Complex(21, 0);
            Assert.IsTrue(CompE.Abi() == "21");

            Complex CompG = new Complex(0, 20);
            Assert.IsTrue(CompG.Abi() == "20i");
        }
        [TestMethod]
        public void TestComplexFractionFromString()
        {
            Complex CompA = new Complex(new Fraction(2, 3).ToDouble(), new Fraction(4, 5).ToDouble());
            Complex CompB = "2/3+(4/5)i".ToComplex();

            //Assert.AreEqual(CompA,CompB);
        }

        [TestMethod]
        public void TestComplexNumberOperationSqrt()
        {
            Complex CompA = Complex.Sqrt(-4);
            Complex CompB = Complex.Sqrt(new Complex(0, 1));

            Complex expectedB = Complex.FromPolarCoordinates(1,Math.PI/4);

            Assert.IsTrue(
                IsApproximatelyZero(Complex.Sqrt(0).Real));

            Assert.IsTrue(
                IsApproximatelyZero(Complex.Sqrt(0).Imaginary));

            Assert.IsTrue(
                AreApproximatelyEqual(CompA, new Complex(0, 2))
                );
            Assert.IsTrue(
                AreApproximatelyEqual(CompB,
                expectedB
                ));
            Assert.IsTrue(
                AreApproximatelyEqual(Complex.Sqrt(2.5),
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
            Complex z1 = new Complex(1, 1);
            Complex minus4 = new Complex(-4, 0);
            Complex z = Complex.FromPolarCoordinates(16, Math.PI / 4);

            Assert.IsTrue(AreApproximatelyEqual(Math.Pow(z1.Modulus(), 2),
                2));
            Assert.IsTrue(AreApproximatelyEqual(Math.PI / 4, z1.Argument()));

            Complex z2 = Complex.FromPolarCoordinates(Math.Sqrt(2),
                Math.PI / 4);

            Assert.IsTrue(AreApproximatelyEqual(z1, z2));

            Assert.IsTrue(AreApproximatelyEqual(minus4.Argument(), Math.PI));

            Assert.IsTrue(AreApproximatelyEqual(z.Modulus(), 16.0));
            Assert.IsTrue(AreApproximatelyEqual(z.Argument(), Math.PI / 4));

            Complex z4 = new Complex(-1,1);
            Assert.IsTrue(AreApproximatelyEqual(z4.Argument(), 3 * Math.PI / 4.0));

            Complex z5 = new Complex(-1, -1);
            Assert.IsTrue(AreApproximatelyEqual(z5.Argument(), -3 * Math.PI / 4.0));

        }
        [TestMethod]
        public void TestLog()
        {
            Complex e = Math.E;
            Complex i = new Complex(0, 1);
            Complex logMinus4 = Complex.Log(-4);

            Assert.IsTrue(
                AreApproximatelyEqual(Complex.Log(e), 1)
                );
            Assert.IsTrue(
                AreApproximatelyEqual(Complex.Log(i),
                    new Complex(0, Math.PI / 2)
                    )
                    );

            Assert.IsTrue(
                AreApproximatelyEqual(logMinus4,
                new Complex(2 * Math.Log(2), Math.PI)));
        }
        [TestMethod]
        public void TestExp()
        {
            Complex zero = 0;
            Complex z = new Complex(0, Math.PI / 2);

            Assert.IsTrue(
                AreApproximatelyEqual(Complex.Exp(zero),
                1));
            Assert.IsTrue(
                AreApproximatelyEqual(Complex.Exp(z),
                new Complex(0, 1)
                ));
        }
        [TestMethod]
        public void TestPow()
        {
            Complex i = new Complex(0, 1);
            Assert.IsTrue(
                AreApproximatelyEqual(Complex.Pow(i, i),
                Math.Exp(-Math.PI/2)));

            Assert.IsTrue(
                AreApproximatelyEqual(Complex.Pow(i,2),-1)
                );

            Assert.IsTrue(
                AreApproximatelyEqual(Complex.Pow(2.3,1.4),
                Math.Pow(2.3,1.4)));
            Complex sqrt = Complex.Pow(-4, 0.5);
            Assert.IsTrue(
                AreApproximatelyEqual(sqrt,
                new Complex(0, 2)));
        }

    }
}
