using System;
using System.Collections.Generic;

namespace B_Geometry.Util
{
    public class Vector
    {
        #region Internal Member Variables

        /// <summary>
        /// The size of the vector
        /// </summary>
        private readonly int _nElements;

        /// <summary>
        /// Has vector been initialised
        /// </summary>
        public bool MIsInitialised;

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public Vector()
        {
        }

        public Vector(int n)
        {
            Elements = new double[n];

            for (var i = 0; i < n; i++)
                Elements[i] = 0.0;

            MIsInitialised = true;
            _nElements = n;
        }


        /// <summary>
        /// Create vector by passing an array of doubles
        /// </summary>
        /// <param name="vectorElements">Vector elements</param>
        public Vector(double[] vectorElements)
        {
            _nElements = vectorElements.Length;
            Elements = vectorElements;
            MIsInitialised = true;
        }

        /// <summary>
        /// Create vector by passing a list of doubles
        /// </summary>
        /// <param name="vectorElements">List of elements of vector</param>
        public Vector(List<double> vectorElements)
        {
            _nElements = vectorElements.Count;
            Elements = vectorElements.ToArray();
            MIsInitialised = true;
        }

        /// <summary>
        /// get/set vector elements.
        /// </summary>
        public double[] Elements { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Returns dimension of vector
        /// </summary>
        /// <returns></returns>
        public int VectorDimension()
        {
            return _nElements;
        }

        /// <summary>
        /// Addition operator override for vectors (v1 + v2)
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static Vector operator +(Vector v1, Vector v2)
        {
            // Check if vector are of same size
            if (v1.VectorDimension() != v2.VectorDimension())
                throw new Exception("Can't add because vectors are not of the same size");

            var resultElements = new List<double>();
            
            // Perform addition of elements in a loop.
            for (var i = 0; i < v1.VectorDimension(); i++)
                resultElements.Add(v1.Elements[i] + v2.Elements[i]);

            return new Vector(resultElements);
        }

        /// <summary>
        /// Subtract operator override for vectors (v1 - v2)
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static Vector operator -(Vector v1, Vector v2)
        {
            // Check if vector are of same size
            if (v1.VectorDimension() != v2.VectorDimension())
                throw new Exception("Can't subtract because vectors are not of the same size");

            var resultElements = new List<double>();

            // In a loop, subtract elements of v1 from v2
            for (var i = 0; i < v1.VectorDimension(); i++)
                resultElements.Add(v1.Elements[i] - v2.Elements[i]);

            return new Vector(resultElements);
        }

        /// <summary>
        /// Scalar product double a * Vector v1
        /// </summary>
        /// <param name="a"></param>
        /// <param name="v1"></param>
        /// <returns></returns>
        public static Vector ScalarProduct(double a, Vector v1)
        {
            var resultElements = new List<double>();

            // Multiply each element of v1 with a
            for (var i = 0; i < v1.VectorDimension(); i++)
                resultElements.Add(a*v1.Elements[i]);

            return new Vector(resultElements);
        }

        /// <summary>
        /// Multiplies a Vector by a scalar and modifies the Vector itself
        /// </summary>
        /// <param name="a">Scalar.</param>
        public void ScalarProduct(double a)
        {
            for (var i = 0; i < _nElements; i++)
                Elements[i] = a*Elements[i];
        }


        public static Vector Subtract(Vector v1, Vector v2)
        {
            // Check dimensions:
            if (v1.VectorDimension() != v2.VectorDimension())
                throw new Exception("Wrong dimensions");

            var resultElements = new double[v1.VectorDimension()];

            for (var i = 0; i < v1.VectorDimension(); i++)
                resultElements[i] = v1.Elements[i] - v2.Elements[i];

            return new Vector(resultElements);
        }

        public void Subtract(Vector v2)
        {
            // Check dimensions
            if (_nElements != v2.VectorDimension())
                throw new Exception("Wrong dimensions");

            for (var i = 0; i < _nElements; i++)
                Elements[i] = Elements[i] - v2.Elements[i];
        }

        public double DotProduct(Vector v2)
        {
            // Check dimensions
            if (_nElements != v2.VectorDimension())
                throw new Exception("Wrong dimension");

            var result = 0.0;

            for (var i = 0; i < _nElements; i++)
                result += Elements[i]*v2.Elements[i];

            return result;
        }

        public double GetLength()
        {
            return Math.Sqrt(DotProduct(this));
        }

        #endregion
    }
}
