using System.Web.Mvc;

namespace FDI.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var cookie = Request.Cookies["IPCID"];
            if (cookie == null) return Redirect("/dang-nhap");

            var cookiepass = Request.Cookies["IPPW"];

            if (cookiepass != null)
            {
                var pass = cookiepass.Value;
                if (pass == "9D31E787F638E7D58A75724398CADA4A")
                    return Redirect("/doi-mat-khau");
            }

            var cookiename = Request.Cookies["IPFN"];
            ViewBag.Name = cookiename.Value;
            ViewBag.ID = cookie.Value;
            return PartialView();
        }

        public ActionResult Infomation()
        {
            var cookie = Request.Cookies["IPCID"];
            var cookiename = Request.Cookies["IPFN"];
            ViewBag.Name = cookiename.Value;
            ViewBag.ID = cookie.Value.ToUpper();
            return PartialView();
        }

        public ActionResult ListDetail()
        {
            return PartialView();
        }

        public ActionResult ChangePass()
        {
            var cookie = Request.Cookies["IPCID"];
            if (cookie == null) return Redirect("/dang-nhap");
            return PartialView();
        }
    }
}
