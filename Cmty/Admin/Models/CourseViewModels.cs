using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Admin.Models
{
    public class CourseReviewViewModels
    {
        [Display(Name = "课程信息")]
        public string Code { get; set; }

        [Display(Name = "开课院校")]
        public string University { get; set; }

        [Display(Name = "课程名称")]
        public string Name { get; set; }

        [Display(Name = "课程简介")]
        public string Desp { get; set; }

        [Display(Name = "课程图片")]
        public string PicUrl { get; set; }

        [Display(Name ="提交人")]
        public string CommitUser { get; set; }

        [Display(Name ="提交时间")]
        public DateTime CommitDate { get; set; }

        [Display(Name = "审核状态")]
        public string Status { get; set; }
    }

    public class CourseViewModels
    {
        [Display(Name = "课程代码")]
        public string Code { get; set; }

        [Display(Name = "开课院校")]
        public string University { get; set; }

        [Display(Name ="课程名称")]
        public string Name { get; set; }

        [Display(Name = "课程简介")]
        public string Desp { get; set; }

        [Display(Name ="课程图片")]
        public string PicUrl { get; set; }
    }
}