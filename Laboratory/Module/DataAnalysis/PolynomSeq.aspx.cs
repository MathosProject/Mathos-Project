using System;
using System.Web.UI;
using Mathos.Calculus;

namespace Laboratory.Module.DataAnalysis
{
    public partial class WebForm1 : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void FindNthTerm_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text != "")
            {
                var tokens = TextBox1.Text.Split(',');

                double[] seq;
                try
                {
                    seq = Array.ConvertAll(tokens, double.Parse);
                }
                catch
                {
                    Label1.Text = "Could not convert the sequence into an array.";

                    return;
                }

                int degree;

                if (FiniteCalculus.HasPattern(seq, out degree))
                {
                    var coeff = FiniteCalculus.GetCoefficientsForNthTerm(seq, degree);
                    var output = FiniteCalculus.GetExpressionForNthTerm(coeff);

                    Label1.Text = output;
                }
                else
                {
                    Label1.Text = "Not enough terms to spot a pattern or not a polynomial sequence.";
                }
            }
            else
            {
                Label1.Text = "No sequence was entered.";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text != "")
            {
                var tokens = TextBox1.Text.Split(',');

                double[] seq;
                try
                {
                    seq = Array.ConvertAll(tokens, double.Parse);
                }
                catch
                {
                    Label1.Text = "Could not convert the sequence into an array.";

                    return;
                }

                int degree;

                if (FiniteCalculus.HasPattern(seq, out degree))
                {
                    var coeff = FiniteCalculus.GetCoefficientsForNthSum(seq, degree);
                    var output = FiniteCalculus.GetExpressionForNthSum(coeff);

                    Label1.Text = output;
                }
                else
                {
                    Label1.Text = "Not enough terms to spot a pattern or not a polynomial sequence.";
                }
            }
            else
            {
                Label1.Text = "No sequence was entered.";
            }
        }
    }
}