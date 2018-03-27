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
            List<CourseReviewViewModels> list = new List<CourseReviewViewModels>();
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

        public ActionResult CourseCenter()
        {
            var list = new List<CourseViewModels>();
            return View(list);
        }
    }
}