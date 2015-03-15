using System;
using System.Linq;

namespace Mathos
{
    //should support complex numbers, surds, etc.
    // we probably need a struct - "Number"
    /// <summary>
    /// 
    /// </summary>
    public class Vector
    {
        double[] _vectorContent;

        /// <summary>
        /// Default constructor
        /// </summary>
        public Vector()
            : this(new double[] { })
        { 
        }

        /// <summary>
        /// Constructor that takes a number of parameters
        /// </summary>
        /// <param name="vector"></param>
        public Vector(params double[] vector)
        {
            _vectorContent = vector;
        }

        /// <summary>
        /// Constructor that takes a double number
        /// </summary>
        /// <param name="number"></param>
        public void Add(double number)
        {
            Array.Resize(ref _vectorContent, _vectorContent.Length+1);
            _vectorContent[_vectorContent.Length-1] = number;
        }

        /// <summary>
        /// Gets the size of "_vectorContent"
        /// </summary>
        public int Length
        {
            get { return _vectorContent.Length; }
            internal set { Array.Resize(ref _vectorContent, value); }
        }

        /// <summary>
        /// The indexer
        /// </summary>
        /// <param name="index"></param>
        public double this[int index]
        {
            get
            {
                return _vectorContent[index];
            }
            set
            {
                _vectorContent[index] = value;
            }
        }

        //overriding ToString, Equals, GetHashCode
        public override string ToString()
        {
            var output = "";
            
            for (var i = 0; i < _vectorContent.Length; i++)
            {
                output += _vectorContent[i].ToString(System.Globalization.CultureInfo.InvariantCulture);
                output += i < _vectorContent.Length - 1 ? " " : "";
            }
            
            return output;
        }
        
        public override bool Equals(object obj)
        {
            if ((obj == null) || (obj.GetType() != GetType()))
                return false;

            var vector = (Vector)obj;
            
            return (this == vector);
        }

        public override int GetHashCode()
        {
            return _vectorContent.GetHashCode();
        }

        // implicit coversion operators
        /// <summary>
        /// Vector initialization form an array of Int16
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static implicit operator Vector(Int16[] input)
        {
            var vector = new Vector(input.Length);
            
            for (var i = 0; i < input.Length; i++)
            {
                vector[i] = input[i];
            }
            
            return vector;
        }

        /// <summary>
        /// Vector initialization form an array of Int32
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static implicit operator Vector(Int32[] input)
        {
            var vector = new Vector(input.Length);
            
            for (var i = 0; i < input.Length; i++)
            {
                vector[i] = input[i];
            }
            
            return vector;
        }

        /// <summary>
        /// Vector initialization form an array of Int64
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static implicit operator Vector(Int64[] input)
        {
            var vector = new Vector();
            
            for (var i = 0; i < input.Length; i++)
            {
                vector[i] = input[i];
            }
            
            return vector;
        }

        /// <summary>
        /// Vector initialization form an array of doubles
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static implicit operator Vector(double[] input)
        {
            var vector = new Vector();
            
            for (var i = 0; i < input.Length; i++)
            {
                vector[i] = input[i];
            }

            return vector;
        }

        // overrding existing operators
        /// <summary>
        /// The plus operator
        /// </summary>
        /// <param name="vec1"></param>
        /// <param name="vec2"></param>
        /// <returns></returns>
        public static Vector operator +(Vector vec1, Vector vec2)
        {
            return Operation(vec1, vec2, (x, y) => x + y);
        }

        /// <summary>
        /// The minus operator
        /// </summary>
        /// <param name="vec1"></param>
        /// <param name="vec2"></param>
        /// <returns></returns>
        public static Vector operator -(Vector vec1, Vector vec2)
        {
            return Operation(vec1, vec2, (x, y) => x - y);
        }

        /// <summary>
        /// The multiplication operator
        /// </summary>
        /// <param name="vec1"></param>
        /// <param name="vec2"></param>
        /// <returns></returns>
        public static Vector operator *(Vector vec1, Vector vec2)
        {
            return Operation(vec1, vec2, (x, y) => x * y);
        }

        /// <summary>
        /// The division operator
        /// </summary>
        /// <param name="vec1"></param>
        /// <param name="vec2"></param>
        /// <returns></returns>
        public static Vector operator /(Vector vec1, Vector vec2)
        {
            return Operation(vec1, vec2, (x, y) => x / y);
        }

        //comparsion
        /// <summary>
        /// The comparsion operator
        /// </summary>
        /// <param name="vec1"></param>
        /// <param name="vec2"></param>
        /// <returns></returns>
        public static Boolean operator ==(Vector vec1, Vector vec2)
        {
            return ComparsionOperation(vec1, vec2, (x, y) => Math.Abs(x - y) < 1);
        }

        /// <summary>
        /// The not-comparsion operator
        /// </summary>
        /// <param name="vec1"></param>
        /// <param name="vec2"></param>
        /// <returns></returns>
        public static Boolean operator !=(Vector vec1, Vector vec2)
        {
            return !(vec1 == vec2);
        }

        //other functions
        private static Vector Operation(Vector vec1, Vector vec2, Func<double,double,double> operation)
        {
            Vector maxLengthVector;
            Vector minLengthVector;
            
            if (vec1.Length <= vec2.Length)
            {
                minLengthVector = vec1;
                maxLengthVector = vec2;
            }
            else
            {
                minLengthVector = vec2;
                maxLengthVector = vec1;
            }

            var result = new Vector { Length = maxLengthVector.Length };
            
            for (var i = 0; i < maxLengthVector.Length; i++)
            {
                if (i < minLengthVector.Length)
                {
                    result[i] = operation(vec1[i], vec2[i]);
                }
                else
                {
                    result[i] = maxLengthVector[i];
                }
            }

            return result;
        }

        private static Boolean ComparsionOperation(Vector vec1, Vector vec2, Func<double, double, bool> comparsionOperation)
        {
            Vector maxLengthVector;
            Vector minLengthVector;

            if (vec1.Length <= vec2.Length)
            {
                minLengthVector = vec1;
                maxLengthVector = vec2;
            }
            else
            {
                minLengthVector = vec2;
                maxLengthVector = vec1;
            }

            if (comparsionOperation(maxLengthVector.Length, minLengthVector.Length))
            {
                for (var i = 0; i < maxLengthVector.Length; i++)
                {
                    if (i >= minLengthVector.Length) continue;
                    
                    if (!comparsionOperation(vec1[i], vec2[i]))
                        return false;
                }
            }
            else
            {
                return false;
            }

            return true;
        }
    }

    /*
     * Matrix class needs functions such as those defined at
     * http://www.mathworks.se/help/techdoc/ref/f16-5872.html#f16-9856
     * 
     */
    /// <summary>
    /// 
    /// </summary>
    public class Matrix
    {
        readonly Vector[] _matrixContent;

        /// <summary>
        /// Default contructor
        /// </summary>
        public Matrix()
            : this(new Vector[] { })
        { 
        }

        /// <summary>
        /// Contructor for defining the "rows" and "colls"
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="colls"></param>
        public Matrix(int rows, int colls)
        {
            _matrixContent = new Vector[rows];
            
            for (var i = 0; i < rows; i++)
            {
                _matrixContent[i] = new Vector { Length = colls };
            }
        }
       
        /// <summary>
        /// Contructor that takes a number of Vectors
        /// </summary>
        /// <param name="matrix"></param>
        public Matrix(params Vector[] matrix)
        {
            _matrixContent = matrix;
        }

        /// <summary>
        /// The indexer
        /// </summary>
        /// <param name="index"></param>
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
        /// The double indexer
        /// </summary>
        /// <param name="row"></param>
        /// <param name="coll"></param>
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
        /// Gets the length of "_matrixContent"
        /// </summary>
        public int Length { get { return _matrixContent.Length; } }

        /// <summary>
        /// The Matrix initialization of a jagged array of doubles
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static implicit operator Matrix(double[][] input)
        {
            var vector = new Matrix(input.Length,input[0].Length);

            for (var i = 0; i < input.Length; i++)
            {
                for (var j = 0; j < input[i].Length; j++)
                {
                    vector[i, j] = input[i][j];
                }   
            }

            return vector;
        }

        /// <summary>
        /// The comparsion operator
        /// </summary>
        /// <param name="add1"></param>
        /// <param name="add2"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static bool operator==(Matrix add1, Matrix add2)
        {
            if (add1 != null && (add2 != null && add1._matrixContent.Length != add2._matrixContent.Length))
                throw new ArgumentException("Matrix passed in does not have the same order as matrix to be added to.");
            if (add2 != null && (add1 != null && add1._matrixContent[0].Length != add2._matrixContent[0].Length))
                throw new ArgumentException("Matrix passed in does not have the same order as matrix to be added to.");

            return !(add2 != null) || !add2._matrixContent.Where((t, i) => add1 != null && add1._matrixContent[i] != t).Any();
        }

        /// <summary>
        /// The not-comparsion operator
        /// </summary>
        /// <param name="add1"></param>
        /// <param name="add2"></param>
        /// <returns></returns>
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
        /// The plus operator
        /// </summary>
        /// <param name="add1"></param>
        /// <param name="add2"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static Matrix operator+(Matrix add1, Matrix add2)
        {
            if (add1._matrixContent.Length != add2._matrixContent.Length)
                throw new ArgumentException("Matrix passed in does not have the same order as matrix to be added to.");
            if (add1._matrixContent[0].Length != add2._matrixContent[0].Length)
                throw new ArgumentException("Matrix passed in does not have the same order as matrix to be added to.");

            var result = Operation(add1, add2, (x, y) => x + y);
            return result;
            
        }

        /// <summary>
        /// The minus operator
        /// </summary>
        /// <param name="add1"></param>
        /// <param name="add2"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static Matrix operator-(Matrix add1, Matrix add2)
        {
            if (add1._matrixContent.Length != add2._matrixContent.Length)
                throw new ArgumentException("Matrix passed in does not have the same order as matrix to be added to.");
            if (add1._matrixContent[0].Length != add2._matrixContent[0].Length)
                throw new ArgumentException("Matrix passed in does not have the same order as matrix to be added to.");

            var result = Operation(add1, add2, (x, y) => x - y);
            
            return result;

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
        /// The plus operator
        /// </summary>
        /// <param name="add1"></param>
        /// <param name="add2"></param>
        /// <returns></returns>
        public static Matrix operator +(Matrix add1, int add2)
        {
            return Operation(add1, add2, (x, y) => x + y);
        }

        /// <summary>
        /// The plus operator
        /// </summary>
        /// <param name="add2"></param>
        /// <param name="add1"></param>
        /// <returns></returns>
        public static Matrix operator +(int add2, Matrix add1)
        {
            return add1 + add2;
        }

        /// <summary>
        /// The multiplication operator
        /// </summary>
        /// <param name="add1"></param>
        /// <param name="add2"></param>
        /// <returns></returns>
        public static Matrix operator *(Matrix add1, int add2)
        {
            return Operation(add1, add2, (x, y) => x * y);
        }

        /// <summary>
        /// The multiplication operator
        /// </summary>
        /// <param name="add2"></param>
        /// <param name="add1"></param>
        /// <returns></returns>
        public static Matrix operator *(int add2, Matrix add1)
        {
            return add1 * add2;
        }

        /// <summary>
        /// The minus operator
        /// </summary>
        /// <param name="add1"></param>
        /// <param name="add2"></param>
        /// <returns></returns>
        public static Matrix operator -(Matrix add1, int add2)
        {
            return Operation(add1, add2, (x, y) => x - y);
        }

        /// <summary>
        /// The minus operator
        /// </summary>
        /// <param name="add2"></param>
        /// <param name="add1"></param>
        /// <returns></returns>
        public static Matrix operator -(int add2, Matrix add1)
        {
            return (add1 - add2) * -1;
        }

        /// <summary>
        /// The division operator
        /// </summary>
        /// <param name="add1"></param>
        /// <param name="add2"></param>
        /// <returns></returns>
        public static Matrix operator /(Matrix add1, double add2)
        {
            return Operation(add1, add2, (x, y) => x / y);
        }
        
        /// <summary>
        /// The multiplication operator
        /// </summary>
        /// <param name="add1"></param>
        /// <param name="add2"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
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
                    {
                        cell += add1[i, k] * add2[k, j];
                    }

                    result[i, j] = cell;
                }
            }

            return result;
        }

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
            int j;
            
            for ( j = 0; j < result._matrixContent.Length;j++ )
                result[j, j] = 1;

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
            int j;
            
            for (j = 0; j < result._matrixContent.Length; j++)
                if (j <n) result[j, j] = 1;
            
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
        /// <exception cref="InvalidOperationException"></exception>
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
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public Matrix Cofactor()
        {
            if (Length != this[0].Length)
                throw new Exception("A square matrix is required to calculate the cofactor");
            
            var cf = new Matrix(Length, Length);
            
            for (var i = 0; i < Length; i++)
                for (var j = 0; j < Length; j++)
                {
                    var minor = new Matrix(this, i, j);
                    cf[i, j] = minor.Determinant() * (int)Math.Pow(-1, i + j) * this[i, j];
                }

            return cf;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public Matrix Adjugate()
        {
            if (Length != this[0].Length)
                throw new Exception("A square matrix is required to calculate the adjugate");
            
            var x = Transposed();
            
            return x.Cofactor();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
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
        /// Determins if "_matrixContent" is equal to "other"'s "_matrixContent"
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        protected bool Equals(Matrix other)
        {
            return Equals(_matrixContent, other._matrixContent);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            
            return obj.GetType() == GetType() && Equals((Matrix)obj);
        }

        public override int GetHashCode()
        {
            return (_matrixContent != null ? _matrixContent.GetHashCode() : 0);
        }
    }
}
