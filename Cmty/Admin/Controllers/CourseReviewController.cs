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
        // GET: CourseReview
        public ActionResult Index()
        {
            List<CourseReviewViewModels> list = new List<CourseReviewViewModels>();
            return View(list);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CourseViewModels model)
        {
            return RedirectToAction("CourseCenter");
        }
    }
}