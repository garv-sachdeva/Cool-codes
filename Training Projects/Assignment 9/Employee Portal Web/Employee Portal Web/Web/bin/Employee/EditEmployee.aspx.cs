using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class EditEmployee : System.Web.UI.Page
    {
      BLL.Employee emp = new BLL.Employee();
      DateTime dobReal;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id;
                if (Request.QueryString["EmployeeId"] !=null)
                    id = int.Parse(Request.QueryString["EmployeeId"]);
                else
                    id = int.Parse(Session["UserId"].ToString());
               
                emp = BLL.Employee.GetEmployee(id);
                TextBoxFName.Text = emp.FirstName;
                TextBoxLName.Text = emp.LastName;
                TextBoxEmail.Text = emp.Email;
                TextBoxDOB.Text = null; 
                DropDownListDepartment.SelectedValue = emp.Department.DepartmentId.ToString();
                TextBoxPswd.Text = emp.Password;
                UpdateButton.Attributes.Add("onclick", "return confirm('Do you want to update the record?');");
            }
        }

        protected void UpdateB(object sender, EventArgs e)
        {
            emp.Department = new BLL.Department();
            emp.EmployeeId = int.Parse(Session["UserId"].ToString());
            emp = BLL.Employee.GetEmployee(emp.EmployeeId);
            dobReal = emp.DateOfBirth;
            emp.FirstName = this.TextBoxFName.Text;
            emp.LastName = this.TextBoxLName.Text;
            emp.Email = this.TextBoxEmail.Text;
            emp.Department.DepartmentId = Int32.Parse(DropDownListDepartment.SelectedValue);
            DateTime? dob = string.IsNullOrEmpty(TextBoxDOB.Text) ? new Nullable<DateTime>() : DateTime.Parse(this.TextBoxDOB.Text);
            if (dob.HasValue)
                emp.DateOfBirth = DateTime.Parse(this.TextBoxDOB.Text);
            else
            emp.DateOfBirth = dobReal;

            emp.Department = BLL.Department.GetDept(emp.Department.DepartmentId);

            if (TextBoxPswd.Text != "")
                emp.Password = this.TextBoxPswd.Text;
            BLL.Employee.UpdateEmployee(emp);
            Server.TransferRequest("~/Default.aspx");
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Server.TransferRequest("~/Default.aspx");
        }
    }
}