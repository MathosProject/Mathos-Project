using System;
using Mathos.Exceptions;

/* MOVED THE PRIVIOUS TRIANGLE CLASS TO RightTriangle.cs */
namespace Mathos.Geometry.Shapes
{
    /// <summary>
    /// 
    /// </summary>
    public class Triangle : IShape2D
    {
        //make the user able to retrieve the values
        private double _sideA;
        private double _sideB;
        private double _sideC;
        private double _angleA;// angle opposite side A
        private double _angleB;// angle opposite side B
        private double _angleC;// angle opposite side C

        /// <summary>
        /// 
        /// </summary>
        public Triangle()
        {
            _sideA = 0;
            _sideB = 0;
            _sideC = 0;
            _angleA = 0;
            _angleB = 0;
            _angleC = 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="length"></param>
        /// <param name="height"></param>
        public Triangle(double length, double height)
        {
            _sideA = length;
            _sideB = height;
            _sideC = Pythagorean.FindHypotenuse(_sideA, _sideB);
            _angleC = 90;
            _angleB = Math.Atan(height / length);
            _angleA = _angleB - 90;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rightTriangle"></param>
        public Triangle(RightTriangle rightTriangle)
        {
            _sideA = rightTriangle.Length;
            _sideB = rightTriangle.Height;
            _sideC = Pythagorean.FindHypotenuse(_sideA, _sideB);
            _angleC = 90;
            _angleB = Math.Atan(_sideB / _sideA);
            _angleA = _angleB - 90;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sideA"></param>
        /// <param name="sideB"></param>
        /// <param name="sideC"></param>
        /// <param name="angleA"></param>
        /// <param name="angleB"></param>
        /// <param name="angleC"></param>
        /// <exception cref="InvalidTriangleException"></exception>
        public Triangle(double sideA=0.0, double sideB=0.0, double sideC=0.0, double angleA=0.0, double angleB=0.0, double angleC=0.0)
        {
            var c = 0;

            _sideA = sideA;
            _sideB = sideB;
            _sideC = sideC;
            _angleA = angleA;
            _angleB = angleB;
            _angleC = angleC;

            while (Math.Abs(_sideA) < 1 || Math.Abs(_sideB) < 1 || Math.Abs(_sideC) < 1 || Math.Abs(_angleA) < 1 ||
                   Math.Abs(_angleB) < 1 || Math.Abs(_angleC) < 1)
            {
                c++;

                if (Math.Abs(_angleA) < 1)
                {
                    //in case of SSA (two sides and an angle is known )A=Sin_inverse(a*sin(B)/b)
                    _angleA = (Math.Abs(_angleB) > 0 && Math.Abs(_angleC) > 0)
                        ? 180 - (_angleB + _angleC)
                        : _angleA;
                    //in case of two known angles third angle = (180-sum of two angles)
                    _angleA = (Math.Abs(_angleB) > 0 && Math.Abs(_sideB) > 0 && Math.Abs(_sideA) > 0)
                        ? (180/Math.PI)*Math.Asin(_sideA*Math.Sin((Math.PI/180)*_angleB)/_sideB)
                        : _angleA;
                    //in case of SSA (two sides and an angle is known )A=Sin_inverse(a*sin(C)/c)
                    _angleA = (Math.Abs(_angleC) > 0 && Math.Abs(_sideC) > 0 && Math.Abs(_sideA) > 0)
                        ? (180/Math.PI)*Math.Asin(_sideA*Math.Sin((Math.PI/180)*_angleC)/_sideC)
                        : _angleA;
                    //in case of SSS (all sides are known) A=Cos_inverse((b^2 + c^2 - a^2)/2bc)
                    _angleA = (Math.Abs(_sideB) > 0 && Math.Abs(_sideC) > 0 && Math.Abs(_sideA) > 0)
                        ? (180/Math.PI)*
                          Math.Acos((_sideB*_sideB + _sideC*_sideC - _sideA*_sideA)/
                                    (2.0*_sideB*_sideC))
                        : _angleA; //in case of SSS (all sides are known) A=Cos_inverse((b^2 + c^2 - a^2)/2bc)
                }
                if (Math.Abs(_angleB) < 1) //similar to angleA
                {
                    _angleB = (Math.Abs(_angleA) > 0 && Math.Abs(_angleC) > 0)
                        ? 180 - (_angleA + _angleC)
                        : _angleB;
                    _angleB = (Math.Abs(_angleA) > 0 && Math.Abs(_sideA) > 0 && Math.Abs(_sideB) > 0)
                        ? (180/Math.PI)*Math.Asin(_sideB*Math.Sin((Math.PI/180)*_angleA)/_sideA)
                        : _angleB;
                    _angleB = (Math.Abs(_angleC) > 0 && Math.Abs(_sideC) > 0 && Math.Abs(_sideB) > 0)
                        ? (180/Math.PI)*Math.Asin(_sideB*Math.Sin((Math.PI/180)*_angleC)/_sideC)
                        : _angleB;
                    _angleB = (Math.Abs(_sideB) > 0 && Math.Abs(_sideC) > 0 && Math.Abs(_sideA) > 0)
                        ? (180/Math.PI)*
                          Math.Acos((_sideC*_sideC + _sideA*_sideA - _sideB*_sideB)/
                                    (2.0*_sideC*_sideA))
                        : _angleB;
                }
                if (Math.Abs(_angleC) < 1) //similar to angleA
                {
                    _angleC = (Math.Abs(_angleA) > 0 && Math.Abs(_angleB) > 0)
                        ? 180 - (_angleA + _angleB)
                        : _angleC;
                    _angleC = (Math.Abs(_angleA) > 0 && Math.Abs(_sideA) > 0 && Math.Abs(_sideC) > 0)
                        ? (180/Math.PI)*Math.Asin(_sideC*Math.Sin((Math.PI/180)*_angleA)/_sideA)
                        : _angleC;
                    _angleC = (Math.Abs(_angleB) > 0 && Math.Abs(_sideB) > 0 && Math.Abs(_sideC) > 0)
                        ? (180/Math.PI)*Math.Asin(_sideC*Math.Sin((Math.PI/180)*_angleB)/_sideB)
                        : _angleC;
                    _angleC = (Math.Abs(_sideB) > 0 && Math.Abs(_sideC) > 0 && Math.Abs(_sideA) > 0)
                        ? (180/Math.PI)*
                          Math.Acos((_sideB*_sideB + _sideA*_sideA - _sideC*_sideC)/
                                    (2.0*_sideB*_sideA))
                        : _angleC;
                }
                if (Math.Abs(_sideA) < 1)
                {
                    //in case of AAS (two angles and a side) a=sin(A)*(b/sin(B))
                    _sideA = (Math.Abs(_angleA) > 0 && Math.Abs(_angleB) > 0 && Math.Abs(_sideB) > 0)
                        ? (Math.Sin((Math.PI/180)*_angleA)*(_sideB/Math.Sin((Math.PI/180)*_angleB)))
                        : _sideA;
                    //in case of AAS (two angles and a side) a=sin(A)*(c/sin(C))
                    _sideA = (Math.Abs(_angleA) > 0 && Math.Abs(_angleC) > 0 && Math.Abs(_sideC) > 0)
                        ? (Math.Sin((Math.PI/180)*_angleA)*(_sideC/Math.Sin((Math.PI/180)*_angleC)))
                        : _sideA;
                    //in case of SSA (two sides and an angle) a=sqrt(b^2 + c^2 - 2*b*c*cos(A))
                    _sideA = (Math.Abs(_sideB) > 0 && Math.Abs(_sideC) > 0 && Math.Abs(_angleA) > 0)
                        ? Math.Sqrt(_sideB*_sideB + _sideC*_sideC -
                                    2.0*_sideB*_sideC*Math.Cos((Math.PI/180)*_angleA))
                        : _sideA;
                }
                if (Math.Abs(_sideB) < 1) //similar to sideA
                {
                    _sideB = (Math.Abs(_angleB) > 0 && Math.Abs(_angleC) > 0 && Math.Abs(_sideC) > 0)
                        ? (Math.Sin((Math.PI/180)*_angleB)*(_sideC/Math.Sin((Math.PI/180)*_angleC)))
                        : _sideB;
                    _sideB = (Math.Abs(_angleB) > 0 && Math.Abs(_angleA) > 0 && Math.Abs(_sideA) > 0)
                        ? (Math.Sin((Math.PI/180)*_angleB)*(_sideA/Math.Sin((Math.PI/180)*_angleA)))
                        : _sideB;
                    _sideB = (Math.Abs(_sideA) > 0 && Math.Abs(_sideC) > 0 && Math.Abs(_angleB) > 0)
                        ? Math.Sqrt(_sideA*_sideA + _sideC*_sideC -
                                    2.0*_sideA*_sideC*Math.Cos((Math.PI/180)*_angleB))
                        : _sideB;
                }
                if (Math.Abs(_sideC) < 1) //similar to side A
                {
                    _sideC = (Math.Abs(_angleC) > 0 && Math.Abs(_angleB) > 0 && Math.Abs(_sideB) > 0)
                        ? (Math.Sin((Math.PI/180)*_angleC)*(_sideB/Math.Sin((Math.PI/180)*_angleB)))
                        : _sideC;
                    _sideC = (Math.Abs(_angleC) > 0 && Math.Abs(_angleA) > 0 && Math.Abs(_sideA) > 0)
                        ? (Math.Sin((Math.PI/180)*_angleC)*(_sideA/Math.Sin((Math.PI/180)*_angleA)))
                        : _sideC;
                    _sideC = (Math.Abs(_sideB) > 0 && Math.Abs(_sideA) > 0 && Math.Abs(_angleC) > 0)
                        ? Math.Sqrt(_sideB*_sideB + _sideA*_sideA -
                                    2.0*_sideB*_sideA*Math.Cos((Math.PI/180)*_angleC))
                        : _sideC;
                }
                if (c == 3) //did not get time to test out if while loop is required here or to find the optimum c
                    throw new InvalidTriangleException("Given information do not form a triangle");
            }

        }

        /// <summary>
        /// Gets or sets the side A
        /// </summary>
        public double SideA
        {
            get { return _sideA; }
            set { _sideA = value < 0 ? 0 : value; }
        }

        /// <summary>
        /// Gets or sets the side B
        /// </summary>
        public double SideB
        {
            get { return _sideB; }
            set { _sideB = value < 0 ? 0 : value; }
        }

        /// <summary>
        /// Gets or sets the side C
        /// </summary>
        public double SideC
        {
            get { return _sideC; }
            set { _sideC = value < 0 ? 0 : value; }
        }
        /// <summary>
        /// Gets or sets the angle opposite to side A
        /// </summary>
        public double AngleA
        {
            get { return _angleA; }
            set { _angleA = value < 0 ? 0 : value; }
        }
        /// <summary>
        /// Gets or sets the angle opposite to side B
        /// </summary>
        public double AngleB
        {
            get { return _angleB; }
            set { _angleB = value < 0 ? 0 : value; }
        }
        /// <summary>
        /// Gets or sets the angle opposite to side C
        /// </summary>
        public double AngleC
        {
            get { return _angleC; }
            set { _angleC = value < 0 ? 0 : value; }
        }
        /// <summary>
        /// Gets the area of the triangle
        /// </summary>
        public double Area
        {
            get 
            {
                var s = 0.5*(SideA + SideB + SideC);
                
                return Math.Sqrt(s*(s-SideA)*(s -SideB)*(s-SideC));
            }
        }

        /// <summary>
        /// Gets the perimeter of the triangle
        /// </summary>
        public double Perimeter
        {
            get { return SideA + SideB + SideC; }
        }

        /// <summary>
        /// Checks whether the given sides form a triangle with an angle sum of 180 degrees.
        /// </summary>
        /// <param name="a">Side A</param>
        /// <param name="b">Side B</param>
        /// <param name="c">Side C</param>
        /// <returns>True if it is an triangle, false if not.</returns>
        private bool IsTriangle(double a, double b, double c)
        {
            return !(a + b <= c) && !(b + c <= a) && !(a + c <= b);
        }

        #region Override Equals

        public override bool Equals(object obj)
        {
            var other = obj as Triangle;
            
            if (other == null)
            {
                return false;
            }

            return Math.Abs(_sideA - other._sideA) < 1 && Math.Abs(_sideB - other._sideB) < 1 &&
                   Math.Abs(_sideC - other._sideC) < 1 && Math.Abs(_angleA - other._angleA) < 1 &&
                   Math.Abs(_angleB - other._angleB) < 1 && Math.Abs(_angleC - other._angleC) < 1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Triangle other)
        {
            if (other == null)
            {
                return false;
            }

            return Math.Abs(_sideA - other._sideA) < 1 && Math.Abs(_sideB - other._sideB) < 1 &&
                   Math.Abs(_sideC - other._sideC) < 1 && Math.Abs(_angleA - other._angleA) < 1 &&
                   Math.Abs(_angleB - other._angleB) < 1 && Math.Abs(_angleC - other._angleC) < 1;
        }

        public override int GetHashCode()
        {
            return _sideA.GetHashCode() ^ _sideB.GetHashCode() ^ _sideC.GetHashCode() ^ _angleA.GetHashCode() ^ _angleB.GetHashCode() ^ _angleC.GetHashCode();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(Triangle a, Triangle b)
        {
            // If both are null, or both are same instance, return true.
            if (ReferenceEquals(a, b))
            {
                return true;
            }

            // If one is null, but not both, return false.
            if (((object)a == null) || ((object)b == null))
            {
                return false;
            }

            return Math.Abs(a._sideA - b._sideA) < 1 && Math.Abs(a._sideB - b._sideA) < 1 &&
                   Math.Abs(a._sideC - b._sideC) < 1 && Math.Abs(a._angleA - b._angleA) < 1 &&
                   Math.Abs(a._angleB - b._angleB) < 1 && Math.Abs(a._angleC - b._angleC) < 1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(Triangle a, Triangle b)
        {
            return !(a == b);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static implicit operator Triangle(RightTriangle a)
        {
            return new Triangle(a);
        }

        #endregion
    }
}
