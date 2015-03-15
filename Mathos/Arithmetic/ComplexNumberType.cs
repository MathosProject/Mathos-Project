using System;
using System.Globalization;
using System.Numerics;
using Mathos.Arithmetic.Fractions;
using Mathos.Calculus;

namespace Mathos.Arithmetic
{
    namespace ComplexNumbers
    {
        /// <summary>
        /// The Complex Number type makes it possible to store numbers in form of a + bi, where a,b are real numbers and i is sqrt(-1).
        /// The real part of the number is stored as a decimal.
        /// </summary>
        [Obsolete]
        public struct ComplexNumber
        {
            private double _realPart;

            /// <summary>
            /// 
            /// </summary>
            public double RealPart
            {
                get { return _realPart; }
                set { _realPart = value; }
            }

            private double _imaginaryPart;
            
            /// <summary>
            /// 
            /// </summary>
            public double ImaginaryPart
            {
                get { return _imaginaryPart; }
                set { _imaginaryPart = value; }
            }
            
            /// <summary>
            /// 
            /// </summary>
            public double Modulus
            {
                get
                {
                    if (Math.Abs(_realPart) >=
                        Math.Abs(_imaginaryPart))
                    {
                        return Math.Abs(_realPart) *
                            Math.Sqrt(1D + Math.Pow(_imaginaryPart / _realPart, 2));
                    }
                    
                    return Math.Abs(_imaginaryPart) *
                           Math.Sqrt(1D + Math.Pow(_realPart / _imaginaryPart, 2));
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public double Argument
            {
                get
                {
                    if (Math.Abs(_realPart) < 1 && Math.Abs(_imaginaryPart) < 1)
                        return 0;
                    
                    return Math.Atan2(_imaginaryPart, _realPart);
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public bool IsReal
            {
                get
                {
                    return Math.Abs(_imaginaryPart) < 1;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public bool IsPureImaginary
            {
                get
                {
                    return Math.Abs(_realPart) < 1;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public ComplexNumber Conjugate
            {
                get
                {
                    return new ComplexNumber(_realPart, -_imaginaryPart);
                }
            }

            ////constructor
            //public ComplexNumber()
            //{
            //    _realPart = 0.0M;
            //    _imaginaryPart = 0.0M;

            //}

            //constructor2
            /// <summary>
            /// 
            /// </summary>
            /// <param name="inRealPart"></param>
            public ComplexNumber (Int64 inRealPart)
            {
                _realPart = inRealPart;
                _imaginaryPart = 0;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="inRealPart"></param>
            public ComplexNumber(decimal inRealPart)
            {
                _realPart = Convert.ToDouble(inRealPart);
                _imaginaryPart = 0;

            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="inRealPart"></param>
            public ComplexNumber(double inRealPart)
            {
                _realPart = inRealPart;
                _imaginaryPart = 0;
            }

            //constructor3
            /// <summary>
            /// 
            /// </summary>
            /// <param name="inRealPart"></param>
            /// <param name="inImaginaryPart"></param>
            public ComplexNumber(Int32 inRealPart, Int32 inImaginaryPart)
            {
                _realPart = inRealPart;
                _imaginaryPart = inImaginaryPart;

            }

            //constructor3
            /// <summary>
            /// 
            /// </summary>
            /// <param name="inRealPart"></param>
            /// <param name="inImaginaryPart"></param>
            public ComplexNumber(decimal inRealPart, decimal inImaginaryPart) :
                this(Convert.ToDouble(inRealPart), Convert.ToDouble(inImaginaryPart)) { }
            
            /// <summary>
            /// 
            /// </summary>
            /// <param name="inRealPart"></param>
            /// <param name="inImaginaryPart"></param>
            public ComplexNumber(double inRealPart, double inImaginaryPart)
            {
                _realPart = inRealPart;
                _imaginaryPart = inImaginaryPart;
            }

            //constructor3
            /// <summary>
            /// 
            /// </summary>
            /// <param name="inRealPart"></param>
            /// <param name="inImaginaryPart"></param>
            public ComplexNumber(Fraction inRealPart, Fraction inImaginaryPart):
                this(inRealPart.ToDouble(), inImaginaryPart.ToDouble())
            {
            }

            //constructor4
            /// <summary>
            /// 
            /// </summary>
            /// <param name="strcomplex"></param>
            public ComplexNumber(string strcomplex)
            {
                _realPart = 0;
                _imaginaryPart = 0;

                char[] seperator = { };
                var factor = 1;
                
                if (strcomplex.IndexOf('+') > 0)
                {
                    char[] seperator1 = { '+', 'i' };

                    seperator = seperator1;
                    factor = 1;
                }
                else if (strcomplex.IndexOf('-') > 0)
                {
                    char[] seperator2 = { '-', 'i' };

                    seperator = seperator2;
                    factor = -1;
                }


                var outStr = strcomplex.Split(seperator);
                var isImaginaryPart = strcomplex.Contains("i");

                outStr[0] = outStr[0].Replace("i", "");

                if ((outStr.Length == 1) && !isImaginaryPart || outStr.Length > 2)
                {
                    Double.TryParse(outStr[0], out _realPart);
                }
                if (isImaginaryPart)
                {
                    Double.TryParse(outStr[outStr.Length == 1 ? 0 : 1], out _imaginaryPart);
                }
                else
                {
                    _imaginaryPart = 0;
                }

                _imaginaryPart = _imaginaryPart * factor;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="c"></param>
            public ComplexNumber(Complex c) : this(c.Real, c.Imaginary)
            {
            }

            /* Struct converters */
            /// <summary>
            /// 
            /// </summary>
            /// <param name="value"></param>
            /// <returns></returns>
            public static implicit operator ComplexNumber(string value)
            {
                return new ComplexNumber(value);
            }
            
            /// <summary>
            /// 
            /// </summary>
            /// <param name="num"></param>
            /// <returns></returns>
            public static implicit operator ComplexNumber(Int16 num)
            {
                return new ComplexNumber(num);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="num"></param>
            /// <returns></returns>
            public static implicit operator ComplexNumber(Int32 num)
            {
                return new ComplexNumber(num);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="num"></param>
            /// <returns></returns>
            public static implicit operator ComplexNumber(Int64 num)
            {
                return new ComplexNumber(num);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="num"></param>
            /// <returns></returns>
            public static implicit operator ComplexNumber(double num)
            {
                return new ComplexNumber(num);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="num"></param>
            /// <returns></returns>
            public static implicit operator ComplexNumber(decimal num)
            {
                return new ComplexNumber(num, 0);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="cnum"></param>
            /// <returns></returns>
            public static implicit operator ComplexNumber(Complex cnum)
            {
                return new ComplexNumber(cnum);
            }

            public override string ToString()
            {
                var outString = "";

                if (_realPart > 0)
                {
                    outString = _realPart.ToString(CultureInfo.InvariantCulture);

                    if (_imaginaryPart > 0)
                    {
                        outString += "+";
                    }
                }

                if (Math.Abs(_imaginaryPart) > 0)
                {
                    outString += _imaginaryPart + "i";
                }

                return outString;
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj))
                    return false;

                return obj is ComplexNumber && Equals((ComplexNumber) obj);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="c1"></param>
            /// <param name="c2"></param>
            /// <returns></returns>
            public static Boolean operator ==(ComplexNumber c1, ComplexNumber c2)
            {
                return (Math.Abs(c1._realPart - c2._realPart) < 1) && (Math.Abs(c1._imaginaryPart - c2._imaginaryPart) < 1);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="c1"></param>
            /// <param name="c2"></param>
            /// <returns></returns>
            public static bool operator !=(ComplexNumber c1, ComplexNumber c2)
            {
                return !(Math.Abs(c1._realPart - c2._realPart) > 0) || (Math.Abs(c1._imaginaryPart - c2._imaginaryPart) > 0);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="c1"></param>
            /// <param name="c2"></param>
            /// <returns></returns>
            public static ComplexNumber operator +(ComplexNumber c1, ComplexNumber c2)
            {
                var result = new ComplexNumber
                {
                    _realPart = c1._realPart + c2._realPart,
                    _imaginaryPart = c1._imaginaryPart + c2._imaginaryPart
                };

                return result;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="c1"></param>
            /// <param name="c2"></param>
            /// <returns></returns>
            public static ComplexNumber operator -(ComplexNumber c1, ComplexNumber c2)
            {
                var result = new ComplexNumber
                {
                    _realPart = c1._realPart - c2._realPart,
                    _imaginaryPart = c1._imaginaryPart - c2._imaginaryPart
                };

                return result;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="c1"></param>
            /// <param name="c2"></param>
            /// <returns></returns>
            public static ComplexNumber operator *(ComplexNumber c1, ComplexNumber c2)
            {
                var result = new ComplexNumber
                {
                    _realPart = (c1.RealPart*c2._realPart) - (c2._imaginaryPart*c1._imaginaryPart),
                    _imaginaryPart = (c1._imaginaryPart*c2._realPart) + (c1._realPart*c2._imaginaryPart)
                };

                return result;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="c1"></param>
            /// <param name="c2"></param>
            /// <returns></returns>
            public static ComplexNumber operator /(ComplexNumber c1, ComplexNumber c2)
            {
                var result = new ComplexNumber();
                var a = c1.RealPart;
                var b = c1.ImaginaryPart;
                var c = c2.RealPart;
                var d = c2.ImaginaryPart;

                //result._realPart = (c1.realPart * c2._realPart) - (c2._imaginaryPart * c1._imaginaryPart);
                //result._imaginaryPart = (c1._imaginaryPart * c2._realPart) + (c1._realPart * c2._imaginaryPart);
                //return result;

                double fact, nom;

                if (Math.Abs(c) >= Math.Abs(d))
                {
                    fact = d / c;
                    nom = c + d * fact;
                    result.RealPart = (a + b * fact) / nom;
                    result.ImaginaryPart = (b - a * fact) / nom;
                }
                else
                {
                    fact = c / d;
                    nom = c * fact + d;
                    result.RealPart = (a * fact + b) / nom;
                    result.ImaginaryPart = (b * fact - a) / nom;
                }

                return result;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="magnitude"></param>
            /// <param name="phase"></param>
            /// <returns></returns>
            public static ComplexNumber FromPolar(double magnitude, double phase)
            {
                return new ComplexNumber(
                    magnitude*Math.Cos(phase),
                    magnitude*Math.Sin(phase)
                    );
            }

            /// <summary>
            /// 
            /// </summary>
            public static ComplexNumber I
            {
                get
                {
                    return new ComplexNumber(0, 1);
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public static ComplexNumber One
            {
                get
                {
                    return 1;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static class ComplexOperation
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="number"></param>
            /// <returns></returns>
            public static double AbsSquared(ComplexNumber number)
            {
                return (number.RealPart * number.RealPart) + 
                    (number.ImaginaryPart * number.ImaginaryPart);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="number"></param>
            /// <returns></returns>
            public static double LogOfAbs(ComplexNumber number)
            {
                var y = Math.Abs(number.ImaginaryPart);
                var x = Math.Abs(number.RealPart);
                var max = x;

                double u;

                if (x >= y)
                    u = y/x;
                else
                {
                    max = y;
                    u = x/y;
                }

                return Math.Log(max) + 0.5 * Elementary.LogOfOnePlusX(u * u);
            }

            // We need to extend this with square root of a complex num.
            // ComplexNumber is obsolete
            /// <summary>
            /// 
            /// </summary>
            /// <param name="number"></param>
            /// <returns></returns>
            public static ComplexNumber Sqrt(Int16 number)
            {
                return Sqrt((double)number);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="number"></param>
            /// <returns></returns>
            public static ComplexNumber Sqrt(Int32 number)
            {
                return Sqrt((double)number);
            } 

            /// <summary>
            /// 
            /// </summary>
            /// <param name="number"></param>
            /// <returns></returns>
            public static ComplexNumber Sqrt(Int64 number)
            {
                return Sqrt((double)number);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="number"></param>
            /// <returns></returns>
            public static ComplexNumber Sqrt(double number)
            {
                return number < 0 ? new ComplexNumber(0, Math.Sqrt(-number)) : Math.Sqrt(number);
            }

            /// <summary>
            /// Principal square root of a complex number
            /// </summary>
            /// <param name="number"></param>
            /// <returns></returns>
            public static ComplexNumber Sqrt(ComplexNumber number)
            {
                //if (number.realPart == 0 && number.imaginaryPart == 0)
                //    return new ComplexNumber(0, 0);

                //// Calculating the square root using the formula
                //// z = a+ib = (c+di)^2
                //// c = sqrt(a+sqrt(a^2+b^2))/2
                //// d = sign(b) * sqrt(-a+sqrt(a^2+b^2))/2

                //decimal sumofPowers = (decimal)(Math.Pow((double)number.realPart, 2) + Math.Pow((double)number.imaginaryPart, 2));
                //decimal x = (decimal)Math.Sqrt((Math.Sqrt((double)sumofPowers) + (double)number.realPart) / 2);
                //decimal y = Math.Sign(number.imaginaryPart) * (decimal)Math.Sqrt((Math.Sqrt((double)sumofPowers) - (double)number.realPart) / 2);
                //return new ComplexNumber(x, y);

                if (number.IsReal)
                {
                    return Sqrt(number.RealPart);
                }

                return ComplexNumber.FromPolar(Math.Sqrt(number.Modulus),
                    number.Argument / 2);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="number"></param>
            /// <returns></returns>
            public static ComplexNumber Log(ComplexNumber number)
            {
                return new ComplexNumber(
                    Math.Log(number.Modulus),
                    number.Argument);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="number"></param>
            /// <returns></returns>
            public static ComplexNumber Exp(ComplexNumber number)
            {
                return new ComplexNumber(
                    Math.Exp(number.RealPart) * Math.Cos(number.ImaginaryPart),
                    Math.Exp(number.RealPart) * Math.Sin(number.ImaginaryPart)
                    );
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <returns></returns>
            public static ComplexNumber Pow(ComplexNumber x, ComplexNumber y)
            {
                return Exp(y * Log(x));
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="z"></param>
            /// <param name="n"></param>
            /// <returns></returns>
            public static ComplexNumber[] Roots(ComplexNumber z, int n)
            {
                var rootMagnitude = Math.Pow(z.Modulus, 1.0 / n);
                var roots = new ComplexNumber[n];
                var delta = 2 * Math.PI / n;
                var phase = z.Argument / n;
                
                for (var i = 0; i < n; i++)
                {
                    roots[i] = ComplexNumber.FromPolar(rootMagnitude,
                        phase);
                    phase += delta;
                }

                return roots;
            }
        }
    }
}
