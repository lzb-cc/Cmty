﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVCViews.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "电子邮件")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "代码")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "记住此浏览器?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "电子邮件")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "电子邮件")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "密码")]
        public string Password { get; set; }

        [Display(Name = "记住我?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "电子邮件")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} 必须至少包含 {2} 个字符。", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "密码")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "确认密码")]
        [Compare("Password", ErrorMessage = "密码和确认密码不匹配。")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "用户名")]
        public string UserName { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "电话号码")]
        public string Tel { get; set; }

        [Display(Name = "学校")]
        public string University { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "电子邮件")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} 必须至少包含 {2} 个字符。", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "密码")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "确认密码")]
        [Compare("Password", ErrorMessage = "密码和确认密码不匹配。")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "电子邮件")]
        public string Email { get; set; }
    }

    public class UserInfoViewModel
    {

        [Display(Name = "电子邮件")]
        public string Email { get; set; }

        [Display(Name = "用户名")]
        public string UserName { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "电话号码")]
        public string Tel { get; set; }

        [Display(Name = "学校")]
        public string University { get; set; }

        [Display(Name = "性别")]
        public string Sex { get; set; }

        [Display(Name = "昵称")]
        public string Nick { get; set; }

        [Display(Name = "兴趣爱好")]
        public string Hobby { get; set; }

        public string Avatar { get; set; }
    }

    public class ForgetPasswordViewModel
    {
        [Display(Name = "注册邮箱")]
        public string Email { get; set; }

        [Display(Name = "用户名")]
        public string UserName { get; set; }

        [Display(Name = "性别")]
        public string Sex { get; set; }

        [Display(Name = "昵称")]
        public string Nick { get; set; }

        [Display(Name = "联系方式")]
        public string Tel { get; set; }
    }

    public class ResetPasswordView
    {
        [Display(Name = "账号")]
        public string Email { get; set; }

        [Display(Name = "重置密码")]
        public string Password { get; set; }
    }
}
