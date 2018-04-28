using Services.cnts;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Services.DAL.Course
{
    public class CourseCommentOperator
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;


        public static bool AddCourseComment(CourseCommentView model)
        {
            var result = false;
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdText = string.Format("insert into CourseCommentSets values (N'{0}', N'{1}' , '{2}', N'{3}', {4})", model.Code, model.Email, model.PubDate, model.Content, model.Floor);
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    result = cmd.ExecuteNonQuery() > 0;
                    conn.Close();
                }
            }
            return result;
        }

        public static bool RemoveCourseComment(CourseCommentView model)
        {
            var result = false;
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdText = string.Format("delete from CourseCommentSets where Code = N'{0}' and Email = N'{1}' and cDate = '{2}'", model.Code, model.Email, model.PubDate);
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    result = cmd.ExecuteNonQuery() > 0;
                    conn.Close();
                }
            }

            return result;
        }

        public static bool RemoveCourseCommentById(int id)
        {
            var result = false;
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdText = string.Format("delete from CourseCommentSets where Id = {0}", id);
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    result = cmd.ExecuteNonQuery() > 0;
                    conn.Close();
                }
            }

            return result;
        }

        public static List<CourseCommentView> GetCourseCommentListByCode(string code)
        {
            var ret = new List<CourseCommentView>();
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdText = string.Format("select Code, Email, cDate, Content, CmtFloor, Id from CourseCommentSets where Code = N'{0}' order by CmtFloor DESC", code);
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var comment = new CourseCommentView()
                        {
                            Code = Convert.ToString(reader.GetValue(0)),
                            Email = Convert.ToString(reader.GetValue(1)),
                            PubDate = Convert.ToDateTime(reader.GetValue(2)),
                            Content = Convert.ToString(reader.GetValue(3)),
                            Floor = Convert.ToInt32(reader.GetValue(4)),
                            Id = Convert.ToInt32(reader.GetValue(5))
                        };
                        ret.Add(comment);
                    }
                }
            }

            return ret;
        }

        public static int GetValidFloor(string code)
        {
            var result = 1;
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdText = string.Format("select max(CmtFloor) from CourseCommentSets where Code = N'{0}'", code);
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    var tmp = cmd.ExecuteScalar();
                    result += Convert.ToInt32(DBNull.Value.Equals(tmp) ? 0 : tmp);
                    conn.Close();
                }
            }

            return result;
        }
    }
}