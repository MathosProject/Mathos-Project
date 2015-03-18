namespace B_Geometry.Util
{
    /// <summary>
    /// Class encapsulating methods associated with tolerant data
    /// </summary>
    public class TolerantUtilities
    {
        private const double MTolerance = 1.0e-11;

        /// <summary>
        /// If a = b within pre-defined tolerance, return true
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool EqualWithinTol(double a, double b)
        {
            // If within tolerance, return true.
            return b - (1.0e-11) < a && a < b + (1.0e-11);
        }

        public double GetTolerance()
        {
            return MTolerance;
        }
    }
}
