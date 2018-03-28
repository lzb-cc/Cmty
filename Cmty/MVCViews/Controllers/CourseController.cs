using Microsoft.AspNet.Identity;
using MVCViews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCViews.Controllers
{
    public class CourseController : AuthorityController
    {
        // GET: Course
        public ActionResult Index(int page = 0)
        {
            var list = new List<CourseViewModels>();
            var array = courseClient.GetCourseByPage(page, 10);
            foreach (var item in array)
            {
                list.Add(new CourseViewModels()
                {
                    Code = item.Code,
                    Desp = item.Desp,
                    Name = item.Name,
                    PicUrl = item.PicUrl,
                    University = utilityClient.NameOfUniversity(item.University)
                });
            }

            return View(list);
        }

        public ActionResult IndexOfApply()
        {
            Authority();
            var list = new List<CourseReviewViewModels>();
            return View(list);
        }

        [HttpGet]
        public ActionResult ApplyForAddCourse()
        {
            Authority();
            return View();
        }

        [HttpPost]
        public ActionResult ApplyForAddCourse(CourseViewModels model)
        {
            Authority();
            if (courseClient.HasMember(model.Code))
            {
                ModelState.AddModelError("", "课程代码已存在!");
                return View(model);
            }
            
            var user = new CourseService.UserApply()
            {
                Email = Request.Cookies.Get(DefaultAuthenticationTypes.ApplicationCookie).Value,
                CommitDate = DateTime.Now,
                Status = 1
            };
            var course = new CourseService.CourseView()
            {
                Code = model.Code,
                Name = model.Name,
                Desp = model.Desp,
                PicUrl = model.PicUrl,
                University = utilityClient.IndexOfUniversity(model.University)
            };

            var result = courseClient.AddCourseApply(course, user);
            if (result == CommonLib.ReturnState.ReturnError)
            {
                ModelState.AddModelError("", "申请失败，请重试!");
                return View(model);
            }

            return RedirectToAction("IndexOfApply");
        }
    }
}