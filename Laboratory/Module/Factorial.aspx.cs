using System;
using System.Diagnostics;
using System.Web.UI;
using Mathos.Arithmetic.Numbers;
using Convert = System.Convert;

namespace Laboratory.Module
{
    public partial class Factorial : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void CalculateButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (NumberText.Text.Length < 5)
                {
                    var watch = new Stopwatch();
                    watch.Start();

                    ResultTextbox.Text =
                        Get.FactorialBigInteger(Convert.ToInt64(NumberText.Text)).ToString();

                    watch.Stop();
                    ElapsedTimeLabel.Text = string.Format("Elapsed time: {0} ms", watch.Elapsed.TotalMilliseconds);
                }
                else
                {
                    ErrorLabel.Text = "At this stage, the number is bigger than the set limit.";
                }
            }
            catch
            {
                ErrorLabel.Text = "Error!";
            }
        }
    }
}