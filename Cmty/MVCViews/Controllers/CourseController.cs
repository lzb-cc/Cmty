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
        /// <summary>
        /// 课程主页
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
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

        public ActionResult Details(string code)
        {
            if (string.IsNullOrEmpty(code))
            {
                return RedirectToAction("Index", new { page = 0 });
            }

            var course = courseClient.GetCourseByCode(code);
            var model = new CourseViewModels()
            {
                Code = course.Code,
                Desp = course.Desp,
                Name = course.Name,
                PicUrl = course.PicUrl,
                University = utilityClient.NameOfUniversity(course.University),
            };

            var teacherList = utilityClient.GetTeacherByCourseId(code);
            var list = new List<string>();
            foreach(var item in teacherList)
            {
                list.Add(teacherClient.GetTeacherInfo(item).UserName);
            }
            ViewBag.Teacher = list;

            // 查询评论
            ViewBag.CmtList = new List<CourseCommentViewModel>();
            var retList = courseCommentClient.GetCommentByCode(code);
            foreach(var item in retList)
            {
                var tmp = new CourseCommentViewModel(item);
                var userInfo = accountClient.GetUserInfo(item.Email);
                tmp.UserAvatar = string.IsNullOrEmpty(userInfo.Avatar) ? "00.jpg" : userInfo.Avatar;
                tmp.UserName = string.IsNullOrEmpty(userInfo.Nick) ? userInfo.UserName : userInfo.Nick;
                tmp.UserEmail = item.Email;
                ViewBag.CmtList.Add(tmp);
            }
            
            return View(model);
        }

        /// <summary>
        /// 我的申请
        /// </summary>
        /// <returns></returns>
        public ActionResult IndexOfApply()
        {
            if(!Authority())
            {
                return _authorityResult;
            }
     
            var list = new List<CourseReviewViewModels>();
            var items = courseClient.GetCourseReviewViewByEmail(Request.Cookies.Get(_cookie.Name).Value);
            foreach(var item in items)
            {
                var course = new CourseReviewViewModels()
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
                list.Add(course);
            }
            return View(list);
        }

        /// <summary>
        /// 申请添加课程
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ApplyForAddCourse()
        {
            if(!Authority())
            {
                return _authorityResult;
            }

            return View();
        }

        [HttpPost]
        public ActionResult ApplyForAddCourse(CourseViewModels model)
        {
            if (!Authority())
            {
                return _authorityResult;
            }

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

            if (string.IsNullOrEmpty(course.PicUrl))
            {
                course.PicUrl = "00.jpg";
            }

            var result = courseClient.AddCourseApply(course, user);
            if (result == CommonLib.ReturnState.ReturnError)
            {
                ModelState.AddModelError("", "申请失败，请重试!");
                return View(model);
            }

            return RedirectToAction("IndexOfApply");
        }

        [HttpPost]
        public JsonResult MakeComment(string code, string content)
        {
            var ret = new CourseOperatorResp
            {
                Status = 0,
            };

            if (!Authority())
            {
                ret.Status = 1;
                ret.Msg = @"请先登录！";
                return Json(ret);
            }

            if (string.IsNullOrEmpty(code) || string.IsNullOrEmpty(content))
            {
                ret.Status = 2;
                ret.Msg = @"";
                return Json(ret);
            }

            var model = new CourseCommentService.CourseCommentView()
            {
                Code = code,
                Content = content,
                Email = Request.Cookies.Get(DefaultAuthenticationTypes.ApplicationCookie).Value,
                PubDate = DateTime.Now,
                Floor = courseCommentClient.GetValidFloor(code)
            };
            courseCommentClient.AddComment(model);
            return Json(ret);
        }

        [HttpPost]
        public JsonResult CommentCancel(int id)
        {
            var ret = new CourseOperatorResp
            {
                Status = 0,
                Msg = @"撤销成功!"
            };

            if (!Authority())
            {
                ret.Status = 1;
                ret.Msg = @"请先登录!";   
            }

            courseCommentClient.RemoveCommentById(id);
            return Json(ret);
        }
    }
}