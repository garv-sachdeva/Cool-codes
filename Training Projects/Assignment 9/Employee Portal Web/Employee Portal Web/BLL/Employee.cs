using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Employee
    {
        int _employeeId;
        string _employeeCode;
        string _firstName;
        string _lastName;
        DateTime _dateOfBirth;
        string _email;
        Department _department;
        DateTime _dateOfJoining;
        string _password;
        char _role;

        public int EmployeeId
        {
            get { return _employeeId; }
            set { _employeeId = value; }
        }

        public string EmployeeCode
        {
            get { return _employeeCode; }
            set { _employeeCode = value; }
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set { _dateOfBirth = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public Department Department
        {
            get { return _department; }
            set { _department = value; }
        }

        public DateTime DateOfJoining
        {
            get { return _dateOfJoining; }
            set { _dateOfJoining = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public char Role
        {
            get { return _role; }
            set { _role = value; }
        }

        public static Employee GetEmployee(int employeeId)
        {
            Employee employee = new Employee();
            employee.Fetch(employeeId);
            return employee;
        }

        public static void NewEmployee(Employee emp)
        {
            //Employee employee = new Employee();
            emp.Save();
            //return employee;
        }

        public static void UpdateEmployee(Employee emp)
        {
            //Employee employee = new Employee();
            //employee.EmployeeId = employeeId;
            emp.Save();
            //return emp;
        }

        public static void DeleteEmployee(int employeeId)
        {
            EmployeeManager.DeleteEmployee(employeeId);
        }

        public Employee()
        {
        }

        private void Fetch(int employeeId)
        {
            EmployeeManager.Employee emp = EmployeeManager.GetEmp(employeeId);
            Department = new BLL.Department();
            EmployeeId = emp.EmployeeId;
            EmployeeCode = emp.EmployeeCode;
            FirstName = emp.FirstName;
            LastName = emp.LastName;
            DateOfBirth = emp.DOB;
            Email = emp.Email;
            Department.DepartmentId = emp.DepartmentId;
            Department.DepartmentName = emp.DepartmentName;
            DateOfJoining = emp.DateOfJoining;
            Password = emp.Password;
        }

        public void Save()
        {
            if (this._employeeId == 0)
            {
                EmployeeManager.Employee emp = new EmployeeManager.Employee();

                
                emp.EmployeeCode = EmployeeCode;
                emp.FirstName = FirstName;
                emp.LastName = LastName;
                emp.DOB = DateOfBirth;
                emp.Email = Email;
                emp.DepartmentId = Department.DepartmentId;
                emp.DepartmentName = Department.DepartmentName;
                emp.DateOfJoining = DateOfJoining;
                emp.Password = Password;
                emp.Role = Role;
                EmployeeManager.AddEmployee(emp);
                EmployeeId = emp.EmployeeId;
                
                // Means this is a new Employee record and needs
                // to be inserted into the database

                // TODO: Code to insert the employee into database
            }
            else
            {
                EmployeeManager.Employee emp = new EmployeeManager.Employee();
                Department department = new BLL.Department();
                emp.EmployeeId = EmployeeId;
                emp.EmployeeCode = EmployeeCode;
                emp.FirstName = FirstName;
                emp.LastName = LastName;
                emp.DOB = DateOfBirth;
                emp.Email = Email;
                emp.DepartmentId = Department.DepartmentId;
                emp.DepartmentName = Department.DepartmentName;
                emp.DateOfJoining = DateOfJoining;
                emp.Password = Password;
                EmployeeManager.UpdateEmployee(emp);

                // Means this Employee record is already present
                // in the database and needs to be updated

                // TODO: Code to update the employee into database
            }
        }

        internal static Employee GetEmployee(EmployeeManager.Employee item)
        {
            Employee emp = new Employee();
            emp.Department = new Department();
            emp.EmployeeId = item.EmployeeId;
            emp.EmployeeCode = item.EmployeeCode;
            emp.FirstName = item.FirstName;
            emp.LastName = item.LastName;
            emp.DateOfBirth = item.DOB;
            emp.Email = item.Email;
            emp.Department.DepartmentId = item.DepartmentId;
            emp.Department.DepartmentName = item.DepartmentName;
            emp.DateOfJoining = item.DateOfJoining;
            return emp;
        }
    }
}
