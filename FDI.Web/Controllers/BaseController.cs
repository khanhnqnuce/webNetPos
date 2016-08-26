using System.Web.Mvc;
using FDI.Utils;

namespace FDI.Web.Controllers
{
    public class BaseController : Controller
    {
        protected string FullName
        {
            get
            {
                var cookie = Request.Cookies["IPFN"];
                return cookie != null ? FDIUtils.Decrypt(cookie.Value) : null;
            }
        }
        
        protected string PassWord
        {
            get
            {
                var cookie = Request.Cookies["IPPW"];
                return cookie != null ? cookie.Value : null;
            }
        }
        protected string CustomerId
        {
            get
            {
                var cookie = Request.Cookies["IPCID"];
                return cookie != null ? FDIUtils.Decrypt(cookie.Value).ToUpper() : null;
            }
        }

    }
}
