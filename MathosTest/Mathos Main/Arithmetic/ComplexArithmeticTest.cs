using System.Numerics;
using Mathos;
using Mathos.Arithmetic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MathosTest.Mathos_Main.Arithmetic
{
    [TestClass]
    public class ComplexArithmeticTest
    {
        double epsilon = 1e-7;

        [TestMethod]
        public void TestRootsOf()

        {
            Complex[] rootsOf4 = { 2.0, -2.0 };
            Complex[] rootsOfMinus4 = { 2.0 * Complex.ImaginaryOne, 
                                          -2.0 * Complex.ImaginaryOne };

            Complex z = Complex.FromPolarCoordinates(16.0, 
                MathematicalConstants.PIOverFour);
            Complex[] rootsOfz = {
                                         new Complex(1.961570561,0.3901806440),
                                         new Complex(-0.3901806440,1.961570561),
                                         new Complex (-1.961570561,0.3901806440),
                                         new Complex(-0.3901806440,-1.961570561)
                                     };

            Complex[] aRootsOf4 = new Complex(4.0,0).Roots(2);
            Complex[] aRootsOfMinus4 = new Complex(-4.0, 0).Roots(2);
            Complex[] aRootsOfz = z.Roots(4);


            Assert.AreEqual(rootsOf4.Length, aRootsOf4.Length);
            for (int i = 0; i < rootsOf4.Length; i++)
            {
                bool assert = rootsOf4[i].ApproximatelyEquals(aRootsOf4[i], epsilon);
                Assert.IsTrue(assert);
            }

            Assert.AreEqual(rootsOfMinus4.Length, aRootsOfMinus4.Length);
            for (int i = 0; i < rootsOfMinus4.Length; i++)
            {
                Assert.IsTrue(rootsOfMinus4[i].ApproximatelyEquals(aRootsOfMinus4[i], epsilon));
            }

            Assert.AreEqual(rootsOfz.Length, aRootsOfz.Length);
            for (int i = 0; i < rootsOfz.Length; i++)
            {
                Assert.IsTrue(rootsOfz[i].ApproximatelyEquals(aRootsOfz[i], epsilon));
            }
        }

        [TestMethod]
        public void TestSqrt()
        {
            Complex z = new Complex(1.961570561, 0.3901806440);
            Complex w = ComplexArithmetic.Sqrt(z);
            Assert.IsTrue(z.ApproximatelyEquals(w * w, epsilon));

            z = new Complex(-1.961570561, 0.3901806440);
            w = ComplexArithmetic.Sqrt(z);
            Assert.IsTrue(z.ApproximatelyEquals(w * w, epsilon));

            z = new Complex(-1.961570561, -0.3901806440);
            w = ComplexArithmetic.Sqrt(z);
            Assert.IsTrue(z.ApproximatelyEquals(w * w, epsilon));

            z = new Complex(1.961570561, -0.3901806440);
            w = ComplexArithmetic.Sqrt(z);
            Assert.IsTrue(z.ApproximatelyEquals(w * w, epsilon));
        }

        [TestMethod]
        public void TestIfMulIsEqualToComplexOperator()
        {
            Complex z1 = new Complex(1.6859, 0.3902);
            Complex z2 = new Complex(3.51896, -0.458);

            Complex w1 = z1 * z2;
            Complex w2 = ComplexArithmetic.Multiply(z1, z2);

            Assert.IsTrue(w1.ApproximatelyEquals(w2, epsilon));
        }

        [TestMethod]
        public void ComparePowIntWithPow()
        {
            Complex z1 = new Complex(1.6859, 0.3902);
            Complex actual = z1.Pow(10);
            Complex expected = z1 * z1 * z1 * z1 * z1 * z1 * z1 * z1 * z1 * z1;

            Assert.IsTrue(expected.ApproximatelyEquals(actual, epsilon));
        }

        [TestMethod]
        public void TestIfPowIntInFasterThanPow()
        {
            int iter = 250000;
            Complex z = new Complex(1.6859, 0.3902);
            double averageIntTime = BenchmarkUtil.Benchmark(
                () => { Complex w = ComplexArithmetic.PowInt(z, 10); }, iter);
            double averageCpTime = BenchmarkUtil.Benchmark(
                () => { Complex w = Complex.Pow(z, 10); }, iter);

            Assert.IsTrue(averageIntTime < averageCpTime);
        }
    }
}
