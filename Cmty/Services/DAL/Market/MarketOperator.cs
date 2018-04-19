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

        public static GoodsInfo QueryGoodsInfoBySellerAndDate(string seller, DateTime date)
        {
            var result = new GoodsInfo();
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
                        result.Id = Convert.ToInt32(reader.GetValue(0));
                        result.Seller = Convert.ToString(reader.GetValue(1));
                        result.Name = Convert.ToString(reader.GetValue(2));
                        result.Money = Convert.ToInt32(reader.GetValue(3));
                        result.PicUrl = Convert.ToString(reader.GetValue(4));
                        result.Desp = Convert.ToString(reader.GetValue(5));
                        result.AddDate = Convert.ToDateTime(reader.GetValue(6));
                        result.Status = NameOfSaleStatus(Convert.ToInt32(reader.GetValue(7)));
                        result.Buyer = Convert.ToString(reader.GetValue(8));
                        result.Comments = Convert.ToString(reader.GetValue(9));
                        result.Type = NameOfGoodsType(Convert.ToInt32(reader.GetValue(10)));
                    }
                    conn.Close();
                }
            }

            return result;
        }
        
        public static GoodsInfo QueryGoodsInfoById(int id)
        {
            var result = new GoodsInfo();
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
                        result.Id = Convert.ToInt32(reader.GetValue(0));
                        result.Seller = Convert.ToString(reader.GetValue(1));
                        result.Name = Convert.ToString(reader.GetValue(2));
                        result.Money = Convert.ToInt32(reader.GetValue(3));
                        result.PicUrl = Convert.ToString(reader.GetValue(4));
                        result.Desp = Convert.ToString(reader.GetValue(5));
                        result.AddDate = Convert.ToDateTime(reader.GetValue(6));
                        result.Status = NameOfSaleStatus(Convert.ToInt32(reader.GetValue(7)));
                        result.Buyer = Convert.ToString(reader.GetValue(8));
                        result.Comments = Convert.ToString(reader.GetValue(9));
                        result.Type = NameOfGoodsType(Convert.ToInt32(reader.GetValue(10)));
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
                        result.Add(model);
                    }
                    conn.Close();
                }
            }

            return result;
        }
    }
}