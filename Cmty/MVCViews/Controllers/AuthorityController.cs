using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCViews.Controllers
{
    public class AuthorityController : Controller
    {

        //protected static AccountServiceDebug.AccountServiceClient accountClient = new AccountServiceDebug.AccountServiceClient();
        //protected static UtilityServiceDebug.UtilityServiceClient utilityClient = new UtilityServiceDebug.UtilityServiceClient();
        //protected static CourseServiceDebug.CourseServiceClient courseClient = new CourseServiceDebug.CourseServiceClient();
        //protected static TeacherServiceDebug.TeacherServiceClient teacherClient = new TeacherServiceDebug.TeacherServiceClient();
        //protected static CourseCommentServiceDebug.CourseCommentServiceClient courseCommentClient = new CourseCommentServiceDebug.CourseCommentServiceClient();
        //protected static MarketServiceDebug.MarketServiceClient marketClient = new MarketServiceDebug.MarketServiceClient();
        //protected static ForumServiceDebug.ForumServiceClient forumClient = new ForumServiceDebug.ForumServiceClient();
        //protected static HttpCookie _cookie = new HttpCookie(DefaultAuthenticationTypes.ApplicationCookie);
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
                _authorityResult =  RedirectToAction("Login", "Account");
                return false;
            }

            var exist = accountClient.HasMember(tmpCookie.Value);
            if (!exist)
            {
                _authorityResult =  RedirectToAction("Register", "Account");
                return false;
            }

            return true;
        }
    }
}