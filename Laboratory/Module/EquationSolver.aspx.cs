using System;
using System.Diagnostics;
using System.Web.UI;
using Mathos;
namespace Laboratory.Module
{
    public partial class EquationSolver : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void SolveSystemOfTwoEquation_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text == "")
                TextBox1.Text = "0";
            if (TextBox2.Text == "")
                TextBox2.Text = "0";
            if (TextBox3.Text == "")
                TextBox3.Text = "0";
            if (TextBox4.Text == "")
                TextBox4.Text = "0";
            if (TextBox5.Text == "")
                TextBox5.Text = "0";
            if (TextBox6.Text == "")
                TextBox6.Text = "0";

            try
            {
                var watch = new Stopwatch();
                watch.Start();

                Vector result = Mathos.EquationSolver.SystemOfTwoEquations(Convert.ToDouble(TextBox1.Text),
                    Convert.ToDouble(TextBox2.Text),
                    Convert.ToDouble(TextBox4.Text),
                    Convert.ToDouble(TextBox5.Text),
                    Convert.ToDouble(TextBox3.Text),
                    Convert.ToDouble(TextBox6.Text));

                watch.Stop();
                EquationElapsedTimeLabel.Text = string.Format("Elapsed time: {0} ms", watch.Elapsed.TotalMilliseconds);

                EquationResultLabel.Text = string.Format(
                    "Result: x = {0}; y = {1}",
                    result[0],
                    result[1]);
            }
            catch
            {
                EquationErrorLabel.Text = "Error!";
            }
        }
        
        protected void SolveQuadraticEquation_Click(object sender, EventArgs e)
        {
            if (TextBox7.Text.Trim() == "" || TextBox7.Text.Trim() == "0")
            {
                QuadraticEquationErrorLabel.Text = "A cannot be 0!";
                return;
            }
            if (TextBox8.Text == "")
                TextBox8.Text = "0";
            if (TextBox9.Text == "")
                TextBox9.Text = "0";

            try
            {
                var watch = new Stopwatch();
                watch.Start();

                var result = Mathos.EquationSolver.QuadraticEquation(Convert.ToDouble(TextBox7.Text),
                    Convert.ToDouble(TextBox8.Text),
                    Convert.ToDouble(TextBox9.Text));

                watch.Stop();
                QuadraticEquationElapsedTimeLabel.Text = string.Format("Elapsed time: {0} ms",
                    watch.Elapsed.TotalMilliseconds);

                QuadraticEquationResultLabel.Text = string.Format(
                    "Result: x2 = {0}; x2 = {1}",
                    result[0].Real,
                    result[1].Imaginary);
            }
            catch
            {
                QuadraticEquationErrorLabel.Text = "Error!";
            }
        }
    }
}