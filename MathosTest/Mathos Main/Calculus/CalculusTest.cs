using System;
using Mathos.Calculus;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MathosTest.Calculus
{
    [TestClass]
    public class CalculusTest
    {

        [TestMethod]
        public void IversonTest()
        {
            //FiniteCalculus.SumWithRule(((x)=> 3x), ((y) => 3y < 10), 0, 10000);

            var result = FiniteCalculus.SumWithRule(x=> x*x, y => y*y < 8, 0, 1000);

            Assert.AreEqual(result, 5);
        }
        
        [TestMethod]
        public void FirstDerivative()
        {
            var derivative = DifferentialCalculus.FirstDerivative(x => (double)3.2M * x * x, 1.0);

            Assert.IsTrue(Math.Abs(derivative - (double)6.40000000000032M) < 1);
            //System.Diagnostics.Debug.WriteLine(derivative);
        }

        [TestMethod]
        public void FirstDerivativeWithSeveralVariables()
        {
            decimal derivative = DifferentialCalculus.FirstDerivative(x => 8*x[0]+x[1], 0,1,1);
            Assert.IsTrue(derivative == 8);
            //System.Diagnostics.Debug.WriteLine(derivative);
        }

        [TestMethod]
        public void FirstDerivativeWithSeveralVariables2()
        {
            decimal derivative = DifferentialCalculus.FirstDerivative(x => 8 * x[0] + x[0] * x[1],0, 1, 1);
            Assert.IsTrue(derivative == 9);
            //System.Diagnostics.Debug.WriteLine(derivative);
        }


        [TestMethod]
        public void SecondDerivative()
        {
            decimal derivative = DifferentialCalculus.SecondDerivative(x => 3 * x * x*x, 2);
            
            Assert.IsTrue(derivative == 36);
            //System.Diagnostics.Debug.WriteLine(derivative);
        }

        [TestMethod]
        public void SecondDerivative2()
        {
            decimal derivative = DifferentialCalculus.SecondDerivative(x => 3 * x[0] * x[0] * x[0] + x[1] * x[0] * x[0],0, 1, 2);

            Assert.IsTrue(derivative == 22);
            //System.Diagnostics.Debug.WriteLine(derivative);
        }



        [TestMethod]
        public void Integration()
        {
            //System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
            //timer.Start();
            double integration = IntegralCalculus.Integrate(x => x * x, 0, 10, IntegralCalculus.IntegrationAlgorithm.RectangleMethod);

            //timer.Stop();

            //System.Diagnostics.Debug.WriteLine(timer.ElapsedMilliseconds);
            ////Assert.IsTrue(derivative == 36);
            //System.Diagnostics.Debug.WriteLine(integration);
        }

        [TestMethod]
        public void Integration2()
        {
            //System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
            //timer.Start();
            double integration = IntegralCalculus.Integrate(x => x*x, 0, 10, IntegralCalculus.IntegrationAlgorithm.TrapezoidalRule);


            double integral = IntegralCalculus.Integrate(x => x * x, 0, 10);

            //timer.Stop();

            //System.Diagnostics.Debug.WriteLine(timer.ElapsedMilliseconds);
            ////Assert.IsTrue(derivative == 36);
            //System.Diagnostics.Debug.WriteLine(integration);
        }

        [TestMethod]
        public void Integration3()
        {
            //System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
            //timer.Start();
            double integration = IntegralCalculus.Integrate(x => x * x, 0, 10,IntegralCalculus.IntegrationAlgorithm.SimpsonsRule, 10000);

            //timer.Stop();

            //System.Diagnostics.Debug.WriteLine(timer.ElapsedMilliseconds);
            ////Assert.IsTrue(derivative == 36);
            //System.Diagnostics.Debug.WriteLine(integration);
        
        }
    }
}
