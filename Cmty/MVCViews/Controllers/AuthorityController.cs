﻿using Microsoft.AspNet.Identity;
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