using System;

namespace Mathos.Geometry.Shapes
{
    /// <summary>
    /// Trapezoid shape
    /// </summary>
    public class Trapezoid : IShape2D
    {
        private double _baseOne;
        private double _baseTwo;
        private double _height;
        private double _legOne;
        private double _legTwo;

        /// <summary>
        /// Default constructor
        /// </summary>
        public Trapezoid() : this(0, 0, 0, 0)
        {
            _height = 0;
        }

        /// <summary>
        /// Constructor with three doubles, "baseOne" "baseTwo" and "height", to base this trapezoid off of
        /// </summary>
        /// <param name="baseOne"></param>
        /// <param name="baseTwo"></param>
        /// <param name="height"></param>
        public Trapezoid(double baseOne, double baseTwo, double height)
        {
            _baseOne = baseOne < 0 ? 0 : baseOne;
            _baseTwo = baseTwo < 0 ? 0 : baseTwo;
            _height = height < 0 ? 0 : height;
        }

        /// <summary>
        /// Constructor with four doubles, "baseOne" "baseTwo" "legOne" and "legTwo", to base this trapezoid off of
        /// </summary>
        /// <param name="baseOne"></param>
        /// <param name="baseTwo"></param>
        /// <param name="legOne"></param>
        /// <param name="legTwo"></param>
        public Trapezoid(double baseOne, double baseTwo, double legOne, double legTwo)
        {
            _baseOne = baseOne < 0 ? 0 : baseOne;
            _baseTwo = baseTwo < 0 ? 0 : baseTwo;
            _legOne = legOne < 0 ? 0 : legOne;
            _legTwo = legTwo < 0 ? 0 : legTwo;
        }

        /// <summary>
        /// Gets or sets the first base of the trapezoid
        /// </summary>
        public double BaseOne
        {
            get { return _baseOne; }
            set { _baseOne = value < 0 ? 0 : value; }
        }

        /// <summary>
        /// Gets or sets the second base of the trapezoid
        /// </summary>
        public double BaseTwo
        {
            get { return _baseTwo; }
            set { _baseTwo = value < 0 ? 0 : value; }
        }

        /// <summary>
        /// Gets or sets the height of the trapezoid
        /// </summary>
        public double Height
        {
            get { return _height; }
            set { _height = value < 0 ? 0 : value; }
        }

        /// <summary>
        /// Gets or sets the length of the first leg
        /// </summary>
        public double LegOne
        {
            get { return _legOne; }
            set { _legOne = value < 0 ? 0 : value; }
        }

        /// <summary>
        /// Gets or sets the length of the first leg
        /// </summary>
        public double LegTwo
        {
            get { return _legTwo; }
            set { _legTwo = value < 0 ? 0 : value; }
        }

        /// <summary>
        /// Gets the area of the trapezoid
        /// </summary>
        public double Area
        {
            get { return (_baseOne + _baseTwo) * _height / 2; }
        }

        /// <summary>
        /// Gets the perimeter of the trapezoid
        /// </summary>
        public double Perimeter
        {
            get { return _baseOne + _baseTwo + LegOne + LegTwo; }
        }

        #region Override Equals

        /// <summary>
        /// Checks whether the trapezoid is equal to the given object.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            var other = obj as Trapezoid;

            return other != null &&
                   (Math.Abs(_baseOne - other._baseOne) < 1 && Math.Abs(_baseTwo - other._baseTwo) < 1 &&
                    Math.Abs(_height - other._height) < 1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Trapezoid other)
        {
            return other != null &&
                   (Math.Abs(_baseOne - other._baseOne) < 1 && Math.Abs(_baseTwo - other._baseTwo) < 1 &&
                    Math.Abs(_height - other._height) < 1);
        }

        /// <summary>
        /// Gets the hashcode of the trapezoid.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return _baseOne.GetHashCode() ^ _baseTwo.GetHashCode() ^ _height.GetHashCode();
        }

        /// <summary>
        /// The equalto operator
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(Trapezoid a, Trapezoid b)
        {
            // If both are null, or both are same instance, return true.
            // If one is null, but not both, return false.
            return ReferenceEquals(a, b) || ((object) a != null) && ((object) b != null) &&
                   (Math.Abs(a._baseOne - b._baseOne) < 1 && Math.Abs(a._baseTwo - b._baseTwo) < 1 &&
                    Math.Abs(a._height - b._height) < 1);
        }

        /// <summary>
        /// The not-equalto operator
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(Trapezoid a, Trapezoid b)
        {
            return ((a != null && b != null) && Math.Abs(a._baseOne - b._baseOne) > 0) ||
                   ((a != null && b != null) && Math.Abs(a._baseTwo - b._baseTwo) > 0) ||
                   ((a != null && b != null) && Math.Abs(a._height - b._height) > 0);
        }
        #endregion
    }
}
