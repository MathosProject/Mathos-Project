using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mathos.Arithmetic;
using System.Diagnostics;

namespace MathosTest.Mathos_Main.Arithmetic
{
    [TestClass]
    public class SingleArthimeticTest
    {
        float epsilon = 0.01f;
        [TestMethod]
        public void TestSqrt()
        {
            float number = MathematicalConstants.Single.PI;

            float root = SingleArithmetic.Sqrt(number);

            Assert.IsTrue(number.ApproximatelyEquals(root * root, epsilon));
        }
    }
}
