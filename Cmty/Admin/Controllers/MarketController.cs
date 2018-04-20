using Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Admin.Controllers
{
    public class MarketController : AuthorityController
    {
        // GET: Market
        public ActionResult Index()
        {
            var list = new List<GoodsInfoView>();
            var retList = marketClient.GetGoodsInfoByStatus(@"待审核");
            foreach (var item in retList)
            {
                list.Add(new GoodsInfoView(item));
            }

            return View(list);
        }


        public ActionResult ReviewPass(int id)
        {
            marketClient.SetGoodsInfoStatusById(id, @"销售中");
            return RedirectToAction("Index");
        }

        public ActionResult ReviewFailed(int id)
        {
            marketClient.SetGoodsInfoStatusById(id, @"审核不通过");
            return RedirectToAction("Index");
        }

        public ActionResult AllInfo()
        {
            var list = new List<GoodsInfoView>();
            var retList = marketClient.GetAllGoodsInfo();
            foreach (var item in retList)
            {
                list.Add(new GoodsInfoView(item));
            }

            return View(list);
        }
    }
}