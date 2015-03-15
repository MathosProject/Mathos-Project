using System;

namespace Mathos.Geometry.Shapes
{  
    /// <summary>
    /// Elliptical shape
    /// </summary>
    public class Ellipse : IShape2D
    {
        private double _majoraxis;
        private double _minoraxis;

        /// <summary>
        /// Default constructor
        /// </summary>
        public Ellipse() : this(0, 0)
        {
        }

        /// <summary>
        /// Constructor with a "majoraxis" and a "minoraxis"
        /// </summary>
        /// <param name="majoraxis"></param>
        /// <param name="minoraxis"></param>
        public Ellipse(double majoraxis, double minoraxis)
        {
            _majoraxis = majoraxis < 0 ? 0 : majoraxis;
            _minoraxis = minoraxis < 0 ? 0 : minoraxis;
        }

        /// <summary>
        /// Gets or sets the "_majoraxis"
        /// </summary>
        public double MajorAxis
        {
            get { return _majoraxis; }
            set { _majoraxis = value < 0 ? 0 : value; }
        }

        /// <summary>
        /// Gets or sets the "_minoraxis"
        /// </summary>
        public double MinorAxis
        {
            get { return _minoraxis; }
            set { _minoraxis = value < 0 ? 0 : value; }
        }

        /// <summary>
        /// Gets the "_majoraxis"'s semi axis
        /// </summary>
        public double MajorSemiAxis
        {
            get { return _majoraxis / 2; }
        }

        /// <summary>
        /// Gets the "_minoraxis"'s semi axis
        /// </summary>
        public double MinorSemiAxis
        {
            get { return _minoraxis / 2; }
        }

        /// <summary>
        /// Gets the area of the ellipse
        /// </summary>
        public double Area
        {                  
            get { return MajorSemiAxis*MinorSemiAxis*Math.PI; }
        }

        /// <summary>
        /// Circumference - Ramanujan's approach
        /// </summary>
        public double Perimeter
        {
            get { return Math.PI*(3*(MajorSemiAxis + MinorSemiAxis) -
                Math.Sqrt((3*MajorSemiAxis + MinorSemiAxis)*
                (3*MinorSemiAxis + MajorSemiAxis))); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public double Eccentricity()
        {
            return Math.Sqrt(1 - Math.Pow(MinorSemiAxis/MajorSemiAxis,2));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public double Focus()
        {
            return Math.Sqrt(Math.Pow(MajorSemiAxis,2) - Math.Pow(MinorSemiAxis,2));
        }
    }
}
