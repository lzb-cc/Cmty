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
        GoodsInfo GetGoodsInfoBySellerAndDate(string seller, DateTime date);

        [OperationContract]
        GoodsInfo GetGoodsInfoById(int id);

        [OperationContract]
        List<GoodsInfo> GetGoodsInfoListBySeller(string seller);

        [OperationContract]
        List<GoodsInfo> GetGoodsInfoListByBuyer(string buyer);
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
}
