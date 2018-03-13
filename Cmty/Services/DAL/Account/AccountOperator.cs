using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using CommonLib;
using System.Data.SqlClient;

namespace Services.DAL.Account
{
    public class AccountOperator
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public static ReturnState Register(RegisterView model)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdText = string.Format("insert into UserSets(Email, Pwd, uType, uName, rDate, Tel) values (N'{0}', N'{1}', {2}, N'{3}', '{4}', N'{5}')", model.Email, model.Password, model.UserType, model.UserName, DateTime.Now, model.Tel);
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
    }
}