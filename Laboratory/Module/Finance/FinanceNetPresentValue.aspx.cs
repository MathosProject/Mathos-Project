using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web.UI;

namespace Laboratory.Module.Finance
{
  public partial class FinanceNetPresentValue : Page
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
      decimal initialInvestmentValue;
      if (
        !Decimal.TryParse(InitialInvestmentValueText.Text, NumberStyles.Any, CultureInfo.CurrentCulture,
          out initialInvestmentValue))
      {
        initialInvestmentValue = 0;
      }

      IList<decimal> cashFlow = new List<decimal>();

      var values = CashFlowValueText.Text.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

      foreach (var value in values)
      {
        decimal cashFlowItem;
        if (!Decimal.TryParse(value, NumberStyles.Any, CultureInfo.CurrentCulture, out cashFlowItem))
        {
          cashFlowItem = 0;
        }

        cashFlow.Add(cashFlowItem);
      }

      decimal rateOfReturn;
      if (!Decimal.TryParse(RateOfReturnText.Text, NumberStyles.Any, CultureInfo.CurrentCulture, out rateOfReturn))
      {
        rateOfReturn = 0;
      }

      var roundToTwoDecimalPlaces = RoundCheck.Checked;

      try
      {
        var result = Mathos.Finance.Finance.NetPresentValue(
          initialInvestmentValue,
          cashFlow,
          rateOfReturn,
          roundToTwoDecimalPlaces);

        ResultLabel.Text = string.Format(
          "Net Present value: {0}",
          result.ToString(CultureInfo.CurrentCulture));
      }
      catch
      {
        ErrorLabel.Text = "Error!";
      }
    }
  }
}