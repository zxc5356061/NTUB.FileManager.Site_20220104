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
            DocEntity result = db.Docs.Find(docId).ToDocEntity();
            return result;
        }

        public IEnumerable<DocEntity> Search(string docTitle, string docDescription)
        {
            var query = db.Docs.AsQueryable();

            if (!string.IsNullOrEmpty(docTitle))
            {
                query = query.Where(x => x.Title.Contains(docTitle));
            }

            if (!string.IsNullOrEmpty(docDescription))
            {
                query = query.Where(x=> x.Description.Contains(docDescription));
            }

            var data = query.OrderBy(x => x.Title).ToList();

            var result = data.Select(x => x.ToDocEntity());//因為ToDocEntity()無法被轉成SQL語法，所以必須分開來寫
            return result;
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