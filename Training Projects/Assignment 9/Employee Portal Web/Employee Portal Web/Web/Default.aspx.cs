using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Security;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using BLL;

namespace Web
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int employeeId = 1;
            EPPrincipal principal = (EPPrincipal)Session["CurrentPrincipal"];

                if(principal!=null)
                {

                    EPIdentity identity = (EPIdentity)principal.Identity;
                    employeeId = identity.EmployeeId;
                    Session["UserId"] = employeeId.ToString();
                }

                UserOpenIssues.DataSource = IssueList.GetUserActiveIssues(employeeId);
                UserOpenIssues.DataBind();
        } 
    }
}