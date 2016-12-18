using Mathos;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MathosTest
{
    [TestClass]
    public class VectorTest
    {
        [TestMethod]
        public void ToStringTest()
        {
            var vector = new Vector(1, 2, 3, 4);

            Assert.AreEqual("1 2 3 4", vector.ToString());
        }

        [TestMethod]
        public void OperationsTest()
        {
            var vecA = new Vector(1, 2, 3, 4, 5);
            var vecB = new Vector(3, 4, 5, 6, 7);
            var result = vecA + vecB;

            Assert.AreEqual(result, new Vector(4, 6, 8, 10, 12));
        }

        [TestMethod]
        public void ComparisonTest()
        {
            var vecA = new Vector(1, 2, 3, 4, 5);
            var vecB = new Vector(1, 2, 3, 4, 5);

            Assert.AreEqual(vecA, vecB);

            var vecC = new Vector(1, 2, 3, 4, 5, 6);

            Assert.AreNotEqual(vecA, vecC);
        }
    }
}
