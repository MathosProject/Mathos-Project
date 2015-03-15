using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Mathos.Syntax;

namespace MathosTest.Mathos_Main
{
    [TestClass]
    public class SyntaxTest
    {
        [TestMethod]
        public void TestSyntax()
        {
            /* 
             * Mathos.Syntax is a collection of extenssion methods
             * for the common value types in .NET Framework.
             */

            const int myNumber = 29;

            var myNumberIsPrime = myNumber.IsPrime(); // true
            var myNumberIsOdd = myNumber.IsEven(); // false
            var myNumberIsPositive = myNumber.IsPositive(); // true

            const long mySecondNumber = 32;
            const long myThirdNumber = 9;

            var areCoprimes = mySecondNumber.IsCoprime(myThirdNumber); // true
        }

        [TestMethod]
        public void TestUsualWay()
        {
            /* Using "Numbers" directly */

            var myNumberIsPrime = Mathos.Arithmetic.Numbers.Check.IsPrime(29);
            var positiveNumber = Mathos.Arithmetic.Numbers.Convert.ToPositive(-2);
            var gdc = Mathos.Arithmetic.Numbers.Get.Gdc(20, 4);

            foreach (var factor in Mathos.Arithmetic.Numbers.Get.Factors(81))
                System.Diagnostics.Debug.WriteLine("Factor: " + factor.ToString(CultureInfo.InvariantCulture));
        }
    }
}
