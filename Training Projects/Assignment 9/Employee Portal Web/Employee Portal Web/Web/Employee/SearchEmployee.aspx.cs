using BLL;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Employee
{
    public partial class SearchEmployee : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CompareValidator1.ValueToCompare = DateTime.Now.Date.ToShortDateString().ToString();
                Page.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string firstName = string.IsNullOrEmpty(TextBoxFName.Text) ? null : TextBoxFName.Text;
            string lastName = string.IsNullOrEmpty(TextBoxLName.Text) ? null : TextBoxLName.Text;
            string employeeCode = string.IsNullOrEmpty(TextBoxEmpCode.Text) ? null : TextBoxEmpCode.Text;
            DateTime? dateOfJoining = string.IsNullOrEmpty(TextBoxDoj.Text) ? new Nullable<DateTime>() : DateTime.Parse(TextBoxDoj.Text);
            int? departmentId = string.IsNullOrEmpty(DropDownListDept.Text) ? new Nullable<Int32>() : int.Parse(DropDownListDept.SelectedValue);
            List<BLL.Employee> searchedEmployees = EmployeeList.GetSearchEmployees(employeeCode, firstName, lastName, departmentId, dateOfJoining);
            if (searchedEmployees.Count > 0)
            {
                GridView1.DataSource = searchedEmployees;
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = searchedEmployees;
                GridView1.DataBind();
            }
        }
    }
}