using System;
using System.Collections.Generic;

namespace B_Geometry.Util
{
    /// <summary>
    /// Class encapsulating matrix operations to be performed in geometry creation routines.
    /// </summary>
    public class BGeomMatrix
    {
        #region Internal Member Variables
        
        private readonly int _mRows;
        private readonly int _mColumns;
        private readonly double[] _mElements;

        #endregion

        private int GetIndex ( int i, int j )
        {
            return i*_mColumns + j;
        }

        public double GetElement(int i, int j)
        {
            return _mElements[GetIndex(i, j)];
        }

        public void SetElement ( int i, int j, double value)
        {
            _mElements[GetIndex(i, j)] = value;
        }

        public BGeomMatrix()
        {
        }

        public BGeomMatrix(IList<List<double>> matrixElements)
        {
            // Find dimensions:
            var rows = matrixElements.Count;
            var columns = matrixElements[0].Count;
            
            _mRows = rows;
            _mColumns = columns;
            
            var nElements = rows * columns;
            
            _mElements = new double[nElements];
            
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < columns; j++)
                    SetElement(i, j, matrixElements[i][j]);
            }
        }

        public BGeomMatrix(double[][] matrixElements)
        {
            var rows = matrixElements.GetLength(0);
            var columns = matrixElements[0].Length;

            _mRows = rows;
            _mColumns = columns;
            
            var nElements = rows * columns;
            
            _mElements = new double[nElements];
            
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < columns; j++)
                    SetElement(i, j, matrixElements[i][j]);
            }
        }

        public BGeomMatrix(int rows, int columns, double[] matrixElements)
        {
            _mRows = rows;
            _mColumns = columns;
            _mElements = matrixElements;
        }

        public Vector GetRow(int row)
        {
            var rowElements = new double[_mColumns];

            for (var i = 0; i < _mColumns; i++)
                rowElements[i] = GetElement(row, i);

            return new Vector(rowElements);
        }

        public Vector GetColumn(int column)
        {
            var columnElements = new double[_mRows];

            for (var i = 0; i < _mRows; i++)
                columnElements[i] = GetElement(i, column);

            return new Vector(columnElements);
        }

        public int GetNRows()
        {
            return _mRows;
        }

        public int GetNColumns()
        {
            return _mColumns;
        }

        public bool FindPivot(ref int row)
        {
            for (var i = 0; i < _mRows; i++)
            {
                if (TolerantUtilities.EqualWithinTol(GetElement(i, 0), 0.0))
                    continue;

                row = i;
                
                return true;
            }

            return false;
        }

        public bool FindPivot(int column, ref int row, ref double pivot)
        {
            for (var i = 0; i < _mRows; i++)
            {
                if (TolerantUtilities.EqualWithinTol(GetElement(i, column), 0.0))
                    continue;

                row = i;
                pivot = GetElement(i, column);
                
                return true;
            }

            return false;
        }

        public void DivideRowByScalar(int row, double a)
        {
            for (var i = 0; i < _mColumns; i++)
                SetElement(row, i, GetElement(row, i)/a);
        }

        public void RowSubtraction(int row1, int row2, double scalingFactor)
        {
            // Get vector from matrix:
            var vec1 = GetRow(row1);
            var vec2 = GetRow(row2);

            // Multiply vec_2 by scaling factor:
            vec2.ScalarProduct(scalingFactor);
            vec1.Subtract(vec2);

            // Replace
            ReplaceRow(row1, vec1);
        }


        public void ReplaceRow(int row, Vector vec)
        {
            // Check dimensions:
            if (_mColumns != vec.VectorDimension())
                throw new Exception("wrong dimension");

            for (var i = 0; i < _mColumns; i++)
                SetElement(row, i, vec.Elements[i]);
        }
    }
}
