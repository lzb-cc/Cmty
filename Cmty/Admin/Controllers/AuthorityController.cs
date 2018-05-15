using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Admin.Controllers
{
    public class AuthorityController : Controller
    {
        //protected static AccountService.AccountServiceClient accountClient = new AccountService.AccountServiceClient();
        //protected static UtilityService.UtilityServiceClient utilityClient = new UtilityService.UtilityServiceClient();
        //protected static CourseService.CourseServiceClient courseClient = new CourseService.CourseServiceClient();
        //protected static TeacherService.TeacherServiceClient teacherClient = new TeacherService.TeacherServiceClient();
        //protected static HttpCookie _cookie = new HttpCookie(DefaultAuthenticationTypes.ApplicationCookie);
        //protected static MarketService.MarketServiceClient marketClient = new MarketService.MarketServiceClient();
        //protected static ForumService.ForumServiceClient forumClient = new ForumService.ForumServiceClient();
        //protected ActionResult _authorityResult;

        protected static Svcs.AccountServiceFactory accountClient = new Svcs.AccountServiceFactory();
        protected static Svcs.UtilityServiceFactory utilityClient = new Svcs.UtilityServiceFactory();
        protected static Svcs.CourseServiceFactory courseClient = new Svcs.CourseServiceFactory();
        protected static Svcs.TeacherServiceFactory teacherClient = new Svcs.TeacherServiceFactory();
        protected static Svcs.CourseCommentServiceFactory courseCommentClient = new Svcs.CourseCommentServiceFactory();
        protected static Svcs.MarketServiceFactory marketClient = new Svcs.MarketServiceFactory();
        protected static Svcs.ForumServiceFactory forumClient = new Svcs.ForumServiceFactory();
        protected static HttpCookie _cookie = new HttpCookie(DefaultAuthenticationTypes.ApplicationCookie);
        protected ActionResult _authorityResult;

        public AuthorityController()
        {

        }

        protected bool Authority()
        {
            var tmpCookie = Request.Cookies.Get(_cookie.Name);
            if (tmpCookie == null)
            {
                _authorityResult = RedirectToAction("Login", "Account");
                return false;
            }

            var exist = accountClient.HasMember(tmpCookie.Value);
            if (!exist)
            {
                _authorityResult = RedirectToAction("Register", "Account");
                return false;
            }

            return true;
        }

        protected void AddErrors(string error)
        {
            ModelState.AddModelError("", error);
        }
    }
}