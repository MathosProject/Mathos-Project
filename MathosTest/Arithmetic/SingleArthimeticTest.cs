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
    public class SingleArthimeticTest
    {
        private const float Epsilon = 0.01f;

        [TestMethod]
        public void TestSqrt()
        {
            const float number = MathematicalConstants.Single.PI;

            var root = SingleArithmetic.Sqrt(number);

            Assert.IsTrue(number.ApproximatelyEquals(root * root, Epsilon));
        }
    }
}
