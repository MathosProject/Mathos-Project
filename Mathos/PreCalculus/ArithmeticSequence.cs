namespace Mathos.PreCalculus
{
    /// <summary>
    /// Represents an arithmetic sequence.
    /// </summary>
    public class ArithmeticSequence
    {
        /// <summary>
        /// Initializes a sequence with both an initial term and a common difference of 0.
        /// </summary>
        public ArithmeticSequence() : this(0, 0)
        {
        }

        /// <summary>
        /// Initializes a sequence with an <paramref name="initialTerm"/> and a <paramref name="commonDifference"/>.
        /// </summary>
        /// <param name="initialTerm">The initial term.</param>
        /// <param name="commonDifference">The common difference.</param>
        public ArithmeticSequence(double initialTerm, double commonDifference)
        {
            InitialTerm = initialTerm;
            CommonDifference = commonDifference;
        }

        /// <summary>
        /// Gets or sets the initial term.
        /// </summary>
        public double InitialTerm { get; set; }

        /// <summary>
        /// Gets or sets the common difference.
        /// </summary>
        public double CommonDifference { get; set; }

        /// <summary>
        /// Gets the <paramref name="n"/>-th term in the sequence.
        /// </summary>
        /// <param name="n">The term to get.</param>
        /// <returns>The <paramref name="n"/>-th term in the sequence.</returns>
        public double NTerm(int n)
        {
            return InitialTerm + (n - 1) * CommonDifference;
        }

        /// <summary>
        /// Gets the sum of <paramref name="n"/> terms.
        /// </summary>
        /// <param name="n">The number of terms.</param>
        /// <returns>The sum of <paramref name="n"/> terms.</returns>
        public double Sum(int n)
        {
            var tmpLeft = (double) n/2;

            return tmpLeft * (2 * InitialTerm + (n - 1) * CommonDifference);
        }
    }
}