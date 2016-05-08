using System;

namespace Mathos.SpecialFunctions
{
    /// <summary>
    /// 
    /// </summary>
    public static class GammaRelated
    {
        // constants used in Lanczos approximation
        // Source : http://my.fit.edu/~gabdo/gamma.txt
        private static readonly double[] Lanczos15 =
        {
            0.99999999999999709182,
            57.156235665862923517,
            -59.597960355475491248,
            14.136097974741747174,
            -0.49191381609762019978,
            .33994649984811888699e-4,
            .46523628927048575665e-4,
            -.98374475304879564677e-4,
            .15808870322491248884e-3,
            -.21026444172410488319e-3,
            .21743961811521264320e-3,
            -.16431810653676389022e-3,
            .84418223983852743293e-4,
            -.26190838401581408670e-4,
            .36899182659531622704e-5
        };

        private const int LanczosCount = 15;
        private const int TableSize = 2000;

        private static readonly double[] LogTable;

        private const double Gam = 607D / 128D;

        // we don't want to recalculate this on each call
        private static readonly double LogPi = Math.Log(Math.PI);
        private static readonly double Log2Pi = Math.Log(Math.PI * 2D);

        static GammaRelated()
        {
            LogTable = new double[TableSize];

            for (var i = 0; i < TableSize; i++)
                LogTable[i] = LogOfGamma(i + 1D);
        }

        /// <summary>
        /// Evaluates gamma(x) by Lanczos approximation, the is has more risk of overflow than LogOfGamma.
        /// </summary>
        /// <param name="x">A non-negative general real number or a non-integer negative number.</param>
        /// <returns>gamma(x)</returns>
        public static double Gamma(double x)
        {
            return Math.Exp(LogOfGamma(x));
        }
        
        /// <summary>
        /// Evaluates natural logarithm of gamma(x) by Lanczos approximation.
        /// </summary>
        /// <param name="x">A non-negative general real number or a non-integer negative number.</param>
        /// <returns>log(gamma(x))</returns>
        public static double LogOfGamma(double x)
        {
            if (x < 0.5)
                return LogPi - Math.Log(Math.Sin(Math.PI * x)) - LogOfGamma(1D - x);

            double sum = 0;
            var z = x - 1D;

            for (var i = LanczosCount - 1; i > 0; i--)
                sum += Lanczos15[i]/(z + i);

            sum += Lanczos15[0];

            var b = z + Gam + 0.5D;

            return 0.5d*Log2Pi + Math.Log(sum) + (z + 0.5d)*Math.Log(b) - b;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static double Beta(double x, double y)
        {
            return Math.Exp(LogOfGamma(x) + LogOfGamma(y) - LogOfGamma(x + y));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static double LogOfFactorial(int n)
        {
            if (n < 0)
                throw new ArgumentOutOfRangeException(nameof(n), "The argument must be non-negative.");
            if ((n == 0) || (n == 1))
                return 0;
            
            return n < TableSize ? LogTable[n] : LogOfGamma(n + 1D);
        }
    }
}
