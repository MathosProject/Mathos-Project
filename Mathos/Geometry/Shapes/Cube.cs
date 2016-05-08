﻿using System;

namespace Mathos.Geometry.Shapes
{
    /// <summary>
    /// A cube.
    /// </summary>
    public class Cube : IShape3D
    {
        private readonly Square _squareBase;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Cube()
        {
            _squareBase = new Square();
        }

        /// <summary>
        /// Constructor with a specified <paramref name="squareBase"/>.
        /// </summary>
        /// <param name="squareBase">The square base.</param>
        public Cube(Square squareBase)
        {
            _squareBase = squareBase;
        }

        /// <summary>
        /// Constructor with a <paramref name="length"/>.
        /// </summary>
        /// <param name="length">The length.</param>
        public Cube(double length)
        {
            _squareBase = new Square(length);
        }

        /// <summary>
        /// Gets or sets the length of a side.
        /// </summary>
        public double Length
        {
            get { return _squareBase.Length; }
            set { _squareBase.Length = value; }
        }

        /// <summary>
        /// Gets the volume of the cube.
        /// </summary>
        public double Volume
        {
            get { return _squareBase.Area * _squareBase.Length; }
        }

        /// <summary>
        /// Gets the surface area of the cube.
        /// </summary>
        public double SurfaceArea
        {
            get { return 6 * _squareBase.Area; }
        }

        #region Override Equals

        /// <summary>
        /// Checks whether the cube is equal to the given object.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            var other = obj as Cube;

            if (other == null)
                return false;

            return Math.Abs(_squareBase.Length - other._squareBase.Length) < 1;
        }

        /// <summary>
        /// Checks to see if "_squareBase".Length is equal to "other"._squareBase.Length
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Cube other)
        {
            if (other == null)
            {
                return false;
            }

            return Math.Abs(_squareBase.Length - other._squareBase.Length) < 1;
        }

        /// <summary>
        /// Gets the hashcode of the cube.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return _squareBase.Length.GetHashCode();
        }

        /// <summary>
        /// The equalto operator
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(Cube a, Cube b)
        {
            // If both are null, or both are same instance, return true.
            // If one is null, but not both, return false.
            return ReferenceEquals(a, b) || (((object) a != null) && ((object) b != null) && (Math.Abs(a._squareBase.Length - b._squareBase.Length) < 1));
        }

        /// <summary>
        /// The not-equalto operator
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(Cube a, Cube b)
        {
            return (a != null) && (b != null) && (Math.Abs(a._squareBase.Length - b._squareBase.Length) > 0);
        }

        #endregion
    }
}
