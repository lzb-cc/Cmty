using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCViews.Models
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

        [Display(Name = "提交人")]
        public string CommitUser { get; set; }

        [Display(Name = "提交时间")]
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

        [Display(Name = "课程名称")]
        public string Name { get; set; }

        [Display(Name = "课程简介")]
        public string Desp { get; set; }

        [Display(Name = "课程图片")]
        public string PicUrl { get; set; }

        public List<string> Teachers { get; set; }
    }

    public class CourseOperatorResp
    {
        public int Status { get; set; }
        public string Msg { get; set; }
    }

    public class CourseCommentViewModel
    {
        public CourseCommentViewModel() { }
        public CourseCommentViewModel(CourseCommentService.CourseCommentView model)
        {
            this.Id = model.Id;
            this.Code = model.Code;
            this.Date = model.PubDate;
            this.Content = model.Content;
            this.Floor = model.Floor;
        }

        public int Id { get; set; }

        public string Code { get; set; }

        public string UserAvatar { get; set; }

        public string UserName { get; set; }

        public string UserEmail { get; set; }

        public DateTime Date { get; set; }

        public string Content { get; set; }

        public int Floor { get; set; }
    }
}