using System;
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
                    throw new ArgumentException(e.Message, e);
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
                catch (Exception e)
                {
                    throw new ArgumentException("Error when calculating the distance.", e);
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
                catch (Exception e)
                {
                    throw new ArgumentException("Error when calculating the MidPoint", e);
                }
            }

            /// <summary>
            /// This works for coordinates containing integers.
            /// </summary>
            /// <param name="dimension"></param>
            /// <param name="coordinates"></param>
            /// <returns></returns>
            public static ulong[,] VisualRepresentation(Coordinate dimension, Coordinate[] coordinates)
            {
                var system = new ulong[dimension.Y.ToLong (), dimension.X.ToLong()];

                foreach (var t in coordinates)
                    system[t.Y.ToLong(), t.X.ToLong()] = 1;

                return system;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public struct Coordinate
        {
            /* Properties */
            
            /// <summary>
            /// The X coordinate
            /// </summary>
            public Fraction X { get; set; }

            /// <summary>
            /// The Y coordinate
            /// </summary>
            public Fraction Y { get; set; }


            /* Constructors, etc */

            /// <summary>
            /// Declaring a new coordinate.
            /// </summary>
            /// <param name="x">The X coordinate</param>
            /// <param name="y">The Y coordinate</param>
            public Coordinate(long x, long y) // our constructor
            {
                X = new Fraction(x);
                Y = new Fraction(y);
            }
            /// <summary>
            /// Declaring a new coordinate.
            /// </summary>
            /// <param name="x">The X coordinate</param>
            /// <param name="y">The Y coordinate</param>
            public Coordinate(Fraction x, Fraction y)
            {
                X = x;
                Y = y;
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
                        X = new Fraction(Convert.ToInt64(coordinateInStringForm.Substring(0, coordinateInStringForm.IndexOf(','))));
                        Y = new Fraction(Convert.ToInt64(coordinateInStringForm.Substring(coordinateInStringForm.IndexOf(',') + 1)));
                    }
                    catch (Exception e)
                    {
                        throw new InvalidCoordinateFormat("See the inner exception for details.", e);
                    }
                }
                else
                {
                    throw new InvalidCoordinateFormat();
                }
            }

            /* Overrides */

            /// <summary>
            /// Convert a coordinate into a string
            /// </summary>
            /// <returns></returns>
            public override string ToString()
            {
                //Returing the coordinate in a string form
                return "(" + X.ToString() + "," + Y.ToString() + ")";
            }

            /// <summary>
            /// Checks whether the coordinate is equal to the given object.
            /// </summary>
            /// <param name="obj"></param>
            /// <returns></returns>
            public override bool Equals(object obj)
            {
                if ((obj == null) || (obj.GetType() != GetType()))
                    return false;
                
                var coordinate = (Coordinate)obj;
                
                return this == coordinate;
            }

            /// <summary>
            /// Gets the hashcode of the coordinate.
            /// </summary>
            /// <returns></returns>
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
            public static implicit operator Coordinate(string value)
            {
                if (!value.Contains(","))
                    throw new InvalidCoordinateFormat();
                
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
            public static bool operator ==(Coordinate coordinate1, Coordinate coordinate2)
            {
                return (coordinate1.X == coordinate2.X) && (coordinate1.Y == coordinate2.Y);
            }

            /// <summary>
            /// The not-equalto operator
            /// </summary>
            /// <param name="coordinate1"></param>
            /// <param name="coordinate2"></param>
            /// <returns></returns>
            public static bool operator !=(Coordinate coordinate1, Coordinate coordinate2)
            {
                return !(coordinate1 == coordinate2);
            }
        }
    }
}
