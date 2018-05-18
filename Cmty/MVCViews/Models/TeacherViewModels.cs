using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCViews.Models
{
    public class TeacherViewModels
    {

        [Display(Name = "电子邮件")]
        public string Email { get; set; }

        [Display(Name = "用户名")]
        public string UserName { get; set; }

        [Display(Name = "学校")]
        public string University { get; set; }

        [Display(Name = "性别")]
        public string Sex { get; set; }

        [Display(Name = "任教时间")]
        public string RegistDate { get; set; }

        [Display(Name = "职称")]
        public string JobTitle { get; set; }

        [Display(Name = "简历")]
        public string Desp { get; set; }
    }

    public class TeacherCommentViewModel
    {
        public TeacherCommentViewModel() { }
        public TeacherCommentViewModel(TeacherService.TeacherCommentView model)
        {
            this.Id = model.Id;
            this.Code = model.Email;
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