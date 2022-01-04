using NTUB.FileManager.Site.Models.DTOs;
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

        //Index
        //Template: List
        //Reference script libraries: Untag
        public ActionResult Index(string title, string description)
        {
            var data = repository
                .Search(title, description)
                .Select(x => x.EntityToIndexVM());

            ViewBag.C_Title = title;
            ViewBag.C_Description = description;

            return View(data);
        }

        //Template: List
        //Reference script libraries: Untag
        public ActionResult Index2(string title, string description)
        {
            var data = repository
                .Search(title, description)
                .Select(x => x.EntityToIndexVM());

            ViewBag.C_Title = title;
            ViewBag.C_Description = description;

            return View(data);
        }

        //Create
        //Template: Create
        //Reference script libraries: Tag!!
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(DocCreateVM model, HttpPostedFileBase file)
        {
            //檢查有沒有上傳檔案(必填)
            if (file == null || file.FileName == null || file.ContentLength == 0)
            {
                ModelState.AddModelError("FileName", "檔案必填");
                return View(model);
            }
            //將檔案儲存，得知實際存的檔名
            string path = Server.MapPath("~/Files/");
            string newFileName = SaveFile(file, path);
            //將新增名存到model
            model.FileName = newFileName;
            //新增紀錄
            service.Create(model.VMToRequest());
            //redirect to index
            return RedirectToAction("Index");
        }

        private string SaveFile(HttpPostedFileBase file, string path)
        {
            string ext = System.IO.Path.GetExtension(file.FileName);

            string targetFileName = Guid.NewGuid().ToString("N") + ext;

            string fullName = System.IO.Path.Combine(path, targetFileName);

            file.SaveAs(fullName);
            return targetFileName;
        }

        //Edit
        //Template: Edit
        //Reference script libraries: Tag!!
        public ActionResult Edit(int id)
        {
            var entity = repository.Load(id);
            //Reference from DocRepository as below
            ////public DocEntity Load(int docId)
            ////{
            ////    var model = db.Docs.Find(docId);
            ////    return model == null ? null : model.DocToEntity();
            ////}
            return View(entity.EntityToEditVM());
        }

        [HttpPost]//程式並沒有進入這個判斷式
        [ValidateAntiForgeryToken]//防止跨網站攻擊
        public ActionResult Edit(HttpPostedFileBase file, DocEditVM model, string btnDeleteName)//Data binding
        {
            //如果有上傳檔案，就先取得DB內的檔名備用，稍後要刪檔案-1
            string originalFileName = repository.Load(model.Id).FileName;

            //判斷刪除按鈕動作
            if (btnDeleteName == "Delete")//"Delete" is the value.
            {
                return Delete(model, originalFileName);
            }

            //如果有上傳檔案就存檔並取得新檔名，且存到model中
            string path = Server.MapPath("~/Files/");
            string newFileName = TrySaveFile(path, file);

            //如果有上傳檔案，就先取得DB內的檔名備用，稍後要刪檔案-2
            model.FileName = string.IsNullOrEmpty(newFileName) ? originalFileName : newFileName;

            //更新紀錄
            service.Update(model.EditVMToRequest());

            //如果有上傳新檔案，就刪除舊檔案
            TryDeleteFile(path, originalFileName);
            return RedirectToAction("Index");
        }

        private string TrySaveFile(string path, HttpPostedFileBase file)
        {
            if ((file == null) || (file.FileName == null) || (file.ContentLength == 0)) return string.Empty;
            string ext = System.IO.Path.GetExtension(file.FileName);
            string targetFileName = Guid.NewGuid().ToString("N") + ext;
            string fullName = System.IO.Path.Combine(path, targetFileName);

            file.SaveAs(fullName);
            return targetFileName;
        }

        //Delete
        private ActionResult Delete(DocEditVM model, string originalFileName)
        {
            try
            {
                this.service.Delete(model.Id);
                string path = Server.MapPath("~/Files/");
                TryDeleteFile(path, originalFileName);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return this.View("Edit", model);//因為Delete沒有index頁面，所以要回到Edit頁面，並顯示View Model
            }
        }

        private void TryDeleteFile(string path, string fileName)
        {
            string fullName = System.IO.Path.Combine(path, fileName);
            if (System.IO.File.Exists(fullName) == false) return;

            System.IO.File.Delete(fullName);
        }
    }
}