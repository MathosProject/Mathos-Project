using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Mathos.Statistics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MathosTest.Uncertainty
{
    [TestClass]
    public class Uncertainty
    {
        [TestMethod]
        public void CustomFunctionOneVar()
        {
            UncertainNumber x = new UncertainNumber(5, 2);
            x= x.CustomFunction(d => d * d);

            Assert.AreEqual((int)x.Value, 25);

            // NOTE: 20.0000000000002 is too accurate, should be simplified to just 15
            Assert.AreEqual(x.Uncertainty, (decimal)20.0000000000002);
        }

        [TestMethod]
        public void CustomFunctionMultipleVar()
        {
            UncertainNumber x = new UncertainNumber(5, 2);
            UncertainNumber y = new UncertainNumber(5,1);

            UncertainNumber num =   UncertainNumber.CustomFunction(d => d[0] * d[1], x,y);


            Assert.AreEqual((int)num.Value, 25);

            // NOTE: 15.0000000000001 is too accurate, should be simplified to just 15
            Assert.AreEqual(num.Uncertainty, (decimal)15.0000000000001);
        }

        [TestMethod]
        public void PowerTest()
        {
            // TODO: 9.00000000000060000000000001 +/- 36.0000000000006 is _way_ too accurate!
            /*
            UncertainNumber x = new UncertainNumber(3, 6);

            UncertainNumber a = x.Pow(2);
            UncertainNumber b = x.CustomFunction(d => d * d);

            Assert.AreEqual(a, b);

            Assert.IsTrue(a.Uncertainty == b.Uncertainty);
            */
        }

        [TestMethod]
        public void FromTSVTest()
        {
            //should be possible to put build in funtions like pow, exp, etc into the custom function.
            string rawData = MathosTest.Properties.Resources.String1;

            UncertainNumber[] hh = UncertainNumber.CustomFunction(d => d[0] * d[0], rawData);
        }


        [TestMethod]
        public void SignificanteFiguresTest()
        {
            // TODO: String formatting needs to be fixed
            /*UncertainNumber bbb = new UncertainNumber(32.7M, 2M);

            bbb = bbb.AutoFormat();
            decimal a = 10.2M;


            UncertainNumber aaaa = new UncertainNumber(12345.00M, 647);

            aaaa = aaaa.AutoFormat();


            UncertainNumber result = UncertainNumber.CustomFunction(e => e[0] * e[1], new UncertainNumber(2, 0.1M), new UncertainNumber(3, 0.1M));
            result = result.AutoFormat();

            UncertainNumber efd = new UncertainNumber(123M, 0.0000051M);
            efd = efd.AutoFormat();*/
        }

        [TestMethod]
        public void Vital()
        {
            // TODO: String formatting needs to be fixed
            /*
            UncertainNumber c = new UncertainNumber(12, 0.1M);

            UncertainNumber b = c.CustomFunction(m=> m*m) ;

            b = b.AutoFormat();



            UncertainNumber y = new UncertainNumber(12, 0.1M);

            y = y.CustomFunction(d => 1 / (d * d));

            y = y.AutoFormat();


            UncertainNumber x = new UncertainNumber(11, 0.1M);

            x = x.CustomFunction(d => 1 / (d * d) );

            x = x.AutoFormat();
            */
        }

        // From http://www.daimi.au.dk/~ivan/FastExpproject.pdf
        // Left to Right Binary Exponentiation
        public static decimal Pow(decimal x, uint y)
        {
            decimal A = 1m;
            System.Collections.BitArray e = new System.Collections.BitArray(BitConverter.GetBytes(y));
            int t = e.Count;

            for (int i = t - 1; i >= 0; --i)
            {
                A *= A;
                if (e[i] == true)
                {
                    A *= x;
                }
            }
            return A;
        }
    }
}
