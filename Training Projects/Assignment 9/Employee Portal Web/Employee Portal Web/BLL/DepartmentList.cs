using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DepartmentList : List<Department>
    {
        private DepartmentList()
        { }

        public static DepartmentList GetAllDept()
        {
            DepartmentList deptList = new DepartmentList();
            deptList.fetchAll();
            return deptList;
        }

        public void fetchAll()
        {
            List<DepartmentManager.Department> dep = DepartmentManager.GetAllDepartments();

            foreach (var item in dep)
            {
                Department department = new Department();
                department.DepartmentId = item.DepartmentId;
                department.DepartmentName = item.DepartmentName;
                this.Add(department);
            }
        }
    }
}
