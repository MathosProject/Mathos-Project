using System;

namespace Mathos.Statistics
{
    /// <summary>
    /// 
    /// </summary>
    public static class HypergeometricDistribution
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="populationSize"></param>
        /// <param name="numberOfSuccessStates"></param>
        /// <param name="numberOfDraws"></param>
        /// <param name="numberOfSuccesses"></param>
        /// <returns></returns>
        public static decimal ProbabilityMassFunction(long populationSize, long numberOfSuccessStates, long numberOfDraws, long numberOfSuccesses)
        {
            if (populationSize <= 0 || numberOfSuccessStates < 0 || numberOfDraws <= 0) return 0;
            
            double mCk = StatisticalProcedures.NumberOfCombinations(numberOfSuccessStates, numberOfSuccesses);
            double nmCnk = StatisticalProcedures.NumberOfCombinations(populationSize - numberOfSuccessStates,
                numberOfDraws - numberOfSuccesses);
            double nCn = StatisticalProcedures.NumberOfCombinations(populationSize, numberOfDraws);

            return (decimal) ((mCk*nmCnk)/nCn);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="populationSize"></param>
        /// <param name="numberOfSuccessStates"></param>
        /// <param name="numberOfDraws"></param>
        /// <returns></returns>
        public static decimal Mean(long populationSize, long numberOfSuccessStates, long numberOfDraws)
        {
            return (decimal)(numberOfDraws * numberOfSuccessStates) / populationSize;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="populationSize"></param>
        /// <param name="numberOfSuccessStates"></param>
        /// <param name="numberOfDraws"></param>
        /// <returns></returns>
        public static decimal Variance(long populationSize, long numberOfSuccessStates, long numberOfDraws)
        {
            decimal n = numberOfDraws;
            decimal m = numberOfSuccessStates;
            decimal n2 = populationSize;

            return n * (m / n2) * (n2 - m) * (1 / n2) * (n2 - n) * (1 / (n2 - 1));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="populationSize"></param>
        /// <param name="numberOfSuccessStates"></param>
        /// <param name="numberOfDraws"></param>
        /// <returns></returns>
        public static decimal StandardDeviation(long populationSize, long numberOfSuccessStates, long numberOfDraws)
        {
            return (decimal)Math.Sqrt((double)Variance(populationSize, numberOfSuccessStates, numberOfDraws));
        }
    }
}
