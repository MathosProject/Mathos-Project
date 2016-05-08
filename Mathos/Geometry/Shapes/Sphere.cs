﻿using System;

namespace Mathos.Geometry.Shapes
{
    /// <summary>
    /// A sphere.
    /// </summary>
    public class Sphere : IShape3D
    {
        private double _radius;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Sphere() : this(0)
        {
        }

        /// <summary>
        /// Constructor with a <paramref name="radius"/>.
        /// </summary>
        /// <param name="radius">The radius.</param>
        public Sphere(double radius)
        {
            _radius = radius < 0 ? 0 : radius;
        }

        /// <summary>
        /// Gets or sets the radius of the sphere.
        /// </summary>
        public double Radius
        {
            get { return _radius; }
            set { _radius = value < 0 ? 0 : value; }
        }

        /// <summary>
        /// Gets the volume of the sphere.
        /// </summary>
        public double Volume
        {
            get { return 4.0 / 3 * Math.PI * Math.Pow(_radius, 3); }
        }

        /// <summary>
        /// Gets the circumference of the sphere.
        /// </summary>
        public double SurfaceArea
        {
            get { return 4 * Math.PI * _radius * _radius; }
        }

        #region Override Equals

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            var other = obj as Sphere;

            return (other != null) && (Math.Abs(_radius - other._radius) < 1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Sphere other)
        {
            return (other != null) && (Math.Abs(_radius - other._radius) < 1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return Radius.GetHashCode();
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
            // If one is null, but not both, return false.
            return ReferenceEquals(a, b) || (((object) a != null) && ((object) b != null) && (Math.Abs(a._radius - b._radius) < 1));
        }

        /// <summary>
        /// The not-equalto operator
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(Sphere a, Sphere b)
        {
            return (a != null) && (b != null) && (Math.Abs(a._radius - b._radius) > 0);
        }

        #endregion
    }
}
