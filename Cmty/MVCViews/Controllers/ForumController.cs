using Microsoft.AspNet.Identity;
using MVCViews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCViews.Controllers
{
    public class ForumController : AuthorityController
    {
        // GET: Forum
        public ActionResult Index()
        {
            var list = new List<PostViewModel>();
            var retList = forumClient.GetPostList();
            foreach (var item in retList)
            {
                list.Add(new PostViewModel(item));
            }

            return View(list);
        }

        [HttpGet]
        public ActionResult AddPost()
        {
            if (!Authority())
            {
                return _authorityResult;
            }

            return View();
        }

        [HttpPost]
        public ActionResult AddPost(PostViewModel model)
        {
            if (!Authority())
            {
                return _authorityResult;
            }

            var post = new ForumService.PostModel()
            {
                Poster = Request.Cookies.Get(DefaultAuthenticationTypes.ApplicationCookie).Value,
                Content = model.Content,
                NoComments = Convert.ToInt32(model.NoComments),
                PostType = model.PostType,
                PublishDate = DateTime.Now,
                Title = model.Title
            };
            forumClient.AddPost(post);

            return RedirectToAction("Index");
        }

        public ActionResult MyPostCenter()
        {
            if (!Authority())
            {
                return _authorityResult;
            }
            var poster = Request.Cookies.Get(DefaultAuthenticationTypes.ApplicationCookie).Value;

            var list = new List<PostViewModel>();
            var retList = forumClient.GetPostListByPoster(poster);
            foreach (var item in retList)
            {
                list.Add(new PostViewModel(item));
            }

            return View(list);
        }

        [HttpGet]
        public ActionResult PostDetails(int id)
        {
            var model = new PostViewModel(forumClient.GetPostById(id));
            ViewBag.ReplyList = forumClient.GetPostReplyListByPostId(id);

            return View(model);
        }

        [HttpGet]
        public ActionResult PostReplyDetails(int id)
        {
            var model = new PostReplyViewModel(forumClient.GetPostReplyById(id));
            ViewBag.ResponseList = forumClient.GetReplyResponseListByPostId(id);

            return View(model);
        }

        [HttpGet]
        public ActionResult PostEdit(int id)
        {
            if (!Authority())
            {
                return _authorityResult;
            }

            var model = new PostViewModel(forumClient.GetPostById(id));
            return View(model);
        }

        [HttpPost]
        public JsonResult PostEdit(PostViewModel model)
        {
            var ret = new PostOperatorRep()
            {
                Status = 0,
                Message = @"更新成功!"
            };

            var post = new ForumService.PostModel()
            {
                Id = model.Id,
                Content = model.Content,
                NoComments =Convert.ToInt32(model.NoComments),
                PostType = model.PostType,
                Title = model.Title
            };

            forumClient.UpdatePost(post);

            return Json(ret);
        }

        [HttpPost]
        public JsonResult PostDel(int id)
        {
            var ret = new PostOperatorRep()
            {
                Status = 0,
                Message = "删除成功!"
            };

            forumClient.DelPost(id);

            return Json(ret);
        }

        [HttpPost]
        public JsonResult AddResponseToPost(int postId, string content)
        {
            var ret = new PostOperatorRep()
            {
                Status = 0,
                Message = "跟帖成功!",
            };

            if (!Authority())
            {
                ret.Status = 1;
                ret.Message = "跟帖失败,请登录!";
                return Json(ret);
            }

            if(forumClient.GetPostById(postId).NoComments > 0)
            {
                ret.Status = 2;
                ret.Message = "跟帖失败,贴住禁止回帖!";
                return Json(ret);
            }

            var model = new ForumService.PostReplyModel();
            model.Responser = Request.Cookies.Get(DefaultAuthenticationTypes.ApplicationCookie).Value;
            model.ResponseTo = postId;
            model.Content = content;
            forumClient.AddResponseToPost(model);

            return Json(ret);
        }

        [HttpPost]
        public JsonResult AddResponseToPostReply(int replyId, string content)
        {
            var ret = new PostOperatorRep()
            {
                Status = 0,
                Message = "跟帖成功!",
            };

            if (!Authority())
            {
                ret.Status = 1;
                ret.Message = "跟帖失败,请登录!";
                return Json(ret);
            }


            var model = new ForumService.PostReplyModel();
            model.Responser = Request.Cookies.Get(DefaultAuthenticationTypes.ApplicationCookie).Value;
            model.ResponseTo = replyId;
            model.Content = content;
            forumClient.AddResponseToPostReply(model);

            return Json(ret);
        }

        [HttpPost]
        public JsonResult RemoveResponseReply(int id)
        {
            var ret = new PostOperatorRep()
            {
                Status = 0,
                Message = "删除成功!",
            };
            forumClient.DelResponseToPostById(id);

            return Json(ret);
        }

        public JsonResult RemoveResponseReplyMsg(int id)
        {
            var ret = new PostOperatorRep()
            {
                Status = 0,
                Message = "删除成功!",
            };
            forumClient.DelResponseToPostReplyById(id);

            return Json(ret);
        }
    }
}