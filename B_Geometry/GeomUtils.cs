using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_Geometry
{
    class GeomUtils
    {
        private static double CentripetalMethod_getChordLength(Vector[] interpolationPoints, ref double[] cache)
        {
            List<double> cache_list = new List<double>();
            double length = 0.0;
            for ( int i = 1; i < interpolationPoints.Length; i++ )
            {
                /// Q_k - Q_k-1
                Vector vec_diff = interpolationPoints[i] - interpolationPoints[i-1];

                /// Size of this vector:
                double vec_size = vec_diff.GetLength();

                /// Sqrt of this size:
                vec_size = Math.Sqrt(vec_size);

                /// Store this in cache list:
                cache_list.Add(vec_size);

                /// Add to length:
                length += vec_size;
            }

            cache = cache_list.ToArray();

            return length;
        }

        private static void CentripetalMethod_calculateInterpolationParameters(
            Vector[] interpolationPoints, ref double[] interpolationParameters)
        {
            List<double> parameters = new List<double>();

            int n_points = interpolationPoints.Length;

            /// Calculate chord length:
            double[] chord_length_cache = null;
            double chord_length = GeomUtils.CentripetalMethod_getChordLength(interpolationPoints, ref chord_length_cache);

            /// The first element is always 0.0;
            parameters.Add(0.0);

            for (int k = 1; k < n_points - 1; k++)
            {
                /// First term:
                double first_term = parameters[k - 1];

                /// use cache:
                double second_term = chord_length_cache[k - 1] / chord_length;

                /// Set new parameter:
                double param = first_term + second_term;

                /// Save:
                parameters.Add(param);
            }

            /// last parameter is always 1.0;
            /// Minus tolerance as a work around for a problem...
            TolerantUtilities T = new TolerantUtilities();
            parameters.Add(1.0 - T.GetTolerance());

            /// Store parameters:
            interpolationParameters = parameters.ToArray();
        }

        /// Calculate knots:
        private static void CentripetalMethod_calculateKnots(int degree, double[] interpolationParameters, ref double[] knots)
        {
            /// Calculate interpolation parameters:
            //double[] interpolationParameters = null;
            //GeomUtils.CentripetalMethod_calculateInterpolationParameters(interpolationPoints, ref interpolationParameters);

            /// knots: 0, 0, 0, u1, u2, ..., un, 1, 1, 1.
            //int n_knots = interpolationParameters.Length + 2 * (degree - 1);
            int n_control_points = interpolationParameters.Length;
            int n_knots = n_control_points + degree + 1;
            knots = new double[n_knots];

            TolerantUtilities T = new TolerantUtilities();

            double factor = 1.0 / (double)degree;

            /// Fill the middle knots:
            for (int i = 0; i < n_knots; i++)
            {
                if (i < degree + 1)
                {
                    knots[i] = 0.0;
                    continue;
                }
                if (i > n_knots - degree - 2)
                {
                    knots[i] = 1.0;
                    continue;
                }

                double temp_knot = 0.0;
                for (int j = i - degree; j < i; j++)
                {
                    temp_knot += interpolationParameters[j];
                }

                knots[i] = factor * temp_knot;
            }
        }

        public static void CentripetalMethod_createSplineByInterpolation(
            int degree, Vector[] interpolationPoints, ref BCurve result)
        {
            /// Calculate interpolation parameters:
            double[] interpolationParameters = null;
            GeomUtils.CentripetalMethod_calculateInterpolationParameters(interpolationPoints, ref interpolationParameters);

            /// Calculate knots:
            double[] knots = null;
            GeomUtils.CentripetalMethod_calculateKnots(degree, interpolationParameters, ref knots);

            /// Create basis function:
            BasisFunction basis = new BasisFunction(knots);

            /// Number of control points:
            int n_control_points = interpolationPoints.Length;

            /// Create set of linearly independent equations:
            double[][] matrix_elements = new double[n_control_points][];

            for (int i = 0; i < n_control_points; i++)
            {
                matrix_elements[i] = new double[n_control_points];

                for (int j = 0; j < n_control_points; j++)
                {
                    if (i == 4 && j == 4)
                    { double x = 0; }
                    matrix_elements[i][j] = basis.Evaluate(j, degree, interpolationParameters[i]);
                }
            }

            /// Create matrix:
            BGeomMatrix matrix = new BGeomMatrix(matrix_elements);

            int dimension = interpolationPoints[0].VectorDimension();

            /// Solve using Gaussian Elimination:
            Vector rhs = new Vector(n_control_points);
            Vector[] controlPoints = new Vector[n_control_points];

            for (int i = 0; i < dimension; i++)
            {
                /// Fill the elements of the rhs:
                for (int j = 0; j < n_control_points; j++)
                {
                    rhs.Elements[j] = interpolationPoints[j].Elements[i];
                }

                double[] GaussResult = null;
                LinearAlgebra.GaussianElimination(matrix, rhs, ref GaussResult);

                /// Fill the control points
                for (int k = 0; k < n_control_points; k++)
                {
                    if ( i == 0)
                    controlPoints[k] = new Vector(dimension);
                    
                    controlPoints[k].Elements[i] = GaussResult[k];
                }
            }

            /// Create spline:
            BCurve curve = new BCurve(degree, controlPoints, basis);

            result = curve;
        }
    }
}
