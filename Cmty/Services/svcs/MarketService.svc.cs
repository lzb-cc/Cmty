using Services.cnts;
using Services.DAL.Market;
using System;
using System.Collections.Generic;
using CommonLib;

namespace Services.svcs
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“MarketService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 MarketService.svc 或 MarketService.svc.cs，然后开始调试。
    public class MarketService : IMarketService
    {
        public GoodsInfo GetGoodsInfoById(int id)
        {
            return MarketOperator.QueryGoodsInfoById(id);
        }

        public GoodsInfo GetGoodsInfoBySellerAndDate(string seller, DateTime date)
        {
            return MarketOperator.QueryGoodsInfoBySellerAndDate(seller, date);
        }

        public List<GoodsInfo> GetGoodsInfoListByBuyer(string buyer)
        {
            return MarketOperator.GetGoodsInfoListByBuyer(buyer);
        }

        public List<GoodsInfo> GetGoodsInfoListBySeller(string seller)
        {
            return MarketOperator.GetGoodsInfoListBySeller(seller);
        }

        public List<GoodsInfo> GetGoodsInfoOnSale()
        {
            return MarketOperator.GetGoodsInfoListBySaleStatus(3);
        }

        public List<GoodsInfo> GetGoodsInfoByStatus(string status)
        {
            return MarketOperator.GetGoodsInfoListBySaleStatus(MarketOperator.IndexOfSaleStatus(status));
        }

        public ReturnState UserAddGoods(GoodsInfo model)
        {
            return MarketOperator.UserAddGoods(model) ? ReturnState.ReturnOK : ReturnState.ReturnError;
        }

        public ReturnState SetGoodsInfoStatusById(int id, string status)
        {
            return MarketOperator.SetGoodsInfoStatusById(id, MarketOperator.IndexOfSaleStatus(status)) ? ReturnState.ReturnOK : ReturnState.ReturnError;
        }

        public List<GoodsInfo> GetAllGoodsInfo()
        {
            return MarketOperator.GetAllGoodsInfo();
        }

        public bool HasMember(GoodsInfo model)
        {
            return MarketOperator.HasMember(model);
        }
    }
}
