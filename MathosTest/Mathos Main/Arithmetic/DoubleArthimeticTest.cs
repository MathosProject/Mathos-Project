using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mathos.Arithmetic;
using System.Diagnostics;

namespace MathosTest.Mathos_Main.Arithmetic
{
    [TestClass]
    public class DoubleArthimeticTest
    {
        [TestMethod]
        public void TestThatNaiveHypotFailsWhenHypotWorks()
        {
            // test with large values
            double M = 1e308;
            double x = 0.3 * M;
            double y = 0.4 * M;

            double naive = Math.Sqrt(x * x + y * y);
            double hypot = DoubleArithmetic.Hypotenuse(x, y);
            
            // assert that naive method blows up
            Assert.IsTrue(double.IsInfinity(naive));
            // assert that our method gives the correct answer
            Assert.AreEqual<double>(0.5 * M, hypot);

            // test with small values
            double eps = 1e-324;
            x = 3 * eps;
            y = 4 * eps;

            naive = Math.Sqrt(x * x + y * y);
            hypot = DoubleArithmetic.Hypotenuse(x, y);

            // assert that naive method vanishes
            Assert.IsTrue(naive==0);
            // assert that our method gives the correct answer
            Assert.AreEqual<double>(5 * eps, hypot);
        }

        [TestMethod]
        public void TestHypotWithSomeKnownValues()
        {
            Assert.AreEqual(13.0,
                DoubleArithmetic.Hypotenuse(5.0, 12.0));

            Assert.AreEqual(25.0,
                DoubleArithmetic.Hypotenuse(7.0, 24.0));
                        
            Assert.AreEqual(641.0,
                DoubleArithmetic.Hypotenuse(200.0, 609.0));
            
            Assert.AreEqual(661.0,
                DoubleArithmetic.Hypotenuse(300.0, 589.0));
        }

        [TestMethod]
        public void TestHypot3D()
        {
            double hypot = DoubleArithmetic.Hypotenuse(3, 4, 12);

            Assert.AreEqual<double>(13.0, hypot);
        }
        [TestMethod]
        public void TestPowIntCorrectnessAndConsistency()
        {
            double pi6 = DoubleArithmetic.PowInt(Math.PI, 6);
            double pi18 = DoubleArithmetic.PowInt(Math.PI, 18);
            double pi17 = DoubleArithmetic.PowInt(Math.PI, 17);
            double oneHalfTo4 = DoubleArithmetic.PowInt(0.5, 4);
            double e218 = DoubleArithmetic.PowInt(Math.E, 218);
            double piToMinus2 = DoubleArithmetic.PowInt(Math.PI, -2);
            double pi6Expected = DoubleArithmetic.Pow6(Math.PI);

            Assert.AreEqual(32.0, DoubleArithmetic.PowInt(2.0, 5));

            Assert.AreEqual(81.0, DoubleArithmetic.PowInt(3.0, 4));

            Assert.AreEqual(pi6Expected,pi6, 1e-12,
                "on pi ^ 6, delta = {0}", 
                Math.Abs(pi6-pi6Expected)
                );

            Assert.AreEqual(pi18, pi17*Math.PI, 1e-6,
                "on pi^18=p^17/pi, delta = {0}",
                Math.Abs(pi18 - pi17 * Math.PI)
                );

            Assert.AreEqual(1.0 / 16.0, oneHalfTo4, 0,
                 "on 0.5^4=1/16, delta = {0}",
                 Math.Abs(1.0 / 16.0 - oneHalfTo4)
                 );

            Assert.AreEqual(218.0, Math.Log(e218), 0,
                 "on ln(e^218)=218, delta = {0}",
                 Math.Abs(218.0 - Math.Log(e218))
                 );

            Assert.AreEqual(1.0 / MathematicalConstants.PISquared, piToMinus2, 1e-16,
                 "on 1/(pi^2), delta = {0}",
                 Math.Abs(1.0 / MathematicalConstants.PISquared - piToMinus2)
                 );
        }

        [TestMethod]
        public void ComparePowIntAndMathSqrtInAccuracy()
        {
            double pi6_powInt = DoubleArithmetic.PowInt(Math.PI, 6);
            double oneHalfTo4_powInt = DoubleArithmetic.PowInt(0.5, 4);
            double piSquared_powInt = DoubleArithmetic.PowInt(Math.PI, 2);

            double pi6_math = Math.Pow(Math.PI, 6.0);
            double oneHalfTo4_math = Math.Pow(0.5, 4.0);
            double piSquared_math = Math.Pow(Math.PI, 2.0);


            double pi6 = DoubleArithmetic.Pow6(Math.PI);
            double oneHalfTo4 = 1.0/16.0;
            double piSquared = MathematicalConstants.PISquared;

            double[] powIntErrors = 
            {
                DoubleArithmetic.RelativeError(pi6,pi6_powInt),
                DoubleArithmetic.RelativeError(oneHalfTo4, oneHalfTo4_powInt),
                DoubleArithmetic.RelativeError(piSquared, piSquared_powInt)
            };

            double[] mathErrors = 
            {
                DoubleArithmetic.RelativeError(pi6,pi6_math),
                DoubleArithmetic.RelativeError(oneHalfTo4, oneHalfTo4_math),
                DoubleArithmetic.RelativeError(piSquared, piSquared_math)
            };

            for (int i = 0; i < powIntErrors.Length; i++)
            {
                Assert.IsTrue(
                    mathErrors[i] >= powIntErrors[i]
                    );
            }
        }

        [TestMethod]
        public void ComparePowIntAndMathSqrtInSpeed()
        {
            double pi6 = DoubleArithmetic.Pow(Math.PI, 6);

            Stopwatch sw = Stopwatch.StartNew();

            for (int i = 0; i < 250000; i++)
            {
                pi6 = DoubleArithmetic.PowInt(Math.PI, 6);
            }

            sw.Stop();
            long arth = sw.ElapsedMilliseconds;

            sw.Restart();

            for (int i = 0; i < 250000; i++)
            {
                pi6 = Math.Pow(Math.PI, 6.0);
            }

            sw.Stop();
            long math = sw.ElapsedMilliseconds;

            Assert.IsTrue(math > arth);
        }

        [TestMethod]
        public void ComparePowIntAndNaiveInSpeed()
        {
            double pi6 = DoubleArithmetic.Pow(Math.PI, 6);

            Stopwatch sw = Stopwatch.StartNew();

            for (int i = 0; i < 250000; i++)
            {
                pi6 = DoubleArithmetic.PowInt(Math.PI, 6);
            }

            sw.Stop();
            long arth = sw.ElapsedMilliseconds;

            sw.Restart();

            for (int i = 0; i < 250000; i++)
            {
                pi6 = NaivePower(Math.PI, 6);
            }

            sw.Stop();
            long naive = sw.ElapsedMilliseconds;

            Assert.IsTrue(naive > arth);
        }

        [TestMethod]
        public void TestCompareTo()
        {
            Assert.AreEqual((2.0).CompareTo(1.0, 0.5), 1);
            
            Assert.AreEqual((-2.0).CompareTo(1.0, 0.001), -1);
            
            Assert.AreEqual((1.0).CompareTo(1.2, 0.4), -1);
        }

        private static double NaivePower(double x, int n)
        {
            double result = 1.0;
            for (int i = 0; i < n; i++)
            {
                result *= x;
            }
            return result;
        }
    }
}
