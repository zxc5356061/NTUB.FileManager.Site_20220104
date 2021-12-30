using NTUB.FileManager.Site.Models.EFModels;
using NTUB.FileManager.Site.Models.Entities;
using NTUB.FileManager.Site.Models.Infrastructures.Extensions;
using NTUB.FileManager.Site.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NTUB.FileManager.Site.Models.Infrastructures
{
    public class DocRepository : IDocRepository
    {
        private AppDbContext db = new AppDbContext();//Using EF Framework
        public void Create(DocEntity docEntity)
        {
            db.Docs.Add(docEntity.ToDoc());
            db.SaveChanges();           
        }

        public void Delete(int docId)
        {
            Doc model = db.Docs.Find(docId);
            if (model == null) {return; }// return void
            
                db.Docs.Remove(model);
                db.SaveChanges();
        }

        public DocEntity Load(int docId)
        {
            Doc model = db.Docs.Find(docId);
            return model == null ? null : model.ToDocEntity();
        }

        public IEnumerable<DocEntity> Search(string docTitle, string docDescription)
        {
            throw new NotImplementedException();
        }

        public void Update(DocEntity docEntity)
        {
            Doc model = db.Docs.Find(docEntity.Id);
            if(model == null) { return; }// return void

            model.Title = docEntity.Title;
            model.Description = docEntity.Description;
            model.FileName = docEntity.FileName;
            model.ModifiedTime = docEntity.ModifiedTime;
        }
    }
}