using System;

namespace Mathos.Geometry.Shapes
{
    /// <summary>
    /// Square shape
    /// </summary>
    public class Square : IShape2D
    {
        private double _length;

        /// <summary>
        /// Default constructor
        /// </summary>
        public Square() : this(0)
        {
        }

        /// <summary>
        /// Constructor with a double, "length", to base this square off of
        /// </summary>
        /// <param name="length"></param>
        public Square(double length)
        {
            _length = length < 0 ? 0 : length;
        }

        /// <summary>
        /// Gets or sets the length of the square
        /// </summary>
        public double Length
        {
            get { return _length; }
            set { _length = value < 0 ? 0 : value; }
        }

        /// <summary>
        /// Gets the area of the square
        /// </summary>
        public double Area
        {
            get { return _length * _length; }
        }

        /// <summary>
        /// Gets the perimeter of the square
        /// </summary>
        public double Perimeter
        {
            get { return _length * 4; }
        }

        /// <summary>
        /// Gets the diagonal of the square
        /// </summary>
        public double Diagonal
        {
            get { return Pythagorean.FindHypotenuse(_length, _length); }
        }

        #region Override Equals

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            var other = obj as Square;

            if (other == null)
                return false;

            return Math.Abs(_length - other._length) < 1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Square other)
        {
            if (other == null)
            {
                return false;
            }

            return Math.Abs(_length - other._length) < 1;
        }

        public override int GetHashCode()
        {
            return _length.GetHashCode();
        }

        /// <summary>
        /// The equalto operator
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(Square a, Square b)
        {
            // If both are null, or both are same instance, return true.
            if (ReferenceEquals(a, b))
                return true;

            // If one is null, but not both, return false.
            if (((object) a == null) || ((object) b == null))
                return false;

            return Math.Abs(a._length - b._length) < 1;
        }

        /// <summary>
        /// The not-equalto operator
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(Square a, Square b)
        {
            return ((a != null && b != null) && Math.Abs(a._length - b._length) > 0);
        }

        #endregion
    }
}
