using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FDI.DA;
using FDI.Simple;
using FDI.Utils;
using NPOI.HSSF.Record.Chart;

namespace FDI.Web.Controllers
{
    public class HomeController : BaseController
    {
        readonly CardDA _da = new CardDA();
        public ActionResult Index()
        {
            if (CustomerId == null) return Redirect("/dang-nhap");
            if (PassWord == "9D31E787F638E7D58A75724398CADA4A")
                return Redirect("/doi-mat-khau");
            ViewBag.Name = FullName;
            ViewBag.ID = CustomerId;
            return PartialView();
        }

        public ActionResult Infomation()
        {
            ViewBag.Name = FullName;
            ViewBag.ID = CustomerId;
            var model = _da.GetListCard(CustomerId);
            var lst = model.Select(c => c.CardNumber).ToList();
            Session["lstCard"] = string.Join(",", lst);
            return PartialView(model);
        }

        public ActionResult ListDetail()
        {
            var model = new List<GiaoDichItem>();
            var card = Request["cardNumber"];
            var lstCard = (string) Session["lstCard"]??"";
            if (!lstCard.Contains(card))
            {
                return Json("<tr><td colspan='5' style='color:red'>Mã thẻ không đúng</td></tr>");
            }
            var fromdate = Request["fromDate"];
            var todate = Request["toDate"];
            model = _da.LichSuGiaoDich(card, ConvertUtil.ToDate(fromdate), ConvertUtil.ToDate(todate).AddDays(1));
            return PartialView(model);
        }

        public ActionResult ChangePass()
        {
            if (CustomerId == null) return Redirect("/dang-nhap");
            return PartialView();
        }
    }
}
