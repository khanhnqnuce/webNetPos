using System;
using System.Web;
using System.Web.Mvc;
using FDI.DA;
using FDI.Simple;
using FDI.Utils;

namespace FDI.Web.Controllers
{
    public class LoginController : Controller
    {
        readonly UserDA _da = new UserDA();

        public ActionResult Index()
        {
            ViewBag.Warning = "<h4>Chào mừng bạn đến đại học FPT</h4>";
            return View();
        }

        [HttpPost]
        public ActionResult ProcessLogin()
        {
            var user = Request["iptLoginUser"] ?? "";
            var pass = Request["iptLoginPass"] ?? "";
            var item = _da.CustomerLogin("17" + user + "05", FDIUtils.GetMd5Sum(pass));
            if (item != null)
            {
                var cookie1 = new HttpCookie("IPFN")
                {
                    Value = item.CustomerName,
                    Expires = DateTime.Now.AddDays(1)
                };
                var cookie2 = new HttpCookie("IPPW")
                {
                    Value = item.PassWord,
                    Expires = DateTime.Now.AddDays(1)
                };
                var cookie3 = new HttpCookie("IPCID")
                {
                    Value = user,
                    Expires = DateTime.Now.AddDays(1)
                };
                Response.SetCookie(cookie1);
                Response.SetCookie(cookie2);
                Response.SetCookie(cookie3);
                return Redirect("/");
            }
            else
            {
                ViewData["Warning"] = "<h4>Sai thông tin đăng nhập</h4>";
                return Redirect("/dang-nhap");
            }
        }

        public ActionResult ProcessLogout()
        {
            var cookie1 = Request.Cookies["IPFN"];
            var cookie2 = Request.Cookies["IPPW"];
            var cookie3 = Request.Cookies["IPCID"];
            if (cookie1 != null)
            {
                cookie1.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(cookie1);
            }
            if (cookie2 != null)
            {
                cookie2.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(cookie2);
            }
            if (cookie3 != null)
            {
                cookie3.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(cookie3);
            }
            return Redirect("/dang-nhap");
        }

        [HttpPost]
        public ActionResult ProcessChangePass()
        {
            var msg = new MsgItem
            {
                Errors = false,
                Msg = "Đổi mật khẩu thành công"
            };
            var pass = Request["iptLoginPass"];
            var cookie = Request.Cookies["IPCID"];
            var cookiePass = Request.Cookies["IPPW"];
            if (FDIUtils.GetMd5Sum(pass)=="9D31E787F638E7D58A75724398CADA4A")
            {
                msg.Errors = true;
                msg.Msg = "Mật khẩu trùng với mật khẩu mặc định";
                return Json(msg);
            }
            if (cookie != null)
            {
                var item = _da.Get("17" + cookie.Value + "05");
                item.PassWord = FDIUtils.GetMd5Sum(pass);
                _da.Save();
                return Json(msg);
            }

            return Json(msg);
        }

    }
}
