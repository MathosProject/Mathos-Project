using System;

namespace Mathos.Geometry.Shapes
{
    /// <summary>
    /// A right circular cylinder.
    /// </summary>
    public class RightCircularCylinder : IShape3D
    {
        private double _height;

        private readonly Circle _circleBase;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public RightCircularCylinder() : this(new Circle(), 0)
        {
        }

        /// <summary>
        /// Constructor with a <paramref name="circleBase"/> and <paramref name="height"/>.
        /// </summary>
        /// <param name="circleBase">The circle base.</param>
        /// <param name="height">The height.</param>
        public RightCircularCylinder(Circle circleBase, double height)
        {
            _circleBase = circleBase;
            _height = height < 0 ? 0 : height;
        }

        /// <summary>
        /// Constructor with a <paramref name="radius"/> and <paramref name="height"/>.
        /// </summary>
        /// <param name="radius">The radius.</param>
        /// <param name="height">The height.</param>
        public RightCircularCylinder(double radius, double height)
        {
            _circleBase = new Circle(radius);
            _height = height < 0 ? 0 : height;
        }

        /// <summary>
        /// Gets or sets the radius of the right circular cylinder.
        /// </summary>
        public double Radius
        {
            get { return _circleBase.Radius; }
            set { _circleBase.Radius = value; }
        }

        /// <summary>
        /// Gets or sets the diameter of the right circular cylinder.
        /// </summary>
        public double Diameter
        {
            get { return _circleBase.Diameter; }
            set { _circleBase.Diameter = value; }
        }

        /// <summary>
        /// Gets or sets the height of the right circular cylinder.
        /// </summary>
        public double Height
        {
            get { return _height; }
            set { _height = value < 0 ? 0 : value; }
        }

        /// <summary>
        /// Gets the area of the right circular cylinder.
        /// </summary>
        public double Volume
        {
            get { return _circleBase.Area * _height; }
        }

        /// <summary>
        /// Gets the surface area of the right circular cylinder.
        /// </summary>
        public double SurfaceArea
        {
            get { return 2 * _circleBase.Area + _circleBase.Circumference * _height; }
        }

        #region Override Equals

        /// <summary>
        /// Checks whether the cylinder is equal to the given object.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            var other = obj as RightCircularCylinder;

            return (other != null) && (_circleBase == other._circleBase) && (Math.Abs(_height - other._height) < 1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(RightCircularCylinder other)
        {
            return (other != null) && (_circleBase == other._circleBase) && (Math.Abs(_height - other._height) < 1);
        }

        /// <summary>
        /// Gets the hashcode of the cylinder.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return _circleBase.GetHashCode() ^ Height.GetHashCode();
        }

        /// <summary>
        /// The equalto operator
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(RightCircularCylinder a, RightCircularCylinder b)
        {
            // If both are null, or both are same instance, return true.
            // If one is null, but not both, return false.
            return ReferenceEquals(a, b) || (((object) a != null) && ((object) b != null) && (a._circleBase == b._circleBase) && (Math.Abs(a._height - b._height) < 1));
        }

        /// <summary>
        /// The not-equalto operator
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(RightCircularCylinder a, RightCircularCylinder b)
        {
            return ((a != null) && (b != null) && (a._circleBase != b._circleBase)) || ((a != null) && (b != null) && (Math.Abs(a._height - b._height) > 0));
        }

        #endregion
    }
}
