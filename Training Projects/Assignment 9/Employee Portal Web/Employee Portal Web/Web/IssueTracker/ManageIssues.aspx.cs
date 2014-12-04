using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace Web
{
    public partial class ManageIssues : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GridViewManageIssue.DataSource = IssueList.GetAllIssues();
            GridViewManageIssue.DataBind();
        }

        protected void ButtonAddIssue_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddNewIssue.aspx");
        }

        protected void GridViewManageIssue_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Issue.Delete(int.Parse(GridViewManageIssue.DataKeys[e.RowIndex]["IssueId"].ToString()));
            Response.Redirect("ManageIssues.aspx");
        }
    }
}