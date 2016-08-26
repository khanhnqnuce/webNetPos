using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using DotNetOpenAuth.Messaging;
using DotNetOpenAuth.OpenId.Extensions.AttributeExchange;
using FDI.DA;
using FDI.Simple;

namespace FDI.Areas.Admin.Controllers
{
    public class ChartController : Controller
    {
        readonly ThongKeTheDA _da = new ThongKeTheDA();

        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated) return Redirect("/Admin/User/Login");
            return View();
        }

        public ActionResult ListItems()
        {
            var model = _da.GetLineChartToObject(Request);
            var lstName = new List<string>();
            var lst = new List<Datum>();
            var item1 = new Datum
            {
                name = "Rut tien",
                data = new List<decimal>()
            };
            var item2 = new Datum
            {
                name = "Nap tien",
                data = new List<decimal>()
            };
            foreach (var item in model)
            {
                item1.data.Add((decimal) (item.OutputValue>0?(-item.OutputValue):0));
                item2.data.Add(item.InputValue??0);
                lstName.Add(item.ObjectName);
            }

            lst.Add(item1);
            lst.Add(item2);
            ViewBag.LstUser = new JavaScriptSerializer().Serialize(lst);
            ViewBag.LstName = new JavaScriptSerializer().Serialize(lstName);
            return View(model);
        }

    }
}
