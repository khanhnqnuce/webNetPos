using System.Web.Mvc;
using FDI.DA;
using FDI.Simple;

namespace FDI.Areas.Admin.Controllers
{
    public class SalesController : Controller
    {
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
            var model = _recordDa.FindDetailEventItems(Request);
            return View(model);
        }
    }
}
