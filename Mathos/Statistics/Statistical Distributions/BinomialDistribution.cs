using System;

namespace Mathos.Statistics.Statistical_Distributions
{
    /// <summary>
    /// 
    /// </summary>
    public static class BinomialDistribution
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfEvents"></param>
        /// <param name="numberOfSuccesses"></param>
        /// <param name="probabilityOfSuccess"></param>
        /// <returns></returns>
        public static decimal ProbabilityMassFunction(long numberOfEvents, long numberOfSuccesses, double probabilityOfSuccess)
        {
            if (!(probabilityOfSuccess >= 0) || !(probabilityOfSuccess <= 1)) return 0;
            
            var combinations = StatisticalProcedures.NumberOfCombinations(numberOfEvents, numberOfSuccesses);
            var pToR = Math.Pow(probabilityOfSuccess, numberOfSuccesses);
            var oneMinP = 1 - probabilityOfSuccess;
            var nMinR = numberOfEvents - numberOfSuccesses;
            var exp = Math.Pow(oneMinP, nMinR);
                
            return (decimal)(combinations * pToR * exp);
        }

        /// <summary>
        /// Calculates Pr(X lessthan or equal to x), where x is number of successes.
        /// </summary>
        /// <param name="numberOfEvents"></param>
        /// <param name="numberOfSuccesses"></param>
        /// <param name="probabilityOfSuccess"></param>
        /// <returns></returns>
        public static decimal CumulativeDistributionFunction(long numberOfEvents, long numberOfSuccesses, double probabilityOfSuccess)
        {
            double returnValue = 0;

            for (var i = 0; i <= numberOfSuccesses; i++)
            {
                var combinations = StatisticalProcedures.NumberOfCombinations(numberOfEvents, i);
                var probToI = Math.Pow(probabilityOfSuccess, i);
                var oneMinPtoNMinI = Math.Pow(1 - probabilityOfSuccess, numberOfEvents - i);

                returnValue += combinations * probToI * oneMinPtoNMinI;
            }

            return (decimal)returnValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfTrials"></param>
        /// <param name="probabilityOfSuccess"></param>
        /// <returns></returns>
        public static decimal Mean(long numberOfTrials, double probabilityOfSuccess)
        {
            return (decimal)(numberOfTrials * probabilityOfSuccess);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfTrials"></param>
        /// <param name="probabilityOfSuccess"></param>
        /// <returns></returns>
        public static decimal Variance(long numberOfTrials, double probabilityOfSuccess)
        {
            return (Mean(numberOfTrials, probabilityOfSuccess) * (decimal)(1 - probabilityOfSuccess));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfTrials"></param>
        /// <param name="probabilityOfSuccess"></param>
        /// <returns></returns>
        public static decimal StandardDeviation(long numberOfTrials, double probabilityOfSuccess)
        {
            return (decimal)Math.Sqrt((double)Variance(numberOfTrials, probabilityOfSuccess));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfTrials"></param>
        /// <param name="probabilityOfSuccess"></param>
        /// <returns></returns>
        public static decimal Skewness(long numberOfTrials, double probabilityOfSuccess)
        {
            return (decimal)((1 - (2 * probabilityOfSuccess)) / Math.Sqrt((double)Variance(numberOfTrials, probabilityOfSuccess)));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfTrials"></param>
        /// <param name="probabilityOfSuccess"></param>
        /// <returns></returns>
        public static decimal ExcessKurtosis(long numberOfTrials, double probabilityOfSuccess)
        {
            var variance = Variance(numberOfTrials, probabilityOfSuccess);
            
            return ((1 - (6 * variance / numberOfTrials)) / variance);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfTrials"></param>
        /// <param name="probabilityOfSuccess"></param>
        /// <param name="variableT"></param>
        /// <returns></returns>
        public static decimal MomentGeneratingFunction(long numberOfTrials, double probabilityOfSuccess, double variableT)
        {
            return (decimal)Math.Pow((1 - probabilityOfSuccess * (1 - Math.Pow(Math.E, variableT))), numberOfTrials);
        }
    }
}
