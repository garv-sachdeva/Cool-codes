using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using BLL;

namespace Web.Controls
{
    public partial class HeaderControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            if (!string.IsNullOrEmpty(HttpContext.Current.User.Identity.Name))
            {
                this.welcomeDiv.Visible = true;
                this.userInfoLabel.Text = HttpContext.Current.User.Identity.Name;
            }
            else
            {
                this.welcomeDiv.Visible = false;
            }
        }

        protected void loginStatus_LoggingOut(object sender, LoginCancelEventArgs e)
        {
			if (HttpContext.Current.Session["CurrentPrincipal"] is EPPrincipal)
			{
				EPPrincipal principal = HttpContext.Current.Session["CurrentPrincipal"] as EPPrincipal;
				principal.Logout();
				FormsAuthentication.SignOut();
				Session["CurrentPrincipal"] = principal;
			}
        }
    }
}