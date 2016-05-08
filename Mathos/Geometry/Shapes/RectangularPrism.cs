using System;

namespace Mathos.Geometry.Shapes
{
    /// <summary>
    /// A rectangular prism.
    /// </summary>
    public class RectangularPrism : IShape3D
    {
        private double _height;

        private readonly Rectangle _rectangleBase;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public RectangularPrism() : this(new Rectangle(), 0)
        {
        }

        /// <summary>
        /// Constructor with a <paramref name="rectangleBase"/> and a <paramref name="height"/>.
        /// </summary>
        /// <param name="rectangleBase">The base.</param>
        /// <param name="height">The height.</param>
        public RectangularPrism(Rectangle rectangleBase, double height)
        {
            _rectangleBase = rectangleBase;
            _height = height < 0 ? 0 : height;
        }

        /// <summary>
        /// Constructor with a <paramref name="length"/>, <paramref name="width"/>, and <paramref name="height"/>.
        /// </summary>
        /// <param name="length">The length.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        public RectangularPrism(double length, double width, double height)
        {
            _rectangleBase = new Rectangle(length, width);
            _height = height < 0 ? 0 : height;
        }

        /// <summary>
        /// Gets or sets the length of the rectangular prism.
        /// </summary>
        public double Length
        {
            get { return _rectangleBase.Length; }
            set { _rectangleBase.Length = value; }
        }

        /// <summary>
        /// Gets or sets the width of the rectangular prism.
        /// </summary>
        public double Width
        {
            get { return _rectangleBase.Width; }
            set { _rectangleBase.Width = value; }
        }

        /// <summary>
        /// Gets or sets the height of the rectangular prism.
        /// </summary>
        public double Height
        {
            get { return _height; }
            set { _height = value < 0 ? 0 : value; }
        }

        /// <summary>
        /// Gets the volume of the rectangular prism.
        /// </summary>
        public double Volume
        {
            get { return _rectangleBase.Area * _height; }
        }

        /// <summary>
        /// Gets the surface area of the rectangular prism.
        /// </summary>
        public double SurfaceArea
        {
            get { return 2*(_rectangleBase.Length*_rectangleBase.Width + _rectangleBase.Width*_height + _rectangleBase.Length*_height); }
        }

        #region Override Equals

        /// <summary>
        /// Checks whether the rectangular prism is equal to the given object.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            var other = obj as RectangularPrism;

            return (other != null) && (_rectangleBase == other._rectangleBase) && (Math.Abs(_height - other._height) < 1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(RectangularPrism other)
        {
            return (other != null) && (_rectangleBase == other._rectangleBase) && (Math.Abs(_height - other._height) < 1);
        }

        /// <summary>
        /// Gets the hashcode of the rectangular prism.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return _rectangleBase.GetHashCode() ^ Height.GetHashCode();
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
            // If one is null, but not both, return false.
            return ReferenceEquals(a, b) || (((object) a != null) && ((object) b != null) && (a._rectangleBase == b._rectangleBase) && (Math.Abs(a._height - b._height) < 1));
        }

        /// <summary>
        /// The not-equalto operator
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(RectangularPrism a, RectangularPrism b)
        {
            return ((a != null) && (b != null) && (a._rectangleBase != b._rectangleBase)) || ((a != null) && (b != null) && (Math.Abs(a._height - b._height) > 0));
        }
        
        #endregion
    }
}
