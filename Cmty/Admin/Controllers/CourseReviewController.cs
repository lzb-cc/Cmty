using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Admin.Models;

namespace Admin.Controllers
{
    public class CourseReviewController : Controller
    {
        private static CourseService.CourseServiceClient courseClient = new CourseService.CourseServiceClient();
        private static UtilityService.UtilityServiceClient utilityClient = new UtilityService.UtilityServiceClient();

        // GET: CourseReview
        public ActionResult Index()
        {
            var list = new List<CourseReviewViewModels>();
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
    }
}