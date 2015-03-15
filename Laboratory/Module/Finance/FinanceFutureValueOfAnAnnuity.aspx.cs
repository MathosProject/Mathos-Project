using System;
using System.Globalization;
using System.Web.UI;

namespace Laboratory.Module.Finance
{
  public partial class FinanceFutureValueOfAnAnnuity : Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void CalculateButton_Click(object sender, EventArgs e)
    {
      Calculate();
    }

    private void Calculate()
    {
      decimal periodicPayment;
      if (!Decimal.TryParse(PeriodicPaymentText.Text, NumberStyles.Any, CultureInfo.CurrentCulture, out periodicPayment))
      {
        periodicPayment = 0;
      }

      decimal ratePerPeriod;
      if (!Decimal.TryParse(RatePerPeriodText.Text, NumberStyles.Any, CultureInfo.CurrentCulture, out ratePerPeriod))
      {
        ratePerPeriod = 0;
      }

      int numberOfPeriods;
      if (!Int32.TryParse(NumberOfPeriodsText.Text, NumberStyles.Any, CultureInfo.CurrentCulture, out numberOfPeriods))
      {
        numberOfPeriods = 0;
      }

      var roundToTwoDecimalPlaces = RoundCheck.Checked;

      try
      {
        var result = Mathos.Finance.Finance.FutureValueOfAnnuity(
          periodicPayment,
          ratePerPeriod,
          numberOfPeriods,
          roundToTwoDecimalPlaces);

        ResultLabel.Text = string.Format(
          "Future Value Of An Annuity: {0}",
          result.ToString(CultureInfo.CurrentCulture));
      }
      catch
      {
        ErrorLabel.Text = "Error!";
      }
    }
  }
}