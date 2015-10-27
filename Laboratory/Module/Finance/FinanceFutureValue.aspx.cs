using System;
using System.Globalization;
using System.Web.UI;

namespace Laboratory.Module.Finance
{
    public partial class FinanceFutureValue : Page
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
            decimal presentValue;

            if (!decimal.TryParse(PresentValueText.Text, NumberStyles.Any, CultureInfo.CurrentCulture, out presentValue))
                presentValue = 0;

            decimal rateOfReturn;

            if (!decimal.TryParse(RateOfReturnText.Text, NumberStyles.Any, CultureInfo.CurrentCulture, out rateOfReturn))
                rateOfReturn = 0;

            int numberOfPeriods;

            if (
                !int.TryParse(NumberOfPeriodsText.Text, NumberStyles.Any, CultureInfo.CurrentCulture,
                    out numberOfPeriods))
                numberOfPeriods = 0;

            var roundToTwoDecimalPlaces = RoundCheck.Checked;

            try
            {
                var result = Mathos.Finance.Finance.FutureValue(
                    presentValue,
                    rateOfReturn,
                    numberOfPeriods,
                    roundToTwoDecimalPlaces);

                ResultLabel.Text = string.Format(
                    "Future value: {0}",
                    result.ToString(CultureInfo.CurrentCulture));
            }
            catch
            {
                ErrorLabel.Text = "Error!";
            }
        }
    }
}