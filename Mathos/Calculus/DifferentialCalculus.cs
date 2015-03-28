using System;

namespace Mathos.Calculus
{
    /// <summary>
    /// This class provides you with tools for calculations of rates of changes.
    /// </summary>
    public static class DifferentialCalculus
    {
        //add more documentation...
        /// <summary>
        /// Calculates the first derivative given a function and an x coordinate
        /// </summary>
        /// <param name="function">The function</param>
        /// <param name="xPoint">The x coordinate</param>
        /// <returns>Returns the first derivative</returns>
        public static double FirstDerivative(Func<double,double> function, double xPoint, double h= 1e-14)
        {
            //const double h = 0.0000000000001M;

            return (function(xPoint + h) - function(xPoint)) / h;

            //use parser to parse string expressions
        }

        /// <summary>
        /// Calculates the first derivative given a multivariable function and a specific set of variables (input parameters).
        /// </summary>
        /// <param name="function">The function</param>
        ///         /// <param name="withRespectTo">The index of the point in "points" variable that the derivative should be differenetiated with resepect to.</param>
        /// <param name="points">The input parameters of the multivariable function.</param>
        /// <returns>Returns the first derivative</returns>
        public static decimal FirstDerivative(Func<decimal[], decimal> function, int withRespectTo ,  params decimal[] points)
        {
            const decimal h = 0.0000000000001M;

            var value1 = function(points);

            points[withRespectTo] += h;
            
            return (function(points) - value1) / h;
        }

        /// <summary>
        /// Calculates the second derivative given a function and an x coordinate
        /// </summary>
        /// <param name="function">The function</param>
        /// <param name="xPoint">The x coordinate</param>
        /// <returns>Returns the second derivative</returns>
        public static decimal SecondDerivative(Func<decimal, decimal> function, decimal xPoint)
        {
            const decimal h = 0.0000000000001M;

            return (function(xPoint +h) - 2*function(xPoint) + function(xPoint-h) )/(decimal.Multiply(h,h));
        }

        /// <summary>
        /// Calculates the second derivative given a multivariable function and a specific set of variables (input parameters).
        /// </summary>
        /// <param name="function">The function</param>
        /// <param name="withRespectTo">The index of the point in "points" variable that the derivative should be differenetiated with resepect to.</param>
        /// <param name="points">The input parameters of the multivariable function.</param>
        /// <returns>Returns the second derivative</returns>
        public static decimal SecondDerivative(Func<decimal[], decimal> function, int withRespectTo , params decimal [] points)
        {
            const decimal h = 0.0000000000001M;

            var xPoint = points[withRespectTo];
            var value1 = function(points);

            points [withRespectTo] = xPoint-h;
            
            var value2 = function(points);

            points[withRespectTo] = xPoint + h;

            return (function(points) - 2 * value1 + value2) / (decimal.Multiply(h, h));
        }
    }
}
