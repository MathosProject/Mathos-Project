using Microsoft.VisualStudio.TestTools.UnitTesting;

using Mathos.Syntax;

namespace MathosTest
{
    [TestClass]
    public class SyntaxTest
    {
        [TestMethod]
        public void IsPositiveTest()
        {
            const int positive = 25;
            const int negative = -36;

            Assert.IsTrue(positive.IsPositive());
            Assert.IsFalse(negative.IsPositive());
        }

        [TestMethod]
        public void IsNegativeTest()
        {
            const int positive = 25;
            const int negative = -36;

            Assert.IsFalse(positive.IsNegative());
            Assert.IsTrue(negative.IsNegative());
        }

        [TestMethod]
        public void IsDivisibleTest()
        {
            const int divisible = 26;
            const int nondivisible = 37;

            Assert.IsTrue(divisible.IsDivisible(2));
            Assert.IsFalse(nondivisible.IsDivisible(2));
        }

        [TestMethod]
        public void IsEvenTest()
        {
            const int even = 26;
            const int odd = 37;

            Assert.IsTrue(even.IsEven());
            Assert.IsFalse(odd.IsEven());
        }

        [TestMethod]
        public void IsOddTest()
        {
            const int even = 26;
            const int odd = 37;

            Assert.IsFalse(even.IsOdd());
            Assert.IsTrue(odd.IsOdd());
        }

        [TestMethod]
        public void IsPrimeTest()
        {
            const int prime = 7;
            const int composite = 10;

            Assert.IsTrue(prime.IsPrime());
            Assert.IsFalse(composite.IsPrime());
        }

        [TestMethod]
        public void IsCoprimeTest()
        {
            const int test = 14;

            const int coprime = 15;
            const int composite = 21;

            Assert.IsTrue(test.IsCoprime(coprime));
            Assert.IsFalse(test.IsCoprime(composite));
        }

        [TestMethod]
        public void ToPositiveTest()
        {
            const int positive = 56;
            const int negative = -47;

            Assert.AreEqual(56, positive.ToPositive());
            Assert.AreEqual(47, negative.ToPositive());
        }

        [TestMethod]
        public void ToNegativeTest()
        {
            const int positive = 56;
            const int negative = -47;

            Assert.AreEqual(-56, positive.ToNegative());
            Assert.AreEqual(-47, negative.ToNegative());
        }
    }
}
