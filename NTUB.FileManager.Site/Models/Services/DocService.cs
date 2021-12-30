using NTUB.FileManager.Site.Models.DTOs;
using NTUB.FileManager.Site.Models.Entities;
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

        public void Create(CreateDocRequest createDocRequest) 
        {
            DocEntity createNewEntity = new DocEntity
            {
                Title = createDocRequest.Title,
                Description = createDocRequest.Description,
                FileName = createDocRequest.FileName,
                ModifiedTime = DateTime.Now,
            };
        }

        public void Update(EditDocRequest editDocRequest)
        {
            DocEntity editCurrentEntity = this._reop.Load(editDocRequest.Id);
            editCurrentEntity.Title = editDocRequest.Title;
            editCurrentEntity.Description = editDocRequest.Description;
            editCurrentEntity.ModifiedTime = DateTime.Now;
            _reop.Update(editCurrentEntity);
        }

        public void Delete(int docId)
        {
            throw new NotImplementedException();
        }
    }
}