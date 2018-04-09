using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Admin.Models
{
    public class TeacherViewModels
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
    }

}