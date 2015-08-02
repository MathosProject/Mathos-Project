using System;

namespace Mathos.Geometry.Shapes
{
    /// <summary>
    /// Rectangle shape
    /// </summary>
    public class Rectangle : IShape2D
    {
        private double _length;
        private double _width;

        /// <summary>
        /// Default constructor
        /// </summary>
        public Rectangle() : this(0, 0)
        {
        }

        /// <summary>
        /// Constructor with a length and width
        /// </summary>
        /// <param name="length"></param>
        /// <param name="width"></param>
        public Rectangle(double length, double width)
        {
            _length = length < 0 ? 0 : length;
            _width = width < 0 ? 0 : width;
        }

        /// <summary>
        /// Gets or sets the length of the rectangle
        /// </summary>
        public double Length
        {
            get { return _length; }
            set { _length = value < 0 ? 0 : value; }
        }

        /// <summary>
        /// Gets or sets the width of the rectangle
        /// </summary>
        public double Width
        {
            get { return _width; }
            set { _width = value < 0 ? 0 : value; }
        }

        /// <summary>
        /// Gets the area of the rectangle
        /// </summary>
        public double Area
        {
            get { return _length * _width; }
        }

        /// <summary>
        /// Gets the perimeter of the rectangle
        /// </summary>
        public double Perimeter
        {
            get { return _length * 2 + _width * 2; }
        }

        /// <summary>
        /// Gets the diagonal of the rectangle
        /// </summary>
        public double Diagonal
        {
            get { return Pythagorean.FindHypotenuse(_length, _width); }
        }

        #region Override Equals

        /// <summary>
        /// Checks whether the rectangle is equal to the given object.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            var other = obj as Rectangle;

            return other != null && (Math.Abs(_length - other._length) < 1 && Math.Abs(_width - other._width) < 1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Rectangle other)
        {
            return other != null && (Math.Abs(_length - other._length) < 1 && Math.Abs(_width - other._width) < 1);
        }

        /// <summary>
        /// Gets the hashcode of the rectangle.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return _length.GetHashCode() ^ _width.GetHashCode();
        }

        /// <summary>
        /// The equalto operator
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(Rectangle a, Rectangle b)
        {
            // If both are null, or both are same instance, return true.
            // If one is null, but not both, return false.
            return ReferenceEquals(a, b) || ((object) a != null) && ((object) b != null) &&
                   (Math.Abs(a._length - b._length) < 1 && Math.Abs(a._width - b._width) < 1);
        }

        /// <summary>
        /// The not-equalto operator
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(Rectangle a, Rectangle b)
        {
            return ((a != null && b != null) && Math.Abs(a._length - b._length) > 0) || ((a != null && b != null) && Math.Abs(a._width - b._width) > 0);
        }

        #endregion
    }
}
