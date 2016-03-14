using System;
using System.Globalization;

namespace Mathos.Converter
{
    /// <summary>
    /// This class provides methods for converting angles.
    /// </summary>
    public class AngleConverter
    {
        /// <summary>
        /// Imputes <paramref name="angle"/> ("degrees.minutesseconds") into decimal degrees.
        /// </summary>
        /// <param name="angle">The angle to convert.</param>
        /// <returns><paramref name="angle"/> imputed into decimal degrees.</returns>
        public static double AngleToDecimalAngle(double angle = 0.0000)
        {
            var degrees = Math.Truncate(angle);
            var minutes = Math.Truncate((angle - degrees) * 100);
            var decimalMinutes = minutes / 60;
            var seconds = Math.Round((((angle * 100) - Math.Truncate(angle * 100)) * 100), 0);
            var decimalSeconds = seconds / 3600;
            
            return degrees + decimalMinutes + decimalSeconds;
        }

        /// <summary>
        /// Imputes <paramref name="angle"/> (decimal degrees) into degrees ("degree.minutesseconds").
        /// </summary>
        /// <param name="angle">The angle to convert.</param>
        /// <returns><paramref name="angle"/> imputed into dergrees.</returns>
        public static double DecimalAngleToAngle(double angle = 0.000000)
        {
            var degrees = Math.Truncate(angle);
            var decimalMinutesAndSeconds = angle - degrees;
            var minutes = Math.Truncate(decimalMinutesAndSeconds * 60);
            var seconds = Math.Round((((decimalMinutesAndSeconds * 60) - minutes) * 60), 0);
            var stringDegrees = Convert.ToString(degrees, CultureInfo.InvariantCulture);
            var stringMinutes = Convert.ToString(minutes, CultureInfo.InvariantCulture);
            var stringSeconds = Convert.ToString(seconds, CultureInfo.InvariantCulture);

            if (Convert.ToDouble(minutes) < 0)
                stringMinutes = Convert.ToString(Convert.ToDouble(stringMinutes)*(-1), CultureInfo.InvariantCulture);
            if (Convert.ToDouble(minutes) < 10 && Convert.ToDouble(minutes) >= 0) //if minutes are less than then then before value of minutes add zero
                stringMinutes = "0" + stringMinutes;
            if (Convert.ToDouble(stringSeconds) < 0)
                stringSeconds = Convert.ToString(Convert.ToDouble(stringSeconds)*(-1), CultureInfo.InvariantCulture);
            if (Convert.ToDouble(stringSeconds) < 10 && Convert.ToDouble(stringSeconds) >= 0) //if seconds are less than then then before value of seconds add zero
                stringSeconds = "0" + stringSeconds;

            var ugaoB = Convert.ToString(stringDegrees) + "." + Convert.ToString(stringMinutes) + Convert.ToString(stringSeconds);
            
            angle = Math.Round(Convert.ToDouble(ugaoB), 4);
            
            return angle;
        }

        /// <summary>
        /// Converts an <paramref name="angle"/> ("degrees.minutesseconds") in to radians
        /// </summary>
        /// <param name="angle">The angle to convert.</param>
        /// <returns><paramref name="angle"/> converted to radians.</returns>
        public static double AngleToRadians(double angle = 0.0000)
        {
            angle = AngleToDecimalAngle(angle);

            return ((angle * Math.PI / 180));
        }

        /// <summary>
        /// Converts <paramref name="radians"/> into decimal degrees.
        /// </summary>
        public static double RadiansToDecimalAngle(double radians = 0.000000)
        {
            return radians * 180 / Math.PI;
        }

        /// <summary>
        /// Converts <paramref name="radians"/> into an angle.
        /// </summary>
        public static double RadiansToAngle(double radians = 0.000000)
        {
            radians = radians * 180 / Math.PI;
            radians = DecimalAngleToAngle(radians);

            return radians;
        }
    }
}
