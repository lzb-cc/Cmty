using Services.cnts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Services;
using System.Configuration;
using CommonLib;
using System.Data.SqlClient;

namespace Services.DAL.Course
{
    public static class CourseOperator
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;


        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="model">注册对象</param>
        /// <returns></returns>
        public static ReturnState AddCourse(CourseView model)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdText = string.Format("insert into CourseSets(Id, university, name, desp, pic_url) values (N'{0}',{1} , N'{2}', N'{3}', N'{4}')", model.Code, model.University, model.Name, model.Desp, model.PicUrl);
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    var result = cmd.ExecuteNonQuery();
                    conn.Close();

                    if (result <= 0)
                    {
                        return ReturnState.ReturnError;
                    }
                }
            }
            return ReturnState.ReturnOK;
        }

        /// <summary>
        /// 查询课程编号是否存在
        /// </summary>
        /// <param name="emal"></param>
        /// <returns></returns>
        public static bool HasMember(string code)
        {
            bool result = false;
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdText = string.Format("select * from CourseSets where Id = N'{0}'", code);
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    result = cmd.ExecuteScalar() != null;
                    conn.Close();
                }
            }

            return result;
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="page"></param>
        /// <param name="nPage"></param>
        /// <returns></returns>
        public static List<CourseView> GetCourseByPage(int page, int nPage = 10)
        {
            var retList = new List<CourseView>();
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdText = string.Format("select top {0} * from CourseSets where Id not in (select top {1} Id from CourseSets)", nPage, page * nPage);
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var course = new CourseView()
                        {
                            Code = Convert.ToString(reader.GetValue(0)),
                            University = Convert.ToInt32(reader.GetValue(1)),
                            Name = Convert.ToString(reader.GetValue(2)),
                            Desp = Convert.ToString(reader.GetValue(3)),
                            PicUrl = Convert.ToString(reader.GetValue(4))
                        };
                        retList.Add(course);
                    }
                }

                return retList;
            }
        }

        public static bool AddCourseApply(CourseView model, UserApply user)
        {
            var result = false;
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdText = string.Format("insert into tmp_CourseSets values (N'{0}', '{1}', {2}, N'{3}', {4}, N'{5}', N'{6}', N'{7}')",user.Email, user.CommitDate, user.Status, model.Code, model.University, model.Name, model.Desp, model.PicUrl);
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    result = cmd.ExecuteNonQuery() > 0;
                    conn.Close();
                }
            }

            return result;
        }

        public static List<CourseReviewView> GetCourseReviewViewByEmail(string email)
        {
            var retList = new List<CourseReviewView>();
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdText = string.Format("select a.CommitDate, a.Code,a.name, a.desp, a.pic_url, b.Desp, c.name from tmp_CourseSets a left join cfg_ReviewStatus b on a.ReviewStatus = b.Id left join cfg_Universities c on a.university = c.Id where a.CommitUser = N'{0}'", email);
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    var reader = cmd.ExecuteReader();
                    while(reader.Read())
                    {
                        var course = new CourseReviewView()
                        {
                            Email = email,
                            CommitDate = Convert.ToDateTime(reader.GetValue(0)),
                            Code = Convert.ToString(reader.GetValue(1)),
                            Name = Convert.ToString(reader.GetValue(2)),
                            Desp = Convert.ToString(reader.GetValue(3)),
                            PicUrl = Convert.ToString(reader.GetValue(4)),
                            Status = Convert.ToString(reader.GetValue(5)),
                            University = Convert.ToString(reader.GetValue(6))
                        };
                        retList.Add(course);
                    }
                }
            }

            return retList;
        }
    }
}