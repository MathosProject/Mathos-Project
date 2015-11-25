using System;
using System.Globalization;
using Mathos.Exceptions;

namespace Mathos.Arithmetic
{
    namespace Fractions
    {
        /// <summary>
        /// The Fraction type makes it possible to store numbers in form of p/q, where p,q are integers.
        /// The integer is stored as Int64 (long).
        /// </summary>
        public struct Fraction : Numbers.IRationalNumber
        {
            /* Properties */

            /// <summary>
            /// Gets or sets the "_numerator"
            /// </summary>
            public long Numerator { get; set; }

            /// <summary>
            /// Gets or sets the "_denominator"
            /// </summary>
            public long Denominator
            {
                get { return _denominator; }
                set
                {
                    if (value != 0)
                    {
                        if (_denominator < 0) // read more at void fractionChecker
                        {
                            _denominator = value * -1;
                            Numerator = Numerator * -1;
                        }
                        else
                        {
                            _denominator = value;
                        }
                    }
                    else
                        throw new DenominatorNullException();
                }
            }

            private long _denominator; // the hidden y coordinate

            void FractionChecker()
            {
                // fractionCheker is designed to avoid fractions like 2/-3 (better: -2/3)
                // and -2/-3 (better: 2/3)
                if (_denominator >= 0)
                    return;
                
                Numerator = Numerator * -1;
                _denominator = _denominator * -1;
            }
            
            /// <summary>
            /// 
            /// </summary>
            /// <param name="f"></param>
            public Fraction(Fraction f) : this()
            {
                Numerator = f.Numerator;
                Denominator = f.Denominator;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="numerator"></param>
            public Fraction(long numerator) : this(numerator, 1) // our constructor
            {
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="numerator"></param>
            /// <param name="denominator"></param>
            public Fraction(long numerator, long denominator) // our constructor
            {
                Numerator = numerator;
                _denominator = denominator;

                FractionChecker(); //cheking
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="fractA"></param>
            /// <param name="fractB"></param>
            public Fraction(Fraction fractA, Fraction fractB)
            {
                this = fractA / fractB;
                FractionChecker();
            }

            /// <summary>
            /// </summary>
            /// <param name="fractionInStringForm"></param>
            public Fraction(string fractionInStringForm) // overloading constructor
            {
                if (fractionInStringForm.Contains("/")) //checking if the separator exists
                {
                    try
                    {
                        fractionInStringForm = fractionInStringForm.Trim(' '); // trim away unnessesary stuff
                        Numerator = Convert.ToInt64(fractionInStringForm.Substring(0, fractionInStringForm.IndexOf('/')));
                        _denominator = Convert.ToInt64(fractionInStringForm.Substring(fractionInStringForm.IndexOf('/') + 1));
                    }
                    catch (Exception e)
                    {
                        throw new InvalidFractionFormatException("See the inner exception for details.", e);
                    }
                }
                else
                {
                    Numerator = Convert.ToInt64(fractionInStringForm.Trim());
                    _denominator = 1;
                }

                FractionChecker(); // checking
            }

            /// <summary>
            /// Returns the fully qualified type name of this instance.
            /// </summary>
            /// <returns>
            /// A <see cref="T:System.String"/> containing a fully qualified type name.
            /// </returns>
            /// <filterpriority>2</filterpriority>
            public override string ToString()
            {
                return _denominator == 1
                    ? Numerator.ToString(CultureInfo.InvariantCulture)
                    : (Numerator == 0 || _denominator == 0 ? "0" : Numerator + "/" + _denominator);
            }

            /// <summary>
            /// Indicates whether this instance and a specified object are equal.
            /// </summary>
            /// <returns>
            /// true if <paramref name="obj"/> and this instance are the same type and represent the same value; otherwise, false.
            /// </returns>
            /// <param name="obj">Another object to compare to. </param><filterpriority>2</filterpriority>
            public override bool Equals(object obj)
            {
                return obj != null && obj.GetType() == GetType() && this == ((Fraction) obj);
            }

            /// <summary>
            /// Returns the hash code for this instance.
            /// </summary>
            /// <returns>
            /// A 32-bit signed integer that is the hash code for this instance.
            /// </returns>
            /// <filterpriority>2</filterpriority>
            /// <exception cref="DenominatorNullException">Thrown if the denominator is null.</exception>
            public override int GetHashCode()
            {
                return Numerator.GetHashCode() ^ Denominator.GetHashCode();
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public decimal ToDecimal()
            {
                return (decimal)Numerator / _denominator;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public long ToInt64()
            {
                return Numerator / _denominator;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public double ToDouble()
            {
                return ((double)Numerator / _denominator);
            }

            /// <summary>
            /// Convert the fraction into a Stern-Brocot system
            /// </summary>
            /// <example>A fraction 3/2 will be expressed as RL.</example>
            /// <remarks>This method will return the fraction in terms of L's and R's</remarks>
            /// <returns>string</returns>
            public string ToSternBrocotSystem()
            {
                var output = "";
                var m = Numerator;
                var n = _denominator;

                while (n != m)
                {
                    if (m < n)
                    {
                        output += "L";
                        n = n - m;
                    }
                    else
                    {
                        output += "R";
                        m = m - n;
                    }
                }

                return output;

            }

            /// <summary>
            /// Convert a fraction in Stern-Brocot system to a fraction.
            /// </summary>
            /// <param name="sternBrocotRepresentation">Enter a string that contains L's and R's. It can be generated from a fraction by ToSternBrocotSystem method.</param>
            /// <remarks>Only works for upper case L and R. This method is case sensetive.</remarks>
            /// <example>LRRL will be 5/7</example>
            /// <returns></returns>
            public static Fraction FromSternBrocotSystem(string sternBrocotRepresentation)
            {
                sternBrocotRepresentation = sternBrocotRepresentation.ToUpper();

                var j = 0;
                var matArray = new Matrix[sternBrocotRepresentation.Length];
                
                foreach (var letter in sternBrocotRepresentation)
                {
                    switch (letter)
                    {
                        case 'L':
                            matArray[j] = new Matrix(new Vector(1, 1), new Vector(0, 1));

                            break;
                        case 'R':
                            matArray[j] = new Matrix(new Vector(1, 0), new Vector(1, 1));

                            break;
                    }

                    j++;
                }


                for (var i = matArray.Length - 2; i >= 0; i--)
                    matArray[i] *= matArray[i + 1];

                return new Fraction(Convert.ToInt64(matArray[0][1][0] + matArray[0][1][1]), Convert.ToInt64(matArray[0][0][0] + matArray[0][0][1]));
            }

            /// <summary>
            /// Converts a decimal to Stern-Brocot number system consisting of L's and R's. In order to convert a fraction, use the non-static method inside the fraction class.
            /// </summary>
            /// <param name="realNumber">Any real number you want to approximate.</param>
            /// <param name="continious">If set to true, the decimal part of the number will be treated as continious. That is, 0.9 would be the same as 1.</param>
            /// <param name="iterations">The number of times the conversion should be performed. The more, the more accurate.</param>
            /// <returns></returns>
            public static string ToSternBrocotSystem(decimal realNumber, bool continious = false, int iterations = 50)
            {
                var output = "";
                
                if (continious)
                {
                    var integerPart = Convert.ToInt64(decimal.Floor(realNumber));
                    //long fractionalPart = Convert.ToInt64(realNumber - decimal.Floor(realNumber));
                    var fractionalPart =
                        Convert.ToInt64(
                            realNumber.ToString(CultureInfo.InvariantCulture)
                                .Substring(
                                    realNumber.ToString(CultureInfo.InvariantCulture)
                                        .IndexOf(".", StringComparison.Ordinal) + 1));

                    output =
                        (integerPart +
                         new Fraction(fractionalPart,
                             Convert.ToInt64(Math.Pow(10, fractionalPart.ToString(CultureInfo.InvariantCulture).Length)) -
                             1)).ToSternBrocotSystem();
                }
                else
                {
                    for (var i = 0; i < iterations; i++)
                    {
                        if (realNumber < 1)
                        {
                            output += "L";
                            realNumber = realNumber / (1 - realNumber);
                        }
                        else
                        {
                            output += "R";
                            realNumber = realNumber - 1;
                        }
                    }
                }

                return output;
            }

            /// <summary>
            /// This method will convert a SternBrocot represented fraction, eg. LLRRLR and convert it to a condensed form.
            /// </summary>
            /// <param name="sternBrocotRepresentation">Enter a string that contains L's and R's. It can be generated from a fraction by ToSternBrocotSystem method.</param>
            /// <returns>For example, LLRRRL will return L(2)R(3)L(1)</returns>
            public static string ToCondensedSternBrocotSystem(string sternBrocotRepresentation)
            {
                sternBrocotRepresentation = sternBrocotRepresentation.ToUpper();

                var count = 0;
                var output = "";
                var type = sternBrocotRepresentation[0] != 'L' ; // true for R's and false for L's

                foreach (var item in sternBrocotRepresentation)
                {
                    if(item == 'L')
                    {
                        if (!type)
                            count++;
                        else
                        {
                            output += "R(" + count + ")";
                            count = 1;
                            type = false;
                        }
                    }
                    else
                    {
                        if (type)
                            count++;
                        else
                        {
                            output += "L(" + count + ")";
                            count = 1;
                            type = true;
                        }
                    }
                }

                output += type ? "R(" + count + ")" : "L(" + count + ")";

                return output;
            }

            /* Functions, etc... */

            /// <summary>
            /// Simplify a fraction
            /// </summary>
            /// <returns></returns>
            public Fraction Simplify()
            {
                var gdc = Numbers.Get.Gdc(Numbers.Convert.ToPositive(Numerator),
                    Numbers.Convert.ToPositive(_denominator));

                return new Fraction(Numerator/gdc, _denominator/gdc);
            }

            /// <summary>
            /// Find the invers
            /// </summary>
            /// <returns></returns>
            /// <exception cref="DenominatorNullException">Thrown if the denominator is null.</exception>
            public Fraction Inverse()
            {
                return new Fraction(Denominator, Numerator);
            }
            
            /* Struct operators */
            // comparison
            /// <summary>
            /// The equalto operator
            /// </summary>
            /// <param name="fractA"></param>
            /// <param name="fractB"></param>
            /// <returns></returns>
            public static bool operator ==(Fraction fractA, Fraction fractB)
            {
                fractA = fractA.Simplify(); // simplifying, e.g. if a is 4/2, and b 2/1, return true
                fractB = fractB.Simplify();

                return ((fractA.Numerator == fractB.Numerator) && (fractA.Denominator == fractB.Denominator));
            }

            /// <summary>
            /// The not-equalto operator
            /// </summary>
            /// <param name="fractA"></param>
            /// <param name="fractB"></param>
            /// <returns></returns>
            public static bool operator !=(Fraction fractA, Fraction fractB)
            {
                return !(fractA == fractB);
            }

            /// <summary>
            /// The more-than operator
            /// </summary>
            /// <param name="fractA"></param>
            /// <param name="fractB"></param>
            /// <returns></returns>
            public static bool operator >(Fraction fractA, Fraction fractB)
            {
                return (decimal)fractA.Numerator * fractB.Denominator > (decimal)fractB.Numerator * fractA.Denominator;
            }

            /// <summary>
            /// The less-than operator
            /// </summary>
            /// <param name="fractA"></param>
            /// <param name="fractB"></param>
            /// <returns></returns>
            public static bool operator <(Fraction fractA, Fraction fractB)
            {
                return (decimal)fractA.Numerator * fractB.Denominator < (decimal)fractB.Numerator * fractA.Denominator;
            }

            /// <summary>
            /// The more-than or equalto operator
            /// </summary>
            /// <param name="fractA"></param>
            /// <param name="fractB"></param>
            /// <returns></returns>
            public static bool operator >=(Fraction fractA, Fraction fractB)
            {
                return !(fractA < fractB);
            }

            /// <summary>
            /// The less-than or equalto operator
            /// </summary>
            /// <param name="fractA"></param>
            /// <param name="fractB"></param>
            /// <returns></returns>
            public static bool operator <=(Fraction fractA, Fraction fractB)
            {
                return !(fractA > fractB);
            }


            //add,sub,mul,div
            /// <summary>
            /// Addition
            /// </summary>
            /// <param name="longA"></param>
            /// <param name="fractA"></param>
            /// <returns></returns>
            public static Fraction operator +(long longA, Fraction fractA)
            {
                //addition
                return new Fraction(longA) + fractA;
            }

            /// <summary>
            /// Addition
            /// </summary>
            /// <param name="fractA"></param>
            /// <param name="fractB"></param>
            /// <returns></returns>
            public static Fraction operator +(Fraction fractA, Fraction fractB)
            {
                //addition
                fractA = fractA.Simplify(); // simplifying
                fractB = fractB.Simplify();

                if (fractA.Denominator == fractB.Denominator)
                {
                    var fraction = new Fraction //creating a new fraction
                    {
                        Numerator = fractA.Numerator + fractB.Numerator, // adding the nominators
                        Denominator = fractA.Denominator // assigning the denominator
                    };

                    return fraction.Simplify(); // a simplified version of the fraction
                }

                var gdc = Numbers.Get.Gdc(fractA.Denominator, fractB.Denominator);
                
                if (gdc == 1)
                {
                    // if the denominators are coprimes, i.e. no factors in common
                    var fraction = new Fraction
                    {
                        Numerator = fractA.Numerator * fractB.Denominator + fractB.Numerator * fractA.Denominator,
                        Denominator = fractA.Denominator * fractB.Denominator
                    };

                    return fraction.Simplify(); // a simplified version of the fraction
                }

                if (fractA.Denominator > fractB.Denominator) //fractA.Denominator will be the new denominator
                {
                    var fraction = new Fraction
                    {
                        Numerator = fractA.Numerator + fractB.Numerator * gdc,
                        Denominator = fractA.Denominator
                    };

                    return fraction.Simplify();
                }
                else //fractB.Denominator will be the new denominator
                {
                    var fraction = new Fraction
                    {
                        Numerator = fractB.Numerator + fractA.Numerator * gdc,
                        Denominator = fractB.Denominator
                    };

                    return fraction.Simplify();
                }
            }

            /// <summary>
            /// Subtraction
            /// </summary>
            /// <param name="fractA"></param>
            /// <param name="fractB"></param>
            /// <returns></returns>
            public static Fraction operator -(Fraction fractA, Fraction fractB)
            {
                //addition
                fractA = fractA.Simplify(); // simplifying
                fractB = fractB.Simplify();
                
                if (fractA.Denominator == fractB.Denominator)
                {
                    var fraction = new Fraction  //creating a new fraction
                    {
                        Numerator = fractA.Numerator - fractB.Numerator, // subtracting the nominators
                        Denominator = fractA.Denominator // assigning the denominator
                    };
                    return fraction.Simplify(); // a simplified version of the fraction
                }

                var gdc = Numbers.Get.Gdc(fractA.Denominator, fractB.Denominator);
                if (gdc == 1)
                {
                    // if the denominators are coprimes, i.e. no factors in common
                    var fraction = new Fraction
                    {
                        Numerator = fractA.Numerator * fractB.Denominator - fractB.Numerator * fractA.Denominator,
                        Denominator = fractA.Denominator * fractB.Denominator
                    };

                    return fraction.Simplify(); // a simplified version of the fraction
                }
                
                if (fractA.Denominator > fractB.Denominator) //fractA.Denominator will be the new denominator
                {
                    var fraction = new Fraction
                    {
                        Numerator = fractA.Numerator - fractB.Numerator * gdc,
                        Denominator = fractA.Denominator
                    };

                    return fraction.Simplify();
                }
                else //fractB.Denominator will be the new denominator
                {
                    var fraction = new Fraction
                    {
                        Numerator = fractB.Numerator - fractA.Numerator * gdc,
                        Denominator = fractB.Denominator
                    };

                    return fraction.Simplify();
                }
            }

            //do not forget multiplication
            /// <summary>
            /// Multiplication
            /// </summary>
            /// <param name="fractA"></param>
            /// <param name="fractB"></param>
            /// <returns></returns>
            public static Fraction operator *(Fraction fractA, Fraction fractB)
            {
                fractA = fractA.Simplify(); // simplifying
                fractB = fractB.Simplify();

                return new Fraction(fractA.Numerator * fractB.Numerator,
                                    fractA.Denominator * fractB.Denominator).Simplify();
            }

            /// <summary>
            /// Division
            /// </summary>
            /// <param name="fractA"></param>
            /// <param name="fractB"></param>
            /// <returns></returns>
            public static Fraction operator /(Fraction fractA, Fraction fractB)
            {
                fractA = fractA.Simplify(); // simplifying
                fractB = fractB.Simplify();

                return new Fraction(fractA.Numerator * fractB.Denominator,
                                    fractA.Denominator * fractB.Numerator).Simplify();
            }


            /* Struct converters */
            /// <summary>
            /// 
            /// </summary>
            /// <param name="value"></param>
            /// <returns></returns>
            public static implicit operator Fraction(string value)
            {
                Fraction fraction;

                if (value.Contains("/")) //checking if the separator exists
                {
                    // if it is a string input
                    try
                    {
                        value = value.Trim(' '); // trim away unnessesary stuff
                        
                        fraction = new Fraction
                        {
                            Numerator = Convert.ToInt64(value.Substring(0, value.IndexOf('/'))),
                            Denominator = Convert.ToInt64(value.Substring(value.IndexOf('/') + 1))
                        };
                        
                        return fraction;
                    }
                    catch
                    {
                        throw new InvalidFractionFormatException();
                    }
                }
                
                value = value.Trim(' '); // trim away unnessesary stuff

                fraction = new Fraction
                {
                    Numerator = Convert.ToInt64(value.Substring(0, value.Length)),
                    Denominator = 1
                };
                
                return fraction;
            }
            
            /// <summary>
            /// 
            /// </summary>
            /// <param name="num"></param>
            /// <returns></returns>
            public static implicit operator Fraction(long num)
            {
                return new Fraction(num);
            }

            //public static implicit operator Fraction(decimal num)
            //{
            //    decimal decimalSign = 0;
            //    decimal Z = 0;
            //    long denominator = 0;
            //    decimal accuracyFactor = 9;


            //    Fraction result = 0;

            //    if (num < 0.0m)
            //        decimalSign = -1.0m;
            //    else
            //        decimalSign = 1.0m;

            //    if (num == (Int64)num)
            //    {
            //        return new Fraction((Int64)num);
            //    }

            //    if (num < (decimal)Math.Pow(10, -19))
            //    {
            //        return new Fraction(999999999999999999);
            //    }


            //    Z = num;

            //    result.Denominator = 1;

            //    while ((decimal)(Math.Abs((double)num - (result.Numerator / result.Denominator))) < accuracyFactor || Z == (Int64)Z)
            //    {
            //        Z = 1 / (Z - (Int64)Z);
            //        long scratchValue = result.Denominator;
            //        result.Denominator = result.Denominator * (Int64)Z + denominator;
            //        denominator = scratchValue;
            //        result.Numerator = (Int64)(num * result.Denominator + 0.5m);

            //    }
            //    return result;
            //}
            /// <summary>
            /// 
            /// </summary>
            /// <param name="fraction"></param>
            /// <returns></returns>
            public static implicit operator decimal(Fraction fraction)
            {
                return (decimal)fraction.Numerator / fraction.Denominator;
            }
        }
    }
}
