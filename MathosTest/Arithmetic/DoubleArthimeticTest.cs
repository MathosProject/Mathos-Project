using System;
using System.Diagnostics;

using Mathos.Arithmetic;

#if NUNIT
using TestClass = NUnit.Framework.TestFixtureAttribute;
using TestMethod = NUnit.Framework.TestAttribute;
using Assert = NUnit.Framework.Assert;
#else
using Microsoft.VisualStudio.TestTools.UnitTesting;
#endif

namespace MathosTest.Arithmetic
{
    [TestClass]
    public class DoubleArthimeticTest
    {
        [TestMethod]
        public void TestThatNaiveHypotFailsWhenHypotWorks()
        {
            // test with large values
            const double m = 1e308;

            var x = 0.3 * m;
            var y = 0.4 * m;

            var naive = Math.Sqrt(x * x + y * y);
            var hypot = DoubleArithmetic.Hypotenuse(x, y);
            
            // assert that naive method blows up
            Assert.IsTrue(double.IsInfinity(naive));
            
            // assert that our method gives the correct answer
            Assert.AreEqual(0.5 * m, hypot);

            // test with small values
            const double eps = 1e-324;

            x = 3 * eps;
            y = 4 * eps;

            naive = Math.Sqrt(x * x + y * y);
            hypot = DoubleArithmetic.Hypotenuse(x, y);

            // assert that naive method vanishes
            Assert.AreEqual(naive, 0);
            // assert that our method gives the correct answer
            Assert.AreEqual(5 * eps, hypot);
        }

        [TestMethod]
        public void TestHypotWithSomeKnownValues()
        {
            Assert.AreEqual(13.0, DoubleArithmetic.Hypotenuse(5.0, 12.0));
            Assert.AreEqual(25.0, DoubleArithmetic.Hypotenuse(7.0, 24.0));
            Assert.AreEqual(641.0, DoubleArithmetic.Hypotenuse(200.0, 609.0));
            Assert.AreEqual(661.0, DoubleArithmetic.Hypotenuse(300.0, 589.0));
        }

        [TestMethod]
        public void TestHypot3D()
        {
            var hypot = DoubleArithmetic.Hypotenuse(3, 4, 12);

            Assert.AreEqual(13.0, hypot);
        }
        [TestMethod]
        public void TestPowIntCorrectnessAndConsistency()
        {
            var pi6 = DoubleArithmetic.PowInt(Math.PI, 6);
            var pi18 = DoubleArithmetic.PowInt(Math.PI, 18);
            var pi17 = DoubleArithmetic.PowInt(Math.PI, 17);
            var oneHalfTo4 = DoubleArithmetic.PowInt(0.5, 4);
            var e218 = DoubleArithmetic.PowInt(Math.E, 218);
            var piToMinus2 = DoubleArithmetic.PowInt(Math.PI, -2);
            var pi6Expected = DoubleArithmetic.Pow6(Math.PI);

            Assert.AreEqual(32.0, DoubleArithmetic.PowInt(2.0, 5));
            Assert.AreEqual(81.0, DoubleArithmetic.PowInt(3.0, 4));
            Assert.AreEqual(pi6Expected, pi6, 1e-12, "on pi ^ 6, delta = {0}", Math.Abs(pi6 - pi6Expected));
            Assert.AreEqual(pi18, pi17*Math.PI, 1e-6, "on pi^18=p^17/pi, delta = {0}", Math.Abs(pi18 - pi17*Math.PI));
            Assert.AreEqual(1.0/16.0, oneHalfTo4, 0, "on 0.5^4=1/16, delta = {0}", Math.Abs(1.0/16.0 - oneHalfTo4));
            Assert.AreEqual(218.0, Math.Log(e218), 0, "on ln(e^218)=218, delta = {0}", Math.Abs(218.0 - Math.Log(e218)));
            Assert.AreEqual(1.0/MathematicalConstants.PISquared, piToMinus2, 1e-16, "on 1/(pi^2), delta = {0}",
                   Math.Abs(1.0/MathematicalConstants.PISquared - piToMinus2));
        }

        [TestMethod]
        public void ComparePowIntAndMathSqrtInAccuracy()
        {
            var pi6PowInt = DoubleArithmetic.PowInt(Math.PI, 6);
            var oneHalfTo4PowInt = DoubleArithmetic.PowInt(0.5, 4);
            var piSquaredPowInt = DoubleArithmetic.PowInt(Math.PI, 2);

            var pi6 = DoubleArithmetic.Pow6(Math.PI);
            var pi6Math = Math.Pow(Math.PI, 6.0);
            var oneHalfTo4Math = Math.Pow(0.5, 4.0);
            var piSquaredMath = Math.Pow(Math.PI, 2.0);

            const double oneHalfTo4 = 1.0/16.0;
            const double piSquared = MathematicalConstants.PISquared;

            double[] powIntErrors =
            {
                DoubleArithmetic.RelativeError(pi6, pi6PowInt),
                DoubleArithmetic.RelativeError(oneHalfTo4, oneHalfTo4PowInt),
                DoubleArithmetic.RelativeError(piSquared, piSquaredPowInt)
            };

            double[] mathErrors =
            {
                DoubleArithmetic.RelativeError(pi6, pi6Math),
                DoubleArithmetic.RelativeError(oneHalfTo4, oneHalfTo4Math),
                DoubleArithmetic.RelativeError(piSquared, piSquaredMath)
            };

            for (var i = 0; i < powIntErrors.Length; i++)
                Assert.IsTrue(mathErrors[i] >= powIntErrors[i]);
        }

        [TestMethod]
        public void ComparePowIntAndMathSqrtInSpeed()
        {
            Math.PI.Pow(6);

            var sw = Stopwatch.StartNew();

            for (var i = 0; i < 250000; i++)
                DoubleArithmetic.PowInt(Math.PI, 6);

            sw.Stop();

            var arth = sw.ElapsedMilliseconds;

            sw.Restart();

            for (var i = 0; i < 250000; i++)
                Math.Pow(Math.PI, 6.0);

            sw.Stop();

            var math = sw.ElapsedMilliseconds;

            Assert.IsTrue(math > arth);
        }

        [TestMethod]
        public void ComparePowIntAndNaiveInSpeed()
        {
            DoubleArithmetic.Pow(Math.PI, 6);

            var sw = Stopwatch.StartNew();

            for (var i = 0; i < 250000; i++)
                DoubleArithmetic.PowInt(Math.PI, 6);

            sw.Stop();

            var arth = sw.ElapsedMilliseconds;

            sw.Restart();

            for (var i = 0; i < 250000; i++)
                NaivePower(Math.PI, 6);

            sw.Stop();

            var naive = sw.ElapsedMilliseconds;

            Assert.IsTrue(naive > arth);
        }

        [TestMethod]
        public void TestCompareTo()
        {
            Assert.AreEqual((2.0).CompareTo(1.0, 0.5), 1);
            
            Assert.AreEqual((-2.0).CompareTo(1.0, 0.001), -1);
            
            Assert.AreEqual((1.0).CompareTo(1.2, 0.4), -1);
        }

        private static void NaivePower(double x, int n)
        {
            var result = 1.0;

            for (var i = 0; i < n; i++)
                result *= x;
        }
    }
}
