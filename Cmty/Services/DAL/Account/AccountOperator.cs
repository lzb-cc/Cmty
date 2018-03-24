using System;
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
                var cmdText = string.Format("insert into UserSets(Email, Pwd, uType, uName, rDate, Tel, University) values (N'{0}', N'{1}', {2}, N'{3}', '{4}', N'{5}', {6})", model.Email, model.Password, model.UserType, model.UserName, DateTime.Now, model.Tel, model.University);
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
    }
}