using System.Numerics;

using Mathos;
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
    public class ComplexArithmeticTest
    {
        private const double Epsilon = 1e-7;

        [TestMethod]
        public void TestRootsOf()
        {
            var rootsOf4 = new Complex[] {2.0, -2.0};
            var rootsOfMinus4 = new[]
            {
                2.0*Complex.ImaginaryOne,
                -2.0*Complex.ImaginaryOne
            };

            var z = Complex.FromPolarCoordinates(16.0, MathematicalConstants.PIOverFour);
            var rootsOfz = new[]
            {
                new Complex(1.961570561, 0.3901806440),
                new Complex(-0.3901806440, 1.961570561),
                new Complex(-1.961570561, 0.3901806440),
                new Complex(-0.3901806440, -1.961570561)
            };

            var aRootsOf4 = new Complex(4.0,0).Roots(2);
            var aRootsOfMinus4 = new Complex(-4.0, 0).Roots(2);
            var aRootsOfz = z.Roots(4);

            Assert.AreEqual(rootsOf4.Length, aRootsOf4.Length);

            for (var i = 0; i < rootsOf4.Length; i++)
                Assert.IsTrue(rootsOf4[i].ApproximatelyEquals(aRootsOf4[i], Epsilon));

            Assert.AreEqual(rootsOfMinus4.Length, aRootsOfMinus4.Length);

            for (var i = 0; i < rootsOfMinus4.Length; i++)
                Assert.IsTrue(rootsOfMinus4[i].ApproximatelyEquals(aRootsOfMinus4[i], Epsilon));

            Assert.AreEqual(rootsOfz.Length, aRootsOfz.Length);

            for (var i = 0; i < rootsOfz.Length; i++)
                Assert.IsTrue(rootsOfz[i].ApproximatelyEquals(aRootsOfz[i], Epsilon));
        }

        [TestMethod]
        public void TestSqrt()
        {
            var z = new Complex(1.961570561, 0.3901806440);
            var w = ComplexArithmetic.Sqrt(z);

            Assert.IsTrue(z.ApproximatelyEquals(w * w, Epsilon));

            z = new Complex(-1.961570561, 0.3901806440);
            w = ComplexArithmetic.Sqrt(z);

            Assert.IsTrue(z.ApproximatelyEquals(w * w, Epsilon));

            z = new Complex(-1.961570561, -0.3901806440);
            w = ComplexArithmetic.Sqrt(z);

            Assert.IsTrue(z.ApproximatelyEquals(w * w, Epsilon));

            z = new Complex(1.961570561, -0.3901806440);
            w = ComplexArithmetic.Sqrt(z);

            Assert.IsTrue(z.ApproximatelyEquals(w * w, Epsilon));
        }

        [TestMethod]
        public void TestIfMulIsEqualToComplexOperator()
        {
            var z1 = new Complex(1.6859, 0.3902);
            var z2 = new Complex(3.51896, -0.458);

            var w1 = z1 * z2;
            var w2 = ComplexArithmetic.Multiply(z1, z2);

            Assert.IsTrue(w1.ApproximatelyEquals(w2, Epsilon));
        }

        [TestMethod]
        public void ComparePowIntWithPow()
        {
            var z1 = new Complex(1.6859, 0.3902);
            var actual = z1.Pow(10);
            var expected = z1 * z1 * z1 * z1 * z1 * z1 * z1 * z1 * z1 * z1;

            Assert.IsTrue(expected.ApproximatelyEquals(actual, Epsilon));
        }

        [TestMethod]
        public void TestIfPowIntInFasterThanPow()
        {
            const int iter = 250000;

            var z = new Complex(1.6859, 0.3902);
            var averageIntTime = BenchmarkUtil.Benchmark(() => { ComplexArithmetic.PowInt(z, 10); }, iter);
            var averageCpTime = BenchmarkUtil.Benchmark(() => { Complex.Pow(z, 10); }, iter);

            Assert.IsTrue(averageIntTime < averageCpTime);
        }
    }
}
