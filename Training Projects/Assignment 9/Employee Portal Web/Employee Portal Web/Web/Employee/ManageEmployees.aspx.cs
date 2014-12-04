using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace Web
{
    public partial class ManageEmployees : System.Web.UI.Page
    {
        private int empId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridViewManageEmployee.DataSource = EmployeeList.GetAllEmployees();
                GridViewManageEmployee.DataBind();
            }
        }

        protected void AddNewEmployee_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Employee/AddEmployee.aspx");
        }

        protected void GridViewManageEmployee_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
            if (e.CommandName == "DeleteButton")
            {
                empId = Convert.ToInt32(e.CommandArgument);
                BLL.Employee.DeleteEmployee(empId);
                Response.Redirect("ManageEmployees.aspx");
            }
           
        }

        protected void GridViewManageEmployee_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string item = e.Row.Cells[1].Text;
                foreach (LinkButton button in e.Row.Cells[5].Controls.OfType<LinkButton>())
                {
                    if (button.CommandName == "Delete")
                    {
                        button.Attributes["onclick"] = "if(!confirm('Do you want to delete " + item + "?')){ return false; };";
                    }
                }
            }
        }
    }
}