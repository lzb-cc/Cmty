using CommonLib;
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
                var cmdText = string.Format("insert into TeacherSets values (N'{0}', N'{1}', '{2}', N'{3}', N'{4}', {5}, {6}, N'{7}')", model.Email, model.UserName, model.RegisteDate, model.Sex, model.Tel, model.University, model.JobTitle, model.Desp);
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
                    while(reader.Read())
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
    }
}