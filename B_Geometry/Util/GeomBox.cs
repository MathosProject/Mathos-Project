namespace B_Geometry.Util
{
    public class GeomBox
    {
        public GeomBox(double xLow, double yLow, double zLow, double xHigh, double yHigh, double zHigh)
        {
            MHighX = xHigh;
            MHighY = yHigh;
            MHighZ = zHigh;
            MLowX = xLow;
            MLowY = yLow;
            MLowZ = zLow;
        }

        public double MHighX { get; private set; }
        public double MHighY { get; private set; }
        public double MHighZ { get; private set; }

        public double MLowZ { get; set; }
        public double MLowX { get; set; }
        public double MLowY { get; set; }
    }
}
