using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace MathosTest
{
    [TestClass]
    public class PreCalculus
    {
        [TestMethod]
        public void CalculateSum()
        {
            int s = Mathos.PreCalculus.Sequences.Fibonacci.Sum(3, 5);
        }

        [TestMethod]
        public void ArithmeticProgression()
        {
            Mathos.PreCalculus.Sequences.ArithmeticProgression ap = new Mathos.PreCalculus.Sequences.ArithmeticProgression();
            ap.CommonDifference = 4;
            ap.InitialTerm = 2;

            Assert.AreEqual(ap.NTerm(5), 18);
        }

        [TestMethod]
        public void GeometricProgression()
        {
            Mathos.PreCalculus.Sequences.GeometricProgression gp = new Mathos.PreCalculus.Sequences.GeometricProgression();

            gp.CommonRatio = 3;
            gp.InitialTerm = 2;

            Assert.AreEqual(gp.NTerm(5), 486);
        }            
    }
}
