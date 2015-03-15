using System;

namespace Mathos.Geometry.Shapes
{
    /// <summary>
    /// Parallelogram shape
    /// </summary>
    public class Parallelogram : IShape2D
    {
        private double _length;
        private double _height;

        /// <summary>
        /// Default constructor
        /// </summary>
        public Parallelogram() : this(0, 0)
        {
        }

        /// <summary>
        /// Constructor with a "length" and "height"
        /// </summary>
        /// <param name="length"></param>
        /// <param name="height"></param>
        public Parallelogram(double length, double height)
        {
            _length = length < 0 ? 0 : length;
            _height = height < 0 ? 0 : height;
        }

        /// <summary>
        /// Gets or sets the length of the parallelogram
        /// </summary>
        public double Length
        {
            get { return _length; }
            set { _length = value < 0 ? 0 : value; }
        }

        /// <summary>
        /// Gets or sets the height of the parallelogram
        /// </summary>
        public double Height
        {
            get { return _height; }
            set { _height = value < 0 ? 0 : value; }
        }

        /// <summary>
        /// Gets the area of the parallelogram
        /// </summary>
        public double Area
        {
            get { return _length * _height; }
        }

        /// <summary>
        /// Gets the perimeter of the parallelogram
        /// </summary>
        public double Perimeter
        {
            get { return _length * 2 + _height * 2; }
        }

        #region Override Equals

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            var other = obj as Parallelogram;
            
            if (other == null)
            {
                return false;
            }

            return Math.Abs(_length - other._length) < 1 && Math.Abs(_height - other._height) < 1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Parallelogram other)
        {
            if (other == null)
            {
                return false;
            }

            return Math.Abs(_length - other._length) < 1 && Math.Abs(_height - other._height) < 1;
        }

        public override int GetHashCode()
        {
            return _length.GetHashCode() ^ _height.GetHashCode();
        }

        /// <summary>
        /// The equalto operator
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(Parallelogram a, Parallelogram b)
        {
            // If both are null, or both are same instance, return true.
            if (ReferenceEquals(a, b))
                return true;

            // If one is null, but not both, return false.
            if (((object)a == null) || ((object)b == null))
                return false;

            return Math.Abs(a._length - b._length) < 1 && Math.Abs(a._height - b._height) < 1;
        }

        /// <summary>
        /// The not-equalto operator
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(Parallelogram a, Parallelogram b)
        {
            return ((a != null && b != null) && Math.Abs(a._length - b._length) > 0) || ((a != null && b != null) && Math.Abs(a._height - b._height) > 0);
        }

        #endregion
    }
}
