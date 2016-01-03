using System;
using System.Linq;

namespace Mathos.Notation
{
    /// <summary>
    /// Implementation of matrixes.
    /// </summary>
    public class Matrix
    {
        private readonly Vector[] _matrixContent;

        /// <summary>
        /// Default contructor
        /// </summary>
        public Matrix()
            : this(new Vector[] { })
        { 
        }

        /// <summary>
        /// Contructor for defining the <paramref name="rows"/> and columns, <paramref name="colls"/>.
        /// </summary>
        /// <param name="rows">The numbers of rows.</param>
        /// <param name="colls">The number of columns.</param>
        public Matrix(int rows, int colls)
        {
            _matrixContent = new Vector[rows];

            for (var i = 0; i < rows; i++)
                _matrixContent[i] = new Vector {Length = colls};
        }
       
        /// <summary>
        /// Contructor that takes a number of Vectors.
        /// </summary>
        /// <param name="vectors">The vectors to use.</param>
        public Matrix(params Vector[] vectors)
        {
            _matrixContent = vectors;
        }

        /// <summary>
        /// The indexer
        /// </summary>
        /// <param name="index">The index.</param>
        public Vector this[int index]
        {
            get
            {
                return _matrixContent[index];
            }
            set
            {
                _matrixContent[index] = value;
            }
        }

        /// <summary>
        /// The double indexer.
        /// </summary>
        /// <param name="row">The row.</param>
        /// <param name="coll">The column.</param>
        public double this[int row, int coll]
        {
            get
            {
                return _matrixContent[row][coll];
            }
            set
            {
                _matrixContent[row][coll] = value;
            }
        }

        /// <summary>
        /// Get the length of <see cref="_matrixContent"/>.
        /// </summary>
        public int Length { get { return _matrixContent.Length; } }

        /// <summary>
        /// The matrix initialization of a jagged array of doubles.
        /// </summary>
        /// <param name="input">The jagged array.</param>
        /// <returns>A matrix from the jagged array.</returns>
        public static implicit operator Matrix(double[][] input)
        {
            var vector = new Matrix(input.Length,input[0].Length);

            for (var i = 0; i < input.Length; i++)
            {
                for (var j = 0; j < input[i].Length; j++)
                    vector[i, j] = input[i][j];
            }

            return vector;
        }

        /// <summary>
        /// Check if two matrixes are equal.
        /// </summary>
        /// <param name="add1">The first matrix.</param>
        /// <param name="add2">The second matrix.</param>
        /// <returns>True if the two matrixes are equal.</returns>
        public static bool operator==(Matrix add1, Matrix add2)
        {
            if (add1 != null && (add2 != null && add1._matrixContent.Length != add2._matrixContent.Length))
                throw new ArgumentException("Matrix passed in does not have the same order as matrix to be added to.");
            if (add2 != null && (add1 != null && add1._matrixContent[0].Length != add2._matrixContent[0].Length))
                throw new ArgumentException("Matrix passed in does not have the same order as matrix to be added to.");

            return !(add2 != null) || !add2._matrixContent.Where((t, i) => add1 != null && add1._matrixContent[i] != t).Any();
        }

        /// <summary>
        /// Check if two matrixes are not equal.
        /// </summary>
        /// <param name="add1">The first matrix.</param>
        /// <param name="add2">The second matrix.</param>
        /// <returns>True if the two matrixes are not equal.</returns>
        public static bool operator!=(Matrix add1, Matrix add2)
        {
            if (add2 != null && (add1 != null && add1._matrixContent.Length != add2._matrixContent.Length))
                return false;
            if (add2 != null && (add1 != null && add1._matrixContent[0].Length != add2._matrixContent[0].Length))
                return false;
            
            var b = (add1 == add2);
            
            return !b;
        }
        
        private static Matrix Operation(Matrix a, Matrix n, Func<double, double, double> ptroperation)
        {
            var result = new Matrix(a._matrixContent.Length, a._matrixContent[0].Length);

            for (var r = 0; r < a._matrixContent.Length; r++)
            {
                for (var s = 0; s < a._matrixContent[0].Length; s++)
                    result[r, s] = ptroperation(a[r, s], n[r,s]);
            }

            return result;
        }

        /// <summary>
        /// Add two matrixes together.
        /// </summary>
        /// <param name="add1">The first matrix.</param>
        /// <param name="add2">The second matrix,</param>
        /// <returns>The two matrixes added together.</returns>
        public static Matrix operator+(Matrix add1, Matrix add2)
        {
            if (add1._matrixContent.Length != add2._matrixContent.Length)
                throw new ArgumentException("Matrix passed in does not have the same order as matrix to be added to.");
            if (add1._matrixContent[0].Length != add2._matrixContent[0].Length)
                throw new ArgumentException("Matrix passed in does not have the same order as matrix to be added to.");
            
            return Operation(add1, add2, (x, y) => x + y);
        }

        /// <summary>
        /// Minus two matrixes.
        /// </summary>
        /// <param name="add1">The first matrix.</param>
        /// <param name="add2">The second matrix.</param>
        /// <returns><paramref name="add2"/> subtracted from <paramref name="add1"/>.</returns>
        public static Matrix operator-(Matrix add1, Matrix add2)
        {
            if (add1._matrixContent.Length != add2._matrixContent.Length)
                throw new ArgumentException("Matrix passed in does not have the same order as matrix to be added to.");
            if (add1._matrixContent[0].Length != add2._matrixContent[0].Length)
                throw new ArgumentException("Matrix passed in does not have the same order as matrix to be added to.");
            
            return Operation(add1, add2, (x, y) => x - y);

        }
       
        private static Matrix Operation(Matrix a, int n, Func<double , int, double> ptroperation)
        {
            var result = new Matrix(a._matrixContent.Length, a._matrixContent[0].Length);

            for (var r = 0; r < a._matrixContent.Length; r++)
            {
                for (var s = 0; s < a._matrixContent[0].Length; s++)
                    result[r, s] = ptroperation(a[r, s] , n);
            }

            return result;
        }

        private static Matrix Operation(Matrix a, double n, Func<double, double, double> ptroperation)
        {
            var result = new Matrix(a._matrixContent.Length, a._matrixContent[0].Length);

            for (var r = 0; r < a._matrixContent.Length; r++)
            {
                for (var s = 0; s < a._matrixContent[0].Length; s++)
                    result[r, s] = ptroperation(a[r, s], n);
            }

            return result;
        }

        /// <summary>
        /// Add a matrix and an integer together.
        /// </summary>
        /// <param name="add1">The matrix.</param>
        /// <param name="add2">The integer.</param>
        /// <returns>The matrix and the integer added together.</returns>
        public static Matrix operator +(Matrix add1, int add2)
        {
            return Operation(add1, add2, (x, y) => x + y);
        }

        /// <summary>
        /// Add a matrix and an integer together. 
        /// </summary>
        /// <param name="add2">The integer.</param>
        /// <param name="add1">The matrix.</param>
        /// <returns>The matrix and the integer added together.</returns>
        public static Matrix operator +(int add2, Matrix add1)
        {
            return add1 + add2;
        }

        /// <summary>
        /// Multiply a matrix by an integer.
        /// </summary>
        /// <param name="add1">The matrix.</param>
        /// <param name="add2">The integer.</param>
        /// <returns>The matrix and the integer multiplied together.</returns>
        public static Matrix operator *(Matrix add1, int add2)
        {
            return Operation(add1, add2, (x, y) => x * y);
        }

        /// <summary>
        /// Multiply a matrix by an integer.
        /// </summary>
        /// <param name="add2">The integer.</param>
        /// <param name="add1">The matrix.</param>
        /// <returns>The matrix and the integer multiplied together.</returns>
        public static Matrix operator *(int add2, Matrix add1)
        {
            return add1 * add2;
        }

        /// <summary>
        /// Minus a matrix from an integer.
        /// </summary>
        /// <param name="add1">The matrix.</param>
        /// <param name="add2">The integer.</param>
        /// <returns>The integer subtracted from the matrix.</returns>
        public static Matrix operator -(Matrix add1, int add2)
        {
            return Operation(add1, add2, (x, y) => x - y);
        }

        /// <summary>
        /// Minus an integer from a matrix.
        /// </summary>
        /// <param name="add2">The integer.</param>
        /// <param name="add1">The matrix.</param>
        /// <returns>The integer subtracted from the matrix.</returns>
        public static Matrix operator -(int add2, Matrix add1)
        {
            return (add1 - add2) * -1;
        }

        /// <summary>
        /// Divide a matrix by an integer.
        /// </summary>
        /// <param name="add1">The matrix.</param>
        /// <param name="add2">The integer.</param>
        /// <returns>The matrix divided by the integer.</returns>
        public static Matrix operator /(Matrix add1, double add2)
        {
            return Operation(add1, add2, (x, y) => x / y);
        }
        
        /// <summary>
        /// Multiply a matrix and an integer together.
        /// </summary>
        /// <param name="add1">The matrix.</param>
        /// <param name="add2">The integer.</param>
        /// <returns>The matrix multiplied by the integer.</returns>
        public static Matrix operator *(Matrix add1, Matrix add2)
        {
            if (add1[0].Length != add2.Length)
                throw new ArgumentException("matrices passed in cannot be multiplied");
            if (add1.Length != add2[0].Length)
                throw new ArgumentException("matrices passed in cannot be multiplied");
            
            var result = new Matrix(add2.Length, add1.Length);
            
            for (var i = 0; i < add2.Length; i++)
            {
                for (var j = 0; j < add1.Length; j++)
                {
                    double cell = 0;

                    for (var k = 0; k < add2.Length; k++)
                        cell += add1[i, k]*add2[k, j];

                    result[i, j] = cell;
                }
            }

            return result;
        }

        /// <summary>
        /// Get matrix as a string.
        /// </summary>
        /// <returns>The matrix as a string.</returns>
        public override string ToString()
        {
            var output = "";

            for (var i = 0; i < _matrixContent.Length; i++)
            {
                for (var j = 0; j < _matrixContent[i].Length; j++)
                {
                    output += _matrixContent[i][j].ToString(System.Globalization.CultureInfo.InvariantCulture);
                    output += j < _matrixContent[i].Length - 1 ? " " : "";
                }

                output += i < _matrixContent.Length - 1 ? Environment.NewLine : "";
            }

            return output;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static Matrix Eye(int n)
        {
            var result = new Matrix(n, n);
            
            for (var i = 0; i < result._matrixContent.Length; i++)
                result[i, i] = 1;

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static Matrix Eye(int m, int n)
        {
            var result = new Matrix(m, n);
            
            for (var i = 0; i < result._matrixContent.Length; i++)
                if (i < n) result[i, i] = 1;
            
            return result;
        }

        /**********************************************
         * private constructor
         * provides input of a matrix x, and row index and colIndex
         * output is a matrix derived from x, which does not include 
         * elements from row and col provided
         * private becasue it is not for public consumption but only 
         * used by Determinant
        ***********************************************/
        private Matrix(Matrix x, int row, int coll)
        {
            int counteri = 0, counterj = 0;
            _matrixContent = new Vector[x._matrixContent.Length - 1];

            for (var i = 0; i < x._matrixContent.Length; i++)
            {
                if (i != row)
                    _matrixContent[counteri] = new Vector { Length = x._matrixContent[0].Length - 1 };
                
                var bIncrementcounter = false;
                
                for (var j = 0; j < x._matrixContent[0].Length; j++)
                {
                    if ((i == row) || (j == coll)) continue;
                    
                    _matrixContent[counteri][counterj++] = x._matrixContent[i][j];
                    bIncrementcounter = true;
                }

                if (!bIncrementcounter) continue;
                
                counteri++;
                counterj = 0;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">A square matrix is required to calculate determinant.</exception>
        public double Determinant()
        {
            //make sure current matrix is a square matrix
            var colNum = _matrixContent[0].Length;
            
            if (_matrixContent.Length != colNum)
                throw new InvalidOperationException("A square matrix is required to calculate determinant");
            
            double detNum = 0;
            
            if (colNum == 2)
                detNum = this[0][0] * this[1][1] - this[0][1] * this[1][0];
            else
            {
                for (var i = 0; i < colNum; i++)
                {
                    var x = new Matrix(this, 0, i);

                    detNum += (this[0][i]) * x.Determinant() * (int)Math.Pow(-1, i);
                }
            }

            return detNum;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Matrix Transposed()
        {
            var t = new Matrix(this[0].Length, Length);

            for (var i = 0; i < Length; i++)
                for (var j = 0; j < this[0].Length; j++)
                    t[i, j] = this[j, i];

            return t;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception">A square matrix is required to calculate the cofactor.</exception>
        public Matrix Cofactor()
        {
            if (Length != this[0].Length)
                throw new Exception("A square matrix is required to calculate the cofactor");
            
            var cf = new Matrix(Length, Length);

            for (var i = 0; i < Length; i++)
            {
                for (var j = 0; j < Length; j++)
                {
                    var minor = new Matrix(this, i, j);

                    cf[i, j] = minor.Determinant()*(int) Math.Pow(-1, i + j)*this[i, j];
                }
            }

            return cf;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception">A square matrix is required to calculate the adjugate.</exception>
        public Matrix Adjugate()
        {
            if (Length != this[0].Length)
                throw new Exception("A square matrix is required to calculate the adjugate");
            
            var x = Transposed();
            
            return x.Cofactor();
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception">
        /// A square matrix is required to calculate the inverted matrix.
        /// 
        /// This is not an invertible matrix because its determinant is 0.
        /// </exception>
        public Matrix Inverse()
        {
            if (Length != this[0].Length)
                throw new Exception("A square matrix is required to calculate the inverted matrix");
            
            var det = Determinant();

            if (Math.Abs(det) < 1)
                throw new Exception("This is not an invertible matrix because its determinant is 0");
            
            var i = Adjugate();
            
            return i / det;
        }


        /// <summary>
        /// Returns a matrix in reduced row echelon form.
        /// </summary>
        /// <returns></returns>
        public Matrix RREF()
        {
            // This version of the code originally comes from: http://pastebin.com/38dD47X2
            var matrix = this; //new Matrix(this,this.Length,this[0].Length);
            int lead = 0, rowCount = matrix.Length, columnCount = matrix[0].Length;
            for (var r = 0; r < rowCount; r++)
            {
                if (columnCount <= lead) break;
                
                var i = r;
                var columnMax = Math.Abs(Convert.ToDouble(matrix[i, lead]));

                // determine which value in the column has the highest absolute value
                for (var j = i; j < rowCount; ++j)
                {
                    if (!(Math.Abs(Convert.ToDouble(matrix[j, lead])) > columnMax))
                        continue;
                    
                    columnMax = Math.Abs(Convert.ToDouble( matrix[j, lead]));
                    i = j;
                }

                // swap the "lead" row with the current row in the algorithm
                if (r != i)
                {
                    for (var j = 0; j < columnCount; j++)
                    {
                        var temp = matrix[r, j];
                        
                        matrix[r, j] = matrix[i, j];
                        matrix[i, j] =temp;
                    }
                }

                var div = Convert.ToDouble( matrix[r, lead]);
                
                if (Math.Abs(div) < 1)
                    return matrix; // added to catch the case where the matrix cant be solved
                
                for (var j = 0; j < columnCount; j++)
                    matrix[r, j] /=div;
                
                for (var j = 0; j < rowCount; j++)
                {
                    if (j == r)
                        continue;
                    
                    var sub =Convert.ToDouble( matrix[j, lead]);
                    
                    for (var k = 0; k < columnCount; k++)
                        matrix[j, k] -= sub * matrix[r, k];
                }

                lead++;
            }

            return matrix;
        }

        /// <summary>
        /// Determines if <see cref="_matrixContent"/> is equal to <paramref name="other"/>'s _matrixContent.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        protected bool Equals(Matrix other)
        {
            return Equals(_matrixContent, other._matrixContent);
        }

        /// <summary>
        /// Checks if the matrix is equal to the given object.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            
            return obj.GetType() == GetType() && Equals((Matrix)obj);
        }

        /// <summary>
        /// Get the hashcode of the matrix.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return (_matrixContent != null ? _matrixContent.GetHashCode() : 0);
        }
    }
}