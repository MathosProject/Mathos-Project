using System.Globalization;
using Mathos.Arithmetic.Numbers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Mathos.Syntax;

namespace MathosTest
{
    [TestClass]
    public class SyntaxTest
    {
        [TestMethod]
        public void TestSyntax()
        {
            const int myNumber = 29;

            Assert.IsTrue(myNumber.IsPrime());
            Assert.IsFalse(myNumber.IsEven());
            Assert.IsTrue(myNumber.IsPositive());
            
            const long mySecondNumber = 32;
            const long myThirdNumber = 9;

            Assert.IsTrue(mySecondNumber.IsCoprime(myThirdNumber));
        }

        [TestMethod]
        public void TestUsualWay()
        {
            Assert.IsTrue(Check.IsPrime(29));
            Assert.AreEqual(2, Convert.ToPositive(-2));
            Assert.AreEqual(4, Get.Gdc(20, 4));

            foreach (var factor in Get.Factors(81))
                System.Diagnostics.Debug.WriteLine("Factor: " + factor.ToString(CultureInfo.InvariantCulture));
        }
    }
}
