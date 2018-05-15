using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Admin.Models;
using Admin.CourseService;

namespace Admin.Controllers
{
    public class CourseReviewController : AuthorityController
    {
        // GET: CourseReview
        public ActionResult Index()
        {
            var list = new List<CourseReviewViewModels>();
            var items = courseClient.GetCourseReviews();
            foreach (var item in items)
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
            if (result == ReturnState.ReturnError)
            {
                ModelState.AddModelError("", "添加失败，请重试!");
                return View(model);
            }

            return RedirectToAction("CourseCenter", new { page = 0 });
        }

        public ActionResult CourseCenter(int page)
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

        public ActionResult ReviewPass(string code)
        {
            courseClient.ReviewPass(code);
            return RedirectToAction("Index");
        }

        public ActionResult ReviewFailed(string code)
        {
            courseClient.ReviewFailed(code);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// 为课程添加授课教师
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public ActionResult Details(string code)
        {
            if (string.IsNullOrEmpty(code))
            {
                return RedirectToAction("CourseCenter", new { page = 0 });
            }

            var course = courseClient.GetCourseByCode(code);
            var model = new CourseViewModels()
            {
                Code = course.Code,
                Desp = course.Desp,
                Name = course.Name,
                PicUrl = course.PicUrl,
                University = utilityClient.NameOfUniversity(course.University)
            };

            //查询授课教师信息
            ViewBag.Emails = utilityClient.GetTeacherByCourseId(code);

            return View(model);
        }


        public ActionResult AddCourseTeacherMap(string code, string email)
        {
            if (!string.IsNullOrEmpty(code) && !string.IsNullOrEmpty(email))
            {
                utilityClient.AddTeacherCourseMap(email, code);
            }
            return RedirectToAction("Details", new { code = code });
        }

        public ActionResult DelCourseTeacherMap(string code, string email)
        {
            if (!string.IsNullOrEmpty(code) && !string.IsNullOrEmpty(email))
            {
                utilityClient.DelTeacherCourseMap(email, code);
            }
            return RedirectToAction("Details", new { code = code });
        }
    }
}