using System;
using System.Diagnostics;
using System.Web.UI;
using Mathos.Arithmetic.Numbers;
using Convert = System.Convert;

namespace Laboratory.Module
{
    public partial class NumberChecker : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void CalculateButton_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text == "")
                return;

            var watch = new Stopwatch();
            watch.Start();

            if (DropDownList1.SelectedIndex == 0)
                ResultLabel.Text = Check.IsPositive(Convert.ToInt64(TextBox1.Text)) ? "True!" : "False!";
            if (DropDownList1.SelectedIndex == 1)
                ResultLabel.Text = Check.IsNegative(Convert.ToInt64(TextBox1.Text)) ? "True!" : "False!";
            if (DropDownList1.SelectedIndex == 2)
                ResultLabel.Text = Check.IsEven(Convert.ToInt64(TextBox1.Text)) ? "True!" : "False!";
            if (DropDownList1.SelectedIndex == 3)
                ResultLabel.Text = Check.IsOdd(Convert.ToInt64(TextBox1.Text)) ? "True!" : "False!";
            if (DropDownList1.SelectedIndex == 4)
                ResultLabel.Text = Check.IsPrime(Convert.ToInt64(TextBox1.Text)) ? "True!" : "False!";

            watch.Stop();
            ElapsedTimeLabel.Text = string.Format("Elapsed time: {0} ms", watch.Elapsed.TotalMilliseconds);
        }
    }
}