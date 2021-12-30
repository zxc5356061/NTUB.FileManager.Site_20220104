using NTUB.FileManager.Site.Models.Infrastructures;
using NTUB.FileManager.Site.Models.Infrastructures.Extensions;
using NTUB.FileManager.Site.Models.Interfaces;
using NTUB.FileManager.Site.Models.Services;
using NTUB.FileManager.Site.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NTUB.FileManager.Site.Controllers
{
    public class DocsController : Controller 
    { 
        private IDocRepository repository;
        private DocService service;
        public DocsController()
        {
            service = new DocService();
            repository = new DocRepository();
        }
    
        // GET: Doc

        //Template: List
        //Reference script libraries: Untag
        public ActionResult Index(string title, string description)
        {
            var data = repository
                .Search(title, description)
                .Select(x => x.ToIndexVM());

            return View(data);
        }

        //Template: Create
        //Reference script libraries: Tag
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(DocCreateVM model)
        {
            return View(model);
        }
    }
}