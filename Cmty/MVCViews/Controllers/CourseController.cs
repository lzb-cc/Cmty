using MVCViews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCViews.Controllers
{
    public class CourseController : Controller
    {
        private static CourseService.CourseServiceClient courseClient = new CourseService.CourseServiceClient();
        private static UtilityService.UtilityServiceClient utilityClient = new UtilityService.UtilityServiceClient();

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

        [HttpGet]
        public ActionResult ApplyForAddCourse()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ApplyForAddCourse(CourseViewModels model)
        {
            return View();
        }
    }
}