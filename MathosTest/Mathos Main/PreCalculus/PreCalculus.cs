using Mathos.PreCalculus;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MathosTest
{
    [TestClass]
    public class PreCalculus
    {
        [TestMethod]
        public void CalculateSum()
        {
            int s = Fibonacci.Sum(3, 5);
        }

        [TestMethod]
        public void ArithmeticProgression()
        {
            ArithmeticProgression ap = new ArithmeticProgression();
            ap.CommonDifference = 4;
            ap.InitialTerm = 2;

            Assert.AreEqual(ap.NTerm(5), 18);
        }

        [TestMethod]
        public void GeometricProgression()
        {
            GeometricProgression gp = new GeometricProgression();

            gp.CommonRatio = 3;
            gp.InitialTerm = 2;

            Assert.AreEqual(gp.NTerm(5), 486);
        }            
    }
}
