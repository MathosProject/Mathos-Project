namespace Mathos.Geometry.Shapes
{
    /// <summary>
    /// A 2D shape
    /// </summary>
    public interface IShape2D
    {
        /// <summary>
        /// Area of the shape
        /// </summary>
        double Area { get; }

        /// <summary>
        /// Perimeter of the shape
        /// </summary>
        double Perimeter { get; }
    }
}
