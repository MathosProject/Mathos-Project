using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Mathos.Arithmetic;
namespace MathosTest.Mathos_Main.Arithmetic
{
    [TestClass]
    public class DecimalArithmetic
    {
        [TestMethod]
        public void TestMethod1()
        {
            decimal twelve = Mathos.Arithmetic.DecimalArithmetic.Ln(12);

            decimal smallerThanOne = Mathos.Arithmetic.DecimalArithmetic.Ln(0.5M);

            //decimal sqrtOfx = Mathos.Arithmetic.DecimalArithmetic.pow(4, 0.5M);
        }
    }
}
