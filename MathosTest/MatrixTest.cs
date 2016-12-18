using System;

using Mathos;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MathosTest
{
    [TestClass]
    public class MatrixTest
    {
        [TestMethod]
        public void ToStringTest()
        {
            var matrix = new Matrix(2, 2);
            
            matrix[0] = new Vector(1, 2);
            matrix[1] = new Vector(3, 4);
            
            Assert.AreEqual("1 2" + Environment.NewLine + "3 4", matrix.ToString());
        }

        //....
        [TestMethod]
        public void TestMethod1()
        {
            Vector a = new Vector();
            Vector b = new Vector(2, 3, 4, 5);
            Vector c = new Vector();

            c.Add(2);
            c.Add(3);

            double result = c[0];

            Matrix m = new Matrix();
            Matrix n = new Matrix(new Vector(1, 2, 3, 4, 5),
                                  new Vector(6, 7, 8, 9, 10));

            Vector[] vectorColletion = new Vector[] { };

            Matrix ar = new double[3][]
            {
                new double[]{4},
                new double[]{5},
                new double[]{6}
            };

            double abc = ar[1][0];

            Matrix ab = new Matrix(4, 4);
        }

        [TestMethod]
        public void AddingMatrixAndScalar()
        {
            Matrix x = new Matrix(new Vector(3, 0, -1),
                                new Vector(2, -5, -1),
                                new Vector(-3, 1, -1));
            int n = 5;

            Matrix result = null;
            Matrix result2 = null;
            bool bCaughtException = false;
            try
            {
                result = x +n;
                result2 = n + x;
            }
            catch (ArgumentException o)
            {
                bCaughtException = true;
                return;
            }
            catch (Exception e)
            {
            }
            Assert.IsTrue(result[0] == new Vector(8, 5, 4));
            Assert.IsTrue(result[1] == new Vector(7, 0, 4));
            Assert.IsTrue(result[2] == new Vector(2, 6, 4));

            Assert.IsTrue(result2[0] == new Vector(8, 5, 4));
            Assert.IsTrue(result2[1] == new Vector(7, 0, 4));
            Assert.IsTrue(result2[2] == new Vector(2, 6, 4));

        }

        [TestMethod]
        public void SubtractingMatrixAndScalar()
        {
            Matrix x = new Matrix(new Vector(3, 0, -1),
                                new Vector(2, -5, -1),
                                new Vector(-3, 1, -1));
            int n = 5;

            Matrix result = null;
            Matrix result2 = null;
            bool bCaughtException = false;
            try
            {
                result = x - n;
                result2 = n - x;
            }
            catch (ArgumentException o)
            {
                bCaughtException = true;
                return;
            }
            catch (Exception e)
            {
            }
            Assert.IsTrue(result[0] == new Vector(-2, -5, -6));
            Assert.IsTrue(result[1] == new Vector(-3, -10, -6));
            Assert.IsTrue(result[2] == new Vector(-8, -4, -6));

            Assert.IsTrue(result2[0] == new Vector(2, 5, 6));
            Assert.IsTrue(result2[1] == new Vector(3, 10, 6));
            Assert.IsTrue(result2[2] == new Vector(8, 4, 6));

        }


        [TestMethod]
        public void Adding2Matrices()
        {
            Matrix x = new Matrix(new Vector(3, 0, -1),
                                new Vector(2, -5, -1),
                                new Vector(-3, 1, -1));
            Matrix y = new Matrix(new Vector(3, 0, 1),
                                new Vector(2, -5, 4),
                                new Vector(-3, 1, 3));
            Matrix result = new Matrix();
            bool bCaughtException = false;
            try
            {
                result = x + y;
            }
            catch (ArgumentException o)
            {
                bCaughtException = true; return;
            }
            catch (Exception e)
            {
            }
            Assert.IsTrue(result[0] == new Vector(6, 0, 0));
            Assert.IsTrue(result[1] == new Vector(4, -10, 3));
            Assert.IsTrue(result[2] == new Vector(-6, 2, 2));

        }
        [TestMethod]
        public void Subtracting2Matrices()
        {
            Matrix x = new Matrix(new Vector(3, 0, -1),
                                new Vector(2, -5, -1),
                                new Vector(-3, 1, -1));
            Matrix y = new Matrix(new Vector(3, 0, -1),
                                new Vector(2, -5, 4),
                                new Vector(-3, 1, 3));
            Matrix result = new Matrix();
            bool bCaughtException = false;
            try
            {
                result = x - y;
            }
            catch (ArgumentException o)
            {
                bCaughtException = true; return;
            }
            catch (Exception e)
            {
            }
            Assert.IsTrue(result[0] == new Vector(0, 0, 0));
            Assert.IsTrue(result[1] == new Vector(0, 0, -5));
            Assert.IsTrue(result[2] == new Vector(0, 0, -4));

        }

        [TestMethod]
        public void Adding2UnequalMatrices()
        {
            Matrix x = new Matrix(new Vector(3, 0),
                                new Vector(2, -5),
                                new Vector(-3, 1));
            Matrix y = new Matrix(new Vector(3, 0, 1),
                                new Vector(2, -5, 4),
                                new Vector(-3, 1, 3));
            bool bCaughtException = false;
            try
            {
                Matrix z = x + y;
            }
            catch (ArgumentException o)
            {
                bCaughtException = true; ;
                System.Diagnostics.Trace.TraceInformation(o.Message);
            }
            catch (Exception)
            {
            }
            Assert.IsTrue(bCaughtException == true);

        }
        [TestMethod]
        public void MultiplyingMatrixAndScalar()
        {
            Matrix x = new Matrix(new Vector(3, 0, -1),
                                new Vector(2, -5, -1),
                                new Vector(-3, 1, -1));
            int n = 5;

            Matrix result = null;
            Matrix result2 = null;
            bool bCaughtException = false;
            try
            {
                result = x * n;
                result2 = n * x;
            }
            catch (ArgumentException o)
            {
                bCaughtException = true;
                return;
            }
            catch (Exception e)
            {
            }
            Assert.IsTrue(result[0] == new Vector(15, 0, -5));
            Assert.IsTrue(result[1] == new Vector(10, -25, -5));
            Assert.IsTrue(result[2] == new Vector(-15, 5, -5));
            
            Assert.IsTrue(result2[0] == new Vector(15, 0, -5));
            Assert.IsTrue(result2[1] == new Vector(10, -25, -5));
            Assert.IsTrue(result2[2] == new Vector(-15, 5, -5));

        }
        [TestMethod]
        public void Equality2UnequalMatrices()
        {
            Matrix x = new Matrix(new Vector(3, 0),
                                new Vector(2, -5),
                                new Vector(-3, 1));
            Matrix y = new Matrix(new Vector(3, 0, 1),
                                new Vector(2, -5, 4),
                                new Vector(-3, 1, 3));
            bool bCaughtException = false;
            try
            {
                bool z = x == y;
            }
            catch (ArgumentException o)
            {
                bCaughtException = true; ;
                System.Diagnostics.Trace.TraceInformation(o.Message);
            }
            catch (Exception)
            {
            }
            Assert.IsTrue(bCaughtException == true);

        }

        [TestMethod]
        public void Equality2equalMatrices()
        {
            Matrix x = new Matrix(new Vector(3, 0, 4),
                                new Vector(2, -5, 3),
                                new Vector(-3, 1, 6));
            Matrix y = new Matrix(new Vector(3, 0, 1),
                                new Vector(2, -5, 4),
                                new Vector(-3, 1, 3));
            Matrix w = new Matrix(new Vector(3, 0, 1),
                                new Vector(2, -5, 4),
                                new Vector(-3, 1, 4));
            Matrix z = new Matrix(new Vector(3, 0, 1),
                               new Vector(2, -5, 4),
                               new Vector(-3, 1, 4));
            bool bCaughtException = false;
            bool b = false,c = false, p = false, d = false ;
            try
            {
                p = x != y;
               
                
                b = y != z;
                c = w == z;
                
                d = z == w;
                
                
            }
            catch (ArgumentException o)
            {
                bCaughtException = true; ;
                System.Diagnostics.Trace.TraceInformation(o.Message);
            }
            catch (Exception e)
            {
                System.Diagnostics.Trace.TraceInformation(e.Message);
            }
            Assert.IsTrue(p == true);
            Assert.IsTrue(b == true);
            Assert.IsTrue(c == true);
            Assert.IsTrue(d == true);
        }

        [TestMethod]
        public void IdentityMatrix()
        {
            Matrix x = Matrix.Eye(2);
            String p = x.ToString();
            System.Diagnostics.Trace.TraceInformation(p);
        }

        [TestMethod]
        public void IdentityMatrixTest2()
        {
            Matrix x = Matrix.Eye(2,3);
            String p = x.ToString();
            System.Diagnostics.Trace.TraceInformation(p);
        }

        [TestMethod]
        public void Determinant()
        {

            Matrix x = new Matrix(new Vector(2, 5),
                                  new Vector(1, -3));
            double p = x.Determinant();
            Assert.IsTrue(p == -11);

            Matrix y = new Matrix(new Vector(3, 0, -1),
                                 new Vector(2, -5, 4),
                                 new Vector(-3, 1, 3));
            double q = y.Determinant();
            Assert.IsTrue(q == -44);

            Matrix z = new Matrix(new Vector(-5, 6, 0, 0),
                                 new Vector(0, 1, -1, 2),
                                 new Vector(-3, 4, -5, 1),
                                 new Vector(1, 6, 0, 3));
            double r = z.Determinant();
            Assert.IsTrue(r == -255);

            Matrix w = new Matrix(new Vector(3, 0),
                                 new Vector(2, 4),
                                 new Vector(-3, 3));
            bool bInvalidOperationExceptionThrown = false;
            try
            {
                double s = w.Determinant();
            }
            catch (InvalidOperationException)
            {
                bInvalidOperationExceptionThrown = true;
            }
            catch(Exception)
            {

            }
            Assert.IsTrue(bInvalidOperationExceptionThrown );

        }

        [TestMethod]
        public void MatrixRREFTest()
        {
            var mat = new Matrix(new Vector(2,1,4), new Vector(1,1,3));
            var newMat = mat.RREF();
        }
    }
}
