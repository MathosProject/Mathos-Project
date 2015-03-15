namespace Mathos.Geometry.Shapes
{
    /// <summary>
    /// A 3D shape
    /// </summary>
    public interface IShape3D
    {
        /// <summary>
        /// Volume of the shape
        /// </summary>
        double Volume { get; }

        /// <summary>
        /// Surface area of the shape
        /// </summary>
        double SurfaceArea { get; }
    }
}
