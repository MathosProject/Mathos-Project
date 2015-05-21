using System;

namespace Mathos.Geometry.Shapes
{
    /// <summary>
    /// Rectangular prism shape
    /// </summary>
    public class RectangularPrism : IShape3D
    {
        private readonly Rectangle _rectangleBase;
        private double _height;

        /// <summary>
        /// Default constructor
        /// </summary>
        public RectangularPrism() : this(new Rectangle(), 0)
        {
        }

        /// <summary>
        /// Constructor with a Rectangle, "rectangleBase", and a double, "height", to base this prism on
        /// </summary>
        /// <param name="rectangleBase"></param>
        /// <param name="height"></param>
        public RectangularPrism(Rectangle rectangleBase, double height)
        {
            _rectangleBase = rectangleBase;
            _height = height < 0 ? 0 : height;
        }

        /// <summary>
        /// Constructor with a "length", "width", and "height" to base this prism on
        /// </summary>
        /// <param name="length"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public RectangularPrism(double length, double width, double height)
        {
            _rectangleBase = new Rectangle(length, width);
            _height = height < 0 ? 0 : height;
        }

        /// <summary>
        /// Gets or sets the length of the rectangular prism
        /// </summary>
        public double Length
        {
            get { return _rectangleBase.Length; }
            set { _rectangleBase.Length = value; }
        }

        /// <summary>
        /// Gets or sets the width of the rectangular prism
        /// </summary>
        public double Width
        {
            get { return _rectangleBase.Width; }
            set { _rectangleBase.Width = value; }
        }

        /// <summary>
        /// Gets or sets the height of the rectangular prism
        /// </summary>
        public double Height
        {
            get { return _height; }
            set { _height = value < 0 ? 0 : value; }
        }

        /// <summary>
        /// Gets the volume of the rectangular prism
        /// </summary>
        public double Volume
        {
            get { return _rectangleBase.Area * _height; }
        }

        /// <summary>
        /// Gets the surface area of the rectangular prism
        /// </summary>
        public double SurfaceArea
        {
            get 
            {
                return 2 * (_rectangleBase.Length * _rectangleBase.Width + _rectangleBase.Width * _height + _rectangleBase.Length * _height); 
            }
        }

        #region Override Equals

        /// <summary>
        /// Checks whether the rectangular prism is equal to the given object.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            var other = obj as RectangularPrism;
            
            if (other == null)
            {
                return false;
            }

            return _rectangleBase == other._rectangleBase && Math.Abs(_height - other._height) < 1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(RectangularPrism other)
        {
            if (other == null)
            {
                return false;
            }

            return _rectangleBase == other._rectangleBase && Math.Abs(_height - other._height) < 1;
        }

        /// <summary>
        /// Gets the hashcode of the rectangular prism.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return _rectangleBase.GetHashCode() ^ _height.GetHashCode();
        }

        /// <summary>
        /// The equalto operator
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(RectangularPrism a, RectangularPrism b)
        {
            // If both are null, or both are same instance, return true.
            if (ReferenceEquals(a, b))
                return true;

            // If one is null, but not both, return false.
            if (((object)a == null) || ((object)b == null))
                return false;

            return a._rectangleBase == b._rectangleBase && Math.Abs(a._height - b._height) < 1;
        }

        /// <summary>
        /// The not-equalto operator
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(RectangularPrism a, RectangularPrism b)
        {
            return ((a != null && b != null) && a._rectangleBase != b._rectangleBase) || ((a != null && b != null) && Math.Abs(a._height - b._height) > 0);
        }
        
        #endregion
    }
}
