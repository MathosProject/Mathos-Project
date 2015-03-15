using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_Geometry
{
    public class BCurve
    {
        #region Internal Member Variables

        /// <summary>
        /// The coefficients of the basis function.
        /// </summary>
        private Vector[] m_control_points = null;

        /// <summary>
        /// Degree of the curve
        /// </summary>
        private int m_degree = 0;

        /// <summary>
        /// The basis function of the curve
        /// </summary>
        private BasisFunction m_basis = new BasisFunction();

        private int m_dimension = 0;

        #endregion

        #region Constructors

        public BCurve()
        {
        }

        public BCurve(int degree, List<Vector> controlPoints, BasisFunction basisFunction)
        {
            if ( controlPoints.Count + 1 + degree != basisFunction.GetNKnots() )
            {
                throw new Exception("Number of control points + 1 + degree != n_knots");
            }

            this.m_degree = degree;
            this.m_control_points = controlPoints.ToArray();
            this.m_basis = basisFunction;
            this.m_dimension = this.m_control_points[0].VectorDimension();
        }

        public BCurve(int degree, Vector[] controlPoints, BasisFunction basisFunction)
        {
            if (controlPoints.Length + degree + 1 != basisFunction.GetNKnots())
            {
                throw new Exception("Number of control points + 1 + degree != n_knots");
            }

            this.m_degree = degree;
            this.m_control_points = controlPoints;
            this.m_basis = basisFunction;
            this.m_dimension = this.m_control_points[0].VectorDimension();
        }

        #endregion

        #region Methods

        public Vector Evaluate(double u)
        {
            Vector result = new Vector(this.m_dimension);
            Vector temp1 = new Vector();
            Vector temp2 = new Vector();
            for ( int i = 0; i < this.m_control_points.Length; i++ )
            {
                temp1 = this.m_control_points[i];
                double coeff = this.m_basis.Evaluate(i, this.m_degree, u);
                if ( TolerantUtilities.EqualWithinTol(coeff, 0.0))
                {
                    continue;
                }
                temp2 = Vector.ScalarProduct(coeff, temp1);
                result = result+temp2;
            }
            return result;
        }

        public List<Vector> GetControlPoints()
        {
            return new List<Vector>(this.m_control_points);
        }
        #endregion
    }
}
