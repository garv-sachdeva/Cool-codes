using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace Web
{
    public partial class AddNewIssue : System.Web.UI.Page
    {
        Issue issue = new Issue();
        int employeeId;
        protected void Page_Load(object sender, EventArgs e)
        {
            EPPrincipal principal = Session["CurrentPrincipal"] as EPPrincipal;
            EPIdentity identity = principal.Identity as EPIdentity;
            employeeId = identity.EmployeeId;
        }

        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {
            issue.Title = TextBoxTitle.Text;
            issue.Description = TextBoxIssueDesc.Text;
            issue.Priority = short.Parse(DropDownListPriority.SelectedValue);
            issue.PostedBy = employeeId;
            issue.AssignedTo = 1;
            issue.DatePosted = DateTime.Now;
            issue.Status = 1;
            issue.Save();
            Response.Redirect("ManageIssues.aspx");
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            TextBoxTitle.Text = " ";
            TextBoxIssueDesc.Text = " ";
            DropDownListPriority.SelectedValue = "";
            Response.Redirect("ManageIssues.aspx");
        }
    }
}