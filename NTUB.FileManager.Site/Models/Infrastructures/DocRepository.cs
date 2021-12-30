using NTUB.FileManager.Site.Models.Entities;
using NTUB.FileManager.Site.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NTUB.FileManager.Site.Models.Infrastructures
{
    public class DocRepository : IDocRepository
    {
        public void Create(DocEntity docEntity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int docId)
        {
            throw new NotImplementedException();
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