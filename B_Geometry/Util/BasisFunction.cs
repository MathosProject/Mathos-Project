using System.Collections.Generic;

namespace B_Geometry.Util
{
    public class BasisFunction
    {
        #region Internal member variables

        /// <summary>
        /// Expanded knots used to evaluate the basis function.
        /// </summary>
        private readonly double[] _mExpandedKnots;

        /// <summary>
        /// Flag indicating whether expanded knots have been set.
        /// </summary>
        public bool MExpandedKnotsSet { get; private set; }

        /// <summary>
        /// Multiplicity of unique knot values.
        /// </summary>
        private int[] _mKnotMultiplicity;

        /// <summary>
        /// Flag indicating whether the knot multiplicities has been set.
        /// </summary>
        private bool _mKnotMultSet;

        /// <summary>
        /// Unique knot values
        /// </summary>
        private double[] _mKnots;

        /// <summary>
        /// Flag indicating whether knots are set.
        /// </summary>
        private bool _mKnotsSet;

        /// <summary>
        /// number of expanded knots
        /// </summary>
        private readonly int _nKnots;
        
        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        public BasisFunction()
        {
        }

        /// <summary>
        /// Initialise BasisFunction with knots multiplicities and unique knots.
        /// </summary>
        /// <param name="knotMultiplicity">Multiplicity of unique knots.</param>
        /// <param name="knots">Unique knots.</param>
        public BasisFunction(List<int> knotMultiplicity, List<double> knots)
        {
            // Set knots and knot multiplicity
            _mKnotMultiplicity = knotMultiplicity.ToArray();
            _mKnots = knots.ToArray();

            _mKnotMultSet = true;
            _mKnotsSet = true;

            // Set n_knots
            _nKnots = 0;

            foreach (var i in _mKnotMultiplicity)
                _nKnots += i;

            // Allocate memory for expanded knots:
            _mExpandedKnots = new double[_nKnots];

            var count = 0;

            // Populate expanded knots:
            for (var i = 0; i < _mKnotMultiplicity.Length; i++)
            {
                for (var j = 0; j < _mKnotMultiplicity[i]; j++)
                {
                    _mExpandedKnots[count] = _mKnots[i];

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
            _mExpandedKnots = expandedKnots.ToArray();
            _nKnots = expandedKnots.Count;

            MExpandedKnotsSet = true;

            // Generate the unique knots and multiplicities using the expanded knots.
            ExpandKnots();
        }

        /// <summary>
        /// Initialise BasisFunction using already expanded knots.
        /// This constructor does not set the knot multiplicites and unique knots.
        /// </summary>
        /// <param name="expandedKnots">Already expanded knots.</param>
        public BasisFunction(double[] expandedKnots)
        {
            _mExpandedKnots = expandedKnots;
            _nKnots = expandedKnots.Length;

            MExpandedKnotsSet = true;

            // Generate the unique knots and multiplicities using the expanded knots.
            ExpandKnots();
        }

        #endregion

        #region Methods

        /// <summary>
        /// If only expanded knots have been supplied, generate unique knots and their multiplicities.
        /// </summary>
        public void ExpandKnots()
        {
            if (_mKnotMultSet || _nKnots == 0)
                return;

            var tempMult = new List<int> {1};
            var tempKnots = new List<double> {_mExpandedKnots[0]};

            // Set counter to 1.
            const int knotCount = 1;

            for (var i = 0; i < _mExpandedKnots.Length; i++)
            {
                // If the next knot in the expanded set is equal to the previous one
                // within supplied tolerance of 1.0e-11, then increment knot_multiplicity.
                if (i != 0 && TolerantUtilities.EqualWithinTol(
                    _mExpandedKnots[i], _mExpandedKnots[knotCount - 1]))
                    tempMult[knotCount - 1]++;
                else
                {
                    // Else add a new entry:
                    tempMult.Add(1);
                    tempKnots.Add(_mExpandedKnots[i]);
                }
            }

            _mKnotMultiplicity = tempMult.ToArray();
            _mKnots = tempKnots.ToArray();

            _mKnotMultSet = true;
            _mKnotsSet = true;
        }

        public double Evaluate(int i, int p, double u)
        {
            // If p == 0, do the following
            if (p == 0)
            {
                /*if (TolerantUtilities.EqualWithinTol(u, this.m_expanded_knots[this.n_knots - 1]))
                {
                    return 1.0;
                }*/

                return _mExpandedKnots[i] <= u &&
                       u < _mExpandedKnots[i + 1]
                    ? 1.0
                    : 0.0;
            }

            // Calculate coefficients
            // 
            double firstCoeff;
            double secondCoeff;

            var firstCoeffBas = Evaluate(i, p - 1, u);
            
            if (TolerantUtilities.EqualWithinTol(firstCoeffBas, 0.0))
            {
                firstCoeff = 1;
            }
            else
            {
                var firstCoeffNum = u - _mExpandedKnots[i];
                var firstCoeffDen = _mExpandedKnots[i + p] - _mExpandedKnots[i];

                firstCoeff = firstCoeffNum / firstCoeffDen;
            }

            var secondCoeffBas = Evaluate(i + 1, p - 1, u);

            if (TolerantUtilities.EqualWithinTol(secondCoeffBas, 0.0))
                secondCoeff = 1;
            else
            {
                var secondCoeffNum = _mExpandedKnots[i + p + 1] - u;
                var secondCoeffDen = _mExpandedKnots[i + p + 1] - _mExpandedKnots[i + 1];
                
                secondCoeff = secondCoeffNum/secondCoeffDen;
            }

            // Combining the coefficients:
            return (firstCoeff)*firstCoeffBas +
                   (secondCoeff)*secondCoeffBas;
        }

        public int GetNKnots()
        {
            return _nKnots;
        }

        #endregion
    }
}
