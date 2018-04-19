using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCViews.Models
{
    public class GoodsInfoView
    {
        public GoodsInfoView()
        {
        }

        public GoodsInfoView(MarketService.GoodsInfo model)
        {
            this.Id = model.Id;
            this.Seller = model.Seller;
            this.Name = model.Name;
            this.Money = model.Money;
            this.PicUrl = model.PicUrl;
            this.Desp = model.Desp;
            this.AddDate = model.AddDate;
            this.Status = model.Status;
            this.Buyer = model.Buyer;
            this.Comments = model.Comments;
            this.Type = model.Type;
        }

        public int Id { get; set; }

        [Display(Name = "卖家")]
        public string Seller { get; set; }

        [Display(Name = "商品名称")]
        public string Name { get; set; }

        [Display(Name = "价格")]
        public int Money { get; set; }

        [Display(Name = "商品图片")]
        public string PicUrl { get; set; }

        [Display(Name = "商品描述")]
        public string Desp { get; set; }

        [Display(Name = "发布时间")]
        public DateTime AddDate { get; set; }

        [Display(Name=("状态"))]
        public string Status { get; set; }

        [Display(Name="买家")]
        public string Buyer { get; set; }

        [Display(Name="买家评论")]
        public string Comments { get; set; }

        [Display(Name = "商品类型")]
        public string Type { get; set; }
    }
}