using System;
using System.Diagnostics;
using System.Globalization;
using System.Web.UI;

namespace Laboratory.Module
{
  public partial class Triangle : Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void CalculateButton_Click(object sender, EventArgs e)
    {
      try
      {
        var watch = new Stopwatch();
        watch.Start();

        var triangle = new Mathos.Geometry.Shapes.Triangle(ToDoubleC(TextBox1.Text), ToDoubleC(TextBox2.Text),
          ToDoubleC(TextBox3.Text), ToDoubleC(TextBox4.Text), ToDoubleC(TextBox5.Text), ToDoubleC(TextBox6.Text));

        watch.Stop();
        ElapsedTimeLabel.Text = string.Format("Elapsed time: {0} ms", watch.Elapsed.TotalMilliseconds);

        TextBox1.Text = triangle.SideA.ToString(CultureInfo.InvariantCulture);
        TextBox2.Text = triangle.SideB.ToString(CultureInfo.InvariantCulture);
        TextBox3.Text = triangle.SideC.ToString(CultureInfo.InvariantCulture);
        TextBox4.Text = triangle.AngleA.ToString(CultureInfo.InvariantCulture);
        TextBox5.Text = triangle.AngleB.ToString(CultureInfo.InvariantCulture);
        TextBox6.Text = triangle.AngleC.ToString(CultureInfo.InvariantCulture);
      }
      catch
      {
        ErrorLabel.Text = "Not enough information!";
      }
    }

    protected double ToDoubleC(string input)
    {
      if (input == "" || input == "NaN")
      {
        return 0;
      }
      return Convert.ToDouble(input);
    }
  }
}