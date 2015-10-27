using System;
using System.Web.UI;

namespace Laboratory.Module
{
    public partial class MConverter : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Length 1
            //Speed 2
            //Mass 3
            //Area 4
            //Volume 5
            //Base 6
            if (Request["t"] == "1" && Request["u1"] == "1" && Request["u2"] == "2")
            {
                //Mathos.Conversion.Converter.From(Enum.GetName(Length,0), "3").To(Length.Foot);
            }
        }
    }
}