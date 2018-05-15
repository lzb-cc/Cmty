using Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Admin.Controllers
{
    public class TeacherController : AuthorityController
    {
        // GET: Teacher
        public ActionResult Index()
        {
            var list = new List<TeacherViewModels>();
            var retList = teacherClient.GetTeacherInfoList();
            foreach (var item in retList)
            {
                var user = new TeacherViewModels()
                {
                    Desp = item.Desp,
                    Email = item.Email,
                    JobTitle = utilityClient.NameOfJobTitle(item.JobTitle),
                    RegistDate = item.RegisteDate.ToString(),
                    Sex = item.Sex,
                    Tel = item.Tel,
                    University = utilityClient.NameOfUniversity(item.University),
                    UserName = item.UserName
                    
                };
                list.Add(user);
            }
            return View(list);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TeacherViewModels model)
        {
            var user = new TeacherService.TeacherInfoView()
            {
                Desp = model.Desp,
                Email = model.Email,
                JobTitle = utilityClient.IndexOfJobTitle(model.JobTitle),
                RegisteDate = Convert.ToDateTime(model.RegistDate),
                Sex = model.Sex,
                Tel = model.Tel,
                University = utilityClient.IndexOfUniversity(model.University),
                UserName = model.UserName
            };
            var result = teacherClient.AddTeacherInfo(user);
            if (result != TeacherService.ReturnState.ReturnOK)
            {
                AddErrors("添加失败，请重试!");
                return View(model);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(string email)
        {
            var model = teacherClient.GetTeacherInfo(email);
            var user = new TeacherViewModels()
            {
                Desp = model.Desp,
                Email = model.Email,
                JobTitle = utilityClient.NameOfJobTitle(model.JobTitle),
                RegistDate = model.RegisteDate.ToString(),
                Sex = model.Sex,
                Tel = model.Tel,
                University = utilityClient.NameOfUniversity(model.University),
                UserName = model.UserName
            };
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(TeacherViewModels model)
        {
            var user = new TeacherService.TeacherInfoView()
            {
                Desp = model.Desp,
                Email = model.Email,
                JobTitle = utilityClient.IndexOfJobTitle(model.JobTitle),
                RegisteDate = Convert.ToDateTime(model.RegistDate),
                Sex = model.Sex,
                Tel = model.Tel,
                University = utilityClient.IndexOfUniversity(model.University),
                UserName = model.UserName
            };
            var result = teacherClient.UpdateTeacherrInfo(user);
            if (result != TeacherService.ReturnState.ReturnOK)
            {
                AddErrors("修改失败，请重试!");
                return View(model);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Detail(string email)
        {
            var model = teacherClient.GetTeacherInfo(email);
            var user = new TeacherViewModels()
            {
                Desp = model.Desp,
                Email = model.Email,
                JobTitle = utilityClient.NameOfJobTitle(model.JobTitle),
                RegistDate = model.RegisteDate.ToString(),
                Sex = model.Sex,
                Tel = model.Tel,
                University = utilityClient.NameOfUniversity(model.University),
                UserName = model.UserName
            };
            return View(user);
        }

        public ActionResult Delete(string email)
        {
            var result = teacherClient.RemoveTeacherInfo(email);
            if (result != TeacherService.ReturnState.ReturnOK)
            {
                AddErrors("删除失败，请重试!");
            }
            return RedirectToAction("Index");
        }
    }
}