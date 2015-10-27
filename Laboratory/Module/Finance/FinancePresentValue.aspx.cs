using System;
using System.Globalization;
using System.Web.UI;

namespace Laboratory.Module.Finance
{
    public partial class FinancePresentValue : Page
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

            if (!decimal.TryParse(FutureValueText.Text, NumberStyles.Any, CultureInfo.CurrentCulture, out futureValue))
                futureValue = 0;

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
                var result = Mathos.Finance.Finance.PresentValue(
                    futureValue,
                    rateOfReturn,
                    numberOfPeriods,
                    roundToTwoDecimalPlaces);

                ResultLabel.Text = string.Format(
                    "Present value: {0}",
                    result.ToString(CultureInfo.CurrentCulture));
            }
            catch
            {
                ErrorLabel.Text = "Error!";
            }
        }
    }
}