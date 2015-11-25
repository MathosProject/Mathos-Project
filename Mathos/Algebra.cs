using System;
using System.Numerics;
using Mathos.Arithmetic;
using Mathos.Notation;

namespace Mathos
{
    /// <summary>
    /// 
    /// </summary>
    public static class EquationSolver
    {
        /// <summary>
        /// Solves a quadratic equation, Ax^2 + Bx + C, where a != 0
        /// </summary>
        /// <param name="a">The first variable.</param>
        /// <param name="b">The second variable.</param>
        /// <param name="c">The third variable.</param>
        /// <returns></returns>
        [Obsolete]
        public static Complex[] QuadraticEquation(double a, double b, double c)
        {
            // only real solutions for the moment
            var discriminant = Math.Pow(b, 2) - 4 * a * c;

            // x1 results wrong value.
            //ComplexNumber x1 = ((ComplexNumber)(-B) + ComplexOperation.Sqrt(discriminant)) / (2 * (ComplexNumber)A);
            //ComplexNumber x2 = (-B - ComplexOperation.Sqrt(discriminant)) / (2 * A);

            //return new ComplexNumber[] { x1, x2 };
            //return new Vector((decimal)x1, (decimal)x2);
            var q = -(b + Math.Sign(b) * ComplexArithmetic.Sqrt(discriminant)) / 2;
            
            return new[] { q / a, c / q };
        }

        /// <summary>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static Complex[] QuadraticEquationEx(double a, double b, double c)
        {
            var discriminant = Math.Pow(b, 2) - 4 * a * c;
            var q = -(b + Math.Sign(b) * ComplexArithmetic.Sqrt(discriminant)) / 2;

            return new[] { q / a, c / q };
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static Complex[] QuadraticEquation(Complex a, Complex b, Complex c)
        {
            var discriminant = b * b - 4 * a * c;
            var x1 = (b * -1 + Complex.Sqrt(discriminant)) / (2 * a);
            var x2 = (b * -1 - Complex.Sqrt(discriminant)) / (2 * a);

            return new[] { x1, x2 };
        }

        /// <summary>
        /// Solves a system of two equations,
        /// Ax + By = E,
        /// Cx + Dy = F
        /// </summary>
        /// <param name="a">A</param>
        /// <param name="b">B</param>
        /// <param name="c">C</param>
        /// <param name="d">D</param>
        /// <param name="e">E</param>
        /// <param name="f">F</param>
        /// <returns></returns>
        public static Vector SystemOfTwoEquations(double a, double b, double c, double d, double e, double f)
        {
            // only real numbers for the moment
            var x = (e * d - f * b) / (a * d - b * c);
            var y = (a * f - e * c) / (a * d - b * c);

            return new Vector(x, y);
        }
    }
}
