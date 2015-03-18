using System;
using System.Collections.Generic;

namespace B_Geometry.Util
{
    public class BCurve
    {
        #region Internal Member Variables

        /// <summary>
        /// The coefficients of the basis function.
        /// </summary>
        private readonly Vector[] _mControlPoints;

        /// <summary>
        /// Degree of the curve
        /// </summary>
        private readonly int _mDegree;

        /// <summary>
        /// The basis function of the curve
        /// </summary>
        private readonly BasisFunction _mBasis = new BasisFunction();

        private readonly int _mDimension;

        #endregion

        #region Constructors

        public BCurve()
        {
        }

        public BCurve(int degree, List<Vector> controlPoints, BasisFunction basisFunction)
        {
            if (controlPoints.Count + 1 + degree != basisFunction.GetNKnots())
                throw new Exception("Number of control points + 1 + degree != n_knots");

            _mDegree = degree;
            _mControlPoints = controlPoints.ToArray();
            _mBasis = basisFunction;
            _mDimension = _mControlPoints[0].VectorDimension();
        }

        public BCurve(int degree, Vector[] controlPoints, BasisFunction basisFunction)
        {
            if (controlPoints.Length + degree + 1 != basisFunction.GetNKnots())
                throw new Exception("Number of control points + 1 + degree != n_knots");

            _mDegree = degree;
            _mControlPoints = controlPoints;
            _mBasis = basisFunction;
            _mDimension = _mControlPoints[0].VectorDimension();
        }

        #endregion

        #region Methods

        public Vector Evaluate(double u)
        {
            var result = new Vector(_mDimension);

            for (var i = 0; i < _mControlPoints.Length; i++)
            {
                var temp1 = _mControlPoints[i];
                var coeff = _mBasis.Evaluate(i, _mDegree, u);

                if (TolerantUtilities.EqualWithinTol(coeff, 0.0))
                    continue;
                
                var temp2 = Vector.ScalarProduct(coeff, temp1);
                
                result = result+temp2;
            }

            return result;
        }

        public List<Vector> GetControlPoints()
        {
            return new List<Vector>(_mControlPoints);
        }

        #endregion
    }
}
