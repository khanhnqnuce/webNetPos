using System;
using System.IO;
using System.Web.Mvc;
using FDI.DA;
using FDI.Simple;
using FDI.Web.Common;

namespace FDI.Areas.Admin.Controllers
{
    public class StatisticsCardController : Controller
    {
        readonly ThongKeTheDA _da = new ThongKeTheDA();
        readonly CardDA _cardDa = new CardDA();
        readonly RecordDA _recordDa = new RecordDA();
        private static ModelCardItem _model;
        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated) return Redirect("/Admin/User/Login");
            var model = new ModelBuidingItem
            {
                LstAreaItems = _recordDa.GetAreaItems(),
                LstBuidingItems = _recordDa.GetBuidingItems(),
                LstObjectItems = _recordDa.GetObjectItems()
            };
            return View(model);
        }

        public ActionResult ListItems()
        {
            _model = new ModelCardItem
            {
                LsThongKeTheItems = _da.GetThongKeTheItems(Request),
                LstCardItems = _cardDa.ReportDetailCard(Request)
            };
            return View(_model);
        }

        [HttpPost]
        public ActionResult GetArea(string code)
        {
            var list = _cardDa.GetArea(code);
            return Json(new { list }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult GetObject(string code)
        {
            var list = _cardDa.GetObject(code);
            return Json(new { list }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ExportExcell()
        {
            var fileName = string.Format("thong-ke-the_{0}.xlsx", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"));
            var filePath = Path.Combine(Request.PhysicalApplicationPath, "File\\ExportImport", fileName);
            var folder = Request.PhysicalApplicationPath + "File\\ExportImport";
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            Excel.ExportToTalCard(filePath, _model);
            var bytes = System.IO.File.ReadAllBytes(filePath);
            return File(bytes, "text/xls", fileName);
        }
    }
}
