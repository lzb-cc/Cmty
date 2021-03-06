﻿using Microsoft.AspNet.Identity;
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
            foreach (var item in retList)
            {
                list.Add(new GoodsInfoView(item));
            }

            return View(list);
        }

        [HttpPost]
        public ActionResult Index(string filter, string findStr)
        {
            var list = new List<GoodsInfoView>();
            if (string.IsNullOrEmpty(filter))
            {
                return View(list);
            }

            var retList = marketClient.GetGoodsInfoListByNameAndDesp(filter, findStr);
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
            foreach (var item in retList)
            {
                if (item.Status.Equals("删除记录"))
                {
                    continue;
                }

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

            var goodsTypeList = marketClient.GetGoodsInfoTypeList();
            var goodsItemList = new List<SelectListItem>();
            foreach(var item in goodsTypeList)
            {
                goodsItemList.Add(new SelectListItem() { Text = item });
            }

            ViewData["GoodsItemList"] = goodsItemList;
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
            
            if(string.IsNullOrEmpty(good.PicUrl))
            {
                good.PicUrl = "00.jpg"; //default.
            }

            marketClient.UserAddGoods(good);

            // ret
            return RedirectToAction("MyCenter");
        }

        public ActionResult Details(int id = -1)
        {
            if (id == -1)
            {
                return RedirectToAction("Index");
            }

            var model = new GoodsInfoView(marketClient.GetGoodsInfoById(id));

            ViewBag.LeaveMsgs = marketClient.GetLeaveMsgListByGid(id);
            return View(model);
        }

        public ActionResult Buy(int id)
        {
            if (!Authority())
            {
                return _authorityResult;
            }

            var email = Request.Cookies.Get(DefaultAuthenticationTypes.ApplicationCookie).Value;
            var goods = marketClient.GetGoodsInfoById(id);

            return View(new GoodsInfoView(goods));
        }

        [HttpPost]
        public JsonResult ConfirmBuy(int id)
        {
            var ret = new MarketOperatorResp()
            {
                Status = 0,
                Msg = @"已经给卖家发送邮件，请稍等卖家联系!"
            };

            if (!Authority())
            {
                ret.Status = 1;
                ret.Msg = @"请先登录!";
                return Json(ret);
            }

            var buyer = Request.Cookies.Get(DefaultAuthenticationTypes.ApplicationCookie).Value;
            if (marketClient.GetGoodsInfoById(id).Seller.Equals(buyer))
            {
                ret.Status = 2;
                ret.Msg = @"不能购买自己的商品！";
                return Json(ret);
            }

            marketClient.SetGoodsInfoSaleStatusAndBuyerById(id, @"等待收货", buyer);

            return Json(ret);
        }

        [HttpPost]
        public JsonResult DeleteShoppingRecords(int id)
        {
            var ret = new MarketOperatorResp()
            {
                Status = 0,
                Msg = @"删除成功!"
            };

            if (!Authority())
            {
                ret.Status = 1;
                ret.Msg = @"请先登录!";
                return Json(ret);
            }

            marketClient.SetGoodsInfoStatusById(id, @"删除记录");
            return Json(ret);
        }

        [HttpPost]
        public JsonResult GoodsDropOff(int id)
        {
            var ret = new MarketOperatorResp()
            {
                Status = 0,
                Msg = @"下架成功"
            };

            if (!Authority())
            {
                ret.Status = 1;
                ret.Msg = @"请先登录!";
                return Json(ret);
            }

            marketClient.SetGoodsInfoStatusById(id, @"下架");
            return Json(ret);
        }

        [HttpGet]
        public ActionResult ShoppingRecordsDetails(int id)
        {
            if (!Authority())
            {
                return _authorityResult;
            }

            var model = new GoodsInfoView(marketClient.GetGoodsInfoById(id));
            return View(model);
        }

        [HttpPost]
        public JsonResult SendMsg(int id, string content)
        {
            var ret = new MarketOperatorResp
            {
                Status = 0,
                Msg = @"留言成功!"
            };

            if (!Authority())
            {
                ret.Status = 1;
                ret.Msg = @"请先登录!";
                return Json(ret);
            }

            var model = new MarketService.LeaveMsgModel();
            model.Email = Request.Cookies.Get(DefaultAuthenticationTypes.ApplicationCookie).Value;
            model.Gid = id;
            model.Content = content;
            marketClient.AddLeaveMsg(model);
            return Json(ret);
        }

        [HttpPost]
        public JsonResult DropMsg(int id)
        {
            var ret = new MarketOperatorResp
            {
                Status = 0, 
                Msg = @"撤销成功!"
            };

            if (!Authority())
            {
                ret.Status = 1;
                ret.Msg = @"请先登录！";
                return Json(ret);
            }

            marketClient.DelLeaveMsgById(id);
            return Json(ret);
        }

        [HttpPost]
        public JsonResult AddGoodsComments(int id, string content)
        {
            var ret = new MarketOperatorResp
            {
                Status = 0,
                Msg = @"评论成功!"
            };

            if(!Authority())
            {
                ret.Status = 1;
                ret.Msg = @"请先登录!";
                return Json(ret);
            }

            marketClient.AddGoodsCommentById(id, content);
            return Json(ret);
        }
    }
}