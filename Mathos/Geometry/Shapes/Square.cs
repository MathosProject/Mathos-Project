using System;

namespace Mathos.Geometry.Shapes
{
    /// <summary>
    /// A square.
    /// </summary>
    public class Square : IShape2D
    {
        private double _length;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Square() : this(0)
        {
        }

        /// <summary>
        /// Constructor with a <paramref name="length"/>.
        /// </summary>
        /// <param name="length">The length.</param>
        public Square(double length)
        {
            _length = length < 0 ? 0 : length;
        }

        /// <summary>
        /// Gets or sets the length of the square.
        /// </summary>
        public double Length
        {
            get { return _length; }
            set { _length = value < 0 ? 0 : value; }
        }

        /// <summary>
        /// Gets the area of the square.
        /// </summary>
        public double Area
        {
            get { return _length * _length; }
        }

        /// <summary>
        /// Gets the perimeter of the square.
        /// </summary>
        public double Perimeter
        {
            get { return _length * 4; }
        }

        /// <summary>
        /// Gets the diagonal of the square.
        /// </summary>
        public double Diagonal
        {
            get { return Pythagorean.FindHypotenuse(_length, _length); }
        }

        #region Override Equals

        /// <summary>
        /// Checks whether the square is equal to the given object.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            var other = obj as Square;

            return (other != null) && (Math.Abs(_length - other._length) < 1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Square other)
        {
            return (other != null) && (Math.Abs(_length - other._length) < 1);
        }

        /// <summary>
        /// Gets the hashcode of the square.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return Length.GetHashCode();
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
            // If one is null, but not both, return false.
            return ReferenceEquals(a, b) || (((object) a != null) && ((object) b != null) && (Math.Abs(a._length - b._length) < 1));
        }

        /// <summary>
        /// The not-equalto operator
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(Square a, Square b)
        {
            return (a != null) && (b != null) && (Math.Abs(a._length - b._length) > 0);
        }

        #endregion
    }
}
