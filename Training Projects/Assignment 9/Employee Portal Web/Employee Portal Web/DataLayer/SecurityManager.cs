using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public static class SecurityManager
    {
        public struct LoginData
        {
            public bool IsAuthenticated;
            public string Name;
            public List<string> Roles;
            public int EmployeeId;
        }

        public static LoginData AuthenticatedUser(string username, string password)
        {
            LoginData loginData = new LoginData();
            loginData.IsAuthenticated = false;
            loginData.Roles = new List<string>();

            using (SqlConnection cn = new SqlConnection(DB.EmployeePortalString))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandText = "Login";
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.Parameters.AddWithValue("@loginName", username);
                    cm.Parameters.AddWithValue("@password", password);
                    using (SqlDataReader dr = cm.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            loginData.Name = username;
                            loginData.Roles.Add(dr["Role"] as string);
                            loginData.EmployeeId = (int)dr["EmployeeId"];

                            loginData.IsAuthenticated = true;
                        }
                        else
                        {
                            loginData.Name = string.Empty;
                            loginData.IsAuthenticated = false;
                        }
                    }
                }
            }

            return loginData;
        }
    }
}
