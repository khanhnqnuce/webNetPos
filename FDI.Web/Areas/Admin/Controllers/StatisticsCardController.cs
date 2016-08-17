using System.Web.Mvc;
using FDI.DA;
using FDI.Simple;

namespace FDI.Areas.Admin.Controllers
{
    public class StatisticsCardController : Controller
    {
        readonly ThongKeTheDA _da = new ThongKeTheDA();
        readonly CardDA _cardDa = new CardDA();
        readonly RecordDA _recordDa = new RecordDA();
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
            var model = new ModelCardItem
            {
                LsThongKeTheItems = _da.GetThongKeTheItems(Request),
                LstCardItems = _cardDa.ReportDetailCard(Request)
            }; 
            return View(model);
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
    }
}
