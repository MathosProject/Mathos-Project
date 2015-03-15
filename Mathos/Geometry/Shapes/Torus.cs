using System;

namespace Mathos.Geometry.Shapes
{
    /// <summary>
    /// Torus shape
    /// </summary>
    public class Torus : IShape3D
    {
        private double _distance; //distance from the center of the tube to the centre of the torus
        private double _tuberadius; // radius of the tube

        /// <summary>
        /// Default constructor
        /// </summary>
        public Torus() : this(0, 0)
        {
        }

        /// <summary>
        /// Constructor with two doubles, "distance" and "tuberadius", to base this torus off of
        /// </summary>
        /// <param name="distance"></param>
        /// <param name="tuberadius"></param>
        public Torus(double distance, double tuberadius)
        {
            _distance = distance < 0 ? 0 : distance;
            _tuberadius = tuberadius < 0 ? 0 : tuberadius;
        }

        /// <summary>
        /// Gets or sets the radius of the tube and distance
        /// </summary>
        public double Distance
        {
            get { return _distance; }
            set { _distance = value < 0 ? 0 : value; }
        }

        /// <summary>
        /// Gets or sets the tube radius
        /// </summary>
        public double TubeRadius
        {
            get { return _tuberadius; }
            set { _tuberadius = value < 0 ? 0 : value; }
        }
        
        /// <summary>
        /// Gets the area of the circle
        /// </summary>
        public double SurfaceArea
        {
            get { return 4* _distance * _tuberadius * Math.Pow(Math.PI,2); }
        }

        /// <summary>
        /// Gets the circumference of the circle
        /// </summary>
        public double Volume
        {
            get { return 2 * _distance * Math.Pow( Math.PI * _tuberadius ,2); }
        }
    }
}
