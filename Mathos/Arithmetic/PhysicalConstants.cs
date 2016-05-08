namespace Mathos.Arithmetic
{
    /// <summary>
    /// 
    /// </summary>
    public static class PhysicalConstants
    {
        /// <summary>
        /// International System of Units
        /// </summary>
        public static class SI
        {
            /// <summary>
            /// The speed of light.
            /// 299792458 m/s
            /// </summary>
            public const double C = 2.99792458e8;

            /// <summary>
            /// The Newton constant.
            /// 6.67408 * 10^-11 m^3 kg^-1 s^-2
            /// </summary>
            public const double NewtonConstant = 6.67408e-11;

            /// <summary>
            /// The Planck constant (h).
            /// 6.62607004 * 10^-34 m^2 kg/s
            /// </summary>
            public const double PlanckConstant = 6.62607004e-34;

            /// <summary>
            /// The h-bar.
            /// 1.0545718 * 10^-34 m^2 kg/s
            /// </summary>
            public const double PlankConstantBar = 1.0545718e-34;

            /// <summary>
            /// The acceleration of gravity.
            /// 9.80665 m/s^2
            /// </summary>
            public const double GravityAccelartion = 9.80665e0;

            /// <summary>
            /// The electron volt (eV).
            /// 1.602176565(35) * 10^−19 J
            /// </summary>
            public const double ElectronVolt = 1.602176462e-19;

            /// <summary>
            /// The electron mass.
            /// 9.10938356 * 10^-31 kilograms
            /// </summary>
            public const double ElectronMass = 9.10938356e-31;

            /// <summary>
            /// The Boltzmann constant (kB or k).
            /// 1.38064852 * 10^-23 m^2 kg s^-2 K^-1
            /// </summary>
            public const double BoltzmannConstant = 1.38064852e-23;
        }

        /// <summary>
        /// Avogadro's number.
        /// 6.02214199 * 10^23
        /// </summary>
        public const double Avogadro = 6.02214199e23;
    }
}
