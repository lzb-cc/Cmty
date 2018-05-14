using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Admin.Models
{
    public class OtherViewModels
    {
        [Display(Name = "序号")]
        public int Id { get; set; }

        [Display(Name = "敏感词")]
        public string Desp { get; set; }
    }
}