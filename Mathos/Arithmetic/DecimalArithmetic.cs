namespace Mathos.Arithmetic
{
    /// <summary>
    /// 
    /// </summary>
    public static class DecimalArithmetic
    {
        /// <summary>
        /// Calculates the natural logarithm of a given x value
        /// </summary>
        /// <param name="x">The x value</param>
        /// <param name="degreeOfTaylorPolynomial">The degree of accuracy</param>
        /// <returns></returns>
        public static decimal Ln(decimal x, int degreeOfTaylorPolynomial = 1000)
        {
            decimal val = 0;

            if (x < 1 || (-x) < 1 && x <0)
            {
                for (var i = 1; i < degreeOfTaylorPolynomial; i++)
                {
                    decimal vec = i % 2 == 1 ? 1 : -1;

                    vec *= Pow(x - 1, i) / i;

                    val += vec;
                }

            }
            else
            {
                for (var i = 1; i < degreeOfTaylorPolynomial; i++)
                {

                    val += decimal.Divide(1, i) * Pow((x - 1) / x, i);
                }
            }

            return val;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="exp"></param>
        /// <returns></returns>
        public static decimal Pow(decimal x, int exp)
        {
            switch (exp)
            {
                case 0:
                    return 1;
                case 1:
                    return x;
                default:
                {
                    decimal val = 1;

                    for (var i = 0; i < exp; i++)
                    {
                        val *= x;
                    }

                    return val;
                }
            }
        }

        //public static decimal pow(decimal x, decimal exp)
        //{

        //    double[] fact = { 1, 1, 2, 6, 24, 120, 720, 5040, 40320, 362880, 3628800, 39916800, 479001600, 6227020800, 87178291200, 1307674368000, 20922789888000, 355687428096000, 6402373705728000, 121645100408832000, 2432902008176640000, 51090942171709440000d, 1124000727777607680000d };

        //    if (exp == 0)
        //    {
        //        return 1;
        //    }
        //    else if (exp == 1)
        //    {
        //        return x;
        //    }
        //    else if ((exp - decimal.Floor(exp)) != 0)
        //    {
        //        decimal val = 0;

        //        decimal logVal = ln(x);

        //        for (int i = 0; i < 19; i++)
        //        {
        //            decimal nom = pow(exp * x, i); // (decimal)(Math.Pow((double)exp,i)*  Math.Pow( (double)exp * Math.Log(Math.Abs((double)x)),i));
        //            val += nom / (decimal)fact[i];
        //        }

        //        return val;
        //    }
        //    else
        //    {
        //        decimal val = 1;

        //        for (int i = 0; i < exp; i++)
        //        {
        //            val *= x;
        //        }

        //        return val;
        //    }

        //}
    }
}
