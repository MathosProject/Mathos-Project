using System;

namespace Mathos.Geometry.Shapes
{
    /// <summary>
    /// A square pyramid.
    /// </summary>
    public class SquarePyramid : IShape3D
    {
        private readonly Square _squareBase;
        private double _height;

        /// <summary>
        /// Default constructor
        /// </summary>
        public SquarePyramid() : this(new Square(), 0)
        {
        }

        /// <summary>
        /// Constructor with a square, "squarebase", and a double, "height", to base this pyramid off of
        /// </summary>
        /// <param name="squareBase"></param>
        /// <param name="height"></param>
        public SquarePyramid(Square squareBase, double height)
        {
            _squareBase = squareBase;
            _height = height < 0 ? 0 : height;
        }

        /// <summary>
        /// Constructor with two doubles, "length" and "height", to base this pyramid off of
        /// </summary>
        /// <param name="length"></param>
        /// <param name="height"></param>
        public SquarePyramid(double length, double height)
        {
            _squareBase = new Square(length);
            _height = height < 0 ? 0 : height;
        }

        /// <summary>
        /// Gets or sets the length of the square base
        /// </summary>
        public double Length
        {
            get { return _squareBase.Length; }
            set { _squareBase.Length = value; }
        }

        /// <summary>
        /// Gets or sets the height of the square pyramid
        /// </summary>
        public double Height
        {
            get { return _height; }
            set { _height = value < 0 ? 0 : value; }
        }

        /// <summary>
        /// Gets the area of the square pyramid
        /// </summary>
        public double Volume
        {
            get { return _squareBase.Area * _height / 3; }
        }

        /// <summary>
        /// Gets the surface area of the square pyramid
        /// </summary>
        public double SurfaceArea
        {
            get 
            { 
                return _squareBase.Area + _squareBase.Perimeter * Pythagorean.FindHypotenuse(_squareBase.Length / 2, _height) / 2; 
            }
        }

        #region Override Equals

        /// <summary>
        /// Checks whether the square pyramid is equal to the given object.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            var other = obj as SquarePyramid;

            return other != null && _squareBase == other._squareBase && Math.Abs(_height - other._height) < 1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(SquarePyramid other)
        {
            return other != null && _squareBase == other._squareBase && Math.Abs(_height - other._height) < 1;
        }

        /// <summary>
        /// Gets the hashcode of the square pyramid.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return _squareBase.GetHashCode() ^ _height.GetHashCode();
        }

        /// <summary>
        /// The equalto operator
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(SquarePyramid a, SquarePyramid b)
        {
            // If both are null, or both are same instance, return true.
            // If one is null, but not both, return false.
            return ReferenceEquals(a, b) || ((object) a != null) && ((object) b != null) && a._squareBase == b._squareBase && Math.Abs(a._height - b._height) < 1;
        }

        /// <summary>
        /// The not-equalto operator
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(SquarePyramid a, SquarePyramid b)
        {
            return (a != null && b != null && a._squareBase != b._squareBase) || (a != null && b != null && Math.Abs(a._height - b._height) > 0);
        }

        #endregion
    }
}
