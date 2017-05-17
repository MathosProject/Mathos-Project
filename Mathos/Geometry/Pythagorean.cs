using System;

namespace Mathos.Geometry
{
    /// <summary>
    /// Used to find the length of a side of a right triangle.
    /// </summary>
    public static class Pythagorean
    {
        /// <summary>
        /// Get the hypotenuse given two sides of a right triangle.
        /// </summary>
        /// <param name="side1">Length of the first side.</param>
        /// <param name="side2">Length of the second side.</param>
        /// <returns>Length of the hypotenuse.</returns>
        public static double FindHypotenuse(double side1, double side2)
        {
            if (side1 <= 0)
                throw new ArgumentOutOfRangeException(nameof(side1));
            if (side2 <= 0)
                throw new ArgumentOutOfRangeException(nameof(side2));

            return Math.Sqrt(side1 * side1 + side2 * side2);
        }

        /// <summary>
        /// Get the length of a side given another side and the hypotenuse of a right triangle.
        /// </summary>
        /// <param name="side1">Length of a side.</param>
        /// <param name="hypotenuse">Length of the hypotenuse.</param>
        /// <returns>Length of the remaining side</returns>
        public static double SideFromHypotenuse(double side1, double hypotenuse)
        {
            if (side1 <= 0 || side1 >= hypotenuse)
                throw new ArgumentOutOfRangeException(nameof(side1));
            if (hypotenuse <= 0)
                throw new ArgumentOutOfRangeException(nameof(hypotenuse));

            return Math.Sqrt(hypotenuse * hypotenuse - side1 * side1);
        }
    }
}
