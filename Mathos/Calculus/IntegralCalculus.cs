﻿using System;

namespace Mathos.Calculus
{
    /// <summary>
    /// This class provides methods for integral calculus.
    /// </summary>
    public static class IntegralCalculus
    {
        /// <summary>
        /// Integral approximation algorithms.
        /// </summary>
        public enum IntegrationAlgorithm
        {
            /// <summary>
            /// Rectangle method.
            /// </summary>
            RectangleMethod,
            /// <summary>
            /// Trapezoidal rule.
            /// </summary>
            TrapezoidalRule,

            /// <summary>
            /// Simpson's rule.
            /// </summary>
            SimpsonsRule
        }

        /// <summary>
        /// Calculates the approximation of an integral given a <paramref name="function"/>, <paramref name="lowerLimit"/>, <paramref name="upperLimit"/>, and an <paramref name="integrationAlgorithm"/>.
        /// </summary>
        /// <param name="function">Assign a function using a lambda expression.</param>
        /// <param name="lowerLimit">Enter the lower limit.</param>
        /// <param name="upperLimit">Enter the upper limit.</param>
        /// <param name="integrationAlgorithm">Specify the integration approximation algorithm. The accuracy depends on the algorithm as well.</param>
        /// <param name="numberOfIntervals">Set the number of intervals. The bigger value, the more accuare approximation. For Simpson's rule, this value should be even.</param>
        /// <returns></returns>
        public static double Integrate(Func<double, double> function, double lowerLimit, double upperLimit, IntegrationAlgorithm integrationAlgorithm = IntegrationAlgorithm.SimpsonsRule, double numberOfIntervals = 100000)
        {
            double sum = 0;

            switch (integrationAlgorithm)
            {
                case IntegrationAlgorithm.RectangleMethod:
                {
                    var sizeOfInterval = ((upperLimit - lowerLimit)/numberOfIntervals);

                    for (var i = 0; i < numberOfIntervals; i++)
                        sum += function(lowerLimit + sizeOfInterval*i)*sizeOfInterval;

                    return sum;
                }
                case IntegrationAlgorithm.TrapezoidalRule:
                {
                    var sizeOfInterval = ((upperLimit - lowerLimit)/numberOfIntervals);

                    sum = function(lowerLimit) + function(upperLimit);

                    for (var i = 1; i < numberOfIntervals; i++)
                        sum += 2*function(lowerLimit + i*sizeOfInterval);

                    return sum*sizeOfInterval/2;
                }
                case IntegrationAlgorithm.SimpsonsRule:
                {
                    var sizeOfInterval = ((upperLimit - lowerLimit)/numberOfIntervals);

                    sum = function(lowerLimit);

                    for (var i = 1; i < numberOfIntervals; i += 2)
                        sum += 4*function(lowerLimit + sizeOfInterval*i);

                    for (var i = 2; i < numberOfIntervals - 1; i += 2)
                        sum += 2*function(lowerLimit + sizeOfInterval*i);

                    sum += function(upperLimit);

                    return sum*sizeOfInterval/3;
                }
                default:
                    return 0;
            }
        }
    }
}
