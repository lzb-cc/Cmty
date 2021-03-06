﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using CommonLib;
using System.Data.SqlClient;
using Services;

namespace Services.DAL.Account
{
    public class AccountOperator
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;


        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="model">注册对象</param>
        /// <returns></returns>
        public static ReturnState Register(RegisterView model)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdText = string.Format("insert into UserSets(Email, Pwd, uName, rDate, Tel, University) values (N'{0}', N'{1}', N'{2}', '{3}', N'{4}', {5})", model.Email, model.Password, model.UserName, DateTime.Now, model.Tel, model.University);
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
                var cmdText = string.Format("select * from UserSets where email = '{0}'", emal);
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    result = cmd.ExecuteScalar() != null;
                    conn.Close();
                }
            }

            return result;
        }

        public static bool Login(LoginView model)
        {
            bool result = false;
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdText = string.Format("select * from UserSets where email = '{0}' and pwd = '{1}'", model.Email, model.Password);
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    result = cmd.ExecuteScalar() != null;
                    conn.Close();
                }
            }

            return result;
        }

        public static UserInfoView GetUserInfo(string email)
        {
            var user = new UserInfoView();
            user.Email = email;
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdText = string.Format("select uName, Tel, c.name, Sex, Nick, Hobby, Avatar from UserSets a left join ExtraUserInfo b on a.Email = b.Email left join cfg_Universities c on a.university = c.Id where a.Email = N'{0}'", email);
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    var reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        user.UserName = Convert.ToString(reader.GetValue(0));
                        user.Tel = Convert.ToString(reader.GetValue(1));
                        user.University = Convert.ToString(reader.GetValue(2));
                        user.Sex = Convert.ToString(reader.GetValue(3));
                        user.Nick = Convert.ToString(reader.GetValue(4));
                        user.Hobby = Convert.ToString(reader.GetValue(5));
                        user.Avatar = Convert.ToString(reader.GetValue(6));
                    }
                    conn.Close();
                }
            }

            return user;
        }

        public static bool UpdateUserInfo(UserInfoView model)
        {
            var result = false;
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdText = string.Format("update UserSets set uName = N'{0}', Tel = N'{1}' where Email = N'{2}'", model.UserName, model.Tel, model.Email);
                var cmdText1 = string.Format(@"if not exists (select * from ExtraUserInfo where Email = N'{0}') insert into ExtraUserInfo values (N'{0}', N'{1}', N'{2}', N'{3}', N'{4}') else update ExtraUserInfo set Sex = N'{1}', Nick = N'{2}', Hobby = N'{3}', Avatar = N'{4}' where Email = N'{0}'", model.Email, model.Sex, model.Nick, model.Hobby, model.Avatar);
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    result = cmd.ExecuteNonQuery() > 0;
                    cmd.CommandText = cmdText1;
                    result = result && (cmd.ExecuteNonQuery() > 0);
                    conn.Close();
                }
            }

            return result;
        }

        public static bool UpdateUserPassword(string email, string password)
        {
            var result = false;
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdText = string.Format("update UserSets set Pwd = N'{1}' where Email = N'{0}'", email, password);
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    result = cmd.ExecuteNonQuery() > 0;
                    conn.Close();
                }
            }
            return result;
        }

        public static bool AdminLogin(LoginView model)
        {
            var result = false;
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdText = string.Format("select * from AdminUsers where Email = N'{0}' and Pwd = N'{1}'", model.Email, model.Password);
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    result = cmd.ExecuteScalar() != null;
                    conn.Close();
                }
            }

            return result;
        }

        public static bool AddEmailToCheckSet(string email)
        {
            var result = false;
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdText = string.Format("insert into EmailCheckSets values(N'{0}', {1}, {2})", email, new Random().Next(), 0);
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    result = cmd.ExecuteNonQuery() > 0;
                    conn.Close();
                }
            }
            return result;
        }

        public static int GetEmailToken(string email)
        {
            var result = 0;
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdText = string.Format("select  Token from EmailCheckSets where Email = N'{0}'", email);
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    var status = cmd.ExecuteScalar();
                    if (status != null)
                    {
                        result = Convert.ToInt32(status);
                    }
                    conn.Close();
                }
            }
            return result;
        }

        public static bool IsEmailValid(string email)
        {
            var result = false;
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdText = string.Format("select  CheckStatus from EmailCheckSets where Email = N'{0}'", email);
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    var status = cmd.ExecuteScalar();
                    if (status != null)
                    {
                        result = Convert.ToBoolean(status);
                    }
                    conn.Close();
                }
            }
            return result;
        }

        public static bool SetEmailStatus(string email, int token)
        {
            var result = false;
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdText = string.Format("update EmailCheckSets set CheckStatus = 1 where Email = N'{0}' and Token = {1}", email, token);
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    result = cmd.ExecuteNonQuery() > 0;
                    conn.Close();
                }
            }
            return result;
        }

        public static int GetEmailCheckStatus(string email)
        {
            var result = 0;
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdText = string.Format("select CheckStatus from EmailCheckSets where Email = N'{0}'", email);
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    var val = cmd.ExecuteScalar();
                    result = Convert.ToInt32(val == null ? 0 : val);
                    conn.Close();
                }
            }

            return result;
        }

        public static int ForgotPasswordApply(ForgotPasswordView model)
        {
            var result = 0;
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdText = string.Format("insert into ForgotPassword values(N'{0}', N'{1}', N'{2}', N'{3}', N'{4}', {5}, '{6}')", model.Email, model.UserName, model.Sex, model.Nick, model.Tel, 0, DateTime.Now);
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    result = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            return result;
        }

        public static int DeleteForgotPassword(int id)
        {
            var result = 0;
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdText = string.Format("delete from ForgotPassword where Id = {0}", id);
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    result = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            return result;
        }

        private static ForgotPasswordView SqlReaderForgotPassword(SqlDataReader reader)
        {
            var model = new ForgotPasswordView();
            model.Id = Convert.ToInt32(reader.GetValue(0));
            model.Email = Convert.ToString(reader.GetValue(1));
            model.UserName = Convert.ToString(reader.GetValue(2));
            model.Sex = Convert.ToString(reader.GetValue(3));
            model.Nick = Convert.ToString(reader.GetValue(4));
            model.Tel = Convert.ToString(reader.GetValue(5));
            model.Status = Convert.ToInt32(reader.GetValue(6));
            model.Date = Convert.ToDateTime(reader.GetValue(7));
            return model;
        }

        public static List<ForgotPasswordView> GetForgotPasswordList()
        {
            var result = new List<ForgotPasswordView>();
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdText = string.Format("select * from ForgotPassword");
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        result.Add(SqlReaderForgotPassword(reader));
                    }
                }
            }
            return result;
        }

        public static ForgotPasswordView GetForgotPasswordById(int id)
        {
            var result = new ForgotPasswordView();
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdText = string.Format("select * from ForgotPassword");
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        result = SqlReaderForgotPassword(reader);
                    }
                }
            }

            return result;
        }

        public static int UpdateForgotPasswordStatus(int id, int status)
        {
            var result = 0;
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdText = string.Format("update ForgotPassword set Stat = {1} where Id = {0}", id, status);
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    result = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            return result;
        }

        public static bool DeleteUser(string email)
        {
            var result = false;
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdText = string.Format(@"delete from PostReplyMsg where Email = N'{0}'
                                              delete from PostReply where Email = N'{0}'
                                              delete from PostMsg where Email = N'{0}'
                                              delete from LeaveMsg where Email = N'{0}'
                                              delete from GoodsSets where Seller = N'{0}' or Buyer = N'{0}'
                                              delete from TeacherCommentSets where Email = N'{0}'
                                              delete from CourseCommentSets where Email = N'{0}'
                                              delete from tmp_CourseSets where CommitUser = N'{0}'
                                              delete from ExtraUserInfo where Email = N'{0}'
                                              delete from UserSets where Email = N'{0}'", email);
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