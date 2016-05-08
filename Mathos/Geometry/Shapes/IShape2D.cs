namespace Mathos.Geometry.Shapes
{
    /// <summary>
    /// Represents a two-dimensional shape.
    /// </summary>
    public interface IShape2D
    {
        /// <summary>
        /// Area of the shape.
        /// </summary>
        double Area { get; }

        /// <summary>
        /// Perimeter of the shape.
        /// </summary>
        double Perimeter { get; }
    }
}
