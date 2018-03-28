using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCViews.Controllers
{
    public class AuthorityController : Controller
    {
        protected static AccountService.AccountServiceClient accountClient = new AccountService.AccountServiceClient();
        protected static UtilityService.UtilityServiceClient utilityClient = new UtilityService.UtilityServiceClient();
        protected static CourseService.CourseServiceClient courseClient = new CourseService.CourseServiceClient();
        protected static HttpCookie _cookie = new HttpCookie(DefaultAuthenticationTypes.ApplicationCookie);

        public AuthorityController()
        {
            
        }

        protected void Authority()
        {
            var tmpCookie = Request.Cookies.Get(_cookie.Name);
            if (tmpCookie == null)
            {
                RedirectToAction("Login", "Account").ExecuteResult(this.ControllerContext);
                return;
            }

            var exist = accountClient.HasMember(tmpCookie.Value);
            if (!exist)
            {
                RedirectToAction("Register", "Account").ExecuteResult(this.ControllerContext);
            }
        }
    }
}