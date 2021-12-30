using NTUB.FileManager.Site.Models.DTOs;
using NTUB.FileManager.Site.Models.Infrastructures;
using NTUB.FileManager.Site.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NTUB.FileManager.Site.Models.Services
{
    public class DocService
    {
        private readonly IDocRepository _reop;
        public DocService()//給service用的
        {
            this._reop = new DocRepository();
        }
        public DocService(IDocRepository reop)//給單元測試用的
        {
            this._reop = reop;
        }

        public void Create(CreateDocRequest request) 
        {
            throw new NotImplementedException();
        }

        public void Update(EditDocRequest request)
        {
            throw new NotImplementedException();
        }

        public void Delete(int docId)
        {
            throw new NotImplementedException();
        }
    }
}