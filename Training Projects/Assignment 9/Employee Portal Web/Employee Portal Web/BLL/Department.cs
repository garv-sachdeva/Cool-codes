using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Department
    {
        int _departmentId;
        string _departmentName;

        public int DepartmentId
        {
            get { return _departmentId; }
            set { _departmentId = value; }
        }

        public string DepartmentName
        {
            get { return _departmentName; }
            set { _departmentName = value; }
        }

        public static Department GetDept(int deptId)
        {
            Department dep = new Department();
            dep.Fetch(deptId);
            return dep;
        }

        public static Department AddDept()
        {
            DepartmentManager.Department dep = new DepartmentManager.Department();

            Department department = new Department();
            dep.DepartmentId = department.DepartmentId;
            dep.DepartmentName = department.DepartmentName;
            dep=DepartmentManager.AddDepartment(dep);
            department.DepartmentId = dep.DepartmentId;
            return department;
        }

        public static void UpdateDept(int deptId)
        {
            DepartmentManager.Department dep = new DepartmentManager.Department();

            Department department = new Department();
            dep.DepartmentId = department.DepartmentId;
            dep.DepartmentName = department.DepartmentName;
            DepartmentManager.UpdateDepartment(dep);
 
        }

        public static void DeleteDept(int deptId)
        {
            DepartmentManager.DeleteDepartment(deptId);
        }

        private void Fetch(int deptId)
        {
            DepartmentManager.Department dep = DepartmentManager.GetDepartment(deptId);

            this.DepartmentId = dep.DepartmentId;
            this.DepartmentName = dep.DepartmentName;
        }
    }
}
