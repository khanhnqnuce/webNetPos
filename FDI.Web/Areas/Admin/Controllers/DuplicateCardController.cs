using System.Web.Mvc;
using FDI.DA;

namespace FDI.Areas.Admin.Controllers
{
    public class DuplicateCardController : Controller
    {
        readonly CardDA _da = new CardDA();
        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated) return Redirect("/Admin/User/Login");
            return View();
        }
        
        public ActionResult ListItems()
        {
            var model = _da.GetDuplicateCard();
            return View(model);
        }
    }
}
