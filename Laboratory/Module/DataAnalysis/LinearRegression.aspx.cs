using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.UI;
using Mathos.Statistics;

namespace Laboratory.Module.DataAnalysis
{
    public partial class LinearRegression : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text != "" && TextBox2.Text != "")
            {
                var xIn = TextBox1.Text.Split(',');
                var yIn = TextBox2.Text.Split(',');

                List<decimal> x;
                List<decimal> y;

                try
                {
                    x = Array.ConvertAll(xIn, decimal.Parse).ToList();
                    y = Array.ConvertAll(yIn, decimal.Parse).ToList();
                }
                catch
                {
                    Label1.Text = "Could not convert the sequence into an array.";

                    return;
                }

                var res = LinearModels.LinearRegression(x, y);
                lblLinearEq.Text = res.ToString();
                lblRVal.Text = res.R.ToString(CultureInfo.InvariantCulture);
                lblRSqVal.Text = res.R2.ToString(CultureInfo.InvariantCulture);
                lblRegCoeff.Text = res.B.ToString(CultureInfo.InvariantCulture);
                lblIntr.Text = res.Intercept.ToString(CultureInfo.InvariantCulture);
            }
            else
            {
                Label1.Text = "No sequence was entered.";
            }
        }
    }
}