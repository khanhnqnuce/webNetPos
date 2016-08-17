using System.Web.Mvc;
using System.Web.Security;
using FDI.DA;

namespace FDI.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        readonly UserDA _da = new UserDA();
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect("/Admin/User/Login");
        }

        public ActionResult Infomation()
        {
            ViewBag.UserName = User.Identity.Name.Split('|')[0];
            return PartialView();
        }

        [HttpPost]
        public ActionResult ProcessLogin()
        {
            var username = Request["Username"];
            var password = Request["Password"];
            var user = _da.Login(username, password);
            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(user.UserName+"|"+user.Password+"|"+user.AreaCode+"|"+user.Right1, true);
            }
            return Redirect("/admin");
        }

    }
}
