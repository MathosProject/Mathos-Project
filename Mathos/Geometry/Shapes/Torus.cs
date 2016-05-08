using System;

namespace Mathos.Geometry.Shapes
{
    /// <summary>
    /// A torus.
    /// </summary>
    public class Torus : IShape3D
    {
        private double _distance;
        private double _tubeRadius;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Torus() : this(0, 0)
        {
        }

        /// <summary>
        /// Constructor with a <paramref name="distance"/> and <paramref name="tubeRadius"/>.
        /// </summary>
        /// <param name="distance">The distance.</param>
        /// <param name="tubeRadius">The tube radius.</param>
        public Torus(double distance, double tubeRadius)
        {
            _distance = distance < 0 ? 0 : distance;
            _tubeRadius = tubeRadius < 0 ? 0 : tubeRadius;
        }

        /// <summary>
        /// Gets or sets the radius of the tube and distance.
        /// </summary>
        public double Distance
        {
            get { return _distance; }
            set { _distance = value < 0 ? 0 : value; }
        }

        /// <summary>
        /// Gets or sets the tube radius.
        /// </summary>
        public double TubeRadius
        {
            get { return _tubeRadius; }
            set { _tubeRadius = value < 0 ? 0 : value; }
        }
        
        /// <summary>
        /// Gets the area of the circle.
        /// </summary>
        public double SurfaceArea
        {
            get { return 4* _distance * _tubeRadius * Math.Pow(Math.PI,2); }
        }

        /// <summary>
        /// Gets the circumference of the circle.
        /// </summary>
        public double Volume
        {
            get { return 2 * _distance * Math.Pow( Math.PI * _tubeRadius ,2); }
        }
    }
}
