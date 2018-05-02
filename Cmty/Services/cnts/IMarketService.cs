using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Services.cnts
{
    [ServiceContract]
    interface IMarketService
    {
        [OperationContract]
        CommonLib.ReturnState UserAddGoods(GoodsInfo model);

        [OperationContract]
        GoodsInfo GetGoodsInfoBySellerAndDate(string seller, DateTime date);

        [OperationContract]
        GoodsInfo GetGoodsInfoById(int id);

        [OperationContract]
        List<GoodsInfo> GetGoodsInfoListBySeller(string seller);

        [OperationContract]
        List<GoodsInfo> GetGoodsInfoListByBuyer(string buyer);

        [OperationContract]
        List<GoodsInfo> GetGoodsInfoOnSale();

        [OperationContract]
        List<GoodsInfo> GetGoodsInfoByStatus(string status);

        [OperationContract]
        CommonLib.ReturnState SetGoodsInfoStatusById(int id, string status);

        [OperationContract]
        List<GoodsInfo> GetAllGoodsInfo();

        [OperationContract]
        CommonLib.ReturnState AddGoodsCommentById(int id, string content);

        [OperationContract]
        bool HasMember(GoodsInfo model);

        [OperationContract]
        CommonLib.ReturnState SetGoodsInfoSaleStatusAndBuyerById(int id, string staus, string buyer);

        [OperationContract]
        CommonLib.ReturnState RemoveGoodsInfo(int id);

        [OperationContract]
        CommonLib.ReturnState AddLeaveMsg(LeaveMsgModel model);

        [OperationContract]
        CommonLib.ReturnState DelLeaveMsgById(int id);

        [OperationContract]
        LeaveMsgModel GetLeaveMsgById(int id);

        [OperationContract]
        List<LeaveMsgModel> GetLeaveMsgListByGid(int gid);

        [OperationContract]
        List<string> GetGoodsInfoTypeList();
    }

    [DataContract]
    public class GoodsInfo
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Seller { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int Money { get; set; }

        [DataMember]
        public string PicUrl { get; set; }

        [DataMember]
        public string Desp { get; set; }

        [DataMember]
        public DateTime AddDate { get; set; }

        [DataMember]
        public string Status { get; set; }

        [DataMember]
        public string Buyer { get; set; }

        [DataMember]
        public string Comments { get; set; }

        [DataMember]
        public string Type { get; set; }
    }

    [DataContract]
    public class LeaveMsgModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int Gid { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public DateTime PubDate { get; set; }

        [DataMember]
        public string Content { get; set; }

        [DataMember]
        public int Floor { get; set; }
    }
}
