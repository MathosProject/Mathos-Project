using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Mathos.Geometry;
using Mathos.Geometry.Shapes;

namespace MathosTest
{
    [TestClass]
    public class PythagoreanTest
    {
        [TestMethod]
        public void FindHypotenuse()
        {
            double hypotenuse = Pythagorean.FindHypotenuse(3, 4);

            // Using pythagorean theorem, this hypotenuse is 5
            Assert.AreEqual(5, hypotenuse);
        }

        [TestMethod]
        public void FindHypotenuseValidateInputs()
        {
            bool error = false;

            try
            {
                // Make sure side 1 is valid
                Pythagorean.FindHypotenuse(0, 2);
                error = true;
            }
            catch
            {
            }

            try
            {
                // Make sure side 2 is valid
                Pythagorean.FindHypotenuse(2, 0);
                error = true;
            }
            catch
            {
            }

            Assert.IsFalse(error, "We should have thrown errors above");
        }

        [TestMethod]
        public void FindNonHypotenuse()
        {
            double side2 = Pythagorean.FindNonHypotenuse(3, 5);

            // Using pythagorean theorem, the other side should be 4
            Assert.AreEqual(4, side2);
        }

        [TestMethod]
        public void FindNonHypotenuseValidateInputs()
        {
            bool error = false;

            try
            {
                // Make sure side 1 is valid
                Pythagorean.FindNonHypotenuse(0, 2);
                error = true;
            }
            catch
            {
            }

            try
            {
                // Make sure hypotenuse is valid
                Pythagorean.FindNonHypotenuse(2, 0);
                error = true;
            }
            catch
            {
            }

            try
            {
                // Make sure hypotenuse is > side 1
                Pythagorean.FindNonHypotenuse(2, 2);
                error = true;
            }
            catch
            {
            }

            Assert.IsFalse(error, "We should have thrown errors above");
        }
    }

    [TestClass]
    public class Shapes
    {
        [TestMethod]
        public void CircleTest()
        {
            Circle circle = new Circle(3);

            Assert.AreEqual(3, circle.Radius);
            Assert.AreEqual(28.274334, Math.Round(circle.Area, 6));
            Assert.AreEqual(18.849556, Math.Round(circle.Circumference, 6));
            Assert.AreEqual(18.849556, Math.Round(circle.Perimeter, 6));
            Assert.AreEqual(6, circle.Diameter);

            circle.Diameter = 10;
            Assert.AreEqual(5, circle.Radius);

            Circle circle2 = new Circle(5);

            Assert.AreEqual(circle, circle2);
        }

        [TestMethod]
        public void CubeTest()
        {
            Cube cube = new Cube(3);

            Assert.AreEqual(27, cube.Volume);
            Assert.AreEqual(54, cube.SurfaceArea);
            Assert.AreEqual(3, cube.Length);

            Cube cube2 = new Cube(3);

            Assert.AreEqual(cube, cube2);
        }

        [TestMethod]
        public void ParallelogramTest()
        {
            Parallelogram parallelogram = new Parallelogram(4, 5);

            Assert.AreEqual(20, parallelogram.Area);
            Assert.AreEqual(4, parallelogram.Length);
            Assert.AreEqual(5, parallelogram.Height);
            Assert.AreEqual(18, parallelogram.Perimeter);


            Parallelogram parallelogram2 = new Parallelogram(4, 5);

            Assert.AreEqual(parallelogram, parallelogram2);
        }

        [TestMethod]
        public void RectangleTest()
        {
            Rectangle rectangle = new Rectangle(4, 5);

            Assert.AreEqual(20, rectangle.Area);
            Assert.AreEqual(4, rectangle.Length);
            Assert.AreEqual(5, rectangle.Width);
            Assert.AreEqual(18, rectangle.Perimeter);

            Rectangle rectangle2 = new Rectangle(4, 5);

            Assert.AreEqual(rectangle, rectangle2);
        }

        [TestMethod]
        public void RectangularPrismTest()
        {
            RectangularPrism rectangularPrism = new RectangularPrism(4, 5, 6);

            Assert.AreEqual(120, rectangularPrism.Volume);
            Assert.AreEqual(148, rectangularPrism.SurfaceArea);
            Assert.AreEqual(4, rectangularPrism.Length);
            Assert.AreEqual(5, rectangularPrism.Width);
            Assert.AreEqual(6, rectangularPrism.Height);

            RectangularPrism rectangularPrism2 = new RectangularPrism(4, 5, 6);

            Assert.AreEqual(rectangularPrism, rectangularPrism2);
        }

        [TestMethod]
        public void RightCircularConeTest()
        {
            RightCircularCone rightCircularCone = new RightCircularCone(3, 4);

            Assert.AreEqual(3, rightCircularCone.Radius);
            Assert.AreEqual(4, rightCircularCone.Height);
            Assert.AreEqual(37.699112, Math.Round(rightCircularCone.Volume, 6));
            Assert.AreEqual(75.398224, Math.Round(rightCircularCone.SurfaceArea, 6));

            RightCircularCone rightCircularCone2 = new RightCircularCone(3, 4);

            Assert.AreEqual(rightCircularCone, rightCircularCone2);
        }

        [TestMethod]
        public void RightCircularCylinderTest()
        {
            RightCircularCylinder rightCircularCylinder = new RightCircularCylinder(3, 4);

            Assert.AreEqual(3, rightCircularCylinder.Radius);
            Assert.AreEqual(4, rightCircularCylinder.Height);
            Assert.AreEqual(113.097336, Math.Round(rightCircularCylinder.Volume, 6));
            Assert.AreEqual(131.946891, Math.Round(rightCircularCylinder.SurfaceArea, 6));

            RightCircularCylinder rightCircularCylinder2 = new RightCircularCylinder(3, 4);

            Assert.AreEqual(rightCircularCylinder, rightCircularCylinder2);
        }

        [TestMethod]
        public void SphereTest()
        {
            Sphere sphere = new Sphere(4);

            Assert.AreEqual(4, sphere.Radius);
            Assert.AreEqual(268.082573, Math.Round(sphere.Volume, 6));
            Assert.AreEqual(201.06193, Math.Round(sphere.SurfaceArea, 6));

            Sphere sphere2 = new Sphere(4);

            Assert.AreEqual(sphere, sphere2);
        }

        [TestMethod]
        public void SquareTest()
        {
            Square square = new Square(5);

            Assert.AreEqual(5, square.Length);
            Assert.AreEqual(25, square.Area);
            Assert.AreEqual(20, square.Perimeter);

            Square square2 = new Square(5);

            Assert.AreEqual(square, square2);
        }

        [TestMethod]
        public void SquarePyramidTest()
        {
            SquarePyramid squarePyramid = new SquarePyramid(5, 6);

            Assert.AreEqual(5, squarePyramid.Length);
            Assert.AreEqual(6, squarePyramid.Height);
            Assert.AreEqual(50, squarePyramid.Volume);
            Assert.AreEqual(90, squarePyramid.SurfaceArea);

            SquarePyramid squarePyramid2 = new SquarePyramid(5, 6);

            Assert.AreEqual(squarePyramid, squarePyramid2);
        }

        [TestMethod]
        public void TrapezoidTest()
        {
            Trapezoid trapezoid = new Trapezoid(5, 6, 7);

            Assert.AreEqual(5, trapezoid.BaseOne);
            Assert.AreEqual(6, trapezoid.BaseTwo);
            Assert.AreEqual(7, trapezoid.Height);
            Assert.AreEqual(38.5, trapezoid.Area);

            Trapezoid trapezoid2 = new Trapezoid(5, 6, 7);

            Assert.AreEqual(trapezoid, trapezoid2);
        }

        [TestMethod]
        public void RightTriangleTest()
        {
            RightTriangle triangle = new RightTriangle(5, 6);

            Assert.AreEqual(5, triangle.Length);
            Assert.AreEqual(6, triangle.Height);
            Assert.AreEqual(15, triangle.Area);

            RightTriangle triangle2 = new RightTriangle(5, 6);

            Assert.AreEqual(triangle, triangle2);

            RightTriangle triangle3 = new RightTriangle(3,4);
            Assert.AreEqual(12, triangle3.Perimeter);
        }

        [TestMethod]
        public void TriangleTest()
        {
            Triangle triangle = new Triangle(length:5, height:6);

            Assert.AreEqual(5, triangle.SideA);
            Assert.AreEqual(6, triangle.SideB);
            Assert.AreEqual(15, triangle.Area);

            RightTriangle triangle2 = new RightTriangle(5, 6);

            Assert.AreEqual(triangle, triangle2);
            Assert.AreEqual(triangle.Perimeter, triangle2.Perimeter);

            Triangle triangle3 = new Triangle(sideB:4,sideC:5,angleC:90);
            Assert.AreEqual(triangle3.Area, 6);
            Assert.AreEqual(12, triangle3.Perimeter);
            Triangle triangle4 = new Triangle(sideB: 3, sideC: 3, angleC: 60);
            Assert.AreEqual(9, triangle4.Perimeter);


            /*
            try
            {
                Triangle wrongTriangle = new Triangle(1,6,10);
                Assert.Fail("This triangle should've thrown an exception!");
            }
            catch (Mathos.Exceptions.InvalidTriangleException)
            {
            }
             */
        }
    }
}
