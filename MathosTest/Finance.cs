using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Mathos.Finance;

namespace MathosTest
{
    [TestClass]
    public class FinanceTest
    {
        [TestMethod]
        public void FutureValue()
        {
            // $1,000 at 0.5% over 12 periods
            var futureValue = Finance.FutureValue(1000M, 0.5M, 12);

            Assert.AreEqual(1061.68M, futureValue);
        }

        [TestMethod]
        public void PresentValue()
        {
            // $,1061.68 at 0.5% over 12 periods
            var futureValue = Finance.PresentValue(1061.68M, 0.5M, 12);

            Assert.AreEqual(1000, futureValue);
        }

        [TestMethod]
        public void NetPresentValue()
        { 
            var cashFlow = new List<decimal> {200000, 300000, 200000};
            var netPresentValue = Finance.NetPresentValue(500000, cashFlow, 10);

            Assert.AreEqual(80015.02M, netPresentValue);
        }

        [TestMethod]
        public void PresentValueOfAnnuity()
        {
            var presentValueOfAnnuity = Finance.PresentValueOfAnnuity(200, 1, 12);

            Assert.AreEqual(2251.02M, presentValueOfAnnuity);
        }

        [TestMethod]
        public void FutureValueOfAnnuity()
        {
            var futureValueOfAnnuity = Finance.FutureValueOfAnnuity(200, 1, 12);

            Assert.AreEqual(2536.50M, futureValueOfAnnuity);
        }

        [TestMethod]
        public void AnnuityPaymentPresentValue()
        {
            var annuityPayment = Finance.AnnuityPaymentPresentValue(1000, 1, 12);

            Assert.AreEqual(88.85M, annuityPayment);
        }

        [TestMethod]
        public void AnnuityPaymentFutureValue()
        {
            var annuityPayment = Finance.AnnuityPaymentFutureValue(5000, 3, 5);

            Assert.AreEqual(941.77M, annuityPayment);
        }

        [TestMethod]
        public void RemainingBalanceOfAnnuity()
        {
            var remaining = Finance.RemainingBalanceOfAnnuity(5000, 200, 3, 15);

            Assert.AreEqual(4070.05M, remaining);
        }
    }
}
