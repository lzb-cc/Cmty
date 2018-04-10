using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Admin.Models
{
    public class CourseTeacherMapModels
    {
        [Display (Name = "课程代码")]
        public string Code { get; set; }

        [Display(Name = "授课教师邮箱")]
        public string Email { get; set; }
    }
}