using Mathos.Arithmetic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
