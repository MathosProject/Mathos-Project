using System;

namespace Mathos.PreCalculus
{
    /// <summary>
    /// Represents the fibonacci sequence.
    /// </summary>
    public class Fibonacci
    {
        /// <summary>
        /// Gets or sets the initial term.
        /// </summary>
        public int InitialTerm { get; set; }

        /// <summary>
        /// Gets or sets the first term.
        /// </summary>
        public int FirstTerm { get; set; } = 1;

        /// <summary>
        /// The golden ratio.
        /// </summary>
        public double GoldenRatio { get; } = (1 + Math.Sqrt(5)) / 2;

        /// <summary>
        /// Gets the <paramref name="n"/>-th term in the sequence.
        /// </summary>
        /// <param name="n">The term to get.</param>
        /// <returns>The <paramref name="n"/>-th term in the sequence.</returns>
        public int NTerm(int n)
        {
            var fk = 0;

            switch (n)
            {
                case 0:
                    return InitialTerm;
                case 1:
                    return FirstTerm;
            }

            if (n <= 1)
                return 0;
            
            //Fk = Fk_1 + Fk_2 & k>=2
            var k = 2;
            var fk2 = InitialTerm;
            var fk1 = FirstTerm;
           
            while (k <= n)
            {
                fk = fk1 + fk2;
                fk2 = fk1;
                fk1 = fk;
                k++; 
            }

            return fk;
        }

        /// <summary>
        /// Gets the <paramref name="n"/>-th term in the sequence using Binet's formula.
        /// </summary>
        /// <param name="n">The term to get.</param>
        /// <returns>The <paramref name="n"/>-th term in the sequence.</returns>
        public static double BinetFormula(int n)
        {
          return (Math.Pow((1 + Math.Sqrt(5)) / 2, n) - Math.Pow((1 - Math.Sqrt(5)) / 2, n)) / Math.Sqrt(5); 
        }

        /// <summary>
        /// Gets the index of number <paramref name="f"/>.
        /// </summary>
        /// <param name="f">The fibonacci number.</param>
        /// <returns>The index of number <paramref name="f"/>.</returns>
        public int Index(int f)
        {
            var phi = GoldenRatio;
            var n = Math.Log(f*Math.Sqrt(5) + 0.5, phi);

            return Convert.ToInt32(Math.Round(n));
        }

        /// <summary>
        /// Gets the sum of fibonacci numbers from <paramref name="low"/> to <paramref name="up"/>.
        /// </summary>
        /// <param name="low">The lower boundary of the interval</param>
        /// <param name="up">The upper boundary of the interval</param>
        /// <returns>The sum of fibonacci numbers from <paramref name="low"/> to <paramref name="up"/>.</returns>
        public static int Sum(int low, int up)
        {
            var sum = FibMatrix(low, 1, 1, 0, 0);

            while (low + 1 <= up)
            {
                sum += FibMatrix(low + 1, 1, 1, 0, 0);
                low++;
            }

            return sum;
        }

        // http://stackoverflow.com/questions/4357223/finding-the-sum-of-fibonacci-numbers
        private static int FibMatrix(int n, int i, int h, int j, int k)
        {
            while (n > 0)
            {
                int t;

                if (n % 2 == 1)
                {
                    t = j * h;
                    j = i * h + j * k + t;
                    i = i * k + t;
                }

                t = h * h;
                h = 2 * k * h + t;
                k = k * k + t;
                n = n / 2;
            }

            return j;
        }
    }
}

