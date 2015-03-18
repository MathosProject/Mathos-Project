using System;
using System.Collections.Generic;

namespace B_Geometry.Util
{
    /// <summary>
    /// Class encapsulating some Linear Algebra Utilities
    /// </summary>
    public class LinearAlgebra
    {
        public static void GaussianElimination(BGeomMatrix matrix, Vector rhs, ref double[] results)
        {
            // Create augmented matrix
            var augmentedElements = new List<List<double>>();

            for (var i = 0; i < matrix.GetNRows(); i++)
            {
                augmentedElements.Add(new List<double>());

                for (var j = 0; j < matrix.GetNColumns(); j++)
                    augmentedElements[i].Add(matrix.GetElement(i, j));
                
                augmentedElements[i].Add(rhs.Elements[i]);
            }

            // Create new matrix:
            var augmentedMatrix = new BGeomMatrix(augmentedElements);

            // Divide first row by the first element:
            var pivot = augmentedMatrix.GetElement(0, 0);

            if (TolerantUtilities.EqualWithinTol(pivot, 0.0))
                throw new Exception("Cannot solve this type of matrix yet");

            var row1 = augmentedMatrix.GetRow(0);
            
            row1.ScalarProduct(1.0 / pivot);

            // Now replace:
            augmentedMatrix.ReplaceRow(0, row1);

            var nRows = augmentedMatrix.GetNRows();

            // Now enter loop
            for (var i = 1; i < nRows; i++)
            {
                for (var j = 0; j < i; j++)
                {
                    // get the jth row and multiply it with the ith row coefficient:
                    row1 = augmentedMatrix.GetRow(j);

                    // get coefficient:
                    var coefficient = augmentedMatrix.GetElement(i, j);

                    // Multiply:
                    row1.ScalarProduct(coefficient);

                    // Get the ith row:
                    var row2 = augmentedMatrix.GetRow(i);

                    // Subtract:
                    var rowSubs = row2 - row1;

                    // Make the first non-zero coeff 1.0:
                    coefficient = rowSubs.Elements[j+1];
                    rowSubs.ScalarProduct(1.0 / coefficient);

                    // Replace
                    augmentedMatrix.ReplaceRow(i, rowSubs);
                }
            }

            // Now back substitution
            var backSubs = new double[nRows];

            // Fill in the last element:
            backSubs[nRows - 1] = augmentedMatrix.GetElement(nRows-1, nRows);

            // Starting from before last, start filling up:
            for (var i = nRows - 2; i >= 0; i--)
            {
                // Get all the factors on the rhs:
                var rhsFactors = 0.0;

                for (var j = nRows - 1; j > i; j--)
                    rhsFactors += augmentedMatrix.GetElement(i, j)*backSubs[j];

                // Now subtract:
                backSubs[i] = augmentedMatrix.GetElement(i, nRows) - rhsFactors;
            }

            results = backSubs;
        }
    }
}
