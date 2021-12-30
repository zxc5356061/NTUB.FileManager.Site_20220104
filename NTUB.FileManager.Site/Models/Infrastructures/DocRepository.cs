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
            var model = db.Docs.Find(docId);
            if (model != null) return;
            
                db.Docs.Remove(model);
                db.SaveChanges();
        }

        public DocEntity Load(int docId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DocEntity> Search(string docTitle, string docDescription)
        {
            throw new NotImplementedException();
        }

        public void Update(DocEntity docEntity)
        {
            throw new NotImplementedException();
        }
    }
}