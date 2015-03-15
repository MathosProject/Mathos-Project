using System;

namespace Mathos.Geometry
{
    /// <summary>
    /// Static class used to find the length of a side of a right triangle
    /// </summary>
    public static class Pythagorean
    {
        /// <summary>
        /// Static method that returns the hypotenuse given two sides of a right triangle
        /// </summary>
        /// <param name="side1">Length of the first side</param>
        /// <param name="side2">Length of the second side</param>
        /// <returns>Length of the hypotenuse</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when invalid side lengths are input</exception>
        public static double FindHypotenuse(double side1, double side2)
        {
            if (side1 <= 0 || side2 <= 0)
                throw new ArgumentOutOfRangeException("Invalid length for sides");

            return Math.Sqrt(side1 * side1 + side2 * side2);
        }

        /// <summary>
        /// Static method that returns the length of a side given the side and hypotenuse of a right triangle
        /// </summary>
        /// <param name="side1">Length of the first side</param>
        /// <param name="hypotenuse">Length of the hypotenuse</param>
        /// <returns>Length of the remaining side</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when invalid side length or hypotenuse is input</exception>
        public static double FindNonHypotenuse(double side1, double hypotenuse)
        {
            if (side1 <= 0 || hypotenuse <= 0 || side1 >= hypotenuse)
                throw new ArgumentOutOfRangeException("Invalid length for side or hypotenuse");

            return Math.Sqrt(hypotenuse * hypotenuse - side1 * side1);
        }
    }
}
