using Microsoft.AspNet.Identity;
using MVCViews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCViews.Controllers
{
    public class TeacherController : AuthorityController
    {
        // GET: Teacher
        public ActionResult Index()
        {
            var retList = teacherClient.GetTeacherInfoList();
            var list = new List<TeacherViewModels>();
            foreach (var item in  retList)
            {
                var user = new TeacherViewModels()
                {
                    Desp = item.Desp,
                    Email = item.Email,
                    JobTitle = utilityClient.NameOfJobTitle(item.JobTitle),
                    RegistDate = item.RegisteDate.ToString(),
                    Sex = item.Sex,
                    University = utilityClient.NameOfUniversity(item.University),
                    UserName = item.UserName
                };
                list.Add(user);
            }
            return View(list);
        }

        public ActionResult Details(string email)
        {
            var info = teacherClient.GetTeacherInfo(email);
            var model = new TeacherViewModels()
            {
                Desp = info.Desp,
                Email = info.Email,
                JobTitle = utilityClient.NameOfJobTitle(info.JobTitle),
                RegistDate = info.RegisteDate.ToString(),
                Sex = info.Sex,
                University = utilityClient.NameOfUniversity(info.University),
                UserName = info.UserName
            };

            var courses = utilityClient.GetCourseIdByTeacher(email);
            var courseList = new List<string>();
            foreach(var item in courses)
            {
                courseList.Add(utilityClient.NameOfCourse(item));
            }

            ViewBag.Courses = courseList;
            ViewBag.CmtList = teacherClient.GetCommentByEmail(email);

            // 查询评论
            ViewBag.CmtList = new List<TeacherCommentViewModel>();
            var retList = teacherClient.GetCommentByEmail(email);
            foreach (var item in retList)
            {
                var tmp = new TeacherCommentViewModel(item);
                var userInfo = accountClient.GetUserInfo(item.Email);
                tmp.UserAvatar = string.IsNullOrEmpty(userInfo.Avatar) ? "00.jpg" : userInfo.Avatar;
                tmp.UserName = string.IsNullOrEmpty(userInfo.Nick) ? userInfo.UserName : userInfo.Nick;
                tmp.UserEmail = item.Email;
                ViewBag.CmtList.Add(tmp);
            }

            return View(model);
        }

        [HttpPost]
        public JsonResult MakeComment(string email, string content)
        {
            var ret = new CourseOperatorResp
            {
                Status = 0,
                Msg = "评论成功！"
            };

            if (!Authority())
            {
                ret.Status = 1;
                ret.Msg = @"请先登录！";
                return Json(ret);
            }

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(content))
            {
                ret.Status = 2;
                ret.Msg = @"";
                return Json(ret);
            }

            var model = new TeacherService.TeacherCommentView()
            {
                Teacher = email,
                Content = content,
                Email = Request.Cookies.Get(DefaultAuthenticationTypes.ApplicationCookie).Value,
                PubDate = DateTime.Now,
                Floor = teacherClient.GetValidFloor(email)
            };
            teacherClient.AddComment(model);
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

            teacherClient.RemoveTeacherCommnetById(id);
            return Json(ret);
        }
    }
}