using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Mathos.Converter
{
    /// <summary>
    /// 
    /// </summary>
    public static class Converter
    {
        private static readonly char[] BaseArray;
        private static readonly Dictionary<Enum, double> UnitConversions;

        static Converter()
        {
            BaseArray = new[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 
                               'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 
                               'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

            UnitConversions = new Dictionary<Enum, double>
            {
                // Angle Conversions
                { Angle.Degree, 57.295779513082323},
                { Angle.Gradian, 63.661977236758133},
                { Angle.Radian, 1},

                // Length Conversions
                { Length.Centimeter, 100 },
                { Length.Foot, 3.28084 },
                { Length.Inch, 39.3701 },
                { Length.Kilometer, 0.001 },
                { Length.Meter, 1 },
                { Length.Millimeter, 1000 },
                { Length.Mile, 0.000621371 },
                { Length.NauticalMile, 0.000539957 },
                { Length.Yard, 1.09361 },

                // Speed Conversions
                { Speed.FeetPerSecond, 3.28084 },
                { Speed.KilometersPerHour, 3.6 },
                { Speed.Knot, 1.94384 },
                { Speed.MetersPerSecond, 1 },
                { Speed.MilesPerHour, 2.23694 },

                // Mass Conversions
                { Mass.Gram, 1000 },
                { Mass.Kilogram, 1 },
                { Mass.LongTon, 0.000984207 },
                { Mass.MetricTon, 0.001 },
                { Mass.Milligram, 1000000 },
                { Mass.Ounce, 35.274 },
                { Mass.Pound, 2.20462 },
                { Mass.ShortTon, 0.00110231 },
                { Mass.Stone, 0.157473 },

                // Volume Conversions
                { Volume.CubicFoot, 0.0353147 },
                { Volume.CubicInch, 61.0237 },
                { Volume.CubicMeter, 0.001 }, 
                { Volume.CupUs, 4.22675 },
                { Volume.GallonImp, 0.219969 },
                { Volume.GallonUs, 0.264172 },
                { Volume.Liter, 1 },
                { Volume.Milliliter, 1000 },
                { Volume.OzImp, 35.1951 },
                { Volume.OzUs, 33.814 },
                { Volume.PintImp, 1.75975 },
                { Volume.PintUs, 2.11338 },
                { Volume.QuartImp, 0.879877 },
                { Volume.QuartUs, 1.05669 },
                { Volume.TablespoonImp, 56.3121 },
                { Volume.TablespoonUs, 67.628 },
                { Volume.TeaspoonImp, 168.936 },
                { Volume.TeaspoonUs, 202.884 },

                // Area Conversion
                { Area.SquareKilometer, 0.000001 },
                { Area.Hectare, 0.0001 },
                { Area.SquareMile, 0.0000003861},
                { Area.SquareMeter, 1 },
                { Area.Acre, 0.000247105 },
                { Area.SquareYard, 1.19599 },
                { Area.SquareFoot, 10.7639 },
                { Area.SquareInch, 1550 },

                // Pressure Conversion
                { Pressure.Pascal, 1 },
                { Pressure.Hectopascal, 100 },
                { Pressure.Kilopascal, 1000 },
                { Pressure.Bar, 0.00001 },
                { Pressure.At, 0.0000101971621298 },
                { Pressure.Atm, 0.00000986923267 },
                { Pressure.Psi, 0.000145037738 },
                { Pressure.MmHg, 0.00750061683 },

                // Power Conversion
                { Power.Milliwatt, 1000 },
                { Power.Watt, 1 },
                { Power.Kilowatt, 0.001 },
                { Power.Megawatt, 0.000001 },
                { Power.JoulesMin, 60 },
                { Power.MetricHp, 0.001359621617303904 },
                { Power.MechanicalHp, 0.001341022071853089 },
                { Power.ElectricalHp, 0.001340482573726541 },
                { Power.FtLbMin, 44.2537289566362 },
                { Power.FtLbSec, 0.73756214927727 },
                { Power.KgfMeterSec, 0.101971621 },
                { Power.KgfMeterMin, 6.11829728 },

                //Temperature Conversions
                { Temperature.DegreeC, 1},  // we have to refer to the TemperatureConverter.cs
                { Temperature.DegreeK, 274.15},
                { Temperature.DegreeF, 33.8}
            };
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"></param>
        /// <returns></returns>
        public static ConversionInfo From(this object value, Enum unit)
        {
            return From(unit, double.Parse(value.ToString()));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"></param>
        /// <returns></returns>
        public static ConversionBase From(this object value, Base unit)
        {
            return From(unit, value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unit"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static ConversionInfo From(Enum unit, double value)
        {
            return new ConversionInfo(unit, value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unit"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static ConversionBase From(Base unit, object value)
        {
            return new ConversionBase(unit, value.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conversionInfo"></param>
        /// <param name="unit"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static double To(this ConversionInfo conversionInfo, Enum unit)
        {
            if (conversionInfo.Unit.GetType() != unit.GetType())
                throw new ArgumentException("You must convert to the same type of unit");

            if (!UnitConversions.Keys.Contains(conversionInfo.Unit))
                throw new ArgumentException("Invalid conversion unit");

            if (!UnitConversions.Keys.Contains(unit))
                throw new ArgumentException("Invalid conversion unit");

            if (conversionInfo.Unit.GetType() == typeof (Temperature))
                return TemperatureConversion.ConvertTemperature(conversionInfo, unit);

            return conversionInfo.Value / UnitConversions[conversionInfo.Unit] * UnitConversions[unit];
        }

        //private static double ConvertTempurature(ConversionInfo conversionInfo, Enum unit)
        //{
        //    throw new NotImplementedException();
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conversionBase"></param>
        /// <param name="resultBase"></param>
        /// <returns></returns>
        public static string To(this ConversionBase conversionBase, Base resultBase)
        {
            return BetweenBases(conversionBase.Value, (sbyte)conversionBase.Unit, (sbyte)resultBase);
        }

        #region Base Conversions

        private static string BetweenBases(string value, sbyte fromBase, sbyte toBase)
        {
            return Encode(Decode(value, fromBase), toBase);
        }

        private static string Encode(long value, sbyte toBase)
        {
            if (toBase < 2 || toBase > 36)
                throw new ArgumentOutOfRangeException("toBase", "Value must be between 2 and 36");

            var encoded = string.Empty;

            if (value == 0)
                return BaseArray[0].ToString(CultureInfo.InvariantCulture).ToUpper();

            while (value != 0)
            {
                encoded = BaseArray[value % toBase] + encoded;
                value /= toBase;
            }

            encoded = encoded.ToUpper();

            return encoded;
        }

        private static long Decode(string value, sbyte fromBase)
        {
            if (fromBase < 2 || fromBase > 36)
                throw new ArgumentOutOfRangeException("fromBase", "Value must be between 2 and 36");

            value = value.Trim();
            value = value.ToLower();

            long decoded = 0;
            var charArray = value.ToCharArray();

            Array.Reverse(charArray);

            for (var i = 0; i < charArray.Length; i++)
            {
                if (Array.IndexOf(BaseArray, charArray[i]) >= fromBase)
                    throw new ArgumentOutOfRangeException("value",
                        "Input contains characters that are not in the base set");

                // find the index in the array that the char resides
                var valueindex = Array.IndexOf(BaseArray, charArray[i]);

                // the actual value given by that is 
                // the index multiplied by the base number to the power of the index
                var temp = valueindex * Math.Pow(fromBase, i);

                // add this value to the counter until there are no more values
                decoded += (long)temp;
            }
            // return the total result
            return decoded;
        }

        #endregion
    }
}
