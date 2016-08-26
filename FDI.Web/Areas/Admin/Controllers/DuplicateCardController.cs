using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;
using FDI.DA;
using FDI.Simple;
using FDI.Web.Common;

namespace FDI.Areas.Admin.Controllers
{
    public class DuplicateCardController : Controller
    {
        readonly CardDA _da = new CardDA();
        private static List<CardItem> _model;

        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated) return Redirect("/Admin/User/Login");
            return View();
        }
        
        public ActionResult ListItems()
        {
            _model = _da.GetDuplicateCard();
            return View(_model);
        }

        public ActionResult ExportExcell()
        {
            var fileName = string.Format("the-trung-nhau_{0}.xlsx", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"));
            var filePath = Path.Combine(Request.PhysicalApplicationPath, "File\\ExportImport", fileName);
            var folder = Request.PhysicalApplicationPath + "File\\ExportImport";
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            Excel.ExportToCard(filePath, _model);
            var bytes = System.IO.File.ReadAllBytes(filePath);
            return File(bytes, "text/xls", fileName);
        }
    }
}
