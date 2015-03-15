using System;
using System.Numerics;

namespace Mathos.Calculus
{
    // Missing functions in Math class
    // functions of real variable
    /// <summary>
    /// 
    /// </summary>
    public static partial class Elementary
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="z"></param>
        /// <returns></returns>
        public static Complex Coth(Complex z)
        {
            return Complex.Reciprocal(Complex.Tanh(z));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="z"></param>
        /// <returns></returns>
        public static Complex Cot(Complex z)
        {
            return Complex.Reciprocal(Complex.Tan(z));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static Complex Log(Complex number)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static Complex Exp(Complex number)
        {
            throw new NotImplementedException();
        }

        // other functions

        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static double LogOfAbs(Complex number)
        {
            var y = Math.Abs(number.Imaginary);
            var x = Math.Abs(number.Real);
            var max = x;
            
            double u;

            if (x >= y)
                u = y/x;
            else
            {
                max = y;
                u = x/y;
            }

            return Math.Log(max) + 0.5 * LogOfOnePlusX(u * u);
        }
    }
}
