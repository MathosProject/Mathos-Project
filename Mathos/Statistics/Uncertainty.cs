using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Mathos.Statistics
{
    /// <summary>
    /// A public class that stores a value and its uncertainty. This class allows you to perform operations between other objects of the same type.
    /// Some functions in this class are static.
    /// </summary>
    public class UncertainNumber
    {
        /// <summary>
        /// 
        /// </summary>
        public enum UncertaintyType
        {
            /// <summary>
            /// 
            /// </summary>
            AbsoluteUncertainty,
            
            /// <summary>
            /// 
            /// </summary>
            RelativeUncertainty
        }

        /// <summary>
        /// Gets the value of this instance
        /// </summary>
        public readonly decimal Value;
        /// <summary>
        /// Gets the current absolute uncertainty
        /// </summary>
        public readonly decimal Uncertainty;

        /// <summary>
        /// Gets the relative uncertainty, ranging from 0 to 100
        /// </summary>
        public decimal RelativeUncertainty
        {
            get { return Uncertainty / Value * 100; }
        }

        /// <summary>
        /// Creates a new UncertainNumber using an absolute uncertainty
        /// </summary>
        /// <param name="value">Value</param>
        /// <param name="uncertainty">Absolute uncertainty</param>
        public UncertainNumber(decimal value, decimal uncertainty)
        {
            Value = value;
            Uncertainty = uncertainty;

            if(Uncertainty < 0)
            {
                Uncertainty = Uncertainty * -1;
            }
        }
        
        /// <summary>
        /// Creates a new UncertainNumber using an absolute OR relative uncertainty
        /// </summary>
        /// <param name="value">Value</param>
        /// <param name="uncertainty">Absolute or relative uncertainty</param>
        /// <param name="uncertaintyType">Type of uncertainty passed in the uncertainty parameter</param>
        public UncertainNumber(decimal value, decimal uncertainty, UncertaintyType uncertaintyType)
        {
            switch (uncertaintyType)
            {
                case UncertaintyType.AbsoluteUncertainty:
                    Value = value;
                    Uncertainty = uncertainty;
                    break;
                case UncertaintyType.RelativeUncertainty:
                    Value = value;
                    Uncertainty = (uncertainty / 100) * value;
                    break;
            }
        }

        /// <summary>
        /// Returns the value obtained by a custom function. (In order to add more input parameters, use the static method UncertainNumber.CustomFunction.)
        /// </summary>
        /// <param name="function">The custom function</param>
        /// <returns></returns>
        public UncertainNumber CustomFunction(Func<decimal, decimal> function)
        {
            //allow usage of mathos parser + lambda functions (write article on how to integrate mathos parser
            return CustomFunction(x => function(x[0]), new UncertainNumber(Value, Uncertainty));
        }

        /// <summary>
        /// Returns the value obtained by a custom function with multiple input variables.
        /// </summary>
        /// <param name="function">The custom function</param>
        /// <param name="points">The set of points</param>
        /// <returns></returns>
        public static UncertainNumber CustomFunction(Func<decimal[],decimal> function , params UncertainNumber[] points )
        {
            //allow usage of mathos parser + lambda functions (write article on how to integrate mathos parser

            decimal absoluteUncertainty = 0;

            var pointValues = ConvertValuesToDecimalArray(points);

            for (var i = 0; i < points.Length; i++)
            {
                var derivative = Calculus.DifferentialCalculus.FirstDerivative(function, i, pointValues);

                if(derivative < 0)
                {
                    derivative = decimal.Negate(derivative);
                }

                absoluteUncertainty += derivative * points[i].Uncertainty;
            }

            return new UncertainNumber(function(pointValues), absoluteUncertainty);
        }

        /// <summary>
        /// Converts an UncertainNumber array to a decimal array with the values only (uncertainties are not included). 
        /// </summary>
        /// <param name="numbers">The array with UncertainNumbers</param>
        /// <returns></returns>
        public static decimal[] ConvertValuesToDecimalArray (UncertainNumber[] numbers)
        {
            var ret = new decimal[numbers.Length];
            
            for (var i = 0; i < numbers.Length; i++)
            {
                ret[i] = numbers[i].Value;
            }

            return ret;
        }

        /// <summary>
        /// Converts an UncertainNumber array to a TSV string.
        /// </summary>
        /// <param name="numbers">The array with UncertainNumbers</param>
        /// <returns></returns>
        public static string ConvertArrayToTsvString(UncertainNumber[] numbers)
        {
            return numbers.Aggregate("", (current, t) => current + (t.Value + "\t" + t.Uncertainty + "\n"));
        }

        /// <summary>
        /// Formats values according to the precision of the uncertainty. The uncertainty is returned with one significant figure.
        /// </summary>
        /// <remarks>This method does not affect the current object but returns a new object with the new formating.</remarks>
        public static UncertainNumber[] AutoFormat(UncertainNumber[] array)
        {
            var output = new UncertainNumber[array.Length];

            for (var i = 0; i < array.Length; i++)
            {
                output[i] = array[i].AutoFormat();
            }

            return output;
        }

        /// <summary>
        /// Returns the value obtained by a custom function with multiple input variables. Reads values from TSV.
        /// </summary>
        /// <param name="function">The custom function</param>
        /// <param name="tsv">The string that contains TSV data</param>
        /// <returns></returns>
        public static UncertainNumber[] CustomFunction(Func<decimal,decimal> function, string tsv)
        {
            return CustomFunction(x => function(x[0]), tsv);
        }

        /// <summary>
        /// Returns the value obtained by a custom function. Reads values from TSV.
        /// </summary>
        /// <param name="function">The custom function</param>
        /// <param name="tsv">The string that contains TSV data</param>
        /// <returns></returns>
        public static UncertainNumber[] CustomFunction(Func<decimal[],decimal> function, string tsv)
        {
            using (var reader = new  System.IO.StringReader(tsv))
            {
                string line;
                var final = new List<UncertainNumber>();
                
                while ((line = reader.ReadLine()) != null)
                {
                    var a = line.Split((char)9);

                    var temp = new UncertainNumber[a.Length/2];
                    
                    for (var i = 0; i < a.Length; i+=2)
                    {
                        temp[i] = new UncertainNumber(Convert.ToDecimal(a[i]), Convert.ToDecimal(a[i + 1]));
                    }
                    
                    final.Add(CustomFunction(function,temp));
                }

                return final.ToArray();
            }   
        }


        /// <summary>
        /// Formats the value according to the precision of the uncertainty. The uncertainty is returned with one significant figure.
        /// </summary>
        /// <remarks>This method does not affect the current object but returns a new object with the new formating.</remarks>
        public UncertainNumber AutoFormat()
        {
            var uncertainty = Uncertainty;// decimal.Ceiling(this.uncertainty);
            var value = Value;
            var uncertaintySigFig = GetSignificantDigitCount(uncertainty);

            //uncertainty = (decimal)Convert.ToDouble(uncertainty);

            if(uncertainty < 1)
            {
                if (uncertaintySigFig > 2)
                {
                    var temp = Convert.ToDecimal( uncertainty.ToString(CultureInfo.InvariantCulture).Replace(".", "")) ;
                    var zero = uncertaintySigFig-temp.ToString(CultureInfo.InvariantCulture).Length; // unsure about this step, although it is good when avoiding cases like 0.001500 (the extra zeroes at the end)
                    var num = PowD(10, zero);
                    
                    uncertainty = decimal.Ceiling(uncertainty * num) / (num * 1.0M);
                }

                value = Convert.ToDecimal(string.Format("{{0:F" + (uncertainty.ToString(CultureInfo.InvariantCulture).Length-2) + "}}", value - decimal.Floor(value))) + decimal.Floor(value) ;
            }
            else
            {
                if (uncertaintySigFig > 1)
                {
                    uncertainty = decimal.Floor(uncertainty);
                    if (uncertainty.ToString(CultureInfo.InvariantCulture).Length > 1)
                    {
                        var num = 1 / PowD(10, uncertainty.ToString(CultureInfo.InvariantCulture).Length - 2) * 0.1M; // important that y is an uint.
                        
                        uncertainty = decimal.Ceiling(uncertainty * num) / (num);
                    }
                }
                value = Convert.ToDecimal( Convert.ToDouble(string.Format("{{0:G" + (decimal.Floor(value).ToString(CultureInfo.InvariantCulture).Length- uncertainty.ToString(CultureInfo.InvariantCulture).Length+1) + "}}", decimal.Floor( value))));//Decimal.Round(Decimal.Floor(value), uncertaintySigFig);
            }

            return new UncertainNumber(value, uncertainty);
        }

        private decimal PowD(decimal x, int y)
        {
            // from http://stackoverflow.com/a/12408927/1275924

            var a = 1m;
            var e = new System.Collections.BitArray(BitConverter.GetBytes(y));
            var t = e.Count;

            for (var i = t - 1; i >= 0; --i)
            {
                a *= a;

                if (e[i])
                {
                    a *= x;
                }
            }

            return a;
        }


        /// <summary>
        /// Returns the number raised to a specified power.
        /// </summary>
        /// <param name="power"></param>
        /// <returns></returns>
        public UncertainNumber Pow(decimal power)
        {
            return new UncertainNumber((decimal)Math.Pow((double)Value, (double)power), Uncertainty * power * Value);
        }

        /// <summary>
        /// Returns the natural (base e) logarithm of the number.
        /// </summary>
        /// <returns></returns>
        public UncertainNumber Log()
        {
            return new UncertainNumber((decimal)Math.Log((double)Value), Uncertainty / Value);
        }
        
        /// <summary>
        /// Returns the sine value of the specified angle (in radians).
        /// </summary>
        /// <returns></returns>
        public UncertainNumber Sin()
        {
            return new UncertainNumber((decimal)Math.Sin((double)Value), (decimal)Math.Cos((double)Value) * Uncertainty);
        }

        /// <summary>
        /// Returns the cosine value of the specified angle (in radians).
        /// </summary>
        /// <returns></returns>
        public UncertainNumber Cos()
        {
            return new UncertainNumber((decimal)Math.Cos((double)Value), (decimal)Math.Sin((double)Value) * Uncertainty);
        }

        /// <summary>
        /// Returns e raised to a specified power.
        /// </summary>
        /// <returns></returns>
        public UncertainNumber Exp()
        {
            return new UncertainNumber((decimal)Math.Exp((double)Value), Uncertainty * (decimal)Math.Exp((double)Value));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static UncertainNumber operator +(UncertainNumber n1, UncertainNumber n2)
        {
            return new UncertainNumber(n1.Value + n2.Value, n1.Uncertainty + n2.Uncertainty);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static UncertainNumber operator -(UncertainNumber n1, UncertainNumber n2)
        {
            return new UncertainNumber(n1.Value - n2.Value, n1.Uncertainty + n2.Uncertainty);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static UncertainNumber operator *(UncertainNumber n1, UncertainNumber n2)
        {
            return new UncertainNumber(n1.Value * n2.Value, n1.RelativeUncertainty + n2.RelativeUncertainty, UncertaintyType.RelativeUncertainty);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="constant"></param>
        /// <returns></returns>
        public static UncertainNumber operator *(UncertainNumber n1, decimal constant)
        {
            return new UncertainNumber(n1.Value * constant, n1.Uncertainty * constant);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static UncertainNumber operator /(UncertainNumber n1, UncertainNumber n2)
        {
            return new UncertainNumber(n1.Value / n2.Value, n1.RelativeUncertainty + n2.RelativeUncertainty, UncertaintyType.RelativeUncertainty);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="constant"></param>
        /// <returns></returns>
        public static UncertainNumber operator /(UncertainNumber n1, decimal constant)
        {
            return new UncertainNumber(n1.Value / constant, n1.Uncertainty * constant);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static bool operator ==(UncertainNumber n1, UncertainNumber n2)
        {
            return n2 != null && (n1 != null && Math.Abs(n1.Value - n2.Value) <= n1.Uncertainty + n2.Uncertainty);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static bool operator ==(UncertainNumber n1, decimal n2)
        {
            return n1 != null && Math.Abs(n1.Value - n2) <= n1.Uncertainty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static bool operator !=(UncertainNumber n1, UncertainNumber n2)
        {
            return !(n2 != null) || (!(n1 != null) || Math.Abs(n1.Value - n2.Value) > n1.Uncertainty + n2.Uncertainty);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static bool operator !=(UncertainNumber n1, decimal n2)
        {
            return !(n1 != null) || Math.Abs(n1.Value - n2) > n1.Uncertainty;
        }

        /// <summary>
        /// Checks whether the uncertain number is equal to the given object.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            
            return obj.GetType() == GetType() && Equals((UncertainNumber) obj);
        }

        /// <summary>
        /// Returns the number including its uncertainty (as a string).
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Value + " +/- " + Uncertainty;
        }

        private static int GetSignificantDigitCount(decimal value)
        {
            /* By Dan Tao at http://stackoverflow.com/q/3683718/1275924 */
            var bits = decimal.GetBits(value);

            if (value >= 1M || value <= -1M)
            {
                var highPart = bits[2];
                var middlePart = bits[1];
                var lowPart = bits[0];
                var num = new decimal(lowPart, middlePart, highPart, false, 0);
                var exponent = (int)Math.Ceiling(Math.Log10((double)num));

                return exponent;
            }
            else
            {
                var scalePart = bits[3];

                // Accoring to MSDN, the exponent is represented by
                // bits 16-23 (the 2nd word):
                // http://msdn.microsoft.com/en-us/library/system.decimal.getbits.aspx
                var exponent = (scalePart & 0x00FF0000) >> 16;

                return exponent + 1;
            }
        }

        /// <summary>
        /// Checks whether the uncertain type is equal to another.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        protected bool Equals(UncertainNumber other)
        {
            return Value == other.Value && Uncertainty == other.Uncertainty;
        }

        /// <summary>
        /// Gets the hashcode of the uncertain type.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return (Value.GetHashCode() * 397) ^ Uncertainty.GetHashCode();
            }
        }
    }
}
