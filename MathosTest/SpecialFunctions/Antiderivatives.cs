using Microsoft.VisualStudio.TestTools.UnitTesting;

using Mathos.SpecialFunctions;

namespace MathosTest.SpecialFunctions
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Erf()
        {
            Assert.AreEqual(Antiderivatives.Erf(5), 0.99999999999846378);
        }

        [TestMethod]
        public void Erfc()
        {
            Assert.AreEqual(Antiderivatives.Erfc(5), 1 - Antiderivatives.Erf(5));
        }
    }
}
