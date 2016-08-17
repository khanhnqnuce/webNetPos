using System.Web.Mvc;
using FDI.DA;

namespace FDI.Areas.Admin.Controllers
{
    public class BackListController : Controller
    {
        readonly BackListDA _da = new BackListDA();
        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated) return Redirect("/Admin/User/Login");
            return View();
        }
        
        public ActionResult ListItems()
        {
            if (!User.Identity.IsAuthenticated) return Redirect("/Admin/User/Login");
            var model = _da.GetAll();
            return View(model);
        }
    }
}
