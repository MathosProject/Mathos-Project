using System;

namespace Mathos.PreCalculus
{
    /// <summary>
    /// Represents a geometric sequence.
    /// </summary>
    public class GeometricSequence
    {
        /// <summary>
        /// Initializes a sequence with both an initial term and common ratio of 1.
        /// </summary>
        public GeometricSequence() : this(1, 1)
        {
        }

        /// <summary>
        /// Initializes a sequence with an <paramref name="initialTerm"/> and a <paramref name="commonRatio"/>.
        /// </summary>
        /// <param name="initialTerm">The initial term.</param>
        /// <param name="commonRatio">The common ratio.</param>
        /// <exception cref="ArgumentException">The initial term nor common ratio can be 0.</exception>
        public GeometricSequence(double initialTerm, double commonRatio)
        {
            if (Math.Abs(initialTerm) > 0 && Math.Abs(commonRatio) > 0)
            {
                InitialTerm = initialTerm;
                CommonRatio = commonRatio;
            }
            else
                throw new ArgumentException("The initial term nor common ratio can be 0.");
        }

        /// <summary>
        /// Gets or sets the initial term.
        /// </summary>
        public double InitialTerm { get; set; }

        /// <summary>
        /// Gets or sets the common ratio.
        /// </summary>
        public double CommonRatio { get; set; }

        /// <summary>
        /// Gets the <paramref name="n"/>-th term in the sequence.
        /// </summary>
        /// <param name="n">The term to get.</param>
        /// <returns>The <paramref name="n"/>-th term in the sequence.</returns>
        public double NTerm(int n)
        {
            return InitialTerm * (Math.Pow(CommonRatio, n));
        }

        /// <summary>
        /// Gets the sum of <paramref name="n"/> terms.
        /// </summary>
        /// <param name="n">The number of terms.</param>
        /// <returns>The sum of <paramref name="n"/> terms.</returns>
        public double Sum(int n)
        {
            return InitialTerm * (1 - Math.Pow(CommonRatio, n + 1)) / (1 - CommonRatio);
        }

        /// <summary>
        /// Gets the infinite sum of the sequence.
        /// </summary>
        /// <exception cref="ArgumentException">The <see cref="CommonRatio"/> must be between -1 and 1.</exception>
        /// <returns>The infinite sum of the sequence.</returns>
        public double InfiniteSum()
        {
            if (Math.Abs(CommonRatio) < 1)
                return InitialTerm / (1 - CommonRatio);
            
            throw new ArgumentException("THe common ratio must be between -1 and 1.");
        }
    }
}