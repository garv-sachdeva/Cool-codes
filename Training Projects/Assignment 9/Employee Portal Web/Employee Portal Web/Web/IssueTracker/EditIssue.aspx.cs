using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace Web
{
    public partial class EditIssue : System.Web.UI.Page
    {
        Issue issue = new Issue();
        int issueId;
        int employeeId;
        protected void Page_Load(object sender, EventArgs e)
        {
            EPPrincipal principal = Session["CurrentPrincipal"] as EPPrincipal;
            EPIdentity identity = principal.Identity as EPIdentity;
            employeeId = identity.EmployeeId;
            if (!IsPostBack)
            {
                issueId = Int32.Parse(Request.QueryString["IssueId"]);
                issue = Issue.GetIssue(issueId);
                LabelIssuecode.Text = Convert.ToString(issue.IssueId);
                TextBoxTitle.Text = issue.Title;
                Description.Text = issue.Description;
                DropDownListPriority.SelectedItem.Value = Convert.ToString(issue.Priority);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            issue.IssueId = int.Parse(LabelIssuecode.Text);
            issue.Title = TextBoxTitle.Text;
            issue.Description = Description.Text;
            issue.Priority = short.Parse(DropDownListPriority.SelectedValue);
            issue.AssignedTo = 1;
            issue.PostedBy = employeeId;
            issue.Status = 1;
            issue.DatePosted = DateTime.Now;
            issue.Comments = TextBoxComments.Text;
            issue.Save();
            Response.Redirect("ManageIssues.aspx");
        }

        protected void TextBoxTitle_TextChanged(object sender, EventArgs e)
        {
            issue.Title = TextBoxTitle.Text;
        }

        protected void Description_TextChanged(object sender, EventArgs e)
        {
            issue.Description = Description.Text;
        }

        protected void DropDownListPriority_SelectedIndexChanged(object sender, EventArgs e)
        {
            issue.Priority = short.Parse(DropDownListPriority.SelectedItem.Value);
        }

        protected void TextBoxComments_TextChanged(object sender, EventArgs e)
        {
            issue.Comments = TextBoxComments.Text;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
           Response.Redirect("ManageIssues.aspx");
        }
    }
}