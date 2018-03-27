﻿using Services.cnts;
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
        public static List<CourseView> GetCourseByPage(int page,int nPage = 10)
        {
            var retList = new List<CourseView>();
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdText = string.Format("select top {0} * from CourseSets where Id not in (select top {1} Id from CourseSets)", nPage, page * nPage);
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    var reader = cmd.ExecuteReader();
                    while(reader.Read())
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
    }
}