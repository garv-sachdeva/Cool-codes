using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public static class NoticeManager
    {

        public struct Notice
        {
            public int NoticeId;
            public string Title;
            public string Description;
            public DateTime StartDate;
            public DateTime ExpirationDate;
            public int PostedById;
            public string PostedByName;
        }

        public static Notice GetNotice(int noticeId)
        {
            Notice noticeData = new Notice();
            noticeData.NoticeId = noticeId;

            using (SqlConnection cn = new SqlConnection(DB.EmployeePortalString))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandText = "GetNotice";
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.Parameters.AddWithValue("@noticeId", noticeData.NoticeId);
                    using (SqlDataReader dr = cm.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            noticeData = ReadNotice(dr);
                        }
                        else
                        {
                            throw new ApplicationException(string.Format("Notice({0}) not found.", noticeData.NoticeId));
                        }
                    }
                }
            }

            return noticeData;
        }

        public static List<Notice> GetAllNotices()
        {
            List<Notice> notices = new List<Notice>();

            using (SqlConnection cn = new SqlConnection(DB.EmployeePortalString))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandText = "GetAllNotices";
                    cm.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader dr = cm.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            notices.Add(ReadNotice(dr));
                        }
                    }
                }
            }

            return notices;
        }

        private static Notice ReadNotice(SqlDataReader dr)
        {
            Notice noticeData = new Notice();
            noticeData.NoticeId = (int)dr["NoticeId"];
            noticeData.Title = dr["Title"] as string;
            noticeData.Description = dr["Description"] as string;
            noticeData.StartDate = (DateTime)dr["StartDate"];
            noticeData.ExpirationDate = (DateTime)dr["ExpirationDate"];
            noticeData.PostedById = (int)dr["EmployeeId"];
            noticeData.PostedByName = (string)dr["FirstName"] + " " + (string)dr["LastName"];
            return noticeData;
        }

        public static Notice InsertNotice(Notice noticeData)
        {
            using (SqlConnection cn = new SqlConnection(DB.EmployeePortalString))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandText = "AddNotice";
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.Parameters.AddWithValue("@title", noticeData.Title);
                    cm.Parameters.AddWithValue("@description", noticeData.Description);
                    cm.Parameters.AddWithValue("@startDate", noticeData.StartDate);
                    cm.Parameters.AddWithValue("@expirationDate", noticeData.ExpirationDate);
                    cm.Parameters.AddWithValue("@postedBy", noticeData.PostedById);

                    noticeData.NoticeId = Convert.ToInt32(cm.ExecuteScalar());
                }
            }

            return noticeData;
        }

        public static void UpdateNotice(Notice noticeData)
        {
            using (SqlConnection cn = new SqlConnection(DB.EmployeePortalString))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandText = "UpdateNotice";
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.Parameters.AddWithValue("@noticeId", noticeData.NoticeId);
                    cm.Parameters.AddWithValue("@title", noticeData.Title);
                    cm.Parameters.AddWithValue("@description", noticeData.Description);
                    cm.Parameters.AddWithValue("@startDate", noticeData.StartDate);
                    cm.Parameters.AddWithValue("@expirationDate", noticeData.ExpirationDate);

                    cm.ExecuteNonQuery();
                }
            }
        }
        public static void DeleteNotice(int noticeId)
        {
            Notice noticeData = new Notice();
            noticeData.NoticeId = noticeId;
            using (SqlConnection cn = new SqlConnection(DB.EmployeePortalString))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandText = "DeleteNotice";
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.Parameters.AddWithValue("@noticeId", noticeData.NoticeId);

                    cm.ExecuteNonQuery();
                }

                cn.Close();
            }
        }
    }
}
