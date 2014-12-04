using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
namespace Web
{
    public partial class AddEmployee : System.Web.UI.Page
    {
       public BLL.Employee emp = new BLL.Employee();
 
        protected void Page_Load(object sender, EventArgs e)
        {
             if (!IsPostBack)
            {
            }
        }

        protected void ButtonAddUpdate_Click(object sender, EventArgs e)
        {
            emp.Department = new Department();
            emp.EmployeeCode = TextBoxEmployeeCode.Text;
            emp.DateOfJoining = DateTime.Parse(TextBoxDateOfJoining.Text);
            emp.FirstName = TextBoxFirstName.Text;
            emp.LastName = TextBoxLastName.Text;
            emp.Email = TextBoxEmail.Text;
            emp.DateOfBirth = DateTime.Parse(TextBoxDateOfBirth.Text);
            emp.Department.DepartmentId = int.Parse(DropDownListDepartment.Text);
            emp.Password = TextBoxPassword.Text;
            emp.Role = 'U';
            BLL.Employee.NewEmployee(emp);
            Response.Redirect("~/Default.aspx");
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Server.TransferRequest("~/Default.aspx");
        }
    }
}