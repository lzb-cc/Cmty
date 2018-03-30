using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Admin.Models;

namespace Admin.Controllers
{
    public class CourseReviewController : AuthorityController
    {
        // GET: CourseReview
        public ActionResult Index()
        {
            var list = new List<CourseReviewViewModels>();
            var items = courseClient.GetCourseReviews();
            foreach(var item in items)
            {
                var tmp = new CourseReviewViewModels()
                {
                    Code = item.Code,
                    CommitDate = item.CommitDate,
                    CommitUser = item.Email,
                    Desp = item.Desp,
                    Name = item.Name,
                    PicUrl = item.PicUrl,
                    Status = item.Status,
                    University = item.University
                };
                list.Add(tmp);
            }
            return View(list);
        }

        /// <summary>
        /// 添加新课程
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CourseViewModels model)
        {
            var course = new CourseService.CourseView()
            {
                Code = model.Code,
                Name = model.Name,
                Desp = model.Desp,
                PicUrl = model.PicUrl,
            };

            if ((course.University = utilityClient.IndexOfUniversity(model.University)) <= 0)
            {
                ModelState.AddModelError("", "Code已存在!");
                return View(model);
            }

            var result = courseClient.AddCourse(course);
            if (result == CommonLib.ReturnState.ReturnError)
            {
                ModelState.AddModelError("", "添加失败，请重试!");
                return View(model);
            }

            return RedirectToAction("CourseCenter");
        }

        public ActionResult CourseCenter(int page)
        {
            var list = new List<CourseViewModels>();
            var array = courseClient.GetCourseByPage(page, 10);
            foreach(var item in array)
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

        public ActionResult ReviewPass(string code)
        {
            courseClient.ReviewPass(code);
            return RedirectToAction("Index");
        }

        public ActionResult ReviewFailed(string code)
        {
            return RedirectToAction("Index");
        }
    }
}