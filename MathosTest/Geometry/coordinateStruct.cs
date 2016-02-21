using Mathos.Syntax;

#if NUNIT
using TestClass = NUnit.Framework.TestFixtureAttribute;
using TestMethod = NUnit.Framework.TestAttribute;
using Assert = NUnit.Framework.Assert;
#else
using Microsoft.VisualStudio.TestTools.UnitTesting;
#endif

namespace MathosTest.Geometry
{
    [TestClass]
    public class CoordinateStruct
    {
        /*
        [TestMethod]
        public void CoordinateBasic()
        {
            // declarations
            Coordinate coord1 = new Coordinate(3, 4);
            Coordinate coord2 = "5,7";
            
            // the result can be expressed as a fraction
            Fraction midPoint1 = Calculate.Slope(coord1, coord2);

            // ... or as a decimal
            decimal midPoint2 = Calculate.Slope("3,4", "5,7");

            decimal distance = Calculate.Distance(coord1, coord2);

        }
        */

        /*
        [TestMethod]
        public void SlopeMidPointCalculation()
        {
            Debug.WriteLine(Calculate.Slope("3,4", "5,7"));
            Debug.WriteLine(Calculate.Slope("3,4", "5,7"));

            Coordinate a = new Coordinate(3,2);
            Coordinate b = new Coordinate(5,7);

            Coordinate midPointAB = Calculate.MidPoint(a, b);

            
            Debug.WriteLine("MidPoint is: " + midPointAB.ToString ());
            Debug.WriteLine(new Coordinate());
            //Mathos.Arithmetics.Numbers.Convert.BaseType.base10
        }
        */

        [TestMethod]
        public void TestingExtensionMethods()
        {
            const int a = 3;

            Assert.IsTrue(a.IsPositive());
            Assert.IsFalse(a.IsNegative());

            const int b = 6;

            Assert.IsTrue(b.IsDivisible(3));
        }

        /*
        [TestMethod]
        public void TestVisualRepresentation()
        {   
            Debug.WriteLine("The coordinate system");

            // declaring a collection of coordinates
            var coords = new[]
            {
                new Coordinate(2, 3), new Coordinate(3, 4),
                new Coordinate(0, 0), new Coordinate(0, 10),
                new Coordinate(10, 0), new Coordinate(10, 10),
            };

            // converting the coolection of coordinates to UInt64 (ulong) array
            var system = Calculate.VisualRepresentation(new Coordinate(11, 11), coords);

            // looping through the array
            for (var i = 0; i < 11; i++)
            {
                for (var j = 0; j < 11; j++)
                    Debug.Write(system[i, j]);

                Debug.WriteLine("");
            }

            // this will output a coordinate system in following format:
            // (x1,y1),(x2,y2)...(xn,y1)
            // (x1,y2),(x2,y2)...(xn,y2)
            // ...
            // x -> to the right
            // y
            // |
            // V
            // to the bottom

            //increase  to <= not < from 0 10 inclusive

        }
        */
    }
}
