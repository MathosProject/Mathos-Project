using Mathos.PreCalculus;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MathosTest.PreCalculus
{
    [TestClass]
    public class PreCalculus
    {
        [TestMethod]
        public void CalculateSum()
        {
            var s = Fibonacci.Sum(3, 5);
            
            Assert.AreEqual(10, s);
        }

        [TestMethod]
        public void ArithmeticSequence()
        {
            var a = new ArithmeticSequence
            {
                InitialTerm = 2,
                CommonDifference = 4
            };

            Assert.AreEqual(18, a.NTerm(5));
        }

        [TestMethod]
        public void GeometricSequence()
        {
            var g1 = new GeometricSequence
            {
                InitialTerm = 2,
                CommonRatio = 3
            };
            
            Assert.AreEqual(486, g1.NTerm(5));

            var g2 = new GeometricSequence
            {
                InitialTerm = 2,
                CommonRatio = 0.5
            };

            Assert.AreEqual(4, g2.InfiniteSum());
        }            
    }
}
