using System;
using System.Collections.Generic;

namespace B_Geometry.Util
{
    public class GeomUtils
    {
        private static double CentripetalMethod_getChordLength(Vector[] interpolationPoints, ref double[] cache)
        {
            // NOTE: cache is equal to null(ArgumentNullException)

            var cacheList = new List<double>();
            var length = 0.0;
            
            for (var i = 1; i < interpolationPoints.Length; i++)
            {
                // Q_k - Q_k-1
                var vecDiff = interpolationPoints[i] - interpolationPoints[i-1];

                // Size of this vector:
                var vecSize = vecDiff.GetLength();

                // Sqrt of this size:
                vecSize = Math.Sqrt(vecSize);

                // Store this in cache list:
                cacheList.Add(vecSize);

                // Add to length:
                length += vecSize;
            }

            cache = cacheList.ToArray();

            return length;
        }

        private static void CentripetalMethod_calculateInterpolationParameters(
            Vector[] interpolationPoints, ref double[] interpolationParameters)
        {
            // NOTE: interpolationParameters is equal to null(ArgumentNullException)

            // The first element is always 0.0;
            var parameters = new List<double> {0.0};

            var nPoints = interpolationPoints.Length;

            // Calculate chord length:
            double[] chordLengthCache = null;
            var chordLength = CentripetalMethod_getChordLength(interpolationPoints, ref chordLengthCache);

            for (var k = 1; k < nPoints - 1; k++)
            {
                // First term:
                var firstTerm = parameters[k - 1];

                // use cache:
                var secondTerm = chordLengthCache[k - 1] / chordLength;

                // Set new parameter:
                var param = firstTerm + secondTerm;

                // Save:
                parameters.Add(param);
            }

            // last parameter is always 1.0;
            // Minus tolerance as a work around for a problem...
            parameters.Add(1.0 - new TolerantUtilities().GetTolerance());

            // Store parameters:
            interpolationParameters = parameters.ToArray();
        }

        /// Calculate knots:
        private static void CentripetalMethod_calculateKnots(int degree, IList<double> interpolationParameters, ref double[] knots)
        {
            // NOTE: knots is equal to null(ArgumentNullException)

            // Calculate interpolation parameters:
            //double[] interpolationParameters = null;
            //GeomUtils.CentripetalMethod_calculateInterpolationParameters(interpolationPoints, ref interpolationParameters);

            // knots: 0, 0, 0, u1, u2, ..., un, 1, 1, 1.
            //int n_knots = interpolationParameters.Length + 2 * (degree - 1);
            var nControlPoints = interpolationParameters.Count;
            var nKnots = nControlPoints + degree + 1;
            
            knots = new double[nKnots];

            var factor = 1.0 / degree;

            // Fill the middle knots:
            for (var i = 0; i < nKnots; i++)
            {
                if (i < degree + 1)
                {
                    knots[i] = 0.0;

                    continue;
                }

                if (i > nKnots - degree - 2)
                {
                    knots[i] = 1.0;

                    continue;
                }

                var tempKnot = 0.0;

                for (var j = i - degree; j < i; j++)
                    tempKnot += interpolationParameters[j];

                knots[i] = factor * tempKnot;
            }
        }

        public static void CentripetalMethod_createSplineByInterpolation(
            int degree, Vector[] interpolationPoints, ref BCurve result)
        {
            // NOTE: result is equal to null(ArgumentNullException)

            // Calculate interpolation parameters:
            double[] interpolationParameters = null;
            CentripetalMethod_calculateInterpolationParameters(interpolationPoints, ref interpolationParameters);

            // Calculate knots:
            double[] knots = null;
            CentripetalMethod_calculateKnots(degree, interpolationParameters, ref knots);

            // Create basis function:
            var basis = new BasisFunction(knots);

            // Number of control points:
            var nControlPoints = interpolationPoints.Length;

            // Create set of linearly independent equations:
            var matrixElements = new double[nControlPoints][];

            for (var i = 0; i < nControlPoints; i++)
            {
                matrixElements[i] = new double[nControlPoints];

                for (var j = 0; j < nControlPoints; j++)
                    matrixElements[i][j] = basis.Evaluate(j, degree, interpolationParameters[i]);
            }

            // Create matrix:
            var matrix = new BGeomMatrix(matrixElements);

            var dimension = interpolationPoints[0].VectorDimension();

            // Solve using Gaussian Elimination:
            var rhs = new Vector(nControlPoints);
            var controlPoints = new Vector[nControlPoints];

            for (var i = 0; i < dimension; i++)
            {
                // Fill the elements of the rhs:
                for (var j = 0; j < nControlPoints; j++)
                    rhs.Elements[j] = interpolationPoints[j].Elements[i];

                double[] gaussResult = null;

                LinearAlgebra.GaussianElimination(matrix, rhs, ref gaussResult);

                // Fill the control points
                for (var k = 0; k < nControlPoints; k++)
                {
                    if ( i == 0)
                        controlPoints[k] = new Vector(dimension);
                    
                    controlPoints[k].Elements[i] = gaussResult[k];
                }
            }

            // Create spline:
            result = new BCurve(degree, controlPoints, basis);
        }
    }
}
