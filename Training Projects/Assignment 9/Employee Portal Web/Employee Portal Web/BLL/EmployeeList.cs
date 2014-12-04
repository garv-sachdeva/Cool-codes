using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class EmployeeList : List<Employee>
    {
        private EmployeeList()
        {
        }

        public static EmployeeList GetAllEmployees()
        {
            EmployeeList empList = new EmployeeList();
            empList.fetchAll();
            return empList;
        }

        public void fetchAll()
        {
            List<EmployeeManager.Employee> empList = EmployeeManager.GetAllEmployees();

            foreach (var item in empList)
            {
                Employee emp = Employee.GetEmployee(item);
                emp.Department = Department.GetDept(emp.Department.DepartmentId);
                this.Add(emp);

            }
        }

       public static EmployeeList GetSearchEmployees(string employeeCode, string firstName, string lastName, int? departmentId, DateTime? dateOfJoining)
        {
            EmployeeList searchedEmployee = new EmployeeList();
            searchedEmployee.FetchSearchEmployee(employeeCode,  firstName,  lastName,  departmentId,  dateOfJoining);
            return searchedEmployee;
        }

       private void FetchSearchEmployee(string employeeCode, string firstName, string lastName, int? departmentId, DateTime? dateOfJoining)
        {
           List<EmployeeManager.Employee> searchEmployee = EmployeeManager.SearchEmployees(employeeCode, firstName, lastName, departmentId,  dateOfJoining); 
           
            foreach (var searchedEmployee in searchEmployee)
            {
                Employee employee = Employee.GetEmployee(searchedEmployee);

                employee.Department = Department.GetDept(searchedEmployee.DepartmentId);
                this.Add(employee);
            }
        }


      
    }
}
