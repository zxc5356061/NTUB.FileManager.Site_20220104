using NTUB.FileManager.Site.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTUB.FileManager.Site.Models.Interfaces
{
    public interface IDocRepository
    {
        void Create(DocEntity docEntity);
        void Update(DocEntity docEntity);
        void Delete(int docId);
        IEnumerable<DocEntity> Search(string docTitle, string docDescription);
        DocEntity Load(int docId);
    }
}
