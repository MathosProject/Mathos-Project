using System;

using Mathos.Notation;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MathosTest.Notation
{
    [TestClass]
    public class SetTest
    {
        [TestMethod]
        public void AddRemoveElements()
        {
            var set = new Set<int>(2, 4, 6, 8, 10);

            Assert.AreEqual("{2,4,6,8,10}", set.ToString());

            set.Add(1, 3, 5, 7, 9);
            
            Assert.AreEqual("{2,4,6,8,10,1,3,5,7,9}", set.ToString());

            set.Remove(9);
            
            Assert.AreEqual("{2,4,6,8,10,1,3,5,7}", set.ToString());
        }

        [TestMethod]
        public void AddSets()
        {
            var a = new Set<int>(1, 2, 3, 4, 5);
            var b = new Set<int>(6, 7, 8, 9, 10);
            
            a.Add(b);
            
            Assert.AreEqual("{1,2,3,4,5,6,7,8,9,10}", a.ToString());
        }

        [TestMethod]
        public void UnionTest()
        {
            var a = new Set<int>(1, 2, 3);
            var b = new Set<int>(2, 3, 4);

            Assert.AreEqual("{1,2,3,4}", a.Union(b).ToString());
        }

        [TestMethod]
        public void IntersectionTest()
        {
            var a = new Set<int>(1, 2, 3);
            var b = new Set<int>(2, 3, 4);
            
            Assert.AreEqual("{2,3}", a.Intersection(b).ToString());
        }

        [TestMethod]
        public void DifferenceTest()
        {
            var a = new Set<int>(1, 2, 3);
            var b = new Set<int>(2, 3, 4);

            Assert.AreEqual("{1}", a.Difference(b).ToString());
            Assert.AreEqual("{4}", b.Difference(a).ToString());
        }

        [TestMethod]
        public void SymmetricTest()
        {
            var a = new Set<int>(1, 2, 3);
            var b = new Set<int>(2, 3, 4);

            Console.WriteLine(a.Symmetric(b));
        }

        [TestMethod]
        public void SubsetTest()
        {
            var a = new Set<int>(1, 2, 3);
            var b = new Set<int>(1, 2, 3);
            var c = new Set<int>(1, 2, 3, 4);

            Assert.IsTrue(a.IsSubset(b));
            Assert.IsTrue(a.IsSubset(c));

            Assert.IsFalse(a.IsProperSubset(b));
            Assert.IsTrue(a.IsProperSubset(c));
        }
    }
}
