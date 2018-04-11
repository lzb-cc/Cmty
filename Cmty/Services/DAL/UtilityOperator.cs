using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Services.DAL
{
    public static class UtilityOperator
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        /// <summary>
        /// 查询大学索引
        /// </summary>
        /// <param name="university"></param>
        /// <returns></returns>
        public static int IndexOfUniversity(string university)
        {
            int result = -1;
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdText = string.Format("select Id from cfg_Universities where name = N'{0}'", university);
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    var obj = cmd.ExecuteScalar();
                    if (obj != null)
                    {
                        result = Convert.ToInt32(obj);
                    }
                    conn.Close();
                }
            }

            return result;
        }

        public static string NameOfUniversity(int id)
        {
            string result = "";
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdText = string.Format("select name from cfg_Universities where id = {0}", id);
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    result = Convert.ToString(cmd.ExecuteScalar());
                    conn.Close();
                }
            }

            return result;
        }

        public static string NameOfJobTitle(int id)
        {
            string result = "";
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdText = string.Format("select Desp from cfg_JobTitle where Id = {0}", id);
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    result = Convert.ToString(cmd.ExecuteScalar());
                    conn.Close();
                }
            }

            return result;
        }

        public static int IndexOfJobTitle(string name)
        {
            int result = 1;
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdText = string.Format("select Id from cfg_JobTitle where Desp = N'{0}'", name);
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    result = Convert.ToInt32(cmd.ExecuteScalar());
                    conn.Close();
                }
            }

            return result;
        }

        public static bool AddTeacherCourseMap(string email, string code)
        {
            var result = false;
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdText = string.Format("insert into TeacherCourseSets values(N'{0}', N'{1}')", email.Trim(), code.Trim());
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    try
                    {
                        result = cmd.ExecuteNonQuery() > 0;
                    }
                    catch (SqlException exp)
                    {
                        result = false;
                    }
                    conn.Close();
                }
            }

            return result;
        }

        public static bool DelTeacherCourseMap(string email, string code)
        {
            var result = false;
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdText = string.Format("delete from TeacherCourseSets where Email = N'{0}' and CourseId = N'{1}'", email.Trim(), code.Trim());
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    result = cmd.ExecuteNonQuery() > 0;
                    conn.Close();
                }
            }

            return result;
        }

        public static List<string> GetCourseByTeacher(string email)
        {
            var ret = new List<string>();
            if (string.IsNullOrEmpty(email))
            {
                return ret;
            }

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdText = string.Format("select CourseId from TeacherCourseSets where Email = N'{0}'", email.Trim());
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ret.Add(Convert.ToString(reader.GetValue(0)));
                    }
                }
            }

            return ret;
        }

        public static List<string> GetTeacherByCourseId(string code)
        {
            var ret = new List<string>();
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdText = string.Format("select Email from TeacherCourseSets where CourseId = N'{0}'", code.Trim());
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ret.Add(Convert.ToString(reader.GetValue(0)));
                    }
                }
            }

            return ret;
        }

        public static string NameOfCourse(string code)
        {
            var result = "";
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdText = string.Format("select name from CourseSets where Id = N'{0}'", code);
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    result = Convert.ToString(cmd.ExecuteScalar());
                    conn.Close();
                }
            }

            return result;
        }
    }
}