using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;
using FDI.DA;
using FDI.Simple;
using FDI.Web.Common;

namespace FDI.Areas.Admin.Controllers
{
    public class BackListController : Controller
    {
        readonly BackListDA _da = new BackListDA();
        private static List<BackListItem> _model;
        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated) return Redirect("/Admin/User/Login");
            return View();
        }
        
        public ActionResult ListItems()
        {
            if (!User.Identity.IsAuthenticated) return Redirect("/Admin/User/Login");
            _model = _da.GetAll();
            return View(_model);
        }

        public ActionResult ExportExcell()
        {
            var fileName = string.Format("danh-sach-the-den_{0}.xlsx", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"));
            var filePath = Path.Combine(Request.PhysicalApplicationPath, "File\\ExportImport", fileName);
            var folder = Request.PhysicalApplicationPath + "File\\ExportImport";
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            Excel.ExportToCardBackList(filePath, _model);
            var bytes = System.IO.File.ReadAllBytes(filePath);
            return File(bytes, "text/xls", fileName);
        }
    }
}
