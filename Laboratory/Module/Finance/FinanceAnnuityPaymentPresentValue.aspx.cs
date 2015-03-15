using System;
using System.Globalization;
using System.Web.UI;

namespace Laboratory.Module.Finance
{
  public partial class FinanceAnnuityPaymentPresentValue : Page
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
      decimal futureValue;
      if (!Decimal.TryParse(FutureValueText.Text, NumberStyles.Any, CultureInfo.CurrentCulture, out futureValue))
      {
        futureValue = 0;
      }

      decimal rateOfReturn;
      if (!Decimal.TryParse(RateOfReturnText.Text, NumberStyles.Any, CultureInfo.CurrentCulture, out rateOfReturn))
      {
        rateOfReturn = 0;
      }

      int numberOfPeriods;
      if (!Int32.TryParse(NumberOfPeriodsText.Text, NumberStyles.Any, CultureInfo.CurrentCulture, out numberOfPeriods))
      {
        numberOfPeriods = 0;
      }

      var roundToTwoDecimalPlaces = RoundCheck.Checked;

      try
      {
        var result = Mathos.Finance.Finance.AnnuityPaymentPresentValue(
          futureValue,
          rateOfReturn,
          numberOfPeriods,
          roundToTwoDecimalPlaces);

        ResultLabel.Text = string.Format(
          "Annuity Payment (Present Value): {0}",
          result.ToString(CultureInfo.CurrentCulture));
      }
      catch
      {
        ErrorLabel.Text = "Error!";
      }
    }
  }
}