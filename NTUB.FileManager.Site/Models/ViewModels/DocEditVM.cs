using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NTUB.FileManager.Site.Models.ViewModels
{
    public class DocEditVM
    {
		public int Id { get; set; }

		[Display(Name = "標題")]
		[Required]
		[MaxLength(30)]
		public string Title { get; set; }

		[Display(Name = "描述")]
		[MaxLength(60)]
		public string Description { get; set; }
		public string FileName { get; set; }

		public bool IsImage
		{
			get
			{
				if (this.FileName == null) return false;//防呆
				string ext = System.IO.Path.GetExtension(this.FileName).ToLower();
				string[] imageExtensions = new string[] { ".gif", ".jfif", ".png", ".jpg", ".jpeg", ".bmp" };
				return imageExtensions.Contains(ext);
			}
		}
	}
}