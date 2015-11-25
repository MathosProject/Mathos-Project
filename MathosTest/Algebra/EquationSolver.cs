using System;
using System.Numerics;
using Mathos;
using Mathos.Arithmetic;
using Mathos.Notation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MathosTest
{
    [TestClass]
    public class EquationSolverTest
    {
        [TestMethod]
        public void QuadraticEquationExTest()
        {
            //equation 2x^2+3x-1

            Complex[] result = EquationSolver.QuadraticEquationEx(2, 3, -1);

            Assert.IsTrue(result[0].ApproximatelyEquals(-1.78077640640442,1e1-0));

            Assert.IsTrue(result[1].ApproximatelyEquals(0.280776406404415, 1e-10));

        }

        [TestMethod]
        [Obsolete]
        public void QuadraticEquationTest()
        {
            //equation 2x^2+3x-1

            Complex[] result = EquationSolver.QuadraticEquation(2, 3, -1);

            Assert.IsTrue(result[0].Real.ApproximatelyEquals(-1.78077640640442, 1e1 - 0));
            Assert.IsTrue(result[0].Imaginary.ApproximatelyEquals(0, 1e1 - 0));

            Assert.IsTrue(result[1].Real.ApproximatelyEquals(0.280776406404415, 1e-10));
            Assert.IsTrue(result[1].Imaginary.ApproximatelyEquals(0, 1e1 - 0));

        }

        [TestMethod]
        public void SystemOfTwoEquationsTest()
        {
            //equation 4x + 5y = 47
            //         2x + 9y = 69

            Vector solution = EquationSolver.SystemOfTwoEquations(4, 5, 2, 9, 47, 69);

            Assert.AreEqual(solution, new Vector(3, 7));
        }
    }
}
