using System;

namespace Mathos.Geometry.Shapes
{
    /// <summary>
    /// Ring shape
    /// </summary>
    public class Ring : IShape2D
    {
        private double _bigradius;
        private double _smallradius;

        /// <summary>
        /// Default constructor
        /// </summary>
        public Ring() : this(0, 0)
        {
        }

        /// <summary>
        /// Constructor with two doubles, "bigradius" and "smallradius", to base this ring off of
        /// </summary>
        /// <param name="bigradius"></param>
        /// <param name="smallradius"></param>
        public Ring(double bigradius, double smallradius)
        {
            _bigradius = bigradius < 0 ? 0 : bigradius;
            _smallradius = smallradius < 0 ? 0 : smallradius;
        }

        /// <summary>
        /// Gets or sets the "_bigradius" of the ring
        /// </summary>
        public double BigRadius
        {
            get { return _bigradius; }
            set { _bigradius = value < 0 ? 0 : value; }
        }

        /// <summary>
        /// Gets or sets the "_smallradius" of the ring
        /// </summary>
        public double SmallRadius
        {
            get { return _smallradius; }
            set { _smallradius = value < 0 ? 0 : value; }
        }

        /// <summary>
        /// Gets or sets the "_bigradius" of the ring
        /// </summary>
        public double BigDiameter
        {
            get { return _bigradius * 2; }
            set { _bigradius = value < 0 ? 0 : value / 2; }
        }

        /// <summary>
        /// Gets or sets the "_smallradius" of the ring
        /// </summary>
        public double SmallDiameter
        {
            get { return _smallradius * 2; }
            set { _smallradius = value < 0 ? 0 : value / 2; }
        }

        /// <summary>
        /// Gets the area of the ring
        /// </summary>
        public double Area
        {
            get { return (_bigradius * _bigradius -_smallradius * _smallradius ) * Math.PI; }
        }

        /// <summary>
        /// Gets the circumference of the ring
        /// </summary>
        public double Circumference
        {
            get { return 2 * Math.PI * (_bigradius + _smallradius); }
        }

        /// <summary>
        /// Gets the perimeter of the ring
        /// </summary>
        public double Perimeter
        {
            get { return Circumference; }
        }
    }
}
