using System;
using System.Globalization;
using System.Web.UI;

namespace Laboratory.Module.Finance
{
  public partial class FinanceRemainingBalanceOfAnnuity : Page
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
      decimal originalValue;
      if (!Decimal.TryParse(OriginalValueText.Text, NumberStyles.Any, CultureInfo.CurrentCulture, out originalValue))
      {
        originalValue = 0;
      }

      decimal payment;
      if (!Decimal.TryParse(PaymentText.Text, NumberStyles.Any, CultureInfo.CurrentCulture, out payment))
      {
        payment = 0;
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
        var result = Mathos.Finance.Finance.RemainingBalanceOfAnnuity(
          originalValue,
          payment,
          ratePerPeriod,
          numberOfPeriods,
          roundToTwoDecimalPlaces);

        ResultLabel.Text = string.Format(
          "Remaining balance of annuity: {0}",
          result.ToString(CultureInfo.CurrentCulture));
      }
      catch
      {
        ErrorLabel.Text = "Error!";
      }
    }
  }
}