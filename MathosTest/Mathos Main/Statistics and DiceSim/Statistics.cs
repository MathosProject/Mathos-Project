using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Mathos.Statistics;
namespace MathosTest
{
    [TestClass]
    public class Statistics
    {
        [TestMethod]
        public void MeanTest()
        {
            Assert.AreEqual(StatisticalProcedures.Mean(Literals.testList), 8.85325m);
            Assert.AreEqual(StatisticalProcedures.Mean(Literals.emptyList), 0);
        }

        [TestMethod]
        public void ModeTest()
        {
            // TODO: Needs to be fixed
            /*var mode = StatisticalProcedures.Mode(Literals.testList);

            for (var i = 0; i < mode.Count; i++)
            {
                var d = mode[i];
                
                Assert.AreEqual(d, Literals.testListModes[i]);
            }*/
        }

        [TestMethod]
        public void MedianTest()
        {
            Assert.AreEqual(StatisticalProcedures.Median(Literals.testList), 3.2535m);
            Assert.AreEqual(StatisticalProcedures.Median(Literals.testListOdd), 3.253m);
            Assert.AreEqual(StatisticalProcedures.Median(Literals.emptyList), 0);
        }

        [TestMethod]
        public void VarianceTest()
        {
            Assert.AreEqual(StatisticalProcedures.Variance(Literals.testList), 78.828212214285714285714285714m);
            Assert.AreEqual(StatisticalProcedures.Variance(Literals.emptyList), 0);
        }

        [TestMethod]
        public void StandardDeviationTest()
        {
            Assert.AreEqual(StatisticalProcedures.StandardDeviation(Literals.testList), 8.87852534007116m);
            Assert.AreEqual(StatisticalProcedures.StandardDeviation(Literals.emptyList), 0);
        }

        [TestMethod]
        public void StandardErrorTest()
        {
            Assert.AreEqual(StatisticalProcedures.StandardError(Literals.testList2), 0.0676113162275986m);
            Assert.AreEqual(StatisticalProcedures.GeometricMean(Literals.emptyList), 0);
        }

        [TestMethod]
        public void GeometricMeanTest()
        {
            Assert.AreEqual(StatisticalProcedures.GeometricMean(Literals.testList), 5.53102373891453m);
            Assert.AreEqual(StatisticalProcedures.GeometricMean(Literals.emptyList), 0);
        }

        [TestMethod]
        public void HarmonicMeanTest()
        {
            Assert.AreEqual(StatisticalProcedures.HarmonicMean(Literals.testListProduct), 4.7368421052631578947368421055m);
            Assert.AreEqual(StatisticalProcedures.GeometricMean(Literals.emptyList), 0);
        }

        [TestMethod]
        public void RootMeanSquareTest()
        {
            Assert.AreEqual(StatisticalProcedures.RootMeanSquare(Literals.testList), 12.1389752965397m);
            Assert.AreEqual(StatisticalProcedures.RootMeanSquare(Literals.emptyList), 0);
        }

        [TestMethod]
        public void RangeTest()
        {
            Assert.AreEqual(StatisticalProcedures.Range(Literals.testList), 21.91m);
            Assert.AreEqual(StatisticalProcedures.Range(Literals.emptyList), 0);
        }

        [TestMethod]
        public void QuartileRangeTest()
        {
            // TODO: Needs to be fixed
            /*Assert.AreEqual(StatisticalProcedures.InterQuartileRange(Literals.testList2), 1.3m);
            Assert.AreEqual(StatisticalProcedures.InterQuartileRange(Literals.emptyList), 0);*/
        }

        [TestMethod]
        public void MaxNumberInListTest()
        {
            Assert.AreEqual(StatisticalProcedures.MaxNumberInList(Literals.testList), 23.91m);
            Assert.AreEqual(StatisticalProcedures.MaxNumberInList(Literals.emptyList), 0);
        }

        [TestMethod]
        public void MinNumberInListTest()
        {
            Assert.AreEqual(StatisticalProcedures.MinNumberInList(Literals.testList), 2);
            Assert.AreEqual(StatisticalProcedures.MinNumberInList(Literals.emptyList), 0);
        }

        [TestMethod]
        public void SortListTest()
        {
            int i = 0;
            foreach (decimal d in StatisticalProcedures.SortList(Literals.testList))
            {
                Assert.AreEqual(d, Literals.testListSorted[i]);
                i++;
            }
        }

        [TestMethod]
        public void SumOfListElementsTest()
        {
            Assert.AreEqual(StatisticalProcedures.SumOfListElements(Literals.testList), 70.826m);
            Assert.AreEqual(StatisticalProcedures.SumOfListElements(Literals.emptyList), 0);
        }

        [TestMethod]
        public void ProductOfListElementsTest()
        {
            Assert.AreEqual(StatisticalProcedures.ProductOfListElements(Literals.testListProduct), 150);
            Assert.AreEqual(StatisticalProcedures.ProductOfListElements(Literals.emptyList), 0);
        }

        [TestMethod]
        public void SumOfReciprocalsOfListElementsTest()
        {
            Assert.AreEqual(StatisticalProcedures.SumOfReciprocalsOfListElements(Literals.testListProduct), 0.6333333333333333333333333333m);
            Assert.AreEqual(StatisticalProcedures.SumOfReciprocalsOfListElements(Literals.emptyList), 0);
        }

        [TestMethod]
        public void PercentileTest()
        {
            // TODO: Needs to be fixed
            /*Assert.AreEqual(StatisticalProcedures.Percentile(Literals.testList2, 0.25), 5.1m);
            Assert.AreEqual(StatisticalProcedures.Percentile(Literals.testList2, 0.75), 6.4m);
            Assert.AreEqual(StatisticalProcedures.Percentile(Literals.testList2, 0.95), 7.3m);
            Assert.AreEqual(StatisticalProcedures.Percentile(Literals.testList, 0.73), 13.6m);
            Assert.AreEqual(StatisticalProcedures.Percentile(Literals.testList, 0.01), 2);
            Assert.AreEqual(StatisticalProcedures.Percentile(Literals.emptyList, 0.5), 0);*/
        }

        [TestMethod]
        public void NumberOfPermutationsTest()
        {
            Assert.AreEqual(StatisticalProcedures.NumberOfPermutations(12, 5), 95040);
            Assert.AreEqual(StatisticalProcedures.NumberOfPermutations(23, 6), 72681840);
            Assert.AreEqual(StatisticalProcedures.NumberOfPermutations(3, 10), 0);
        }

        [TestMethod]
        public void NumberOfCombinationsTest()
        {
            Assert.AreEqual(StatisticalProcedures.NumberOfCombinations(12, 5), 792);
            Assert.AreEqual(StatisticalProcedures.NumberOfCombinations(23, 12), 1352078);
            Assert.AreEqual(StatisticalProcedures.NumberOfCombinations(3, 10), 0);
        }

        private class Literals
        {
            public static List<decimal> testList = new List<decimal>(){ 3.253m, 2, 19.556m, 13.6m, 3.254m, 2, 23.91m, 3.253m };
            public static List<decimal> testList2 = new List<decimal>() { 5m, 6.4m, 6.5m, 6.7m, 6.3m, 4.6m, 6.9m, 6.2m, 5.9m, 4.6m, 6.1m, 6m, 6.5m,
                5.6m, 6.5m, 5.8m, 6.8m, 5.1m, 5.7m, 6.2m, 7.7m, 6.3m, 6.7m, 7.6m, 4.9m, 5.5m, 6.7m, 7m, 6.4m, 6.1m, 4.8m, 5.9m, 5.5m, 6.3m, 6.4m, 5.2m,
                4.9m, 5.4m, 7.9m, 4.4m, 6.7m, 5m, 5.8m, 4.4m, 7.7m, 6.3m, 4.7m, 5.5m, 7.2m, 4.8m, 5.1m, 6.1m, 4.8m, 5m, 5m, 6.1m, 6.4m, 4.3m, 5.8m, 5.1m, 
                6.7m, 6.2m, 4.9m, 5.1m, 5.6m, 5.8m, 5m, 4.6m, 6m, 5.7m, 5.7m, 5m, 7.7m, 6.3m, 5.8m, 5.7m, 7.2m, 5.4m, 5.2m, 7.1m, 6.4m, 6m, 6.3m, 4.9m, 
                5.6m, 5.7m, 5.5m, 4.9m, 7.7m, 6m, 5.4m, 6.6m, 5.2m, 6m, 5m, 4.4m, 5m, 5.5m, 5.8m, 4.7m, 4.6m, 6.9m, 6.2m, 7.4m, 5.9m, 5.1m, 5m, 5.6m, 6m, 
                7.3m, 6.7m, 4.9m, 6.7m, 6.3m, 5.4m, 5.6m, 6.3m, 6.1m, 6.4m, 5.1m, 5.7m, 6.5m, 6.9m, 5.4m, 5.1m, 7.2m, 6.5m, 6.1m, 5.6m, 6.9m, 6.4m, 6.8m, 
                5.5m, 4.8m, 4.8m, 4.5m, 5.7m, 5.7m, 5.1m, 5.5m, 6.6m, 6.8m, 5.4m, 5.1m, 5.2m, 5.8m, 6.7m, 6.3m, 5.3m, 5m };
            public static List<decimal> testListSorted = new List<decimal> { 2, 2, 3.253m, 3.253m, 3.254m, 13.6m, 19.556m, 23.91m };
            public static List<decimal> testListModes = new List<decimal> { 2, 3.253m };
            public static List<decimal> testListProduct = new List<decimal>() { 3, 5, 10 };
            public static List<decimal> testListOdd = new List<decimal> { 3.253m, 2, 19.556m, 13.6m, 3.254m, 2, 23.91m, 3.253m, 2.5m };
            public static List<decimal> emptyList = new List<decimal>();
        }
    }
}
