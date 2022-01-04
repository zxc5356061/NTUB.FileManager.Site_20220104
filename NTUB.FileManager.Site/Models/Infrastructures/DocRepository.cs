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

        public void Create(DocEntity entity)
        {

            db.Docs.Add(entity.EntityToDoc());
            db.SaveChanges();

        }

        public void Delete(int docId)
        {
            var model = db.Docs.Find(docId);
            if (model == null) return;// return void
            db.Docs.Remove(model);
            db.SaveChanges();
        }


        public DocEntity Load(int docId)
        {
            var model = db.Docs.Find(docId);
            return model == null ? null : model.DocToEntity();
        }

        public IEnumerable<DocEntity> Search(string title, string description)
        {
            var query = db.Docs.AsQueryable();
            if (!string.IsNullOrEmpty(title))
            {
                query = query.Where(x => x.Title.Contains(title));
            }
            if (!string.IsNullOrEmpty(description))
            {
                query = query.Where(x => x.Description.Contains(description));
            }
            var data = query.OrderBy(x => x.Title).ToList();
            var result = data.Select(x => x.DocToEntity());//因為ToDocEntity()無法被轉成SQL語法，所以必須分開來寫
            return result;
        }

        public void Update(DocEntity entity)
        {
            Doc model = db.Docs.Find(entity.Id);
            if (model == null) return;

            model.Title = entity.Title;
            model.Description = entity.Description;
            model.ModifiedTime = entity.ModifiedTime;
            model.FileName = entity.FileName;

            db.SaveChanges();
        }
    }
}