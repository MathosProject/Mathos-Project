using System;

namespace Mathos.Calculus
{
    /// <summary>
    /// This class provides methods for differential calculus.
    /// </summary>
    public static class DifferentialCalculus
    {
        /// <summary>
        /// Calculates the first derivative given a single-variable <paramref name="function"/> and an <paramref name="xPoint"/>.
        /// </summary>
        /// <param name="function">The function.</param>
        /// <param name="xPoint">The x coordinate.</param>
        /// <param name="h"></param>
        /// <returns>Returns the first derivative given a single-variable <paramref name="function"/> and an <paramref name="xPoint"/>.</returns>
        public static double FirstDerivative(Func<double,double> function, double xPoint, double h = 1e-14)
        {
            return (function(xPoint + h) - function(xPoint - h))/(2*h);
        }

        /// <summary>
        /// Calculates the first derivative given a multi-variable <paramref name="function"/>, index <paramref name="withRespectTo"/>, and a set of <paramref name="points"/>.
        /// </summary>
        /// <param name="function">The function.</param>
        /// <param name="withRespectTo">The index of the point in <paramref name="points"/> that the derivative should be differenetiated with resepect to.</param>
        /// <param name="points">The input parameters for the multi-variable function.</param>
        /// <returns>Returns the first derivative given a multi-variable <paramref name="function"/>, <paramref name="withRespectTo"/>, and a set of <paramref name="points"/>.</returns>
        public static decimal FirstDerivative(Func<decimal[], decimal> function, int withRespectTo, params decimal[] points)
        {
            const decimal h = 0.0000000000001M;

            var value1 = function(points);

            points[withRespectTo] += h;
            
            return (function(points) - value1) / h;
        }

        /// <summary>
        /// Calculates the second derivative given a single-variable <paramref name="function"/> and an <paramref name="xPoint"/>.
        /// </summary>
        /// <param name="function">The function.</param>
        /// <param name="xPoint">The x coordinate.</param>
        /// <returns>Returns the second derivative given a single-variable <paramref name="function"/> and an <paramref name="xPoint"/>.</returns>
        public static decimal SecondDerivative(Func<decimal, decimal> function, decimal xPoint)
        {
            const decimal h = 0.0000000000001M;

            return (function(xPoint + h) - 2*function(xPoint) + function(xPoint - h))/decimal.Multiply(h, h);
        }

        /// <summary>
        /// Calculates the second derivative given a multi-variable <paramref name="function"/>, index <paramref name="withRespectTo"/>, and a set of <paramref name="points"/>.
        /// </summary>
        /// <param name="function">The function</param>
        /// <param name="withRespectTo">The index of the point in <paramref name="points"/> that the derivative should be differenetiated with resepect to.</param>
        /// <param name="points">The input parameters for the multi-variable function.</param>
        /// <returns>Returns the second derivative given a multi-variable <paramref name="function"/>, index <paramref name="withRespectTo"/>, and a set of <paramref name="points"/>.</returns>
        public static decimal SecondDerivative(Func<decimal[], decimal> function, int withRespectTo, params decimal[] points)
        {
            const decimal h = 0.0000000000001M;

            var xPoint = points[withRespectTo];
            var value1 = function(points);

            points[withRespectTo] = xPoint - h;

            var value2 = function(points);

            points[withRespectTo] = xPoint + h;

            return (function(points) - 2*value1 + value2)/decimal.Multiply(h, h);
        }
    }
}
