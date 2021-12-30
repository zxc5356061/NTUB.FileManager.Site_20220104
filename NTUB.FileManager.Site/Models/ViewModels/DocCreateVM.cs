using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NTUB.FileManager.Site.Models.ViewModels
{
    public class DocCreateVM
    {
        [Display(Name ="標題")]
        [Required]
        [MaxLength(30)]
        public string Title { get; set; }

        [Display(Name = "描述")]
        [MaxLength(60)]
        public string Description { get; set; }

        [Display(Name = "檔案名稱")]
        public string FileName { get; set; }
    }
}