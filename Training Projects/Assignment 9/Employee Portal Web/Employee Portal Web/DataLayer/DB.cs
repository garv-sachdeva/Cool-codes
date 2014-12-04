using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DB
    {
        public static string EmployeePortalString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["EmployeePortalString"].ConnectionString;
                //string constr = ConfigurationManager.ConnectionStrings["EmployeePortalString"].ConnectionString;
                //SqlConnectionStringBuilder s = new SqlConnectionStringBuilder();
                //s.ApplicationName = applicationName;// ?? s.ApplicationName;
                //s.ConnectTimeout = connectionTimeout;
                ////s.ConnectTimeout = (connectionTimeout > 0) ? connectionTimeout : s.ConnectTimeout;
                //return s.ToString();

            }
        }
        /// <summary>
        /// Property used to override the name of the application
        /// </summary>
        public static string applicationName;

        /// <summary>
        /// overrides the connection timeout
        /// </summary>
        public static int connectionTimeout;

        /// <summary>
        /// returns an open connection
        /// </summary>
        /// <returns></returns>
        public static SqlConnection GetSqlConn()
        {
            SqlConnection s = new SqlConnection(EmployeePortalString);
            s.Open();
            return s;
        }
    }
}
