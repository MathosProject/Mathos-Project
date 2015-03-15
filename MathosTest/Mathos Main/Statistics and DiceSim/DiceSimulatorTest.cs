using Mathos.Statistics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Mathos.Testing;

namespace MathosTest
{
    [TestClass]
    public class DiceSimulatorTest
    {
        [TestMethod]
        public void TestRoll6Dice()
        {
            const int numDice = 6;
            var d = new DiceSimulator(numDice);
            var p = d.ToString();
            
            System.Diagnostics.Trace.TraceInformation(p);
            //testing indexer
            System.Diagnostics.Trace.TraceInformation(d[1] + " " + d[2] +" " + d[3]);
            
            var sum = d.SumDiceRoll();
            Assert.IsTrue(sum <= numDice * 6);

            var max = d.MaxDiceRoll();
            Assert.IsTrue(max <=  6);
        }

        [TestMethod]
        public void DiceDiff()
        {
            var d = new DiceSimulator(2);
            int iter = 250000;

            double averageTime = BenchmarkUtil.Benchmark(() => d.DiffDiceRoll(), iter);

            System.Diagnostics.Debug.WriteLine("DiceDiffExecution time: " +averageTime.ToString() + "ms");
            
            

        }
    }
}
