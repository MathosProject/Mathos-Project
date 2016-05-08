﻿using System;

namespace Mathos.Geometry.Shapes
{
    /// <summary>
    /// A circle.
    /// </summary>
    public class Circle : IShape2D
    {
        private double _radius;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Circle() : this(0)
        {
        }

        /// <summary>
        /// Constructor with a <paramref name="radius"/>.
        /// </summary>
        /// <param name="radius">The radius.</param>
        public Circle(double radius)
        {
            _radius = radius < 0 ? 0 : radius;
        }

        /// <summary>
        /// Gets or sets the radius of the circle.
        /// </summary>
        public double Radius
        {
            get { return _radius; }
            set { _radius = value < 0 ? 0 : value; }
        }

        /// <summary>
        /// Gets or sets the Diameter of the circle.
        /// </summary>
        public double Diameter
        {
            get { return _radius * 2; }
            set { _radius = value < 0 ? 0 : value / 2; }
        }

        /// <summary>
        /// Gets the area of the circle.
        /// </summary>
        public double Area
        {
            get { return _radius * _radius * Math.PI; }
        }

        /// <summary>
        /// Gets the circumference of the circle.
        /// </summary>
        public double Circumference
        {
            get { return 2 * Math.PI * _radius; }
        }

        /// <summary>
        /// Gets the perimeter of the circle.
        /// </summary>
        public double Perimeter
        {
            get { return Circumference; }
        }

        #region Override Equals

        /// <summary>
        /// Checks whether the circle is equal to the given object.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            var other = obj as Circle;

            // What this returns might not be accurate, update this if needed.
            return (other != null) && (Math.Abs(_radius - other._radius) < 1);
        }

        /// <summary>
        /// Checks to see if the radius is equal to <paramref name="other"/>'s radius.
        /// </summary>
        /// <param name="other">The other circle.</param>
        /// <returns></returns>
        public bool Equals(Circle other)
        {
            return (other != null) && (Math.Abs(_radius - other._radius) < 1);
        }

        /// <summary>
        /// Gets the hashcode of the circle.
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
        public static bool operator ==(Circle a, Circle b)
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
        public static bool operator !=(Circle a, Circle b)
        {
            return (a != null) && (b != null) && (Math.Abs(a._radius - b._radius) > 0);
        }

        #endregion
    }
}
