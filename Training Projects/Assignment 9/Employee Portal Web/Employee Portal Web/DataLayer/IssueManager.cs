using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class IssueManager
    {
        public struct Issue
        {
            public int IssueId;
            public string Title;
            public string Description;
            public DateTime DatePosted;
            public int PostedBy;
            public int AssignedTo;
            public short Status;
            public string StatusName;
            public short Priority;
            public string Comment;
            public DateTime DateModified;
            public string EmployeeName;
        }

        public static Issue AddIssue(Issue IssueData)
        {
            using (SqlConnection cn = new SqlConnection(DB.EmployeePortalString))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandText = "AddIssue";
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.Parameters.AddWithValue("@title", IssueData.Title);
                    cm.Parameters.AddWithValue("@description", IssueData.Description);
                    cm.Parameters.AddWithValue("@postedBy", IssueData.PostedBy);
                    cm.Parameters.AddWithValue("@assignedTo", IssueData.AssignedTo);
                    cm.Parameters.AddWithValue("@status", IssueData.Status);
                    cm.Parameters.AddWithValue("@priority", IssueData.Priority);
                    cm.Parameters.AddWithValue("@issueId", 0);
                    IssueData.IssueId = Convert.ToInt32(cm.ExecuteScalar());
                }
            }

            return IssueData;
        }

        public static List<Issue> GetAllIssues()
        {
            List<Issue> issues = new List<Issue>();

            using (SqlConnection cn = new SqlConnection(DB.EmployeePortalString))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandText = "GetAllIssues";
                    cm.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader dr = cm.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            issues.Add(ReadIssue(dr));
                        }
                    }
                }
            }
            return issues;
        }

        private static Issue ReadIssue(SqlDataReader dr)
        {
            Issue IssueData = new Issue();
            IssueData.IssueId = (int)dr["IssueId"];
            IssueData.Title = dr["Title"] as string;
            IssueData.Description = dr["Description"] as string;
            IssueData.DatePosted = (DateTime)dr["DatePosted"];
            IssueData.PostedBy = (int)dr["PostedBy"];
            IssueData.AssignedTo = (int)dr["AssignedTo"];
            IssueData.Status = (short)dr["Status"];
            IssueData.Priority = (short)dr["Priority"];
            if (IssueData.Status == 1)
                IssueData.StatusName = "Raised";
            if (IssueData.Status == 2)
                IssueData.StatusName = "Work in Progress";
            if (IssueData.Status == 3)
                IssueData.StatusName = "Resolved";
            if (IssueData.Status == 4)
                IssueData.StatusName = "Closed";
            IssueData.EmployeeName=  GetName(IssueData.PostedBy);

            return IssueData;
        }

        private static string GetName(int p)
        {
            string name = " ";
            using (SqlConnection cn = new SqlConnection(DB.EmployeePortalString))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandText = "GetEmployeeName";
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.Parameters.AddWithValue("@PostedBy", p);
                    using (SqlDataReader dr = cm.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            string FName = dr["FirstName"] as string;
                            string LName = dr["LastName"] as string;
                            name = FName + " " + LName;
                        }
                    }
                }
            }
            return name;
        }

        public static Issue GetIssue(int issueId)
        {
            Issue issueData = new Issue();
            issueData.IssueId = issueId;

            using (SqlConnection cn = new SqlConnection(DB.EmployeePortalString))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandText = "GetIssue";
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.Parameters.AddWithValue("@issueId", issueData.IssueId);
                    using (SqlDataReader dr = cm.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            issueData = ReadIssue(dr);
                        }
                        else
                        {
                            throw new ApplicationException(string.Format("Issue({0}) not found.", issueData.IssueId));
                        }
                    }
                }
            }
            return issueData;
        }

        public static List<Issue> GetAllOpenIssues()
        {
            List<Issue> issues = new List<Issue>();

            using (SqlConnection cn = new SqlConnection(DB.EmployeePortalString))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandText = "GetAllOpenIssues";
                    cm.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader dr = cm.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            issues.Add(ReadIssue(dr));
                        }
                    }
                }
            }
            return issues;
        }

        public static void UpdateIssue(Issue IssueData)
        {
            using (SqlConnection cn = new SqlConnection(DB.EmployeePortalString))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandText = "UpdateIssue";
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.Parameters.AddWithValue("@issueId", IssueData.IssueId);
                    cm.Parameters.AddWithValue("@title", IssueData.Title);
                    cm.Parameters.AddWithValue("@description", IssueData.Description);
                    cm.Parameters.AddWithValue("@postedBy", IssueData.PostedBy);
                    cm.Parameters.AddWithValue("@assignedTo", IssueData.AssignedTo);
                    cm.Parameters.AddWithValue("@status", IssueData.Status);
                    cm.Parameters.AddWithValue("@priority", IssueData.Priority);
                    cm.Parameters.AddWithValue("@comments", IssueData.Comment);

                    cm.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteIssue(int issueId)
        {
            Issue issueData = new Issue();
            issueData.IssueId = issueId;
            using (SqlConnection cn = new SqlConnection(DB.EmployeePortalString))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandText = "DeleteIssue";
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.Parameters.AddWithValue("@issueId", issueData.IssueId);
                    SqlDataReader dr = cm.ExecuteReader();
                }
            }
        }

        public static List<Issue> GetAllOpenIssues(int employeeId)
        {
           List<Issue> issues = new List<Issue>();

           using (SqlConnection cn = new SqlConnection(DB.EmployeePortalString))
           {
               cn.Open();
               using (SqlCommand cm = cn.CreateCommand())
               {
                   cm.CommandText = "GetUserOpenIssue";
                   cm.CommandType = CommandType.StoredProcedure;
                   cm.Parameters.AddWithValue(@"userId", employeeId);
                   using (SqlDataReader dr = cm.ExecuteReader())
                   {
                       while (dr.Read())
                       {
                           issues.Add(ReadIssue(dr));
                       }
                   }
               }
           }
           return issues;
           throw new NotImplementedException();
        }
    }
}
