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
    }
}