﻿using NTUB.FileManager.Site.Models.EFModels;
using NTUB.FileManager.Site.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NTUB.FileManager.Site.Models.Infrastructures.Extensions
{
    public static class DocEntityExtensions
    {
        public static Doc ToDoc(this DocEntity source)
        {
            return new Doc
            {
                Title = source.Title,
                Description = source.Description,
                FileName = source.FileName,
                ModifiedTime = source.ModifiedTime,
            };
        }
}
}