using System;
using Mathos.Notation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MathosTest.Mathos_Main.Theory
{
    [TestClass]
    public class SetTest
    {
        [TestMethod]
        public void AddRemoveElements()
        {
            var set = new Set<int>(2, 4, 6, 8, 10);

            Console.WriteLine(set.ToString());

            set.Add(1, 3, 5, 7, 9);

            Console.WriteLine(set.ToString());

            set.Remove(9);

            Console.WriteLine(set.ToString());
        }

        [TestMethod]
        public void AddSets()
        {
            var a = new Set<int>(1, 2, 3, 4, 5);
            var b = new Set<int>(6, 7, 8, 9, 10);
            
            a.Add(b);

            Console.WriteLine(a.ToString());
        }

        [TestMethod]
        public void UnionTest()
        {
            var a = new Set<int>(1, 2, 3);
            var b = new Set<int>(2, 3, 4);

            Console.WriteLine(a.Union(b));
        }

        [TestMethod]
        public void IntersectionTest()
        {
            var a = new Set<int>(1, 2, 3);
            var b = new Set<int>(2, 3, 4);

            Console.WriteLine(a.Intersection(b));
        }

        [TestMethod]
        public void DifferenceTest()
        {
            var a = new Set<int>(1, 2, 3);
            var b = new Set<int>(2, 3, 4);

            Console.WriteLine(a.Difference(b));
            Console.WriteLine(b.Difference(a));
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

            Console.WriteLine(a + @" ⊆ " + b + @" = " + a.IsSubset(b));
            Console.WriteLine(a + @" ⊆ " + c + @" = " + a.IsSubset(c));

            Console.WriteLine(a + @" ⊂ " + b + @" = " + a.IsProperSubset(b));
            Console.WriteLine(a + @" ⊂ " + c + @" = " + a.IsProperSubset(c));
        }

        [TestMethod]
        public void TechnicalTesting()
        {
            var set = new Set<int>(1, 2, 3, 4);

            Console.WriteLine(set.ToString());
            Console.WriteLine(set.GetHashCode());
            Console.WriteLine(set.Equals(new Set<int>(1, 2, 3, 4)));
        }
    }
}
