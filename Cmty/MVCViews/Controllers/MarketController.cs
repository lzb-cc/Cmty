using Microsoft.AspNet.Identity;
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

        public ActionResult MyCenter()
        {
            if (!Authority())
            {
                return _authorityResult;
            }

            // get goods info
            var seller = Request.Cookies.Get(DefaultAuthenticationTypes.ApplicationCookie).Value;
            var retList = marketClient.GetGoodsInfoListBySeller(seller);
            var list = new List<GoodsInfoView>();
            foreach(var item in retList)
            {
                list.Add(new GoodsInfoView(item));
            }

            // ret
            return View(list);
        }

        public ActionResult MyPayList()
        {
            if (!Authority())
            {
                return _authorityResult;
            }

            // get goods info
            var buyer = Request.Cookies.Get(DefaultAuthenticationTypes.ApplicationCookie).Value;
            var retList = marketClient.GetGoodsInfoListByBuyer(buyer);
            var list = new List<GoodsInfoView>();
            foreach (var item in retList)
            {
                list.Add(new GoodsInfoView(item));
            }

            // ret
            return View(list);
        }
    }
}