using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_Geometry
{
    public class GeomBox
    {
        private double m_lowX = 0.0;
        private double m_lowY = 0.0;
        private double m_lowZ = 0.0;

        private double m_highX = 0.0;
        private double m_highY = 0.0;
        private double m_highZ = 0.0;

        public GeomBox(double x_low, double y_low, double z_low, double x_high, double y_high, double z_high)
        {
            this.m_highX = x_high;
            this.m_highY = y_high;
            this.m_highZ = z_high;
            this.m_lowX = x_low;
            this.m_lowY = y_low;
            this.m_lowZ = z_low;
        }
    }
}
