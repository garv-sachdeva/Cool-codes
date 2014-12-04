using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DepartmentManager
    {
        public struct Department
        {
            public int DepartmentId;
            public string DepartmentName;
        }
        public static Department GetDepartment(int DepartmentId)
        {

            Department DepartmentData = new Department();
            //DepartmentData.DepartmentId = DepartmentId;
            using (SqlConnection cn = new SqlConnection(DB.EmployeePortalString))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandText = "GetDepartment";
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.Parameters.AddWithValue("@DepartmentId", DepartmentId);
                    using (SqlDataReader dr = cm.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            DepartmentData = ReadDepartment(dr);
                        }
                        else
                        {
                            throw new ApplicationException(string.Format("Department({0}) not found.", DepartmentData.DepartmentId));
                        }
                    }
                }
            }
            return DepartmentData;

        }

        public static List<Department> GetAllDepartments()
        {
            List<Department> Departments = new List<Department>();

            using (SqlConnection cn = new SqlConnection(DB.EmployeePortalString))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandText = "GetAllDepartments";
                    cm.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader dr = cm.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Departments.Add(ReadDepartment(dr));
                        }
                    }
                }
            }
            return Departments;
        }

        private static Department ReadDepartment(SqlDataReader dr)
        {
            Department DepartmentData = new Department();
            DepartmentData.DepartmentId = (int)dr["DepartmentId"];
            DepartmentData.DepartmentName = (string)dr["DepartmentName"];
            return DepartmentData;
        }

        public static Department AddDepartment(Department DepartmentData)
        {
            using (SqlConnection cn = new SqlConnection(DB.EmployeePortalString))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandText = "AddDepartment";
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.Parameters.AddWithValue("@DepartmentName", DepartmentData.DepartmentName);
                    DepartmentData.DepartmentId = Convert.ToInt32(cm.ExecuteScalar());
                }
            }
            return DepartmentData;
        }

        public static void UpdateDepartment(Department DepartmentData)
        {
            using (SqlConnection cn = new SqlConnection(DB.EmployeePortalString))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandText = "UpdateDepartment";
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.Parameters.AddWithValue("@DepartmentId", DepartmentData.DepartmentId);
                    cm.Parameters.AddWithValue("@DepartmentName", DepartmentData.DepartmentName);
                    cm.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteDepartment(int departmentId)
        {
            Department departmentData = new Department();
            departmentData.DepartmentId = departmentId;
            using (SqlConnection cn = new SqlConnection(DB.EmployeePortalString))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandText = "DeleteDepartment";
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.Parameters.AddWithValue("@DepartmentId", departmentData.DepartmentId);
                    SqlDataReader dr = cm.ExecuteReader();
                }
            }
        }
    }
}