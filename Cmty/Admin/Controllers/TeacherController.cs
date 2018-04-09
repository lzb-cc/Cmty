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
    }
}