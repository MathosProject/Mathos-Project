using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Mathos.Calculus;

namespace MathosTest.Mathos_Main.Calculus
{
    [TestClass]
    public class FiniteCalculusTest
    {
        [TestMethod]
        public void GetCoefficientsForNthTermTest()
        {
            int index;
            double[] sequence = new double[] { 1, 2, 3, 4, 5 };

            FiniteCalculus.HasPattern(sequence, out index);

            var a = FiniteCalculus.GetCoefficientsForNthTerm( sequence, index);

            Assert.AreEqual(a[0],1.0);
            Assert.AreEqual(a[1], 0.0);

        }
        [TestMethod]
        public void GetExpressionForNthTermTest()
        {
            int index;
            double[] sequence = new double[] { 1, 2, 3, 4, 5 };

            FiniteCalculus.HasPattern(sequence, out index);

            var expression = FiniteCalculus.GetExpressionForNthTerm(FiniteCalculus.GetCoefficientsForNthTerm(sequence,index));
            
            Assert.AreEqual(expression,"1x");

            
            double[] sequence2 = new double[] { 1 ,4,8,13 };

            FiniteCalculus.HasPattern(sequence2, out index);


            var expression2 = FiniteCalculus.GetExpressionForNthTerm(FiniteCalculus.GetCoefficientsForNthTerm(sequence2, index));

            Assert.AreEqual(expression2, "0.8888888889x^2+0.4444444444x+0.1111111111");
        }


        [TestMethod]
        public void HasPatternForceCheck()
        {
            int index = 0;
            Assert.AreEqual(FiniteCalculus.HasPattern(new double[] { 1, 2, 3, 4, 5, 6 }, out index, false), true);
            Assert.AreEqual(FiniteCalculus.HasPattern(new double[] { 1, 2, 3, 4, 5, 7 }, out index, true), false);

            Assert.AreEqual(FiniteCalculus.HasPattern(new double[] { 0, 1, 4, 9, 16, 25 }, out index, true), true);
            Assert.AreEqual(FiniteCalculus.HasPattern(new double[] { 0, 1, 4, 9, 16, 26 }, out index, true), false);


        }

        [TestMethod]
        public void GetDifferenceTest1()
        {
            Assert.AreEqual(FiniteCalculus.GetDifference(new double[] { 2, 6, 12, 20, 30, 42, 56, 72 }, 0, 4), 0);
            Assert.AreEqual(FiniteCalculus.GetDifference(new double[] { 2, 6, 12, 20, 30, 42, 56, 72 }, 0, 3), 0);
            Assert.AreEqual(FiniteCalculus.GetDifference(new double[] { 2, 6, 12, 20, 30, 42, 56, 72 }, 0, 2), 2);
        }

        [TestMethod]
        public void HasPatternTest()
        {
            int returnVal = 0;

            Assert.AreEqual(FiniteCalculus.HasPattern(new double[] { 2, 6, 12, 20, 30, 42, 56, 72 }, out returnVal), true);

            Assert.AreEqual(FiniteCalculus.HasPattern(new double[] { 2, 6, 12, 20 }, out returnVal), true);

            Assert.AreEqual(FiniteCalculus.HasPattern(new double[] { 0, 1, 3, 7, 15, 31, 63, 127, 255, 511, 1023 }, out returnVal), false); // dangerous case that will not work because of 2^x

            Assert.AreEqual(FiniteCalculus.HasPattern(new double[] { 0, 2, 8, 26, 80, 242, 728, 2186, 6560 }, out returnVal), false); //

        }

        [TestMethod]
        public void GetNextTermTest()
        {
            Assert.AreEqual(FiniteCalculus.GetNextTerm(new double[] { 1, 2, 3, 4 }), 5);
            Assert.AreEqual(FiniteCalculus.GetNextTerm(new double[] { 1, 2, 3, 4,5}), 6);

            Assert.AreEqual(FiniteCalculus.GetNextTerm(new double[] { 2, 5, 10, 17 }), 26);

        }

        [TestMethod]
        public void GetCoefficientsForNthSum()
        {
            int index = 0;
            double[] sequence =new double[] { 1, 2, 3, 4, 5 };

            FiniteCalculus.HasPattern(sequence, out index);
            var coeff = FiniteCalculus.GetCoefficientsForNthSum(sequence, index);

            var expr = FiniteCalculus.GetExpressionForNthSum(coeff);

            //Assert.AreEqual(new double[] { 1, 2, 3, 4, 5 }, new double[] { });
        }
        [TestMethod]
        public void GetExpressionForNthSum()
        {

            int index;
            double[] sequence = new double[] { 3, 9, 18, 30 };

            FiniteCalculus.HasPattern(sequence, out index);

            var coeff = FiniteCalculus.GetCoefficientsForNthSum(sequence, index);

            var expr = FiniteCalculus.GetExpressionForNthSum(coeff);


        }
    }
}
