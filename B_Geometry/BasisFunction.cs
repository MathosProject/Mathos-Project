using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_Geometry
{
    public class BasisFunction
    {
        #region Internal member variables

        /// <summary>
        /// Expanded knots used to evaluate the basis function.
        /// </summary>
        private double[] m_expanded_knots = null;

        /// <summary>
        /// Flag indicating whether expanded knots have been set.
        /// </summary>
        private bool m_expanded_knots_set = false;

        /// <summary>
        /// Multiplicity of unique knot values.
        /// </summary>
        private int[] m_knot_multiplicity = null;

        /// <summary>
        /// Flag indicating whether the knot multiplicities has been set.
        /// </summary>
        private bool m_knot_mult_set = false;

        /// <summary>
        /// unique knot values
        /// </summary>
        private double[] m_knots = null;

        /// <summary>
        /// Flag indicating whether knots are set.
        /// </summary>
        private bool m_knots_set = false;

        /// <summary>
        /// number of expanded knots
        /// </summary>
        private int n_knots = 0;
        
        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public BasisFunction()
        {
        }

        /// <summary>
        /// Initialise BasisFunction with knots multiplicities and unique knots.
        /// </summary>
        /// <param name="knotMultiplicity">Multiplicity of unique knots.</param>
        /// <param name="Knots">Unique knots.</param>
        public BasisFunction(List<int> knotMultiplicity, List<double> Knots)
        {
            /// Set knots and knot multiplicity
            this.m_knot_multiplicity = knotMultiplicity.ToArray();
            this.m_knots = Knots.ToArray();

            this.m_knot_mult_set = true;
            this.m_knots_set = true;

            /// Set n_knots
            n_knots = 0;
            foreach (int i in this.m_knot_multiplicity)
            {
                n_knots += i;
            }

            /// Allocate memory for expanded knots:
            this.m_expanded_knots = new double[n_knots];

            int count = 0;

            /// Populate expanded knots:
            for (int i = 0; i < this.m_knot_multiplicity.Length; i++)
            {
                for (int j = 0; j < this.m_knot_multiplicity[i]; j++)
                {
                    this.m_expanded_knots[count] = this.m_knots[i];
                    count++;
                }
            }
        }

        /// <summary>
        /// Initialise BasisFunction using already expanded knots.
        /// This constructor does not set the knot multiplicites and unique knots.
        /// </summary>
        /// <param name="expandedKnots">Already expanded knots.</param>
        public BasisFunction(List<double> expandedKnots)
        {
            this.m_expanded_knots = expandedKnots.ToArray();
            this.n_knots = expandedKnots.Count;

            this.m_expanded_knots_set = true;

            /// Generate the unique knots and multiplicities using the expanded knots.
            this.ExpandKnots();
        }

        /// <summary>
        /// Initialise BasisFunction using already expanded knots.
        /// This constructor does not set the knot multiplicites and unique knots.
        /// </summary>
        /// <param name="expandedKnots">Already expanded knots.</param>
        public BasisFunction(double[] expandedKnots)
        {
            this.m_expanded_knots = expandedKnots;
            this.n_knots = expandedKnots.Length;

            this.m_expanded_knots_set = true;

            /// Generate the unique knots and multiplicities using the expanded knots.
            this.ExpandKnots();
        }

        #endregion

        #region Methods

        /// <summary>
        /// If only expanded knots have been supplied, generate unique knots and their multiplicities.
        /// </summary>
        public void ExpandKnots()
        {
            if (!this.m_knot_mult_set && this.n_knots != 0)
            {
                List<int> temp_mult = new List<int>();
                List<double> temp_knots = new List<double>();

                /// Collapse knots
                temp_knots.Add(this.m_expanded_knots[0]);
                temp_mult.Add(1); ;

                /// Set counter to 1.
                int knot_count = 1;

                for (int i = 0; i < this.m_expanded_knots.Length; i++)
                {
                    /// If the next knot in the expanded set is equal to the previous one
                    /// within supplied tolerance of 1.0e-11, then increment knot_multiplicity.
                    if ( i != 0 && TolerantUtilities.EqualWithinTol(
                        this.m_expanded_knots[i], this.m_expanded_knots[knot_count - 1]))
                    {
                        temp_mult[knot_count - 1]++;
                    }

                    else
                    {
                        /// Else add a new entry:
                        temp_mult.Add(1);
                        temp_knots.Add(this.m_expanded_knots[i]);
                    }
                }

                this.m_knot_multiplicity = temp_mult.ToArray();
                this.m_knots = temp_knots.ToArray();

                this.m_knot_mult_set = true;
                this.m_knots_set = true;
            }
        }

        public double Evaluate(int i, int p, double u)
        {
            /// If p == 0, do the following
            if (p == 0)
            {
                /*if (TolerantUtilities.EqualWithinTol(u, this.m_expanded_knots[this.n_knots - 1]))
                {
                    return 1.0;
                }*/
                if (this.m_expanded_knots[i] <= u
                    &&
                    u < this.m_expanded_knots[i + 1])
                {
                    return 1.0;
                }
                else
                {
                    return 0.0;
                }
            }

            /// Calculate coefficients
            /// 
            double first_coeff_num, first_coeff_den, first_coeff_bas, first_coeff = 0.0;
            double second_coeff_num, second_coeff_den, second_coeff_bas, second_coeff = 0.0;

            first_coeff_bas = this.Evaluate(i, p - 1, u);
            if (TolerantUtilities.EqualWithinTol(first_coeff_bas, 0.0))
            {
                first_coeff = 1;
            }
            else
            {
                first_coeff_num = u - this.m_expanded_knots[i];
                first_coeff_den = this.m_expanded_knots[i + p] - this.m_expanded_knots[i];
                first_coeff = first_coeff_num / first_coeff_den;
            }

            second_coeff_bas = this.Evaluate(i + 1, p - 1, u);
            if (TolerantUtilities.EqualWithinTol(second_coeff_bas, 0.0))
            {
                second_coeff = 1;
            }
            else
            {
                second_coeff_num = this.m_expanded_knots[i + p + 1] - u;
                second_coeff_den = this.m_expanded_knots[i + p + 1] - this.m_expanded_knots[i + 1];
                second_coeff = second_coeff_num / second_coeff_den;
            }

            /// Combining the coefficients:
            double result =
                (first_coeff) * first_coeff_bas +
                (second_coeff) * second_coeff_bas;

            return result;
        }

        public int GetNKnots()
        {
            return this.n_knots;
        }



        #endregion
    }
}
