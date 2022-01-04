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
        private readonly IDocRepository _repo;

        public DocService()//給service用的
        {
            this._repo = new DocRepository();
        }
        public DocService(IDocRepository repo)//給單元測試用的
        {
            _repo = repo;
        }


        public void Create(CreateDocRequest request)
        {
            DocEntity entity = new DocEntity
            {
                Title = request.Title,
                Description = request.Description,
                FileName = request.FileName,
                ModifiedTime = DateTime.Now,
            };
            _repo.Create(entity);
        }


        public void Update(EditDocRequest request)
        {
            //先把現有資料從資料庫撈出來，只改需要更動的部分，剩下的不動。
            DocEntity entity = this._repo.Load(request.Id);

            entity.Title = request.Title;
            entity.Description = request.Description;
            entity.FileName = request.FileName;
            entity.ModifiedTime = DateTime.Now;
            _repo.Update(entity);
        }


        public void Delete(int docId)
        {
            this._repo.Delete(docId);
        }
    }
}