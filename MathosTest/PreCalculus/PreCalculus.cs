using Mathos.PreCalculus;

#if NUNIT
using TestClass = NUnit.Framework.TestFixtureAttribute;
using TestMethod = NUnit.Framework.TestAttribute;
using Assert = NUnit.Framework.Assert;
#else
using Microsoft.VisualStudio.TestTools.UnitTesting;
#endif

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
        public void ArithmeticProgression()
        {
            var ap = new ArithmeticProgression
            {
                CommonDifference = 4,
                InitialTerm = 2
            };

            Assert.AreEqual(ap.NTerm(5), 18);
        }

        [TestMethod]
        public void GeometricProgression()
        {
            var gp = new GeometricProgression
            {
                CommonRatio = 3,
                InitialTerm = 2
            };
            
            Assert.AreEqual(gp.NTerm(5), 486);
        }            
    }
}
