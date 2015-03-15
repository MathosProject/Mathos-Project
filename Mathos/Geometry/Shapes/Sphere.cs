using System;

namespace Mathos.Geometry.Shapes
{
    /// <summary>
    /// Sphere shape
    /// </summary>
    public class Sphere : IShape3D
    {
        private double _radius;

        /// <summary>
        /// Default constructor
        /// </summary>
        public Sphere() : this(0)
        {
        }

        /// <summary>
        /// Constructor with a double, "radius", to base this sphere off of
        /// </summary>
        /// <param name="radius"></param>
        public Sphere(double radius)
        {
            _radius = radius < 0 ? 0 : radius;
        }

        /// <summary>
        /// Gets or sets the radius of the sphere
        /// </summary>
        public double Radius
        {
            get { return _radius; }
            set { _radius = value < 0 ? 0 : value; }
        }

        /// <summary>
        /// Gets the volume of the sphere
        /// </summary>
        public double Volume
        {
            get { return 4.0 / 3 * Math.PI * Math.Pow(_radius, 3); }
        }

        /// <summary>
        /// Gets the circumference of the sphere
        /// </summary>
        public double SurfaceArea
        {
            get { return 4 * Math.PI * _radius * _radius; }
        }

        #region Override Equals

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            var other = obj as Sphere;

            if (other == null)
                return false;

            return Math.Abs(_radius - other._radius) < 1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Sphere other)
        {
            if (other == null)
            {
                return false;
            }

            return Math.Abs(_radius - other._radius) < 1;
        }

        public override int GetHashCode()
        {
            return _radius.GetHashCode();
        }

        /// <summary>
        /// The equalto operator
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(Sphere a, Sphere b)
        {
            // If both are null, or both are same instance, return true.
            if (ReferenceEquals(a, b))
                return true;

            // If one is null, but not both, return false.
            if (((object) a == null) || ((object) b == null))
                return false;

            return Math.Abs(a._radius - b._radius) < 1;
        }

        /// <summary>
        /// The not-equalto operator
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(Sphere a, Sphere b)
        {
            return ((a != null && b != null) && Math.Abs(a._radius - b._radius) > 0);
        }

        #endregion
    }
}
