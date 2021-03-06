﻿using CommonLib;
using Services.cnts;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Services.DAL.Teacher
{
    public static class TeacherOperator
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;


        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="model">注册对象</param>
        /// <returns></returns>
        public static ReturnState AddTeacherInfo(TeacherInfoView model)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdText = string.Format("insert into TeacherSets values (N'{0}', N'{1}', '{2}', N'{3}', N'{4}', {5}, {6}, N'{7}')", model.Email, model.UserName, DateTime.Now, model.Sex, model.Tel, model.University, model.JobTitle, model.Desp);
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
        /// 查询邮箱是否存在
        /// </summary>
        /// <param name="emal"></param>
        /// <returns></returns>
        public static bool HasMember(string emal)
        {
            bool result = false;
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdText = string.Format("select * from TeacherSets where email = N'{0}'", emal);
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    result = cmd.ExecuteScalar() != null;
                    conn.Close();
                }
            }

            return result;
        }

        public static TeacherInfoView GetTeacherInfo(string email)
        {
            var user = new TeacherInfoView();
            user.Email = email;
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdText = string.Format("select uName, rDate, Sex, Tel, University, jTitle, Desp from TeacherSets where Email = N'{0}'", email);
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    var reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        user.UserName = Convert.ToString(reader.GetValue(0));
                        user.RegisteDate = Convert.ToDateTime(reader.GetValue(1));
                        user.Sex = Convert.ToString(reader.GetValue(2));
                        user.Tel = Convert.ToString(reader.GetValue(3));
                        user.University = Convert.ToInt32(reader.GetValue(4));
                        user.JobTitle = Convert.ToInt32(reader.GetValue(5));
                        user.Desp = Convert.ToString(reader.GetValue(6));
                    }
                    conn.Close();
                }
            }

            return user;
        }

        public static List<TeacherInfoView> GetTeacherInfoList()
        {
            var retList = new List<TeacherInfoView>();
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdText = string.Format("select uName, rDate, Sex, Tel, University, jTitle, Desp, Email from TeacherSets");
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var user = new TeacherInfoView();
                        user.UserName = Convert.ToString(reader.GetValue(0));
                        user.RegisteDate = Convert.ToDateTime(reader.GetValue(1));
                        user.Sex = Convert.ToString(reader.GetValue(2));
                        user.Tel = Convert.ToString(reader.GetValue(3));
                        user.University = Convert.ToInt32(reader.GetValue(4));
                        user.JobTitle = Convert.ToInt32(reader.GetValue(5));
                        user.Desp = Convert.ToString(reader.GetValue(6));
                        user.Email = Convert.ToString(reader.GetValue(7));
                        retList.Add(user);
                    }
                    conn.Close();
                }
            }

            return retList;
        }

        public static bool UpdateUserInfo(TeacherInfoView model)
        {
            var result = false;
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdText = string.Format("update TeacherSets set uName = N'{1}', rDate = '{2}', Sex = N'{3}', Tel = N'{4}', University = {5}, jTitle = {6}, Desp = N'{7}'  where Email = N'{0}'", model.Email, model.UserName, model.RegisteDate, model.Sex, model.Tel, model.University, model.JobTitle, model.Desp);
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    result = cmd.ExecuteNonQuery() > 0;
                    conn.Close();
                }
            }

            return result;
        }

        public static bool DelelteTeacherInfo(string email)
        {
            var result = false;
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdText = string.Format("delete from TeacherSets where Email = N'{0}'", email);
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    result = cmd.ExecuteNonQuery() > 0;
                    conn.Close();
                }
            }

            return result;
        }

        public static bool DeleteTeacherCommnetById(int id)
        {
            var result = false;
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdText = string.Format("delete from TeacherCommentSets where Id = {0}", id);
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    result = cmd.ExecuteNonQuery() > 0;
                    conn.Close();
                }
            }

            return result;
        }

        public static bool AddCourseComment(TeacherCommentView model)
        {
            var result = false;
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdText = string.Format("insert into TeacherCommentSets values (N'{0}', N'{1}' , '{2}', N'{3}', {4})", model.Teacher, model.Email, DateTime.Now, model.Content, model.Floor);
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    result = cmd.ExecuteNonQuery() > 0;
                    conn.Close();
                }
            }
            return result;
        }

        public static bool RemoveCourseComment(TeacherCommentView model)
        {
            var result = false;
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdText = string.Format("delete from TeacherCommentSets where T_Id = N'{0}' and Email = N'{1}' and cDate = '{2}'", model.Teacher, model.Email, model.PubDate);
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    result = cmd.ExecuteNonQuery() > 0;
                    conn.Close();
                }
            }

            return result;
        }

        public static List<TeacherCommentView> GetCourseCommentListByEmail(string email)
        {
            var ret = new List<TeacherCommentView>();
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdText = string.Format("select T_Id, Email, cDate, Content, CmtFloor, Id from TeacherCommentSets where T_Id = N'{0}' order by CmtFloor DESC", email);
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var comment = new TeacherCommentView();
                        comment.Teacher = Convert.ToString(reader.GetValue(0));
                        comment.Email = Convert.ToString(reader.GetValue(1));
                        comment.PubDate = Convert.ToDateTime(reader.GetValue(2));
                        comment.Content = Convert.ToString(reader.GetValue(3));
                        comment.Floor = Convert.ToInt32(reader.GetValue(4));
                        comment.Id = Convert.ToInt32(reader.GetValue(5));
                        ret.Add(comment);
                    }
                }
            }

            return ret;
        }

        public static int GetValidFloor(string email)
        {
            var result = 1;
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdText = string.Format("select max(CmtFloor) from TeacherCommentSets where T_Id = N'{0}'", email);
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    var tmp = cmd.ExecuteScalar();
                    result += Convert.ToInt32(DBNull.Value.Equals(tmp) ? 0 : tmp);
                    conn.Close();
                }
            }

            return result;
        }

        public static List<string> GetTeacherByCourse(string code)
        {
            var result = new List<string>();
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdText = string.Format("");
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        result.Add(Convert.ToString(reader.GetValue(0)));
                    }
                    conn.Close();
                }
            }
            return result;
        }

    }
}