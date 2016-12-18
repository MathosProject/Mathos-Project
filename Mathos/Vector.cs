using System;
using System.Text;

namespace Mathos
{
    /// <summary>
    /// Represents a vector.
    /// </summary>
    public class Vector
    {
        private double[] _vectorContent;

        /// <summary>
        /// Default constructor
        /// </summary>
        public Vector()
            : this(new double[0])
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
        /// Add a <paramref name="number"/>.
        /// </summary>
        /// <param name="number">The number to add.</param>
        public void Add(double number)
        {
            Array.Resize(ref _vectorContent, _vectorContent.Length+1);

            _vectorContent[_vectorContent.Length-1] = number;
        }

        /// <summary>
        /// Get the size of <see cref="_vectorContent"/>.
        /// </summary>
        public int Length
        {
            get { return _vectorContent.Length; }
            internal set { Array.Resize(ref _vectorContent, value); }
        }

        /// <summary>
        /// The indexer
        /// </summary>
        /// <param name="index">The index.</param>
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
        
        /// <summary>
        /// Get the vector as a string.
        /// </summary>
        /// <returns>The vector as a string.</returns>
        public override string ToString()
        {
            var output = new StringBuilder();
            
            for (var i = 0; i < _vectorContent.Length; i++)
            {
                output.Append(_vectorContent[i].ToString(System.Globalization.CultureInfo.InvariantCulture));
                output.Append(i < _vectorContent.Length - 1 ? " " : "");
            }
            
            return output.ToString();
        }
        
        /// <summary>
        /// Check if the vector is equal to the given object, <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The object to compare to.</param>
        /// <returns>True if the vector is equal to the given object.</returns>
        public override bool Equals(object obj)
        {
            if ((obj == null) || (obj.GetType() != GetType()))
                return false;

            var vector = (Vector)obj;
            
            return this == vector;
        }

        /// <summary>
        /// The hashcode the the vector.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return _vectorContent.GetHashCode();
        }

        // implicit coversion operators

        /// <summary>
        /// Vector initialization form an array of int16.
        /// </summary>
        /// <param name="input">The array.</param>
        /// <returns>A vector from the array.</returns>
        public static implicit operator Vector(short[] input)
        {
            var vector = new Vector(input.Length);

            for (var i = 0; i < input.Length; i++)
                vector[i] = input[i];

            return vector;
        }

        /// <summary>
        /// Vector initialization form an array of ints.
        /// </summary>
        /// <param name="input">The array.</param>
        /// <returns>A vector from the array.</returns>
        public static implicit operator Vector(int[] input)
        {
            var vector = new Vector(input.Length);

            for (var i = 0; i < input.Length; i++)
                vector[i] = input[i];

            return vector;
        }

        /// <summary>
        /// Vector initialization form an array of int64.
        /// </summary>
        /// <param name="input">The array.</param>
        /// <returns>A vector from the array.</returns>
        public static implicit operator Vector(long[] input)
        {
            var vector = new Vector();

            for (var i = 0; i < input.Length; i++)
                vector[i] = input[i];

            return vector;
        }

        /// <summary>
        /// Vector initialization form an array of doubles.
        /// </summary>
        /// <param name="input">The array.</param>
        /// <returns>A vector from the array.</returns>
        public static implicit operator Vector(double[] input)
        {
            var vector = new Vector();

            for (var i = 0; i < input.Length; i++)
                vector[i] = input[i];

            return vector;
        }

        // overrding existing operators

        /// <summary>
        /// Add two vectors together.
        /// </summary>
        /// <param name="vec1">The first vector.</param>
        /// <param name="vec2">The second vector.</param>
        /// <returns>The two vectors added together.</returns>
        public static Vector operator +(Vector vec1, Vector vec2)
        {
            return Operation(vec1, vec2, (x, y) => x + y);
        }

        /// <summary>
        /// Minus two vectors.
        /// </summary>
        /// <param name="vec1">The first vector.</param>
        /// <param name="vec2">The second vector.</param>
        /// <returns><paramref name="vec2"/> substracted from <paramref name="vec1"/>.</returns>
        public static Vector operator -(Vector vec1, Vector vec2)
        {
            return Operation(vec1, vec2, (x, y) => x - y);
        }

        /// <summary>
        /// Multiply two vectors together.
        /// </summary>
        /// <param name="vec1">The first vector.</param>
        /// <param name="vec2">The second vector.</param>
        /// <returns>The two vectors multiplied together.</returns>
        public static Vector operator *(Vector vec1, Vector vec2)
        {
            return Operation(vec1, vec2, (x, y) => x * y);
        }

        /// <summary>
        /// Divide two vectors.
        /// </summary>
        /// <param name="vec1">The first vector.</param>
        /// <param name="vec2">The second vector.</param>
        /// <returns><paramref name="vec1"/> divided by <paramref name="vec2"/>.</returns>
        public static Vector operator /(Vector vec1, Vector vec2)
        {
            return Operation(vec1, vec2, (x, y) => x / y);
        }

        //comparsion
        /// <summary>
        /// Check if two vectors are equal.
        /// </summary>
        /// <param name="vec1">The first vector.</param>
        /// <param name="vec2">The second vector.</param>
        /// <returns>True if the two vectors are equal.</returns>
        public static bool operator ==(Vector vec1, Vector vec2)
        {
            return ComparsionOperation(vec1, vec2, (x, y) => Math.Abs(x - y) < 1);
        }

        /// <summary>
        /// Check if two vectors are not equal.
        /// </summary>
        /// <param name="vec1">The first vector.</param>
        /// <param name="vec2">The second vector.</param>
        /// <returns>True if the two vectors are not equal.</returns>
        public static bool operator !=(Vector vec1, Vector vec2)
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
                    result[i] = operation(vec1[i], vec2[i]);
                else
                    result[i] = maxLengthVector[i];
            }

            return result;
        }

        private static bool ComparsionOperation(Vector vec1, Vector vec2, Func<double, double, bool> comparsionOperation)
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
                    if (i >= minLengthVector.Length)
                        continue;
                    if (!comparsionOperation(vec1[i], vec2[i]))
                        return false;
                }
            }
            else
                return false;

            return true;
        }
    }
}
