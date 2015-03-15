using System;

namespace Mathos.Converter
{
    /// <summary>
    /// 
    /// </summary>
    public class ConversionInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public Enum Unit;
        
        /// <summary>
        /// 
        /// </summary>
        public double Value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unit"></param>
        /// <param name="value"></param>
        public ConversionInfo(Enum unit, double value)
        {
            Unit = unit;
            Value = value;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ConversionBase
    {
        /// <summary>
        /// 
        /// </summary>
        public Base Unit;
        
        /// <summary>
        /// 
        /// </summary>
        public string Value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unit"></param>
        /// <param name="value"></param>
        public ConversionBase(Base unit, string value)
        {
            Unit = unit;
            Value = value;
        }
    }
}
