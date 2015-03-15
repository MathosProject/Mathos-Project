using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_Geometry
{
    /// <summary>
    /// Class encapsulating matrix operations to be performed in geometry creation routines.
    /// </summary>
    public class BGeomMatrix
    {
        #region Internal Member Variables
        
        private int m_rows = 0;
        private int m_columns = 0;
        private double[] m_elements = null;

        #endregion

        private int getIndex ( int i, int j )
        {
            return i*this.m_columns + j;
        }

        public double getElement(int i, int j)
        {
            int index = this.getIndex(i, j);
            return this.m_elements[index];
        }

        public void setElement ( int i, int j, double value)
        {
            int index = this.getIndex(i,j);
            this.m_elements[index] = value;
        }

        public BGeomMatrix()
        { }


        public BGeomMatrix(List<List<double>> matrix_elements)
        {
            /// Find dimensions:
            int rows = matrix_elements.Count;
            int columns = matrix_elements[0].Count;
            this.m_rows = rows;
            this.m_columns = columns;
            int n_elements = rows * columns;
            this.m_elements = new double[n_elements];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    this.setElement(i, j, matrix_elements[i][j]);
                }
            }
        }

        public BGeomMatrix(double[][] matrix_elements)
        {
            int rows = matrix_elements.GetLength(0);
            //int columns = matrix_elements.GetLength(1);
            int columns = matrix_elements[0].Length;
            this.m_rows = rows;
            this.m_columns = columns;
            int n_elements = rows * columns;
            this.m_elements = new double[n_elements];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    this.setElement(i, j, matrix_elements[i][j]);
                }
            }
        }

        public BGeomMatrix(int rows, int columns, double[] matrix_elements)
        {
            this.m_rows = rows;
            this.m_columns = columns;
            this.m_elements = matrix_elements;
        }

        public Vector GetRow(int row)
        {
            double[] row_elements = new double[this.m_columns];
            for (int i = 0; i < m_columns; i++)
            {
                row_elements[i] = this.getElement(row, i);
            }
            Vector result = new Vector(row_elements);
            return result;
        }

        public Vector GetColumn(int column)
        {
            double[] column_elements = new double[this.m_rows];
            for (int i = 0; i < m_rows; i++)
            {
                column_elements[i] = this.getElement(i, column);
            }
            Vector result = new Vector(column_elements);
            return result;
        }

        public int GetNRows()
        {
            return this.m_rows;
        }

        public int GetNColumns()
        {
            return this.m_columns;
        }

        public bool FindPivot(ref int row)
        {
            for ( int i = 0; i < this.m_rows; i++ )
            {
                if (!TolerantUtilities.EqualWithinTol(this.getElement(i, 0), 0.0))
                {
                    row = i;
                    return true;
                }
            }
            return false;
        }

        public bool FindPivot(int column, ref int row, ref double pivot)
        {
            for (int i = 0; i < this.m_rows; i++)
            {
                if (!TolerantUtilities.EqualWithinTol(this.getElement(i, column), 0.0))
                {
                    row = i;
                    pivot = this.getElement(i, column);
                    return true;
                }
            }
            return false;
        }

        public void DivideRowByScalar(int row, double a)
        {
            for (int i = 0; i < this.m_columns; i++)
            {
                this.setElement(row, i, this.getElement(row, i)/a);
            }
        }

        public void RowSubtraction(int row1, int row2, double scaling_factor)
        {
            /// Get vector from matrix:
            Vector vec_1 = this.GetRow(row1);
            Vector vec_2 = this.GetRow(row2);

            /// Multiply vec_2 by scaling factor:
            vec_2.ScalarProduct(scaling_factor);

            vec_1.Subtract(vec_2);

            /// Replace
            ReplaceRow(row1, vec_1);
        }


        public void ReplaceRow(int row, Vector vec)
        {
            /// Check dimensions:
            if (this.m_columns != vec.VectorDimension())
            {
                throw new Exception("wrong dimension");
            }

            for (int i = 0; i < this.m_columns; i++)
            {
                this.setElement(row, i, vec.Elements[i]);
            }
        }
        
    }
}
