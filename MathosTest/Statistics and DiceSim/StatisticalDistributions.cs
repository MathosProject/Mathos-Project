using Mathos.Statistics.Statistical_Distributions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MathosTest.Statistics_and_DiceSim
{
    [TestClass]
    public class StatisticalDistributions
    {
        [TestMethod]
        public void BinomialDistributionPMF()
        {
            Assert.AreEqual(BinomialDistribution.ProbabilityMassFunction(10, 5, .3), 0.1029193452m);
        }
        
        [TestMethod]
        public void BinomialDistributionCDF()
        {
            Assert.AreEqual(BinomialDistribution.CumulativeDistributionFunction(10, 5, .3), 0.952651012599999m);
        }

        [TestMethod]
        public void BinomialDistributionMean()
        {
            Assert.AreEqual(BinomialDistribution.Mean(13, .3), 3.9m);
        }

        [TestMethod]
        public void BinomialDistributionVariance()
        {
            Assert.AreEqual(BinomialDistribution.Variance(13, .3), 2.73m);
        }

        [TestMethod]
        public void BinomialDistributionStandardDeviation()
        {
            Assert.AreEqual(BinomialDistribution.StandardDeviation(15, .3), 1.77482393492988m);
        }

        [TestMethod]
        public void BinomialDistributionSkewness()
        {
            Assert.AreEqual(BinomialDistribution.Skewness(15, .3), 0.225374467927604m);
        }

        [TestMethod]
        public void BinomialDistributionExcessKurtosis()
        {
            Assert.AreEqual(BinomialDistribution.ExcessKurtosis(25, .5), -0.08m); 
        }

        [TestMethod]
        public void BinomialDistributionMGF()
        {
            Assert.AreEqual(BinomialDistribution.MomentGeneratingFunction(15, .3, .25), 3.40951455551722m);
        }

        [TestMethod]
        public void PoissonDistributionPMF()
        {
            Assert.AreEqual(PoissonDistribution.ProbabilityMassFunction(10, 7), 0.090079225719216m);
        }

        [TestMethod]
        public void PoissonDistributionCDF()
        {
            Assert.AreEqual(PoissonDistribution.CumulativeDistributionFunction(10, 7), 0.220220646601699m);
        }

        [TestMethod]
        public void PoissonDistributionMean()
        {
            Assert.AreEqual(PoissonDistribution.Mean(10.343434), 10.343434m);
        }

        [TestMethod]
        public void PoissonDistributionVariance()
        {
            Assert.AreEqual(PoissonDistribution.Variance(10.343434), 10.343434m);
        }

        [TestMethod]
        public void PoissonDistributionStandardDeviation()
        {
            Assert.AreEqual(PoissonDistribution.StandardDeviation(25), 5);
        }

        [TestMethod]
        public void PoissonDistributionSkewness()
        {
            Assert.AreEqual(PoissonDistribution.Skewness(10.343434), 0.310933579257802m);
        }

        [TestMethod]
        public void PoissonDistributionExcessKurtosis()
        {
            Assert.AreEqual(PoissonDistribution.ExcessKurtosis(10.343434), 0.0966796907100678m);
        }

        [TestMethod]
        public void PoissonDistributionMGF()
        {
            Assert.AreEqual(PoissonDistribution.MomentGeneratingFunction(10.343434, .25), 18.8742423103652m);
        }

        [TestMethod]
        public void HypergeometricDistributionPMF()
        {
            Assert.AreEqual(HypergeometricDistribution.ProbabilityMassFunction(14, 10, 8, 6), 0.41958041958042m);
        }

        [TestMethod]
        public void HypergemoetricDistributionMean()
        {
            Assert.AreEqual(HypergeometricDistribution.Mean(14, 10, 8), 5.7142857142857142857142857143m);
        }

        [TestMethod]
        public void HypergeometricDistributionVariance()
        {
            Assert.AreEqual(HypergeometricDistribution.Variance(14, 10, 8), 0.7535321821036106750392464673m);
        }

        [TestMethod]
        public void HypergeometricDistributionStandardDeviation()
        {
            Assert.AreEqual(HypergeometricDistribution.StandardDeviation(14, 10, 8), 0.868062314643143m);
        }
    }
}
