using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class EmployeeManager
    {
        public struct Employee
        {
            public int EmployeeId;
            public string EmployeeCode;
            public string FirstName;
            public string LastName;
            public DateTime DOB;
            public string Email;
            public string DepartmentName;
            public int DepartmentId;
            public DateTime DateOfJoining;
            public char Role;
            public string Password;
        }

        public static Employee Load(SqlDataReader reader)
        {
            Employee e=new Employee();
            try
            {
                //e.EmployeeId = Int32.Parse(reader[@"EmployeeId"].ToString());
                e.EmployeeCode = reader[@"EmployeeCode"].ToString();
                e.FirstName = reader[@"FirstName"].ToString();
                e.LastName = reader[@"LastName"].ToString();
                e.DOB = DateTime.Parse(reader[@"DOB"].ToString());
                e.Email = reader[@"Email"].ToString();
                e.DepartmentId = Int32.Parse(reader[@"DepartmentId"].ToString());
                e.DepartmentName = reader[@"DepartmentName"].ToString();
                e.DateOfJoining = DateTime.Parse(reader[@"DateOfJoining"].ToString());

            }
            catch
            {
            }
            return e;
        }

        public static Employee GetEmp(int empId)
        {
            Employee empData = new Employee();
            using (SqlConnection cn = DB.GetSqlConn())
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandText = "GetEmployee";
                    //cm.CommandText = string.Format(cm.CommandText);
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.Parameters.AddWithValue("@EmployeeId", empId);
                    using (SqlDataReader dr = cm.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            empData = Load(dr);
                            empData.EmployeeId = empId;
                            empData.Password = GetPass(empId);
                        }
                        else
                        {
                            try
                            {
                                throw new ApplicationException(string.Format("Employee {0} not found.", empId));
                            }
                            catch
                            {
                                throw new ApplicationException(string.Format("Employee {0} not found.", empId));
                            }
                        }
                    }
                }
            }

            return empData;
        }

        private static string GetPass(int empId)
        {
            string pass="";
            using (SqlConnection cn = DB.GetSqlConn())
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandText = "GetPassword";
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.Parameters.AddWithValue("@EmployeeId", empId);
                    using (SqlDataReader dr = cm.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            pass = dr[@"Password"].ToString();
                        }
                    }
                }
            }
            return pass;
            //throw new NotImplementedException();
        }

        public static Employee AddEmployee(Employee empData)
        {
            using (SqlConnection cn = new SqlConnection(DB.EmployeePortalString))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandText = "AddEmployee";
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.Parameters.AddWithValue("@EmployeeCode", empData.EmployeeCode);
                    cm.Parameters.AddWithValue("@FirstName", empData.FirstName);
                    cm.Parameters.AddWithValue("@LastName", empData.LastName);
                    cm.Parameters.AddWithValue("@DOB", empData.DOB);
                    cm.Parameters.AddWithValue("@Email", empData.Email);
                    cm.Parameters.AddWithValue("@DepartmentId", empData.DepartmentId);
                    cm.Parameters.AddWithValue("@Role", empData.Role);
                    cm.Parameters.AddWithValue("@Password", empData.Password);
                    cm.Parameters.AddWithValue("@DateOfJoining", empData.DateOfJoining);
                    cm.Parameters.AddWithValue("@EmployeeId", empData.EmployeeId);
                    //empData.EmployeeId = Convert.ToInt32(cm.ExecuteScalar());
                    cm.ExecuteNonQuery();
                }
            }

            return empData;
        }

        public static List<Employee> GetAllEmployees()
        {
            List<Employee> EmpList = new List<Employee>();

            using (SqlConnection cn = new SqlConnection(DB.EmployeePortalString))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandText = "GetAllEmployees";
                    cm.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader dr = cm.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Employee e = new Employee();
                            e.EmployeeId = (int)dr["EmployeeId"];
                            e.EmployeeCode = dr[@"EmployeeCode"].ToString();
                            e.FirstName = dr[@"FirstName"].ToString();
                            e.LastName = dr[@"LastName"].ToString();
                            e.DOB = DateTime.Parse(dr[@"DOB"].ToString());
                            e.Email = dr[@"Email"].ToString();
                            e.DepartmentId = Int32.Parse(dr[@"DepartmentId"].ToString());
                            //e.DepartmentName = dr[@"DepartmentName"].ToString();
                            e.DateOfJoining = DateTime.Parse(dr[@"DateOfJoining"].ToString());
                            EmpList.Add(e);
                        }
                    }
                }
            }
            return EmpList;
        }

        public static List<Employee> SearchEmployees(string employeeCode, string firstName, string lastName, int? departmentId, DateTime? dateOfJoining)
        {
            List<Employee> empList = new List<Employee>();
            Employee empData = new Employee();
            //empData.EmployeeCode = employeeCode;
            //empData.FirstName = firstName;
            //empData.LastName = lastName;
            //empData.DepartmentId = departmentId;
            //empData.DateOfJoining = dateOfJoining;

            using (SqlConnection cn = new SqlConnection(DB.EmployeePortalString))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandText = "SearchEmployees";
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.Parameters.AddWithValue("@EmployeeCode", employeeCode);
                    cm.Parameters.AddWithValue("@FirstName", firstName);
                    cm.Parameters.AddWithValue("@LastName", lastName);
                    cm.Parameters.AddWithValue("@DepartmentId", departmentId);
                    cm.Parameters.AddWithValue("@DateOfJoining", dateOfJoining);
                    using (SqlDataReader dr = cm.ExecuteReader())
                    {
                        while(dr.Read())
                        {
                            empData.EmployeeId = (int)dr["EmployeeId"];
                            empData.EmployeeCode = dr["EmployeeCode"] as string;
                            empData.FirstName = dr["FirstName"] as string;
                            empData.LastName = dr["LastName"] as string;
                            empData.DOB = (DateTime)dr["DOB"];
                            empData.Email = dr["Email"] as string;
                            empData.DepartmentId = (int)dr["DepartmentId"];
                            empData.DateOfJoining = (DateTime)dr["DateOfJoining"];
                            empList.Add(empData);
                        }
                        //else
                        //{
                        //    throw new ApplicationException(string.Format("Employee({0}) not found.", empData.EmployeeId));
                        //}
                    }
                }
            }
            return empList;
        }

        public static void UpdateEmployee(Employee employeeData)
        {
            using (SqlConnection cn = new SqlConnection(DB.EmployeePortalString))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandText = "UpdateEmployee";
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.Parameters.AddWithValue("@EmployeeId", employeeData.EmployeeId);
                    cm.Parameters.AddWithValue("@FirstName", employeeData.FirstName);
                    cm.Parameters.AddWithValue("@LastName", employeeData.LastName);
                    cm.Parameters.AddWithValue("@DOB", employeeData.DOB);
                    cm.Parameters.AddWithValue("@Email", employeeData.Email);
                    cm.Parameters.AddWithValue("@DepartmentId", employeeData.DepartmentId);
                    cm.Parameters.AddWithValue("@Password", employeeData.Password);
                    cm.Parameters.AddWithValue("@DepartmentName", employeeData.DepartmentName);

                    cm.ExecuteNonQuery();
                }
            }
        }
        public static void DeleteEmployee(int employeeId)
        {
            //Employee employeeData = new Employee();
            //employeeData.EmployeeId = employeeId;
            using (SqlConnection cn = new SqlConnection(DB.EmployeePortalString))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandText = "DeleteEmployee";
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.Parameters.AddWithValue("@employeeId", employeeId);
                    SqlDataReader dr = cm.ExecuteReader();
                }
            }
        }
    }
}
