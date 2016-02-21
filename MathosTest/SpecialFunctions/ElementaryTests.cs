using System;
using System.Numerics;
using Mathos.Calculus;
using Mathos.SpecialFunctions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MathosTest.Mathos_Main.SpecialFunctions
{
    [TestClass]
    public class ElementaryTests
    {
        // Using Asser.AreEqual almost always fails
        // Everything here is an approximation
        const double EPS = 1e-15;
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
        public void Test_Cot()
        {
            Complex r = new Complex(Math.PI / 4, 0);
            Complex i = new Complex(0, Math.Log(3));
            Complex c = new Complex(Math.PI / 2, Math.Log(3));

            Complex cotr = Elementary.Cot(r);
            Complex coti = Elementary.Cot(i);
            Complex cotc = Elementary.Cot(c);

            
            Assert.IsTrue(AreApproximatelyEqual(cotr.Real,1D));
            Assert.IsTrue(IsApproximatelyZero(cotr.Imaginary));

            Assert.IsTrue(IsApproximatelyZero(coti.Real));
            Assert.IsTrue(AreApproximatelyEqual(coti.Imaginary,-1.25D));

            Assert.IsTrue(IsApproximatelyZero(cotc.Real));
            Assert.IsTrue(AreApproximatelyEqual(cotc.Imaginary, -0.8D));
        }

        [TestMethod]
        public void Test_Coth()
        {
            Complex r = new Complex(Math.Log(3), 0);
            Complex i = new Complex(0, Math.PI/4);
            Complex c = new Complex(Math.Log(3), Math.PI / 2);

            Assert.IsTrue(AreApproximatelyEqual(Elementary.Coth(r).Real, 1.25D));
            Assert.IsTrue(IsApproximatelyZero(Elementary.Coth(r).Imaginary));

            Assert.IsTrue(IsApproximatelyZero(Elementary.Coth(i).Real));
            Assert.IsTrue(AreApproximatelyEqual(Elementary.Coth(i).Imaginary, -1D));

            Assert.IsTrue(IsApproximatelyZero(Elementary.Coth(c).Imaginary));
            Assert.IsTrue(AreApproximatelyEqual(Elementary.Coth(c).Real, 4D/5D));
        }
        [TestMethod]
        public void Test_Roots()
        {
            //Complex[] expected = { Complex.One, Complex.ImaginaryOne, -Complex.One, -Complex.ImaginaryOne };

            //Complex[] actual = Elementary.Roots(Complex.One, 4);

            //Assert.AreEqual(actual.Length, expected.Length);

            //for (int i = 0; i < expected.Length; i++)
            //{
            //    Assert.IsTrue(AreApproximatelyEqual(actual[i], expected[i]));
            //}
        }

    }
}
