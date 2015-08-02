/* under development */
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mathos.Statistics
{
    /// <summary>
    /// 
    /// </summary>
    public class NumberList
    {
        private readonly List<decimal> _content = new List<decimal>();

        /// <summary>
        /// Add number to content
        /// </summary>
        /// <param name="number"></param>
        public void Add(decimal number)
        {
            _content.Add(number);
        }
    }

    /// <summary>
    /// Extension methods that should faciliate the way we work with statistics
    /// </summary>
    public static class StatisticalProcedures
    {
        /// <summary>
        /// Calculates the mean of a given list
        /// </summary>
        /// <param name="list">A list of numbers</param>
        /// <returns>Returns the mean value</returns>
        public static decimal Mean(this List<decimal> list)
        {
            decimal result;

            try
            {
                result = list.Average();
            }
            catch
            {
                result = 0;
            }
            
            return result;
        }

        /// <summary>
        /// Calculates the mode of a given list
        /// </summary>
        /// <param name="list">A list of numbers</param>
        /// <returns>Returns a list of modes</returns>
        /// <exception cref="ArgumentNullException">An item in <paramref name="list" /> is null.</exception>
        /// <exception cref="InvalidOperationException">The default comparer <see cref="P:System.Collections.Generic.Comparer`1.Default" /> cannot find an implementation of the <see cref="T:System.IComparable`1" /> generic interface or the <see cref="T:System.IComparable" /> interface for type <see cref="decimal" />.</exception>
        public static List<decimal> Mode(this List<decimal> list)
        {
            var dicList = new Dictionary<decimal, int>();

            int value;

            foreach (var d in list.Where(d => !dicList.TryGetValue(d, out value)))
                dicList[d] = 1;

            var listOfModes = new List<decimal>();
            decimal currentRepeatCount = 0;

            foreach (var k in dicList)
            {
                if (k.Value > currentRepeatCount)
                {
                    listOfModes.Clear();
                    listOfModes.Add(k.Key);
                    currentRepeatCount = k.Value;
                }
                else if (k.Value == currentRepeatCount)
                    listOfModes.Add(k.Key);
            }

            return SortList(listOfModes);
        }

        /// <summary>
        /// Calculates the median of a given list
        /// </summary>
        /// <param name="list">A list of numbers</param>
        /// <returns>Returns the median</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="InvalidOperationException">The default comparer <see cref="P:System.Collections.Generic.Comparer`1.Default" /> cannot find an implementation of the <see cref="T:System.IComparable`1" /> generic interface or the <see cref="T:System.IComparable" /> interface for type <see cref="decimal" />.</exception>
        public static decimal Median(this List<decimal> list)
        {
            var listSorted = SortList(list);
            var listLength = listSorted.Count;

            if (listLength == 0)
                return 0;

            if (0 != listLength%2)
                return listSorted[((listLength + 1)/2) - 1];
            
            var leftMedian = listSorted[(listLength / 2) - 1]; //subtracting 1 accomdates 0-based index
            var rightMedian = listSorted[(listLength / 2)];
                
            return (leftMedian + rightMedian) / 2;
        }

        /// <summary>
        /// Calculates the variance of a given list
        /// </summary>
        /// <param name="list">A list of numbers</param>
        /// <returns>Returns the variance</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="OverflowException">The sum is larger than <see cref="F:System.Decimal.MaxValue" />.</exception>
        public static decimal Variance(this List<decimal> list)
        {
            var meanOfList = Mean(list);
            var listOfMeanDifferencesSquared = list.Select(d => (d - meanOfList)*(d - meanOfList)).ToList();

            return SumOfListElements(listOfMeanDifferencesSquared) / (listOfMeanDifferencesSquared.Count - 1);
        }

        /// <summary>
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="OverflowException">The sum is larger than <see cref="F:System.Decimal.MaxValue" />.</exception>
        public static decimal StandardDeviation(this List<decimal> list)
        {
            var variance = Variance(list);
            
            return (decimal)Math.Sqrt((double)variance);
        }

        /// <summary>
        /// Computes the standard error of the mean, given a list
        /// </summary>
        /// <param name="list"></param>
        /// <returns>Returns the standard error of a mean</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="OverflowException">The number of elements in <paramref name="list" /> is larger than <see cref="F:System.Int32.MaxValue" />.</exception>
        public static decimal StandardError(this List<decimal> list)
        {
            return list.Any() ? (decimal) (Math.Sqrt((double) Variance(list))/Math.Sqrt(list.Count())) : 0;
        }

        /// <summary>
        /// Calculates the geometric mean of a given list
        /// </summary>
        /// <param name="list">A list of numbers</param>
        /// <returns>Returns the geometric mean</returns>
        /// <exception cref="ArgumentNullException"><paramref name="list" /> is null.</exception>
        public static decimal GeometricMean(this List<decimal> list)
        {
            return list.Count > 0 ? (decimal) Math.Pow((double) ProductOfListElements(list), 1/(double) list.Count) : 0;
        }

        /// <summary>
        /// Calculates the harmonic mean given a list
        /// </summary>
        /// <param name="list">A list of numbers</param>
        /// <returns>Returns the harmonic mean</returns>
        /// <exception cref="ArgumentNullException"><paramref name="list" /> is null.</exception>
        /// <exception cref="OverflowException">The sum is larger than <see cref="F:System.Decimal.MaxValue" />.</exception>
        public static decimal HarmonicMean(this List<decimal> list)
        {
            return list.Count > 0 ? list.Count/SumOfReciprocalsOfListElements(list) : 0;
        }

        /// <summary>
        /// Calculates the root rean rquare (RMS) value of a given list
        /// </summary>
        /// <param name="list">A list of numbers</param>
        /// <returns>Returns the root mean square(RMS) value</returns>
        public static decimal RootMeanSquare(this List<decimal> list)
        {
            try
            {
                double listCount = list.Count;
                var listOfSquares = list.Select(d => Math.Pow((double) d, 2)).ToList();

                return (decimal)Math.Sqrt((1 / listCount) * listOfSquares.Sum());
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Calculates the range of a given list (max value minus min value)
        /// </summary>
        /// <param name="list">A list of numbers</param>
        /// <returns>Returns the range value</returns>
        public static decimal Range(this List<decimal> list)
        {
            try
            {
                return list.Max() - list.Min();
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Computes the range between the lower and upper quartile
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="InvalidOperationException"><paramref name="list" /> contains no elements.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="list" /> is null.</exception>
        /// <exception cref="OverflowException">The number of elements in <paramref name="list" /> is larger than <see cref="F:System.Int32.MaxValue" />.</exception>
        public static decimal InterQuartileRange(this List<decimal> list)
        {
            return UpperQuartile(list) - LowerQuartile(list);
        }

        /// <summary>
        /// Calculates the max number given a list
        /// </summary>
        /// <param name="list">A list of numbers</param>
        /// <returns>Returns the max number</returns>
        public static decimal MaxNumberInList(this List<decimal> list)
        {
            try
            {
                return list.Max();
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Calculates the min value given a list
        /// </summary>
        /// <param name="list">A list of numbers</param>
        /// <returns>Returns the min value</returns>
        public static decimal MinNumberInList(this List<decimal> list)
        {
            try
            {
                return list.Min();
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Sorts a list
        /// </summary>
        /// <param name="list">A list of numbers</param>
        /// <returns>Returns a sorted list</returns>
        /// <exception cref="InvalidOperationException">The default comparer <see cref="P:System.Collections.Generic.Comparer`1.Default" /> cannot find an implementation of the <see cref="T:System.IComparable`1" /> generic interface or the <see cref="T:System.IComparable" /> interface for type <see cref="decimal" />.</exception>
        public static List<decimal> SortList(this List<decimal> list)
        {
            list.Sort();

            return list;
        }

        /// <summary>
        /// Calculates the sum of list elements
        /// </summary>
        /// <param name="list">A list of numbers</param>
        /// <returns>Returns the sum of list elements</returns>
        /// <exception cref="ArgumentNullException"><paramref name="list" /> is null.</exception>
        /// <exception cref="OverflowException">The sum is larger than <see cref="F:System.Decimal.MaxValue" />.</exception>
        public static decimal SumOfListElements(this List<decimal> list)
        {
            return list.Sum();
        }

        /// <summary>
        /// Calculates the product of list items
        /// </summary>
        /// <param name="list">A list of numbers</param>
        /// <returns>Returns the product of list items</returns>
        /// <exception cref="ArgumentNullException"><paramref name="list" /> is null.</exception>
        public static decimal ProductOfListElements(this List<decimal> list)
        {
            return list.Count > 0 ? list.Aggregate<decimal, decimal>(1, (current, d) => current*d) : 0;
        }

        /// <summary>
        /// Calculates the sum of reciprocals of list elements
        /// </summary>
        /// <param name="list">A list of numbers</param>
        /// <returns>Returns the sum of reciprocals of list elements</returns>
        /// <exception cref="ArgumentNullException"><paramref name="list" /> is null.</exception>
        /// <exception cref="OverflowException">The sum is larger than <see cref="F:System.Decimal.MaxValue" />.</exception>
        public static decimal SumOfReciprocalsOfListElements(this List<decimal> list)
        {
            return list.Count > 0 ? list.Sum(d => 1/d) : 0;
        }

        /// <summary>
        /// Calculates a percentile using the nearest rank method
        /// </summary>
        /// <param name="list">List of numbers to calculate the percentile from</param>
        /// <param name="p">Percentile to calculate, ranging from zero to one</param>
        /// <returns>Percentile if the list has elements and p is between 0 and 1, otherwise returns zero</returns>
        /// <exception cref="ArgumentNullException"><paramref name="list" /> is null.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="list" /> contains no elements.</exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="OverflowException">The number of elements in <paramref name="list" /> is larger than <see cref="F:System.Int32.MaxValue" />.</exception>
        public static decimal Percentile(this List<decimal> list, double p)
        {
            if (p < 0 || p > 1 || !list.Any())
                return 0;

            if (Math.Abs(p - 1) < 0)
                return list.Max();
            if (Math.Abs(p) > 0)
                return list.Min();
            
            list.Sort();

            var rank = (int)Math.Round(p * list.Count() + 0.5, 0, MidpointRounding.AwayFromZero);

            return list.ElementAt(rank - 1);
        }

        /// <summary>
        /// Calculates the 25th percentile
        /// </summary>
        /// <param name="list">A list of numbers</param>
        /// <returns>Returns the 25th percentile</returns>
        /// <exception cref="ArgumentNullException"><paramref name="list" /> is null.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="list" /> contains no elements.</exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="OverflowException">The number of elements in <paramref name="list" /> is larger than <see cref="F:System.Int32.MaxValue" />.</exception>
        public static decimal LowerQuartile(this List<decimal> list)
        {
            return Percentile(list, 0.25);
        }

        /// <summary>
        /// Calculates the 75th percentile
        /// </summary>
        /// <param name="list">A list of numbers</param>
        /// <returns>Returns the 75th percentile</returns>
        /// <exception cref="ArgumentNullException"><paramref name="list" /> is null.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="list" /> contains no elements.</exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="OverflowException">The number of elements in <paramref name="list" /> is larger than <see cref="F:System.Int32.MaxValue" />.</exception>
        public static decimal UpperQuartile(this List<decimal> list)
        {
            return Percentile(list, 0.75);
        }

        /// <summary>
        /// Computes the Pearson product-moment correlation coefficient for a sample
        /// </summary>
        /// <param name="x">A list of numbers</param>
        /// <param name="y">A list of numbers</param>
        /// <returns>Returns the Pearson product-mean correlation coefficient of a sample</returns>
        /// <remarks>An ArgumentException will be thrown if x and y are of different size</remarks>
        /// <exception cref="ArgumentNullException">Either <paramref name="x" /> or <paramref name="y"/> is null.</exception>
        /// <exception cref="OverflowException">Either the number of elements in <paramref name="x" /> or <paramref name="y" /> is larger than <see cref="F:System.Int32.MaxValue" />.</exception>
        /// <exception cref="ArgumentException">This method expects the x and y lists to be of equal size</exception>
        /// <exception cref="InvalidOperationException">Either <paramref name="x" /> or <paramref name="y"/> contains no elements.</exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static decimal PearsonR(this List<decimal> x, List<decimal> y)
        {
            if (x.Count() != y.Count())
                throw new ArgumentException("This method expects the x and y lists to be of equal size");
            if (!x.Any())
                return 0;

            decimal xMean = x.Average(), yMean = y.Average();
            decimal covariance = 0, xVariance = 0, yVariance = 0;

            for (var i = 0; i < x.Count(); i++)
            {
                covariance += (x[i] - xMean) * (y[i] - yMean);
                xVariance += (x[i] - xMean) * (x[i] - xMean);
                yVariance += (y[i] - yMean) * (y[i] - yMean);
            }

            return covariance / ((decimal)Math.Sqrt((double)xVariance) * (decimal)Math.Sqrt((double)yVariance));
        }

        /// <summary>
        /// Calculate the number of permutations
        /// </summary>
        /// <param name="sizeOfList">The size of the list</param>
        /// <param name="sizeOfPermutations">The size of permutations</param>
        /// <returns>Returns the number of permutations</returns>
        /// <remarks>The size of the list and permutations should both be positive integers, and "r" less than or equal to "n", for Permutation and Combination.</remarks>
        public static long NumberOfPermutations(long sizeOfList, long sizeOfPermutations)
        {
            if (sizeOfPermutations >= sizeOfList) return 0;
            
            var factN = Arithmetic.Numbers.Get.FactorialBigInteger(sizeOfList);
            var factNMinR = Arithmetic.Numbers.Get.FactorialBigInteger(sizeOfList - sizeOfPermutations);
            
            return (long)(factN / factNMinR);
        }

        /// <summary>
        /// Calculates the number of permutations 
        /// </summary>
        /// <param name="sizeOfList">The size of the list</param>
        /// <param name="sizeOfCombinations">The size of combinations</param>
        /// <returns>Returns the number of permutations</returns>
        public static long NumberOfCombinations(long sizeOfList, long sizeOfCombinations)
        {
            if (sizeOfCombinations >= sizeOfList) return 0;
            
            var permutations = NumberOfPermutations(sizeOfList, sizeOfCombinations);
            var factR = Arithmetic.Numbers.Get.FactorialBigInteger(sizeOfCombinations);

            return permutations / (long)factR;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public static class LinearModels
    {
        /// <summary>
        /// 
        /// </summary>
        public class LinearRegressionResults
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="intercept"></param>
            /// <param name="b"></param>
            /// <param name="r"></param>
            public LinearRegressionResults(decimal intercept, decimal b, decimal r)
            {
                Intercept = intercept;
                B = b;
                R = r;
                R2 = r * r;
            }

            /// <summary>
            /// Gets the results as a string.
            /// </summary>
            /// <returns></returns>
            /// <exception cref="ArgumentNullException"></exception>
            /// <exception cref="FormatException">The index of a format item is not zero or one.</exception>
            public override string ToString()
            {
                return string.Format("y={0}+{1}x", Intercept, B);
            }

            /// <summary>
            /// Predicts the y-term given an x value.
            /// </summary>
            /// <param name="x"></param>
            /// <returns></returns>
            public decimal Predict(decimal x)
            {
                return Intercept + B * x;
            }

            /// <summary>
            /// Predicts the y-term given a list of x values.
            /// </summary>
            /// <param name="x"></param>
            /// <returns></returns>
            /// <exception cref="ArgumentOutOfRangeException"></exception>
            /// <exception cref="ArgumentNullException"><paramref name="x" /> is null.</exception>
            /// <exception cref="OverflowException">The number of elements in <paramref name="x" /> is larger than <see cref="F:System.Int32.MaxValue" />.</exception>
            public List<decimal> Predict(List<decimal> x)
            {
                var predictedValues = new List<decimal>(x.Count());

                for (var i = 0; i < x.Count; i++)
                    predictedValues[i] = Intercept + B * x[i];

                return predictedValues;
            }

            /// <summary>
            /// Intercept for the linear regression model
            /// </summary>
            public readonly decimal Intercept;
            /// <summary>
            /// Regression coefficient
            /// </summary>
            public readonly decimal B;
            /// <summary>
            /// R value for this model
            /// </summary>
            public readonly decimal R;
            /// <summary>
            /// R-square value for this model
            /// </summary>
            public readonly decimal R2;
        }

        /// <summary>
        /// Computes simple linear regression
        /// </summary>
        /// <param name="x">independent variable</param>
        /// <param name="y">dependent variable</param>
        /// <returns>regression results if x and y have elements, otherwise returns null</returns>
        /// <remarks>An ArgumentException will be thrown if x and y are of different size</remarks>
        /// <exception cref="ArgumentNullException">Either <paramref name="x" /> or <paramref name="y"/> is null.</exception>
        /// <exception cref="OverflowException">The number of elements in either <paramref name="x" /> or <paramref name="y"/> is larger than <see cref="F:System.Int32.MaxValue" />.</exception>
        /// <exception cref="ArgumentException">This method expects the x and y lists to be of equal size</exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="InvalidOperationException">Either <paramref name="x" /> or <paramref name="y" /> contains no elements.</exception>
        public static LinearRegressionResults LinearRegression(List<decimal> x, List<decimal> y)
        {
            if (x.Count() != y.Count())
                throw new ArgumentException("This method expects the x and y lists to be of equal size");
            if (!x.Any())
                return null;

            decimal sX = 0;
            decimal sXx = 0;
            decimal sY = 0;
            decimal sXy = 0;

            var n = x.Count();

            for (var i = 0; i < n; i++)
            {
                sX += x[i];
                sXx += x[i] * x[i];
                sY += y[i];
                sXy += x[i] * y[i];
            }

            var tmpLeft = ((decimal) 1/n);
            var tmpRight = ((decimal) 1/n);
            var b = (n * sXy - sX * sY) / (n * sXx - sX * sX);
            var a = tmpLeft * sY - b * tmpRight * sX;

            var predictedValues = new List<decimal>(n);
            
            predictedValues.AddRange(x.Select(c => a + b*c));

            var r = y.PearsonR(predictedValues);

            return new LinearRegressionResults(a, b, r);
        }
    }
}
