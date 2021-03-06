﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;
using FDI.DA;
using FDI.Simple;
using FDI.Utils;
using FDI.Web.Common;

namespace FDI.Areas.Admin.Controllers
{
    public class CardController : Controller
    {
        readonly CardDA _da = new CardDA();
        readonly RecordDA _recordDa = new RecordDA();
        private static List<CardItem> _model;

        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated) return Redirect("/Admin/User/Login");
            var model = new ModelBuidingItem
            {
                LstAreaItems = _recordDa.GetAreaItems(),
                LstBuidingItems = _recordDa.GetBuidingItems(),
                LstObjectItems = _recordDa.GetObjectItems()
            };
            return View(model);
        }

        public ActionResult ListItems()
        {

            var fillter = Request["fillter"] ?? "false";
            if (fillter == "true")
            {
                var searchIn = Request["SearchIn"];
                var keyword = Request["Keyword"]??"";
                var cardNumber = "";
                var code = "";
                var name = "";
                if (searchIn.Contains("CardNumber"))
                    cardNumber = keyword;
                else if (searchIn.Contains("CustomerID"))
                    code = keyword;
                else if (searchIn.Contains("CustomerName"))
                    name = keyword;

                var buiding = Request["BuidingCode"] ?? "";
                var area = Request["AreaCode"] ?? "";
                var obj = Request["ObjectCode"] ?? "";
                const string cardType = "";
                var status = Request["status"] ?? "";

                _model = _da.FindCardItems(buiding, area, obj, cardType, cardNumber, code, name, status);
            }
            else
            {
                _model = _da.GetAll();
            }

            return View(_model);
        }

        public ActionResult AjaxView(int id, string cardNumber)
        {
            var now = DateTime.Now;
            var startDate = new DateTime(now.Year, now.Month, 1);
            var endDate = new DateTime(now.Year, now.Month, now.Day).AddDays(1);
            var model = new ModelCustomerItem
            {
                CustomerItem = _da.GetCustomer(id),
                LsGiaoDichItems = _da.GiaoDichGanNhat(cardNumber, startDate, endDate)
            };
            return PartialView(model);
        }

        public string GetGiaoDich(string card, string fromdate, string todate)
        {
            var startDate = ConvertUtil.ToDate(fromdate);
            var endDate = ConvertUtil.ToDate(todate);
            var model = _da.GiaoDichGanNhat(card, startDate, endDate);
            var txt = "";
            foreach (var item in model)
            {
                txt += "<tr>";
                txt += string.Format("<td>{0}</td>", item.Date.ToString("dd/MM/yyyy HH:mm"));
                txt += string.Format("<td>{0}</td>", item.Event);
                txt += string.Format("<td>{0}</td>", string.Format("{0:0,0}", item.Value));
                txt += string.Format("<td>{0}</td>", string.Format("{0:0,0}", item.Balance));
                txt += string.Format("<td>{0}</td>", item.Object);
                txt += "</tr>";
            }
            return txt;
        }

        public ActionResult ExportExcell()
        {
            var fileName = string.Format("danh-sach-the_{0}.xlsx", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"));
            var filePath = Path.Combine(Request.PhysicalApplicationPath, "File\\ExportImport", fileName);
            var folder = Request.PhysicalApplicationPath + "File\\ExportImport";
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            Excel.ExportToCard(filePath,_model);
            var bytes = System.IO.File.ReadAllBytes(filePath);
            return File(bytes, "text/xls", fileName);
        }
    }
}
