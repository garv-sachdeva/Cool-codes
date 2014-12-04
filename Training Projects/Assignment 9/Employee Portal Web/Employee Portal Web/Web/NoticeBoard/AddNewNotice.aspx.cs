using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace Web
{
    public partial class AddNewNotice : System.Web.UI.Page
    {
        int employeeId;

        protected void Page_Load(object sender, EventArgs e)
        {
            EPPrincipal principal = Session["CurrentPrincipal"] as EPPrincipal;
            EPIdentity identity = principal.Identity as EPIdentity;
            employeeId = identity.EmployeeId;
        }

        protected void BackLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/NoticeBoard/ManageNotices.aspx");
        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            Notice notice = new Notice();
            notice.Title = TitleTextBox.Text;
            notice.Description = DescriptionTextBox.Text;
            notice.StartDate = DateTime.Parse(StartDateTextBox.Text);
            notice.ExpirationDate = DateTime.Parse(ExpDateTextBox.Text);
            notice.PostedById = employeeId;
            notice.Save();
            Response.Redirect("ManageNotices.aspx");
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            TitleTextBox.Text = "";
            DescriptionTextBox.Text = "";
            StartDateTextBox.Text = "";
            ExpDateTextBox.Text = "";
        }

    }
}