using Mathos.Geometry.Shapes;

namespace Mathos.Geometry
{
    /// <summary>
    ///       A
    ///       |\
    /// SideA | \ SideC
    ///       |  \
    ///      B----- C
    ///       SideB
    /// 
    /// Note: Right angles should be used.
    /// </summary>
    public static class Trigonometry
    {
        /// <summary>
        /// Angles of a triangle.
        /// </summary>
        public enum TriangleAngle
        {
            /// <summary>
            /// Angle A (Top)
            /// </summary>
            A,
            /// <summary>
            /// Angle C (Corner)
            /// </summary>
            C
        }

        /// <summary>
        /// Calculates the sine of <paramref name="angle"/> in <paramref name="tri"/>.
        /// </summary>
        /// <param name="tri">The triangle</param>
        /// <param name="angle">The angle to calculate.</param>
        /// <returns>The sine of <paramref name="angle"/>.</returns>
        public static double Sine(Triangle tri, TriangleAngle angle = TriangleAngle.C)
        {
            switch (angle)
            {
                case TriangleAngle.A:
                    return tri.SideB/tri.SideC;
                default:
                    return tri.AngleA/tri.SideC;
            }
        }

        /// <summary>
        /// Calculates the cosine of <paramref name="angle"/> in <paramref name="tri"/>.
        /// </summary>
        /// <param name="tri">The triangle</param>
        /// <param name="angle">The angle to calculate.</param>
        /// <returns>The cosine of <paramref name="angle"/>.</returns>
        public static double Cosine(Triangle tri, TriangleAngle angle = TriangleAngle.C)
        {
            switch (angle)
            {
                case TriangleAngle.A:
                    return tri.SideA / tri.SideC;
                default:
                    return tri.AngleB / tri.SideC;
            }
        }

        /// <summary>
        /// Calculates the tangent of <paramref name="angle"/> in <paramref name="tri"/>.
        /// </summary>
        /// <param name="tri">The triangle</param>
        /// <param name="angle">The angle to calculate.</param>
        /// <returns>The tangent of <paramref name="angle"/>.</returns>
        public static double Tangent(Triangle tri, TriangleAngle angle = TriangleAngle.C)
        {
            switch (angle)
            {
                case TriangleAngle.A:
                    return tri.SideB / tri.SideA;
                default:
                    return tri.AngleA / tri.SideB;
            }
        }
    }
}
