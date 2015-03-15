using System;

namespace Mathos.Converter
{
    /// <summary>
    /// 
    /// </summary>
    public class AngleConversionM
    {
        /// <summary>
        /// Static method that returns angle imputed as "degrees.minutesseconds" in to decimal degree
        /// </summary>
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
        /// Static method that returns angle imputed as decimal degree in to degree ("degree.minutesseconds")
        /// </summary>
        public static double DecimalAngleToAngle(double angle = 0.000000)
        {
            var degrees = Math.Truncate(angle);
            var decimalMinutesAndSeconds = angle - degrees;
            var minutes = Math.Truncate(decimalMinutesAndSeconds * 60);
            var seconds = Math.Round((((decimalMinutesAndSeconds * 60) - minutes) * 60), 0);
            var stringDegrees = Convert.ToString(degrees);
            var stringMinutes = Convert.ToString(minutes);
            var stringSeconds = Convert.ToString(seconds);
            
            if (Convert.ToDouble(minutes) < 0)
            {
                stringMinutes = Convert.ToString(Convert.ToDouble(stringMinutes) * (-1));
            }
            if (Convert.ToDouble(minutes) < 10 && Convert.ToDouble(minutes) >= 0) //if minutes are less than then then before value of minutes add zero
            {
                stringMinutes = "0" + stringMinutes;
            }
            if (Convert.ToDouble(stringSeconds) < 0)
            {
                stringSeconds = Convert.ToString(Convert.ToDouble(stringSeconds) * (-1));
            }
            if (Convert.ToDouble(stringSeconds) < 10 && Convert.ToDouble(stringSeconds) >= 0) //if seconds are less than then then before value of seconds add zero
            {
                stringSeconds = "0" + stringSeconds;
            }

            var ugaoB = Convert.ToString(stringDegrees) + "." + Convert.ToString(stringMinutes) + Convert.ToString(stringSeconds);
            
            angle = Math.Round(Convert.ToDouble(ugaoB), 4);
            
            return angle;
        }
        /// <summary>
        /// Static method that returns angle imputed as "degrees.minutesseconds" in to radians
        /// </summary>
        public static double AngleToRadians(double angle = 0.0000)
        {
            angle = AngleToDecimalAngle(angle);

            return ((angle * Math.PI / 180));
        }
        /// <summary>
        /// Static method that returns angle imputed as radians in to decimal degrees
        /// </summary>
        public static double RadiansToDecimalAngle(double angle = 0.000000)
        {
            return angle * 180 / Math.PI;
        }
        /// <summary>
        /// Static method that returns angle imputed as radians in to decimal degrees
        /// </summary>
        public static double RadiansToAngle(double angle = 0.000000)
        {
            angle = angle * 180 / Math.PI;
            angle = DecimalAngleToAngle(angle);

            return angle;
        }

    }
}
