using NTUB.FileManager.Site.Models.DTOs;
using NTUB.FileManager.Site.Models.EFModels;
using NTUB.FileManager.Site.Models.Entities;
using NTUB.FileManager.Site.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NTUB.FileManager.Site.Models.Infrastructures.Extensions
{
    public static class DocEntityExtensions
    {
		public static Doc EntityToDoc(this DocEntity source)
			=> new Doc
			{
				Title = source.Title,
				Description = source.Description,
				FileName = source.FileName,
				ModifiedTime = source.ModifiedTime

			};

		public static DocIndexVM EntityToIndexVM(this DocEntity source)
			=> new DocIndexVM
			{
				Id = source.Id,
				Title = source.Title,
				Description = source.Description,
				ModifiedTime = source.ModifiedTime,
				FileName = source.FileName,

			};

		public static DocEditVM EntityToEditVM(this DocEntity source)
		{
			return new DocEditVM
			{
				Id = source.Id,
				Title = source.Title,
				Description = source.Description,
				FileName = source.FileName,
			};
		}

		public static EditDocRequest EditVMToRequest(this DocEditVM source)
		{
			return new EditDocRequest
			{
				Id = source.Id,
				Title = source.Title,
				Description = source.Description,
				FileName = source.FileName,
			};
		}
	}
}