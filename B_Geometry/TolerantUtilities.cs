using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_Geometry
{
    /// <summary>
    /// Class encapsulating methods associated with tolerant data
    /// </summary>
    public class TolerantUtilities
    {
        private double m_tolerance = 1.0e-11;

        public TolerantUtilities()
        {
        }

        /// <summary>
        /// If a = b within pre-defined tolerance, return true
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool EqualWithinTol(double a, double b)
        {
            /// If within tolerance, return true.
            if (b - (1.0e-11) < a && a < b + (1.0e-11))
                return true;
            else
                return false;
        }

        public double GetTolerance()
        {
            return this.m_tolerance;
        }
    }
}
