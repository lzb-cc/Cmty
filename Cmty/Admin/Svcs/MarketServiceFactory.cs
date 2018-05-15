using Admin.MarketService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Admin.Svcs
{
    public class MarketServiceFactory
    {
        private static MarketService.MarketService marketClient = new MarketService.MarketService();
        private static bool specify = false;

        public ReturnState UserAddGoods(GoodsInfo model)
        {
            ReturnState result;
            marketClient.UserAddGoods(model, out result, out specify);
            return result;
        }

        public GoodsInfo GetGoodsInfoBySellerAndDate(string seller, DateTime date)
        {
            return marketClient.GetGoodsInfoBySellerAndDate(seller, date, specify);
        }

        public GoodsInfo GetGoodsInfoById(int id)
        {
            return marketClient.GetGoodsInfoById(id, true);
        }

        public GoodsInfo[] GetGoodsInfoListBySeller(string seller)
        {
            return marketClient.GetGoodsInfoListBySeller(seller);
        }

        public GoodsInfo[] GetGoodsInfoListByBuyer(string buyer)
        {
            return marketClient.GetGoodsInfoListByBuyer(buyer);
        }

        public GoodsInfo[] GetGoodsInfoOnSale()
        {
            return marketClient.GetGoodsInfoOnSale();
        }

        public GoodsInfo[] GetGoodsInfoByStatus(string status)
        {
            return marketClient.GetGoodsInfoByStatus(status);
        }

        public ReturnState SetGoodsInfoStatusById(int id, string status)
        {
            ReturnState result;
            marketClient.SetGoodsInfoStatusById(id, specify, status, out result, out specify);
            return result;
        }

        public GoodsInfo[] GetAllGoodsInfo()
        {
            return marketClient.GetAllGoodsInfo();
        }

        public ReturnState AddGoodsCommentById(int id, string content)
        {
            ReturnState result;
            marketClient.AddGoodsCommentById(id, specify, content, out result, out specify);
            return result;
        }

        public bool HasMember(GoodsInfo model)
        {
            bool result;
            marketClient.HasMember(model, out result, out specify);
            return result;
        }

        public ReturnState SetGoodsInfoSaleStatusAndBuyerById(int id, string staus, string buyer)
        {
            ReturnState result;
            marketClient.SetGoodsInfoSaleStatusAndBuyerById(id, specify, staus, buyer, out result, out specify);
            return result;
        }

        public ReturnState RemoveGoodsInfo(int id)
        {
            ReturnState result;
            marketClient.RemoveGoodsInfo(id, specify, out result, out specify);
            return result;
        }

        public ReturnState AddLeaveMsg(LeaveMsgModel model)
        {
            ReturnState result;
            marketClient.AddLeaveMsg(model, out result, out specify);
            return result;
        }

        public ReturnState DelLeaveMsgById(int id)
        {
            ReturnState result;
            marketClient.DelLeaveMsgById(id, specify, out result, out specify);
            return result;
        }

        public LeaveMsgModel GetLeaveMsgById(int id)
        {
            return marketClient.GetLeaveMsgById(id, specify);
        }

        public LeaveMsgModel[] GetLeaveMsgListByGid(int gid)
        {
            return marketClient.GetLeaveMsgListByGid(gid, specify);
        }

        public string[] GetGoodsInfoTypeList()
        {
            return marketClient.GetGoodsInfoTypeList();
        }

        public GoodsInfo[] GetGoodsInfoListByNameAndDesp(string filter, string findStr)
        {
            return marketClient.GetGoodsInfoListByNameAndDesp(filter, findStr);
        }
    }
}