using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NTUB.FileManager.Site.Models.ViewModels
{
    public class DocIndexVM
    {
		public int Id { get; set; }
		public string FileName { get; set; }

		[Display(Name = "標題")]
		public string Title { get; set; }
		public string Description { get; set; }

		[Display(Name = "異動日期")]
		[DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:yyyy/MM/dd HH:mm:ss}")]
		public DateTime ModifiedTime { get; set; }

		[Display(Name = "描述")]
		public string BriefDescription
		{
			get
			{
				if (string.IsNullOrEmpty(this.Description))
				{
					return string.Empty;
				}
				int maxLength = 10;
				return this.Description.Length > maxLength
					? this.Description.Substring(0, maxLength) + "..."
					: this.Description;
			}
		}
	}
}