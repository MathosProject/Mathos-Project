using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_Geometry
{
    /// <summary>
    /// Class encapsulating some Linear Algebra Utilities
    /// </summary>
    public class LinearAlgebra
    {
        public static void GaussianElimination(BGeomMatrix matrix, Vector rhs, ref double[] results)
        {
            /// Create augmented matrix
            List<List<double>> augmented_elements = new List<List<double>>();
            for (int i = 0; i < matrix.GetNRows(); i++)
            {
                augmented_elements.Add(new List<double>());
                for (int j = 0; j < matrix.GetNColumns(); j++)
                {
                    augmented_elements[i].Add(matrix.getElement(i, j));
                }
                augmented_elements[i].Add(rhs.Elements[i]);
            }

            /// Create new matrix:
            BGeomMatrix augmented_matrix = new BGeomMatrix(augmented_elements);

            /// Divide first row by the first element:
            double pivot = augmented_matrix.getElement(0, 0);
            if (TolerantUtilities.EqualWithinTol(pivot, 0.0))
            {
                throw new Exception("Cannot solve this type of matrix yet");
            }

            Vector row1 = augmented_matrix.GetRow(0);
            row1.ScalarProduct(1.0 / pivot);

            Vector row2 = new Vector();

            /// Now replace:
            augmented_matrix.ReplaceRow(0, row1);

            int n_rows = augmented_matrix.GetNRows();

            /// Now enter loop
            for (int i = 1; i < n_rows; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    /// get the jth row and multiply it with the ith row coefficient:
                    row1 = augmented_matrix.GetRow(j);

                    /// get coefficient:
                    double coefficient = augmented_matrix.getElement(i, j);

                    /// Multiply:
                    row1.ScalarProduct(coefficient);

                    /// Get the ith row:
                    row2 = augmented_matrix.GetRow(i);

                    /// Subtract:
                    Vector row_subs = row2 - row1;

                    /// Make the first non-zero coeff 1.0:
                    coefficient = row_subs.Elements[j+1];
                    row_subs.ScalarProduct(1.0 / coefficient);

                    /// Replace
                    augmented_matrix.ReplaceRow(i, row_subs);
                }
            }

            /// Now back substitution
            double[] back_subs = new double[n_rows];

            /// Fill in the last element:
            back_subs[n_rows - 1] = augmented_matrix.getElement(n_rows-1, n_rows);

            /// Starting from before last, start filling up:
            for (int i = n_rows - 2; i >= 0; i--)
            {
                /// Get all the factors on the rhs:
                double rhs_factors = 0.0;
                for (int j = n_rows - 1; j > i; j--)
                {
                    rhs_factors += augmented_matrix.getElement(i, j) * back_subs[j];
                }

                /// Now subtract:
                back_subs[i] = augmented_matrix.getElement(i, n_rows) - rhs_factors;
            }

            results = back_subs;
        }

    }
}
