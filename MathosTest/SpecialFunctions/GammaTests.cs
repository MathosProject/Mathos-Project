using System;
using System.Collections.Generic;
using System.Linq;
using Mathos.Arithmetic.Numbers;
using Mathos.SpecialFunctions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MathosTest.Mathos_Main.SpecialFunctions
{
    [TestClass]
    public class GammaTests
    {
        const double EPS = 1e-7;
        private bool AreApproximatelyEqual(double d1, double d2)
        {
            return Math.Abs(d1 - d2) < EPS;
        }

        private bool IsApproximatelyZero(double d)
        {
            return Math.Abs(d) < EPS;
        }
        [TestMethod]
        public void Test_Gamma_Of_Valid_Values()
        {
            Dictionary<double, double> expected = new Dictionary<double, double> {
                {1,1},
                {Math.PI, 2.288037796},
                {Math.E, 1.567468255},
                {-1.5,2.363271801}
            };

            //foreach (var item in expected)
            //{
            //    double actual = GammaRelated.Gamma(item.Key);
            //    Assert.IsTrue(AreApproximatelyEqual(item.Value, actual));
            //}

            Assert.IsTrue(
                expected.All(x =>
                    AreApproximatelyEqual(x.Value, GammaRelated.Gamma(x.Key))
                    )
                    );

            Assert.IsTrue(
                AreApproximatelyEqual(
                GammaRelated.Gamma(Math.PI + 1),
                Math.PI * GammaRelated.Gamma(Math.PI)
                )
                );
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Test_Invalid_Values()
        {
            GammaRelated.LogOfFactorial(-1);
        }

        [TestMethod]
        public void Test_Log_Of_Factorial()
        {
            Dictionary<int, long> factorials = new Dictionary<int, long>();
            for (int i = 0; i < 20; i++)
            {
                factorials.Add(i,
                    Get.Factorial(i));
            }

            Assert.IsTrue(
                factorials.All(x =>
                    AreApproximatelyEqual(
                    Math.Log(x.Value),
                    GammaRelated.LogOfFactorial(x.Key))
                    )
                    );
        }
    }
}
