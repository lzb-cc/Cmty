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
    }
}