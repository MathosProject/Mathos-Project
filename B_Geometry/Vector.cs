using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_Geometry
{
    public class Vector
    {
        #region Internal Member Variables
        /// <summary>
        /// The elements of the vector
        /// </summary>
        private double[] m_elements = null;

        /// <summary>
        /// The size of the vector
        /// </summary>
        private int n_elements = 0;

        /// <summary>
        /// Has vector been initialised
        /// </summary>
        private bool m_is_initialised = false;

        #endregion

        #region Constructors

        /// <summary>
        /// Null constructor
        /// </summary>
        public Vector()
        {
            /// Do nothing
            /// 
        }

        public Vector(int n)
        {
            this.m_elements = new double[n];
            for (int i = 0; i < n; i++)
            {
                this.m_elements[i] = 0.0;
            }
            this.m_is_initialised = true;
            this.n_elements = n;
        }


        /// <summary>
        /// Create vector by passing an array of doubles
        /// </summary>
        /// <param name="vector_elements">Vector elements</param>
        public Vector(double[] vector_elements)
        {
            this.n_elements = vector_elements.Length;
            this.m_elements = vector_elements;
            this.m_is_initialised = true;
        }

        /// <summary>
        /// get/set vector elements.
        /// </summary>
        public double[] Elements
        {
            get
            {
                return this.m_elements;
            }
            set
            {
                this.m_elements = value;
            }
        }

        /// <summary>
        /// Create vector by passing a list of doubles
        /// </summary>
        /// <param name="vector_elements">List of elements of vector</param>
        public Vector(List<double> vector_elements)
        {
            this.n_elements = vector_elements.Count;
            this.m_elements = vector_elements.ToArray();
            this.m_is_initialised = true;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Returns dimension of vector
        /// </summary>
        /// <returns></returns>
        public int VectorDimension()
        {
            return this.n_elements;
        }

        /// <summary>
        /// Addition operator override for vectors (v1 + v2)
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static Vector operator +(Vector v1, Vector v2)
        {
            /// Check if vector are of same size
            if (v1.VectorDimension() != v2.VectorDimension())
            {
                throw new Exception("Can't add because vectors are not of the same size");
            }

            List<double> result_elements = new List<double>();
            
            /// Perform addition of elements in a loop.
            for (int i = 0; i < v1.VectorDimension(); i++)
            {
                result_elements.Add(v1.Elements[i] + v2.Elements[i]);
            }

            return new Vector(result_elements);
        }

        /// <summary>
        /// Subtract operator override for vectors (v1 - v2)
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static Vector operator -(Vector v1, Vector v2)
        {
            /// Check if vector are of same size
            if (v1.VectorDimension() != v2.VectorDimension())
            {
                throw new Exception("Can't subtract because vectors are not of the same size");
            }

            List<double> result_elements = new List<double>();

            /// In a loop, subtract elements of v1 from v2
            for (int i = 0; i < v1.VectorDimension(); i++)
            {
                result_elements.Add(v1.Elements[i] - v2.Elements[i]);
            }

            return new Vector(result_elements);
        }

        /// <summary>
        /// Scalar product double a * Vector v1
        /// </summary>
        /// <param name="a"></param>
        /// <param name="v1"></param>
        /// <returns></returns>
        public static Vector ScalarProduct(double a, Vector v1)
        {
            List<double> result_elements = new List<double>();

            /// Multiply each element of v1 with a
            for (int i = 0; i < v1.VectorDimension(); i++)
            {
                result_elements.Add(a * v1.Elements[i]);
            }

            return new Vector(result_elements);
        }

        /// <summary>
        /// Multiplies a Vector by a scalar and modifies the Vector itself
        /// </summary>
        /// <param name="a">Scalar.</param>
        public void ScalarProduct(double a)
        {
            for (int i = 0; i < this.n_elements; i++)
            {
                this.m_elements[i] = a * this.m_elements[i];
            }
        }


        public static Vector Subtract(Vector v1, Vector v2)
        {
            /// Check dimensions:
            if (v1.VectorDimension() != v2.VectorDimension())
            {
                throw new Exception("Wrong dimensions");
            }

            double[] result_elements = new double[v1.VectorDimension()];
            for (int i = 0; i < v1.VectorDimension(); i++)
            {
                result_elements[i] = v1.Elements[i] - v2.Elements[i];
            }

            Vector result = new Vector(result_elements);
            return result;
        }

        public void Subtract(Vector v2)
        {
            /// Check dimensions
            if (this.n_elements != v2.VectorDimension())
            {
                throw new Exception("Wrong dimensions");
            }

            for (int i = 0; i < this.n_elements; i++)
            {
                this.m_elements[i] = this.m_elements[i] - v2.Elements[i];
            }
        }

        public double DotProduct(Vector v2)
        {
            /// Check dimensions
            if (this.n_elements != v2.VectorDimension())
            {
                throw new Exception("Wrong dimension");
            }

            double result = 0.0;
            for (int i = 0; i < this.n_elements; i++)
            {
                result += this.Elements[i] * v2.Elements[i];
            }

            return result;
        }

        public double GetLength()
        {
            double dot = this.DotProduct(this);
            return Math.Sqrt(dot);
        }

        #endregion

    }
}
