﻿using System;
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
            this.NoComments = model.NoComments;
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
        public int NoComments { get; set; }
    }
}