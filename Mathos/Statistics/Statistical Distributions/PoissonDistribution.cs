using System;
using Mathos.Arithmetic.Numbers;

namespace Mathos.Statistics
{
    /// <summary>
    /// 
    /// </summary>
    public static class PoissonDistribution
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="poissonParameter"></param>
        /// <param name="numberOfOccurences"></param>
        /// <returns></returns>
        public static decimal ProbabilityMassFunction(double poissonParameter, long numberOfOccurences)
        {
            if (numberOfOccurences < 0 || !(poissonParameter > 0)) return 0;
            
            var lambdaToK = Math.Pow(poissonParameter, numberOfOccurences);
            var kFactRec = Get.Factorial(numberOfOccurences);
            var eToNegLambda = Math.Pow(Math.E, -poissonParameter);

            return (decimal)(lambdaToK * ((double)1 / kFactRec) * eToNegLambda);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="poissonParameter"></param>
        /// <param name="numberOfOccurences"></param>
        /// <returns></returns>
        public static decimal CumulativeDistributionFunction(double poissonParameter, long numberOfOccurences)
        {
            var sum = 0.0;
            var eToLambda = Math.Pow(Math.E, -poissonParameter);

            for (var i = 0; i <= numberOfOccurences; i++)
            {
                sum += Math.Pow(poissonParameter, i) / (double)Get.FactorialBigInteger(i);
            }

            return (decimal)(eToLambda * sum);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="poissonParameter"></param>
        /// <returns></returns>
        public static decimal Mean(double poissonParameter)
        {
            return (decimal)poissonParameter;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="poissonParameter"></param>
        /// <returns></returns>
        public static decimal Variance(double poissonParameter)
        {
            return Mean(poissonParameter);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="poissonParameter"></param>
        /// <returns></returns>
        public static decimal StandardDeviation(double poissonParameter)
        {
            return (decimal)Math.Sqrt((double)Variance(poissonParameter));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="poissonParameter"></param>
        /// <returns></returns>
        public static decimal Skewness(double poissonParameter)
        {
            return (decimal)Math.Pow(poissonParameter, -.5);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="poissonParameter"></param>
        /// <returns></returns>
        public static decimal ExcessKurtosis(double poissonParameter)
        {
            return (decimal)(1 / poissonParameter);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="poissonParameter"></param>
        /// <param name="variableT"></param>
        /// <returns></returns>
        public static decimal MomentGeneratingFunction(double poissonParameter, double variableT)
        {
            var eTMin1 = Math.Pow(Math.E, variableT) - 1;

            return (decimal)Math.Pow(Math.E, poissonParameter * eTMin1);
        }
    }
}
