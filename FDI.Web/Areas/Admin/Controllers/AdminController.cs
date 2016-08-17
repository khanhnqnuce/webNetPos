using System.Web.Mvc;

namespace FDI.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/Admin/

        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated) return Redirect("/Admin/User/Login");
            return Redirect("/Admin/Card");
        }

        public ActionResult Menu()
        {
            var index = Request.Url.Segments.Length;
            var url = Request.Url.Segments[index-1];
            ViewBag.url = url;
            if (url == "Card" || url == "DuplicateCard" || url == "BackList" || url == "StatisticsCard")
            {
                ViewBag.Check = 1;
            }
            else if (url == "RevenueCard" || url == "Sales")
            {
                ViewBag.Check = 2;
            }
            
            return PartialView();
        }

    }
}
