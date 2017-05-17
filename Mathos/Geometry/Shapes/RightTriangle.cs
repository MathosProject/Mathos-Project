using System;

namespace Mathos.Geometry.Shapes
{
    /// <summary>
    /// A right triangle.
    /// </summary>
    public class RightTriangle : IShape2D
    {
        private double _length;
        private double _height;
        
        /// <summary>
        /// Constructor with a <paramref name="length"/> and <paramref name="height"/>.
        /// </summary>
        /// <param name="length">The length.</param>
        /// <param name="height">The height.</param>
        public RightTriangle(double length, double height)
        {
            _length = length < 0 ? 0 : length;
            _height = height < 0 ? 0 : height;

            if(_length > 0 && _height > 0)
                Hypotenuse = Pythagorean.FindHypotenuse(_length, _height);
        }

        /// <summary>
        /// Gets or sets the length of the triangle.
        /// </summary>
        public double Length
        {
            get { return _length; }
            set { _length = value < 0 ? 0 : value; }
        }

        /// <summary>
        /// Gets or sets the height of the triangle.
        /// </summary>
        public double Height
        {
            get { return _height; }
            set { _height = value < 0 ? 0 : value; }
        }

        /// <summary>
        /// Gets the hypotenuse of the triangle.
        /// </summary>
        public double Hypotenuse { get; }

        /// <summary>
        /// Gets the area of the triangle.
        /// </summary>
        public double Area => _length * _height / 2;

        /// <summary>
        /// Returns the perimeter of the triangle.
        /// </summary>
        public double Perimeter => _length + _height + Pythagorean.FindHypotenuse(_length, _height);

        #region Override Equals

        /// <summary>
        /// Checks whether the right triangle is equal to the given object.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            var other = obj as RightTriangle;

            return other != null && Math.Abs(_length - other._length) < 1 && Math.Abs(_height - other._height) < 1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(RightTriangle other)
        {
            return other != null && Math.Abs(_length - other._length) < 1 && Math.Abs(_height - other._height) < 1;
        }

        /// <summary>
        /// Gets the hashcode of the right triangle.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return Length.GetHashCode() ^ Height.GetHashCode();
        }

        /// <summary>
        /// The equalto operator
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(RightTriangle a, RightTriangle b)
        {
            // If both are null, or both are same instance, return true.
            // If one is null, but not both, return false.
            return ReferenceEquals(a, b) || (object) a != null && (object) b != null && Math.Abs(a._length - b._length) < 1 && Math.Abs(a._height - b._height) < 1;
        }

        /// <summary>
        /// The not-equalto operator
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(RightTriangle a, RightTriangle b)
        {
            return a != null && b != null && Math.Abs(a._length - b._length) > 0 || a != null && b != null && Math.Abs(a._length - b._length) > 0;
        }

        #endregion
    }
}
