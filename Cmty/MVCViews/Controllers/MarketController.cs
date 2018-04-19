using MVCViews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCViews.Controllers
{
    public class MarketController : AuthorityController
    {
        // GET: Market
        public ActionResult Index()
        {
            var list = new List<GoodsInfoView>();
            var retList = marketClient.GetGoodsInfoOnSale();
            foreach(var item in retList)
            {
                list.Add(new GoodsInfoView(item));
            }


            return View(list);
        }
    }
}