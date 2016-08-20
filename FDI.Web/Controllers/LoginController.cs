using System;
using System.Web;
using System.Web.Mvc;
using FDI.DA;
using FDI.Simple;
using FDI.Utils;

namespace FDI.Web.Controllers
{
    public class LoginController : BaseController
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
            var msg = new MsgItem
            {
                Errors = false,
                Msg = "Đăng nhập thành công"
            };
            try
            {
                var user = Request["iptLoginUser"] ?? "";
                var pass = Request["iptLoginPass"] ?? "";
                var item = _da.CustomerLogin("17" + user + "05", FDIUtils.GetMd5Sum(pass));
                if (item != null)
                {
                    var cookie1 = new HttpCookie("IPFN")
                    {
                        Value = FDIUtils.Encrypt(item.CustomerName),
                        Expires = DateTime.Now.AddDays(1)
                    };
                    var cookie2 = new HttpCookie("IPPW")
                    {
                        Value = item.PassWord,
                        Expires = DateTime.Now.AddDays(1)
                    };
                    var cookie3 = new HttpCookie("IPCID")
                    {
                        Value = FDIUtils.Encrypt(user),
                        Expires = DateTime.Now.AddDays(1)
                    };
                    Response.SetCookie(cookie1);
                    Response.SetCookie(cookie2);
                    Response.SetCookie(cookie3);
                }
                else
                {
                    msg.Errors = true;
                    msg.Msg = "Sai thông tin đăng nhập";
                }
            }
            catch (Exception)
            {
                msg.Errors = true;
                msg.Msg = "Đăng nhập thất bại";
            }
            return Json(msg);
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
            if (FDIUtils.GetMd5Sum(pass) == "9D31E787F638E7D58A75724398CADA4A")
            {
                msg.Errors = true;
                msg.Msg = "Mật khẩu trùng với mật khẩu mặc định";
            }
            else
            {
                var item = _da.Get("17" + CustomerId + "05");
                item.PassWord = FDIUtils.GetMd5Sum(pass);
                _da.Save();
            }
            return Json(msg);

        }

    }
}
