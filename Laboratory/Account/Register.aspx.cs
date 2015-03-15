using System;
using System.Web.Security;
using System.Web.UI;

namespace Laboratory.Account
{
  public partial class Register : Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
        RegisterUser.ContinueDestinationPageUrl = Request.QueryString["ReturnUrl"];
    }

    protected void RegisterUser_CreatedUser(object sender, EventArgs e)
    {
        FormsAuthentication.SetAuthCookie(RegisterUser.UserName, false /* createPersistentCookie */);

        var continueUrl = RegisterUser.ContinueDestinationPageUrl;

        if (String.IsNullOrEmpty(continueUrl))
        {
            continueUrl = "~/";
        }

        Response.Redirect(continueUrl);
    }
  }
}