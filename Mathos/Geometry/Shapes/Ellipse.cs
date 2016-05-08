using System;

namespace Mathos.Geometry.Shapes
{  
    /// <summary>
    /// An elliptical shape.
    /// </summary>
    public class Ellipse : IShape2D
    {
        private double _majorAxis;
        private double _minorAxis;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Ellipse() : this(0, 0)
        {
        }

        /// <summary>
        /// Constructor with a <paramref name="majorAxis"/> and <paramref name="minorAxis"/>.
        /// </summary>
        /// <param name="majorAxis">The major axis.</param>
        /// <param name="minorAxis">The minor axis.</param>
        public Ellipse(double majorAxis, double minorAxis)
        {
            _majorAxis = majorAxis < 0 ? 0 : majorAxis;
            _minorAxis = minorAxis < 0 ? 0 : minorAxis;
        }

        /// <summary>
        /// Gets or sets the major axis.
        /// </summary>
        public double MajorAxis
        {
            get { return _majorAxis; }
            set { _majorAxis = value < 0 ? 0 : value; }
        }

        /// <summary>
        /// Gets or sets the minor axis.
        /// </summary>
        public double MinorAxis
        {
            get { return _minorAxis; }
            set { _minorAxis = value < 0 ? 0 : value; }
        }

        /// <summary>
        /// Gets the major axis's semi-axis.
        /// </summary>
        public double MajorSemiAxis
        {
            get { return _majorAxis / 2; }
        }

        /// <summary>
        /// Gets the minor axis's semi-axis.
        /// </summary>
        public double MinorSemiAxis
        {
            get { return _minorAxis / 2; }
        }

        /// <summary>
        /// Gets the area of the ellipse.
        /// </summary>
        public double Area
        {                  
            get { return MajorSemiAxis*MinorSemiAxis*Math.PI; }
        }

        /// <summary>
        /// Gets the circumference of the ellipse.
        /// </summary>
        /// <remarks>Uses Ramanujan's approach.</remarks>
        public double Perimeter
        {
            get { return Math.PI*(3*(MajorSemiAxis + MinorSemiAxis) -
                Math.Sqrt((3*MajorSemiAxis + MinorSemiAxis)*
                (3*MinorSemiAxis + MajorSemiAxis))); }
        }

        /// <summary>
        /// Gets the eccentricity of the ellipse.
        /// </summary>
        /// <returns>The eccentricity of the ellipse</returns>
        public double Eccentricity
        {
            get { return Math.Sqrt(1 - Math.Pow(MinorSemiAxis/MajorSemiAxis, 2)); }
        }

        /// <summary>
        /// Gets the focus of the ellipse.
        /// </summary>
        /// <returns>The focus of the ellipse.</returns>
        public double Focus
        {
            get { return Math.Sqrt(Math.Pow(MajorSemiAxis, 2) - Math.Pow(MinorSemiAxis, 2)); }
        }
    }
}
