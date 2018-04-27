using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCViews.Models
{
    public class PostViewModel
    {
        public PostViewModel() { }

        public PostViewModel(ForumService.PostModel model)
        {
            this.Id = model.Id;
            this.Poster = model.Poster;
            this.Title = model.Title;
            this.PostType = model.PostType;
            this.Content = model.Content;
            this.PublishDate = model.PublishDate;
            this.NoComments = model.NoComments > 0;
        }
        public int Id { get; set; }

        [Display(Name = "发布者")]
        public string Poster { get; set; }

        [Display(Name = "标题")]
        public string Title { get; set; }

        [Display(Name = "帖子类型")]
        public string PostType { get; set; }

        [Display(Name = "内容")]
        public string Content { get; set; }

        [Display(Name = "发布时间")]
        public DateTime PublishDate { get; set; }

        [Display(Name = "是否禁止回帖")]
        public bool NoComments { get; set; }
    }

    public class PostReplyViewModel
    {
        public PostReplyViewModel() { }
        public PostReplyViewModel(ForumService.PostReplyModel model)
        {
            this.Id = model.Id;
            this.Responser = model.Responser;
            this.Content = model.Content;
            this.ResponseDate = model.ResponseDate;
            this.ResponseTo = model.ResponseTo;
        }

        public int Id { get; set; }
        public string Responser { get; set; }
        public int ResponseTo { get; set; }
        public DateTime ResponseDate { get; set; }
        public string Content { get; set; }
    }

    public class PostOperatorRep
    {
        public int Status { get; set; }
        public string Message { get; set; }
    }
}