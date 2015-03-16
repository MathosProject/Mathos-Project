using System;
using Mathos.Arithmetic.Fractions;
using Mathos.Exceptions;

namespace Mathos.Geometry // add these namespaces up to Mathos.Geometry.CoordinateGeomotry
{
    namespace TwoDimensional
    {
        /// <summary>
        /// 
        /// </summary>
        public class Calculate
        {
            /// <summary>
            /// Caclulate the slope of the line passing through the given coordinates.
            /// </summary>
            /// <param name="coordinateA">The first coordinate</param>
            /// <param name="coordinateB">The second coordinate</param>
            /// <returns></returns>
            public static Fraction Slope(Coordinate coordinateA, Coordinate coordinateB)
            {
                try
                {
                    return new Fraction(coordinateB.Y - coordinateA.Y, coordinateB.X - coordinateA.X).Simplify();
                }
                catch (Exception e)
                {
                    throw new ArgumentException(e.Message);
                }
            }

            /// <summary>
            /// Caclulate the distance between two points.
            /// </summary>
            /// <param name="coordinateA">The first coordinate</param>
            /// <param name="coordinateB">The second coordinate</param>
            /// <returns></returns>
            public static decimal Distance(Coordinate coordinateA, Coordinate coordinateB)
            {
                try
                {
                    return Convert.ToDecimal(Math.Sqrt(Math.Pow((double)coordinateA.X.ToDecimal() - (double)coordinateB.X.ToDecimal(), 2) + Math.Pow((double)coordinateA.Y.ToDecimal() - (double)coordinateB.Y.ToDecimal(), 2)));
                }
                catch
                {
                    throw new ArgumentException("Error when calculating the distance.");
                }
            }

            /// <summary>
            /// Calculate the mid point of two coordinates.
            /// </summary>
            /// <param name="coordinateA">The first coordinate</param>
            /// <param name="coordinateB">The second coordinate</param>
            /// <returns></returns>
            public static Coordinate MidPoint(Coordinate coordinateA, Coordinate coordinateB)
            {
                try
                {
                    return new Coordinate((coordinateA.X + coordinateB.X) / 2,
                                          (coordinateA.Y + coordinateB.Y) / 2);
                }
                catch
                {
                    throw new ArgumentException("Error when calculating the MidPoint");
                }
            }

            /// <summary>
            /// This works for coordinates containing integers.
            /// </summary>
            /// <param name="dimension"></param>
            /// <param name="coordinates"></param>
            /// <returns></returns>
            public static UInt64[,] VisualRepresentation(Coordinate dimension, Coordinate[] coordinates)
            {
                var system = new UInt64[dimension.Y.ToInt64 (), dimension.X.ToInt64()];

                foreach (var t in coordinates)
                {
                    system[t.Y.ToInt64(), t.X.ToInt64()] = 1;
                }

                return system;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public struct Coordinate
        {
            /* Proporties */
            private Fraction _x; // the hidden x coordinate
            /// <summary>
            /// The X coordinate
            /// </summary>
            public Fraction X
            {
                get { return _x; }
                set { _x = value; }
            }

            private Fraction _y; // the hidden y coordinate
            /// <summary>
            /// The Y coordinate
            /// </summary>
            public Fraction Y
            {
                get { return _y; }
                set { _y = value; }
            }


            /* Constructors, etc */

            /// <summary>
            /// Declaring a new coordinate.
            /// </summary>
            /// <param name="x">The X coordinate</param>
            /// <param name="y">The Y coordinate</param>
            public Coordinate(long x, long y) // our constructor
            {
                _x = new Fraction(x);
                _y = new Fraction(y);
            }
            /// <summary>
            /// Declaring a new coordinate.
            /// </summary>
            /// <param name="x">The X coordinate</param>
            /// <param name="y">The Y coordinate</param>
            public Coordinate(Fraction x, Fraction y)
            {
                _x = x;
                _y = y;
            }
            /// <summary>
            /// Declaring a new coordinate.
            /// </summary>
            /// <param name="coordinateInStringForm">The coordinate in a string</param>
            public Coordinate(string coordinateInStringForm) // overloading constructor
            {
                if (coordinateInStringForm.Contains(",")) //checking if the separator exists
                {
                    try
                    {
                        coordinateInStringForm = coordinateInStringForm.Trim(' ', '(', ')'); // trim away unnessesary stuff
                        _x = new Fraction(Convert.ToInt64(coordinateInStringForm.Substring(0, coordinateInStringForm.IndexOf(','))));
                        _y = new Fraction(Convert.ToInt64(coordinateInStringForm.Substring(coordinateInStringForm.IndexOf(',') + 1)));
                    }
                    catch
                    {
                        throw new InvalidCoordinateFormat();
                    }
                }
                else
                {
                    throw new InvalidCoordinateFormat();
                }
            }


            /* overriding ...*/
            /// <summary>
            /// Convert a coordinate into a string
            /// </summary>
            /// <returns></returns>
            public override string ToString()
            {
                //Returing the coordinate in a string form
                return "(" + _x.ToString() + "," + _y.ToString() + ")";
            }

            public override bool Equals(object obj)
            {
                if ((obj == null) || (obj.GetType() != GetType()))
                    return false;
                
                var coordinate = (Coordinate)obj;
                
                return (this == coordinate);
            }

            public override int GetHashCode()
            {
                return X.GetHashCode() ^ Y.GetHashCode();
            }


            /* Struct converters */
            /// <summary>
            /// 
            /// </summary>
            /// <param name="value"></param>
            /// <returns></returns>
            /// <exception cref="InvalidCoordinateFormat"></exception>
            public static implicit operator Coordinate(string value)
            {
                if (!value.Contains(",")) throw new InvalidCoordinateFormat();
                
                // if it is a string input
                try
                {
                    value = value.Trim(' ', '(', ')'); // trim away unnessesary stuff
                    
                    var coordinate = new Coordinate
                    {
                        X = new Fraction(Convert.ToInt64(value.Substring(0, value.IndexOf(',')))),
                        Y = new Fraction(Convert.ToInt64(value.Substring(value.IndexOf(',') + 1)))
                    };

                    return coordinate;
                }
                catch
                {
                    throw new InvalidCoordinateFormat();
                }
            }

            /* Struct operators */
            /// <summary>
            /// The equalto operator
            /// </summary>
            /// <param name="coordinate1"></param>
            /// <param name="coordinate2"></param>
            /// <returns></returns>
            public static Boolean operator ==(Coordinate coordinate1, Coordinate coordinate2)
            {
                return ((coordinate1.X == coordinate2.X) && (coordinate1.Y == coordinate2.Y));
            }

            /// <summary>
            /// The not-equalto operator
            /// </summary>
            /// <param name="coordinate1"></param>
            /// <param name="coordinate2"></param>
            /// <returns></returns>
            public static Boolean operator !=(Coordinate coordinate1, Coordinate coordinate2)
            {
                return !(coordinate1 == coordinate2);
            }
        }
    }
}
