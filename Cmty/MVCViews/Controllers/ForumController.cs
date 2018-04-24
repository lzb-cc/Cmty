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
            foreach(var item in retList)
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
                NoComments = model.NoComments,
                PostType = model.PostType,
                PublishDate = model.PublishDate,
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
            var ret = new PostEditResp()
            {
                Status = 0,
                Message = @"更新成功"
            };

            var post = new ForumService.PostModel()
            {
                Id = model.Id,
                Content = model.Content,
                NoComments = model.NoComments,
                PostType = model.PostType,
                Title = model.Title
            };

            forumClient.UpdatePost(post);

            return Json(ret);
        }
    }
}