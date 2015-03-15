using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mathos.Arithmetic;
using System.Diagnostics;

namespace MathosTest.Mathos_Main.Arithmetic
{
    [TestClass]
    public class IntegerArthimeticTest
    {
        [TestMethod]
        public void TestSqrt()
        {
            Assert.AreEqual(9, IntegerArithmetic.Sqrt(81));

            Assert.AreEqual(9, IntegerArithmetic.Sqrt(99));
        }

        //[TestMethod]
        //public void TestIfSqrtIsFasterThanMathSqrt()
        //{
        //    int iter = 250000;

        //    double avgSqrt = BenchmarkUtil.Benchmark(() =>
        //        { int r = IntegerArithmetic.Sqrt(28); },
        //        iter);

        //    double avgMath = BenchmarkUtil.Benchmark(() =>
        //    { int r = (int)Math.Sqrt(28); },
        //        iter);

        //    Assert.IsTrue(avgMath > avgSqrt);
        //}
        // It does not seem to be actually faster :(
    }
}
