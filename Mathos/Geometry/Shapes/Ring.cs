using System;

namespace Mathos.Geometry.Shapes
{
    /// <summary>
    /// A ring shape.
    /// </summary>
    public class Ring : IShape2D
    {
        private double _bigRadius;
        private double _smallRadius;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Ring() : this(0, 0)
        {
        }

        /// <summary>
        /// Constructor with <paramref name="bigRadius"/> and <paramref name="smallRadius"/>.
        /// </summary>
        /// <param name="bigRadius">The big radius.</param>
        /// <param name="smallRadius">The small radius.</param>
        public Ring(double bigRadius, double smallRadius)
        {
            _bigRadius = bigRadius < 0 ? 0 : bigRadius;
            _smallRadius = smallRadius < 0 ? 0 : smallRadius;
        }

        /// <summary>
        /// Gets or sets the big radius.
        /// </summary>
        public double BigRadius
        {
            get { return _bigRadius; }
            set { _bigRadius = value < 0 ? 0 : value; }
        }

        /// <summary>
        /// Gets or sets the small radius.
        /// </summary>
        public double SmallRadius
        {
            get { return _smallRadius; }
            set { _smallRadius = value < 0 ? 0 : value; }
        }

        /// <summary>
        /// Gets or sets the big diameter.
        /// </summary>
        public double BigDiameter
        {
            get { return _bigRadius * 2; }
            set { _bigRadius = value < 0 ? 0 : value / 2; }
        }

        /// <summary>
        /// Gets or sets the small diameter.
        /// </summary>
        public double SmallDiameter
        {
            get { return _smallRadius * 2; }
            set { _smallRadius = value < 0 ? 0 : value / 2; }
        }

        /// <summary>
        /// Gets the area of the ring.
        /// </summary>
        public double Area
        {
            get { return (_bigRadius * _bigRadius -_smallRadius * _smallRadius ) * Math.PI; }
        }

        /// <summary>
        /// Gets the circumference of the ring.
        /// </summary>
        public double Circumference
        {
            get { return 2 * Math.PI * (_bigRadius + _smallRadius); }
        }

        /// <summary>
        /// Gets the perimeter of the ring.
        /// </summary>
        public double Perimeter
        {
            get { return Circumference; }
        }
    }
}
