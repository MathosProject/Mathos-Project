using System;
using System.Globalization;
using Convert = System.Convert;

using Mathos.Arithmetic.Numbers;
using Mathos.Exceptions;

namespace Mathos
{
    /// <summary>
    /// The fraction type makes it possible to store numbers in form of p/q, where p and q are integers.
    /// </summary>
    [Serializable]
    public class Fraction : IRational, IEquatable<Fraction>
    {
        /// <summary>
        /// Gets or sets the numerator.
        /// </summary>
        public long Numerator { get; set; }

        /// <summary>
        /// Gets or sets the denominator.
        /// </summary>
        public long Denominator
        {
            get { return _denominator; }
            set
            {
                if (value != 0)
                {
                    if (_denominator < 0)
                    {
                        _denominator = value * -1;
                        Numerator = Numerator * -1;
                    }
                    else
                        _denominator = value;
                }
                else
                    throw new DenominatorZeroException();
            }
        }

        private long _denominator;

        /// <summary>
        /// Create a fraction equal to one (1/1).
        /// </summary>
        public Fraction()
        {
            Numerator = 1;
            Denominator = 1;
        }

        /// <summary>
        /// Create a fraction from another.
        /// </summary>
        /// <param name="f">The other fraction.</param>
        public Fraction(Fraction f)
        {
            Numerator = f.Numerator;
            Denominator = f.Denominator;
        }

        /// <summary>
        /// Create a fraction with a numerator, defaulting the denominator to 1.
        /// </summary>
        /// <param name="numerator">The numerator.</param>
        public Fraction(long numerator) : this(numerator, 1)
        {
        }

        /// <summary>
        /// Create a fraction with a numerator and denominator.
        /// </summary>
        /// <param name="numerator">The numerator.</param>
        /// <param name="denominator">The denominator.</param>
        public Fraction(long numerator, long denominator)
        {
            Numerator = numerator;
            Denominator = denominator;

            FractionChecker();
        }

        /// <summary>
        /// Create a fraction from the result of dividing two others.
        /// </summary>
        /// <param name="fractA">The first fraction.</param>
        /// <param name="fractB">The second fraction.</param>
        public Fraction(Fraction fractA, Fraction fractB)
        {
            var tmp = fractA / fractB;

            Numerator = tmp.Numerator;
            Denominator = tmp.Denominator;

            FractionChecker();
        }

        /// <summary>
        /// Create a fraction from a string.
        /// </summary>
        /// <param name="fractionInStringForm">The string to use.</param>
        public Fraction(string fractionInStringForm)
        {
            if (fractionInStringForm.Contains("/")) //checking if the separator exists
            {
                try
                {
                    fractionInStringForm = fractionInStringForm.Trim(' '); // trim away unnessesary stuff
                    Numerator = Convert.ToInt64(fractionInStringForm.Substring(0, fractionInStringForm.IndexOf('/')));
                    _denominator =
                        Convert.ToInt64(fractionInStringForm.Substring(fractionInStringForm.IndexOf('/') + 1));
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

            FractionChecker();
        }

        /// <summary>
        /// Returns the fully qualified type name of this instance.
        /// </summary>
        /// <returns>The string version of the fraction.</returns>
        public override string ToString()
        {
            return _denominator == 1
                ? Numerator.ToString()
                : (Numerator == 0 ? "0" : Numerator + "/" + _denominator);
        }

        /// <summary>
        /// Gets the hashcode of this instance.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return (_denominator.GetHashCode() * 397) ^ Numerator.GetHashCode();
            }
        }

        /// <summary>
        /// Indicates whether this instance and a given object are equal.
        /// </summary>
        /// <param name="obj">The object to compare to.</param>
        /// <returns>Whether <paramref name="obj"/> is equal to the current fraction.</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            var frac = obj as Fraction;

            if (frac == null)
                return false;

            return this == frac;
        }

        /// <summary>
        /// Indicates whether this instance and a given fraction are equal.
        /// </summary>
        /// <returns>Whether <paramref name="other"/> is equal to the current fraction.</returns>
        /// <param name="other">Another object to compare to. </param>
        public bool Equals(Fraction other)
        {
            return other != null && this == other;
        }

        /// <summary>
        /// Convert the fraction into a decimal.
        /// </summary>
        /// <returns>The fraction converted into a decimal.</returns>
        public decimal ToDecimal()
        {
            return (decimal) Numerator / _denominator;
        }

        /// <summary>
        /// Convert the fraction into a long.
        /// </summary>
        /// <returns>The fraction converted into a long.</returns>
        public long ToLong()
        {
            return Numerator / _denominator;
        }

        /// <summary>
        /// Convert the fraction into a double.
        /// </summary>
        /// <returns>The fraction converted into a double.</returns>
        public double ToDouble()
        {
            return (double) Numerator / _denominator;
        }

        /// <summary>
        /// Convert the fraction into a float.
        /// </summary>
        /// <returns>The fraction converted into a float.</returns>
        public float ToFloat()
        {
            return (float) Numerator / _denominator;
        }

        /// <summary>
        /// Convert the fraction into a Stern-Brocot system
        /// </summary>
        /// <example>A fraction 3/2 will be expressed as RL.</example>
        /// <remarks>This method will return the fraction in terms of L's and R's</remarks>
        /// <returns>The fraction in Stern-Brocot form</returns>
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
        /// <param name="sternBrocotRepresentation">
        /// A string that contains L's and R's.
        /// It can be generated from a fraction by ToSternBrocotSystem method.
        /// </param>
        /// <remarks>Only works for upper case L and R. This method is case sensetive.</remarks>
        /// <example>LRRL will be 5/7</example>
        /// <returns>A fraction form <paramref name="sternBrocotRepresentation"/>.</returns>
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

            return new Fraction(Convert.ToInt64(matArray[0][1][0] + matArray[0][1][1]),
                Convert.ToInt64(matArray[0][0][0] + matArray[0][0][1]));
        }

        /// <summary>
        /// Converts a decimal to Stern-Brocot number system consisting of L's and R's. In order to convert a fraction, use the non-static method inside the fraction class.
        /// </summary>
        /// <param name="realNumber">Any real number you want to approximate.</param>
        /// <param name="continious">If set to true, the decimal part of the number will be treated as continious. That is, 0.9 would be the same as 1.</param>
        /// <param name="iterations">The number of times the conversion should be performed. The more, the more accurate.</param>
        /// <returns>The fraction as a Stern-Brocot string.</returns>
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
        /// <example>LLRRRL will return L(2)R(3)L(1)</example>
        /// <returns>The fraction in a condensed form of a Stern-Brocot string.</returns>
        public static string ToCondensedSternBrocotSystem(string sternBrocotRepresentation)
        {
            sternBrocotRepresentation = sternBrocotRepresentation.ToUpper();

            var count = 0;
            var output = "";
            var type = sternBrocotRepresentation[0] != 'L'; // true for R's and false for L's

            foreach (var item in sternBrocotRepresentation)
            {
                if (item == 'L')
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

        /// <summary>
        /// Simplify a fraction
        /// </summary>
        /// <returns>The simplified form of the fraction.</returns>
        public Fraction Simplify()
        {
            var gdc = Get.Gcd(Arithmetic.Numbers.Convert.ToPositive(Numerator),
                Arithmetic.Numbers.Convert.ToPositive(_denominator));

            return new Fraction(Numerator / gdc, _denominator / gdc);
        }

        /// <summary>
        /// Gets the inverse of this instance.
        /// </summary>
        /// <example>2/3 -> 3/2</example>
        /// <returns>The inverse of this fraction.</returns>
        public Fraction Inverse()
        {
            return new Fraction(Denominator, Numerator);
        }

        /// <summary>
        /// Gets the reciprocal of this instance.
        /// </summary>
        /// <example>2/3 -> 3/2</example>
        /// <returns>The reciprocal of this fraction.</returns>
        public Fraction Reciprocal()
        {
            return new Fraction(Denominator, Numerator);
        }

        /// <summary>
        /// Avoid fractions like 2/-3 (better: -2/3)
        /// and -2/-3 (better: 2/3).
        /// </summary>
        private void FractionChecker()
        {
            if (_denominator >= 0)
                return;

            Numerator = Numerator * -1;
            _denominator = _denominator * -1;
        }

        /// <summary>
        /// The equal-to operator.
        /// </summary>
        /// <param name="fractA">The first fraction.</param>
        /// <param name="fractB">The second fraction.</param>
        /// <returns>Whether <paramref name="fractA"/> is equal to <paramref name="fractB"/>.</returns>
        public static bool operator ==(Fraction fractA, Fraction fractB)
        {
            if (fractA == null || fractB == null)
                return fractA == null && fractB == null;

            fractA = fractA.Simplify();
            fractB = fractB.Simplify();

            return fractA.Numerator == fractB.Numerator && fractA.Denominator == fractB.Denominator;
        }

        /// <summary>
        /// The not-equal-to operator
        /// </summary>
        /// <param name="fractA">The first fraction.</param>
        /// <param name="fractB">The second fraction.</param>
        /// <returns>Whether <paramref name="fractA"/> does not equal <paramref name="fractB"/>.</returns>
        public static bool operator !=(Fraction fractA, Fraction fractB)
        {
            return !(fractA == fractB);
        }

        /// <summary>
        /// The more-than operator
        /// </summary>
        /// <param name="fractA">The first fraction.</param>
        /// <param name="fractB">The second fraction.</param>
        /// <returns>Whether <paramref name="fractA"/> is greater than <paramref name="fractB"/>.</returns>
        public static bool operator >(Fraction fractA, Fraction fractB)
        {
            return (decimal) fractA.Numerator * fractB.Denominator > (decimal) fractB.Numerator * fractA.Denominator;
        }

        /// <summary>
        /// The less-than operator
        /// </summary>
        /// <param name="fractA">The first fraction.</param>
        /// <param name="fractB">The second fraction.</param>
        /// <returns>Whether <paramref name="fractA"/> is less than <paramref name="fractB"/>.</returns>
        public static bool operator <(Fraction fractA, Fraction fractB)
        {
            return (decimal) fractA.Numerator * fractB.Denominator < (decimal) fractB.Numerator * fractA.Denominator;
        }

        /// <summary>
        /// The more-than or equal-to operator
        /// </summary>
        /// <param name="fractA">The first fraction.</param>
        /// <param name="fractB">The second fraction.</param>
        /// <returns>Whether <paramref name="fractA"/> is greater than or equal to <paramref name="fractB"/>.</returns>
        public static bool operator >=(Fraction fractA, Fraction fractB)
        {
            return !(fractA < fractB);
        }

        /// <summary>
        /// The less-than or equal-to operator
        /// </summary>
        /// <param name="fractA">The first fraction.</param>
        /// <param name="fractB">The second fraction.</param>
        /// <returns>Whether <paramref name="fractA"/> is less than or equal to <paramref name="fractB"/>.</returns>
        public static bool operator <=(Fraction fractA, Fraction fractB)
        {
            return !(fractA > fractB);
        }

        /// <summary>
        /// The addition operator
        /// </summary>
        /// <param name="longA">The first fraction.</param>
        /// <param name="fractA">The second fraction.</param>
        /// <returns><paramref name="longA"/> added to <paramref name="fractA"/>.</returns>
        public static Fraction operator +(long longA, Fraction fractA)
        {
            return new Fraction(longA) + fractA;
        }

        /// <summary>
        /// The addition operator
        /// </summary>
        /// <param name="fractA">The first fraction.</param>
        /// <param name="fractB">The second fraction.</param>
        /// <returns><paramref name="fractA"/> added to <paramref name="fractB"/>.</returns>
        public static Fraction operator +(Fraction fractA, Fraction fractB)
        {
            fractA = fractA.Simplify();
            fractB = fractB.Simplify();

            if (fractA.Denominator == fractB.Denominator)
            {
                var fraction = new Fraction
                {
                    Numerator = fractA.Numerator + fractB.Numerator,
                    Denominator = fractA.Denominator
                };

                return fraction.Simplify();
            }

            var gdc = Get.Gcd(fractA.Denominator, fractB.Denominator);

            if (gdc == 1)
            {
                var fraction = new Fraction
                {
                    Numerator = fractA.Numerator * fractB.Denominator + fractB.Numerator * fractA.Denominator,
                    Denominator = fractA.Denominator * fractB.Denominator
                };

                return fraction.Simplify();
            }

            if (fractA.Denominator > fractB.Denominator)
            {
                var fraction = new Fraction
                {
                    Numerator = fractA.Numerator + fractB.Numerator * gdc,
                    Denominator = fractA.Denominator
                };

                return fraction.Simplify();
            }
            else
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
        /// The subtraction operator
        /// </summary>
        /// <param name="fractA">The first fraction.</param>
        /// <param name="fractB">The second fraction.</param>
        /// <returns><paramref name="fractB"/> substracted from <paramref name="fractA"/>.</returns>
        public static Fraction operator -(Fraction fractA, Fraction fractB)
        {
            fractA = fractA.Simplify();
            fractB = fractB.Simplify();

            if (fractA.Denominator == fractB.Denominator)
            {
                var fraction = new Fraction
                {
                    Numerator = fractA.Numerator - fractB.Numerator,
                    Denominator = fractA.Denominator
                };
                return fraction.Simplify();
            }

            var gdc = Get.Gcd(fractA.Denominator, fractB.Denominator);

            if (gdc == 1)
            {
                var fraction = new Fraction
                {
                    Numerator = fractA.Numerator * fractB.Denominator - fractB.Numerator * fractA.Denominator,
                    Denominator = fractA.Denominator * fractB.Denominator
                };

                return fraction.Simplify();
            }

            if (fractA.Denominator > fractB.Denominator)
            {
                var fraction = new Fraction
                {
                    Numerator = fractA.Numerator - fractB.Numerator * gdc,
                    Denominator = fractA.Denominator
                };

                return fraction.Simplify();
            }
            else
            {
                var fraction = new Fraction
                {
                    Numerator = fractB.Numerator - fractA.Numerator * gdc,
                    Denominator = fractB.Denominator
                };

                return fraction.Simplify();
            }
        }

        /// <summary>
        /// The multiplication operator
        /// </summary>
        /// <param name="fractA">The first fraction.</param>
        /// <param name="fractB">The second fraction.</param>
        /// <returns><paramref name="fractA"/> multiplied by <paramref name="fractB"/>.</returns>
        public static Fraction operator *(Fraction fractA, Fraction fractB)
        {
            fractA = fractA.Simplify();
            fractB = fractB.Simplify();

            return new Fraction(fractA.Numerator * fractB.Numerator,
                fractA.Denominator * fractB.Denominator).Simplify();
        }

        /// <summary>
        /// The division operator
        /// </summary>
        /// <param name="fractA">The dividend.</param>
        /// <param name="fractB">The divisor.</param>
        /// <returns><paramref name="fractA"/> divided by <paramref name="fractB"/>.</returns>
        public static Fraction operator /(Fraction fractA, Fraction fractB)
        {
            fractA = fractA.Simplify();
            fractB = fractB.Simplify();

            return new Fraction(fractA.Numerator * fractB.Denominator,
                fractA.Denominator * fractB.Numerator).Simplify();
        }

        /// <summary>
        /// Implicit string to fraction operator.
        /// </summary>
        /// <param name="value">The value to turn into a fraction.</param>
        /// <returns>Returns <paramref name="value"/> converted into a fraction.</returns>
        public static implicit operator Fraction(string value)
        {
            Fraction fraction;

            if (value.Contains("/"))
            {
                try
                {
                    value = value.Trim(' ');

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

            value = value.Trim(' ');

            fraction = new Fraction
            {
                Numerator = Convert.ToInt64(value.Substring(0, value.Length)),
                Denominator = 1
            };

            return fraction;
        }

        /// <summary>
        /// The implicit long to fraction operator.
        /// </summary>
        /// <param name="num">The number to convert into a fraction.</param>
        /// <returns>Returns <paramref name="num"/> converted into a fraction.</returns>
        public static implicit operator Fraction(long num)
        {
            return new Fraction(num);
        }

        /// <summary>
        /// The implicit fraction to decimal operator.
        /// </summary>
        /// <param name="fraction">The fraction to convert into a double.</param>
        /// <returns>Returns <paramref name="fraction"/> converted into a double.</returns>
        public static explicit operator decimal(Fraction fraction)
        {
            return (decimal) fraction.Numerator / fraction.Denominator;
        }
    }
}
