using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mathos.Converter;

namespace Laboratory.Module
{
    public partial class Converter : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (DropDownList2.SelectedValue == "Please select a unit")
                SetValues(0);
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetValues(DropDownList1.SelectedIndex);
        }

        protected void CalculateButton_Click(object sender, EventArgs e)
        {
            Enum a;
            Enum b;

            switch (DropDownList1.SelectedIndex)
            {
                case 0:
                    a = (Length) Enum.Parse(typeof (Length), DropDownList2.SelectedValue, true);
                    b = (Length) Enum.Parse(typeof (Length), DropDownList3.SelectedValue, true);
                    break;
                case 1:
                    a = (Speed) Enum.Parse(typeof (Speed), DropDownList2.SelectedValue, true);
                    b = (Speed) Enum.Parse(typeof (Speed), DropDownList3.SelectedValue, true);
                    break;
                case 2:
                    a = (Mass) Enum.Parse(typeof (Mass), DropDownList2.SelectedValue, true);
                    b = (Mass) Enum.Parse(typeof (Mass), DropDownList3.SelectedValue, true);
                    break;
                case 3:
                    a = (Area) Enum.Parse(typeof (Area), DropDownList2.SelectedValue, true);
                    b = (Area) Enum.Parse(typeof (Area), DropDownList3.SelectedValue, true);
                    break;
                case 4:
                    a = (Volume) Enum.Parse(typeof (Volume), DropDownList2.SelectedValue, true);
                    b = (Volume) Enum.Parse(typeof (Volume), DropDownList3.SelectedValue, true);
                    break;
                case 5:
                    a = (Base) Enum.Parse(typeof (Base), DropDownList2.SelectedValue, true);
                    b = (Base) Enum.Parse(typeof (Base), DropDownList3.SelectedValue, true);
                    break;
                case 6:
                    a = (Angle) Enum.Parse(typeof (Angle), DropDownList2.SelectedValue, true);
                    b = (Angle) Enum.Parse(typeof (Angle), DropDownList3.SelectedValue, true);
                    break;
                case 7:
                    a = (Power) Enum.Parse(typeof (Power), DropDownList2.SelectedValue, true);
                    b = (Power) Enum.Parse(typeof (Power), DropDownList3.SelectedValue, true);
                    break;
                case 8:
                    a = (Pressure) Enum.Parse(typeof (Pressure), DropDownList2.SelectedValue, true);
                    b = (Pressure) Enum.Parse(typeof (Pressure), DropDownList3.SelectedValue, true);
                    break;
                case 9:
                    a = (Temperature) Enum.Parse(typeof (Temperature), DropDownList2.SelectedValue, true);
                    b = (Temperature) Enum.Parse(typeof (Temperature), DropDownList3.SelectedValue, true);
                    break;
                default:
                    a = (Length) Enum.Parse(typeof (Length), DropDownList2.SelectedValue, true);
                    b = (Length) Enum.Parse(typeof (Length), DropDownList3.SelectedValue, true);
                    break;
            }

            try
            {
                var watch = new Stopwatch();
                watch.Start();

                TextBox2.Text = DropDownList1.SelectedIndex != 5
                    ? Mathos.Converter.Converter.From(a, Convert.ToDouble(TextBox1.Text))
                        .To(b)
                        .ToString(CultureInfo.InvariantCulture)
                    : Mathos.Converter.Converter.From((Base) a, TextBox1.Text).To((Base) b);

                watch.Stop();
                ElapsedTimeLabel.Text = string.Format("Elapsed time: {0} ms", watch.Elapsed.TotalMilliseconds);
            }
            catch
            {
                TextBox2.Text = "Error!";
            }
        }

        protected void SetValues(int type)
        {
            string[] itemvalues;

            switch (type)
            {
                case 0:
                    itemvalues = Enum.GetNames(typeof (Length));
                    break;
                case 1:
                    itemvalues = Enum.GetNames(typeof (Speed));
                    break;
                case 2:
                    itemvalues = Enum.GetNames(typeof (Mass));
                    break;
                case 3:
                    itemvalues = Enum.GetNames(typeof (Area));
                    break;
                case 4:
                    itemvalues = Enum.GetNames(typeof (Volume));
                    break;
                case 5:
                    itemvalues = Enum.GetNames(typeof (Base));
                    break;
                case 6:
                    itemvalues = Enum.GetNames(typeof (Angle));
                    break;
                case 7:
                    itemvalues = Enum.GetNames(typeof (Power));
                    break;
                case 8:
                    itemvalues = Enum.GetNames(typeof (Pressure));
                    break;
                case 9:
                    itemvalues = Enum.GetNames(typeof (Temperature));
                    break;
                default:
                    itemvalues = Enum.GetNames(typeof (Length));
                    break;
            }

            DropDownList2.Items.Clear();
            DropDownList3.Items.Clear();

            foreach (var item in itemvalues.Select(t => new ListItem(t)))
            {
                DropDownList2.Items.Add(item);
                DropDownList3.Items.Add(item);
            }
        }
    }
}