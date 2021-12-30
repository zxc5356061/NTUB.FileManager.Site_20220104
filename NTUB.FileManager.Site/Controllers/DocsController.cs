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
        // GET: Doc

        //Template: List
        //Reference script libraries: Untag
        public ActionResult Index()
        {
            return View();
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