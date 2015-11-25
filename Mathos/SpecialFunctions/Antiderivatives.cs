using System;
using System.Numerics;
using Mathos.Calculus;
using Mathos.Arithmetic;

namespace Mathos.SpecialFunctions
{
    /// <summary>
    /// 
    /// </summary>
    public static class Antiderivatives
    {
        /// <summary>
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static double Erf(double x)
        {
            return MathematicalConstants.TwoOverSqrtOfPI * IntegralCalculus.Integrate(t => Math.Pow(Math.E, -(t * t)), 0, x);
        }

        /// <summary>
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static double Erfc(double x)
        {
            return 1 - Erf(x);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="z"></param>
        /// <returns></returns>
        public static Complex Erfi(Complex z)
        {
            throw new NotImplementedException();
        }
    }
}
