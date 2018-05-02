using Services.cnts;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Services.DAL.Market
{
    public class MarketOperator
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public static string NameOfSaleStatus(int id)
        {
            var result = string.Empty;
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdText = string.Format("select Desp from cfg_SaleStatus where Id = {0}", id);
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    var dbRet = cmd.ExecuteScalar();
                    result = DBNull.Value.Equals(dbRet) ? string.Empty : Convert.ToString(dbRet);
                    conn.Close();
                }
            }
            return result;
        }

        public static int IndexOfSaleStatus(string name)
        {
            var result = 0;
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdText = string.Format("select Id from cfg_SaleStatus where Desp = N'{0}'", name);
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    var dbRet = cmd.ExecuteScalar();
                    result = DBNull.Value.Equals(dbRet) ? 1 : Convert.ToInt32(dbRet);
                    conn.Close();
                }
            }
            return result;
        }

        public static string NameOfGoodsType(int id)
        {
            var result = string.Empty;
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdText = string.Format("select Desp from cfg_GoodsType where Id = {0}", id);
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    var dbRet = cmd.ExecuteScalar();
                    result = DBNull.Value.Equals(dbRet) ? string.Empty : Convert.ToString(dbRet);
                    conn.Close();
                }
            }
            return result;
        }

        public static int IndexOfGoodsType(string name)
        {
            var result = 0;
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdText = string.Format("select Id from cfg_GoodsType where Desp = N'{0}'", name);
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    var dbRet = cmd.ExecuteScalar();
                    result = DBNull.Value.Equals(dbRet) ? 1 : Convert.ToInt32(dbRet);
                    conn.Close();
                }
            }
            return result;
        }

        public static bool UserAddGoods(GoodsInfo model)
        {
            var result = false;
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdText = string.Format("insert into GoodsSets values (N'{0}', N'{1}', {2}, N'{3}', N'{4}', '{5}', {6}, N'{7}', N'{8}', {9})", model.Seller, model.Name, model.Money, model.PicUrl, model.Desp, model.AddDate, IndexOfSaleStatus(model.Status), model.Buyer, model.Comments, IndexOfGoodsType(model.Type));
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    result = cmd.ExecuteNonQuery() > 0;
                    conn.Close();
                }
            }

            return result;
        }

        public static bool UpdateGoodsInfoCommentById(int id, string content)
        {
            var result = false;
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdText = string.Format("update GoodsSets set Comment = N'{1}' where id = {0}", id, content);
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    result = cmd.ExecuteNonQuery() > 0;
                    conn.Close();
                }
            }

            return result;
        }

        public static GoodsInfo SqlReaderGoodsInfo(SqlDataReader reader)
        {
            var model = new GoodsInfo();
            model.Id = Convert.ToInt32(reader.GetValue(0));
            model.Seller = Convert.ToString(reader.GetValue(1));
            model.Name = Convert.ToString(reader.GetValue(2));
            model.Money = Convert.ToInt32(reader.GetValue(3));
            model.PicUrl = Convert.ToString(reader.GetValue(4));
            model.Desp = Convert.ToString(reader.GetValue(5));
            model.AddDate = Convert.ToDateTime(reader.GetValue(6));
            model.Status = NameOfSaleStatus(Convert.ToInt32(reader.GetValue(7)));
            model.Buyer = Convert.ToString(reader.GetValue(8));
            model.Comments = Convert.ToString(reader.GetValue(9));
            model.Type = NameOfGoodsType(Convert.ToInt32(reader.GetValue(10)));

            return model;
        }

        public static GoodsInfo QueryGoodsInfoBySellerAndDate(string seller, DateTime date)
        {
            GoodsInfo result = null;
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdText = string.Format("select * from GoodsSets where Seller = N'{0}' and PubDate = '{1}'", seller, date);
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    var reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        result = SqlReaderGoodsInfo(reader);
                    }
                    conn.Close();
                }
            }

            return result;
        }

        public static GoodsInfo QueryGoodsInfoById(int id)
        {
            GoodsInfo result = null;
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdText = string.Format("select * from GoodsSets where Id = {0}", id);
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    var reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        result = SqlReaderGoodsInfo(reader);
                    }
                    conn.Close();
                }
            }

            return result;
        }

        public static List<GoodsInfo> GetGoodsInfoListBySeller(string seller)
        {
            var result = new List<GoodsInfo>();
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdText = string.Format("select * from GoodsSets where Seller = N'{0}'", seller);
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var model = SqlReaderGoodsInfo(reader);
                        result.Add(model);
                    }
                    conn.Close();
                }
            }

            return result;
        }

        public static List<GoodsInfo> GetGoodsInfoListByBuyer(string buyer)
        {
            var result = new List<GoodsInfo>();
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdText = string.Format("select * from GoodsSets where Buyer = N'{0}'", buyer);
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var model = SqlReaderGoodsInfo(reader);
                        result.Add(model);
                    }
                    conn.Close();
                }
            }

            return result;
        }

        public static List<GoodsInfo> GetGoodsInfoListBySaleStatus(int status)
        {
            var result = new List<GoodsInfo>();
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdText = string.Format("select * from GoodsSets where SStatus = {0}", status);
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var model = SqlReaderGoodsInfo(reader);
                        result.Add(model);
                    }
                    conn.Close();
                }
            }

            return result;
        }

        public static bool SetGoodsInfoStatusById(int id, int status)
        {
            var result = false;
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdText = string.Format("update GoodsSets set SStatus = {1} where Id = {0}", id, status);
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    result = cmd.ExecuteNonQuery() > 0;
                    conn.Close();
                }
            }

            return result;
        }

        public static List<string> GetGoodsInfoTypeList()
        {
            var result = new List<string>();
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdText = string.Format("select Desp from cfg_GoodsType");
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    var reader = cmd.ExecuteReader();
                    while(reader.Read())
                    {
                        result.Add(Convert.ToString(reader.GetValue(0)));
                    }
                }
            }
            return result;
        }

        public static bool HasMember(GoodsInfo model)
        {
            var result = false;
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdText = string.Format("select * from GoodsSets where Seller = N'{0}' and PubDate = '{1}'", model.Seller, model.AddDate);
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    result = cmd.ExecuteScalar() != null;
                    conn.Close();
                }
            }

            return result;
        }

        public static List<GoodsInfo> GetAllGoodsInfo()
        {
            var result = new List<GoodsInfo>();
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdText = string.Format("select * from GoodsSets");
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var model = SqlReaderGoodsInfo(reader);
                        result.Add(model);
                    }
                    conn.Close();
                }
            }

            return result;
        }

        public static bool SetGoodsInfoSaleStatusAndBuyerById(int id, int status, string buyer)
        {
            var result = false;
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdText = string.Format("update GoodsSets set SStatus = {1}, buyer = N'{2}' where Id = {0}", id, status, buyer);
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    result = cmd.ExecuteNonQuery() > 0;
                    conn.Close();
                }
            }

            return result;
        }

        public static bool RemoveGoodsInfoById(int id)
        {
            var result = false;
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdText = string.Format("delete from GoodsSets where Id = {0}", id);
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    result = cmd.ExecuteNonQuery() > 0;
                    conn.Close();
                }
            }

            return result;
        }

        public static bool AddLeaveMsg(LeaveMsgModel model)
        {
            var result = false;
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdText = string.Format("insert into LeaveMsg values({0}, N'{1}', '{2}', N'{3}', {4})", model.Gid, model.Email, DateTime.Now, model.Content, GetValidFloorByGid(model.Gid));
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    result = cmd.ExecuteNonQuery() > 0;
                    conn.Close();
                }
            }

            return result;
        }

        public static bool RemoveLeaveMsgById(int id)
        {
            var result = false;
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdText = string.Format("delete from LeaveMsg where Id = {0}", id);
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    result = cmd.ExecuteNonQuery() > 0;
                    conn.Close();
                }
            }

            return result;
        }

        public static int GetValidFloorByGid(int gid)
        {
            var result = 1;
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdText = string.Format("select max(LmFloor) from LeaveMsg where Gid = {0}", gid);
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    var val = cmd.ExecuteScalar();
                    result += Convert.ToInt32(DBNull.Value.Equals(val) ? 0 : val);
                    conn.Close();
                }
            }

            return result;
        }

        public static LeaveMsgModel SqlReaderLeaveMsg(SqlDataReader reader)
        {
            var model = new LeaveMsgModel();
            model.Id = Convert.ToInt32(reader.GetValue(0));
            model.Gid = Convert.ToInt32(reader.GetValue(1));
            model.Email = Convert.ToString(reader.GetValue(2));
            model.PubDate = Convert.ToDateTime(reader.GetValue(3));
            model.Content = Convert.ToString(reader.GetValue(4));
            model.Floor = Convert.ToInt32(reader.GetValue(5));
            return model;
        }

        public static List<LeaveMsgModel> QueryLeaveMsgListByGid(int gid)
        {
            var result = new List<LeaveMsgModel>();
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdText = string.Format("select * from LeaveMsg where Gid = {0}", gid);
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        result.Add(SqlReaderLeaveMsg(reader));
                    }
                    conn.Close();
                }
            }

            return result;
        }

        public static LeaveMsgModel QueryLeaveMsgById(int id)
        {
            LeaveMsgModel result = null;
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdText = string.Format("select * from LeaveMsg where Id = {0}", id);
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    var reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        result = SqlReaderLeaveMsg(reader);
                    }
                    conn.Close();
                }
            }

            return result;
        }
    }
}