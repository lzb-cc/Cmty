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
            var retList = marketClient.GetGoodsInfoByStatus(@"销售中");
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

        [HttpGet]
        public ActionResult AddGoods()
        {
            if (!Authority())
            {
                return _authorityResult;
            }

            return View();
        }

        [HttpPost]
        public ActionResult AddGoods(GoodsInfoView model)
        {
            if (!Authority())
            {
                return _authorityResult;
            }

            // edit model
            var good = new MarketService.GoodsInfo()
            {
                Seller = Request.Cookies.Get(DefaultAuthenticationTypes.ApplicationCookie).Value,
                AddDate = DateTime.Now,
                Buyer = string.Empty,
                Comments = string.Empty,
                Desp = model.Desp,
                Money = model.Money,
                Name = model.Name,
                PicUrl = model.PicUrl,
                Status = @"待审核",
                Type = model.Type
            };
            marketClient.UserAddGoods(good);

            // ret
            return RedirectToAction("MyCenter");
        }

        public ActionResult Details(int id)
        {
            var model = new GoodsInfoView(marketClient.GetGoodsInfoById(id));

            ViewBag.LeaveMsgs = new List<string>();
            return View(model);
        }
    }
}