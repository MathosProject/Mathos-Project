using System;

namespace Mathos.Converter
{
    /// <summary>
    /// 
    /// </summary>
    public class TemperatureConversion
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="conversionInfo"></param>
        /// <param name="unit"></param>
        /// <returns></returns>
        public static double ConvertTemperature(ConversionInfo conversionInfo, Enum unit)
        {
            /*
            if ((Temperature)conversionInfo.Unit == Temperature.DegreeC && (Temperature)unit == Temperature.DegreeK)
            { return conversionInfo.Value + 273.15; }

            if ((Temperature)conversionInfo.Unit == Temperature.DegreeC && (Temperature)unit == Temperature.DegreeF)
            { return conversionInfo.Value * 9 / 5 + 32; }

            if ((Temperature)conversionInfo.Unit == Temperature.DegreeF && (Temperature)unit == Temperature.DegreeC)
            { return (conversionInfo.Value - 32) * 5 / 9 ; }

            if ((Temperature)conversionInfo.Unit == Temperature.DegreeF && (Temperature)unit == Temperature.DegreeK)
            { return (conversionInfo.Value - 32) * 5 / 9 + 273.15; }

            if ((Temperature)conversionInfo.Unit == Temperature.DegreeK && (Temperature)unit == Temperature.DegreeF)
            { return (conversionInfo.Value - 273.15) * 9 / 5 + 32; }

            if ((Temperature)conversionInfo.Unit == Temperature.DegreeK && (Temperature)unit == Temperature.DegreeC)
            { return conversionInfo.Value - 273.15; }

            // in case of conversion to same type

            return conversionInfo.Value;
            */

            //temperature conversions
            return (Temperature) conversionInfo.Unit == Temperature.DegreeC && (Temperature) unit == Temperature.DegreeK
                ? conversionInfo.Value + 273.15
                : ((Temperature) conversionInfo.Unit == Temperature.DegreeC && (Temperature) unit == Temperature.DegreeF
                    ? conversionInfo.Value*9/5 + 32
                    : ((Temperature) conversionInfo.Unit == Temperature.DegreeF &&
                       (Temperature) unit == Temperature.DegreeC
                        ? (conversionInfo.Value - 32)*5/9
                        : ((Temperature) conversionInfo.Unit == Temperature.DegreeF &&
                           (Temperature) unit == Temperature.DegreeK
                            ? (conversionInfo.Value - 32)*5/9 + 273.15
                            : ((Temperature) conversionInfo.Unit == Temperature.DegreeK &&
                               (Temperature) unit == Temperature.DegreeF
                                ? (conversionInfo.Value - 273.15)*9/5 + 32
                                : ((Temperature) conversionInfo.Unit == Temperature.DegreeK &&
                                   (Temperature) unit == Temperature.DegreeC
                                    ? conversionInfo.Value - 273.15
                                    : conversionInfo.Value)))));
        }
    };
}