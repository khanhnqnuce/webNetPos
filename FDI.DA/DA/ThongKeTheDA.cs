using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FDI.Base;
using FDI.Simple;
using FDI.Utils;

namespace FDI.DA
{
    public partial class ThongKeTheDA : BaseDA
    {
        public List<ThongKeTheItem> GetThongKeTheItems(HttpRequestBase httpRequest)
        {
            try
            {
                var buiding = httpRequest["BuidingCode"] ?? "";
                var area = httpRequest["AreaCode"] ?? "";
                var obj = httpRequest["ObjectCode"] ?? ""; 
                var query = from c in FDIDB.sp_ThongKeThe(buiding, area, obj)
                            select new ThongKeTheItem
                    {
                        NameType = c.NameType,
                        TotalCard = c.TotalCard ?? 0,
                        TotalUsed = c.TotalUsed ?? 0,
                        TotalNotUsed = c.TotalNotUsed ?? 0,
                        TotalBlock = c.TotalBlock ?? 0,
                        TotalBalance = c.TotalBalance??0
                    };
                return query.ToList();
            }
            catch (Exception)
            {
                return null;
            }

        }

        public List<sp_LineChartToObject_Result> GetLineChartToObject(HttpRequestBase httpRequest)
        {
            var now = DateTime.Now;
            var rqfromDate = httpRequest["fromDate"];
            var rqtoDate = httpRequest["toDate"];
            var fromdate = !string.IsNullOrEmpty(rqfromDate)
                ? ConvertUtil.ToDate(rqfromDate)
                : new DateTime(now.Year, now.Month, 1);
            var todate = !string.IsNullOrEmpty(rqtoDate)
                ? ConvertUtil.ToDate(rqtoDate)
                : now;
            var query = from c in FDIDB.sp_LineChartToObject(fromdate, todate) select c;
            return query.ToList();
        }

        public List<sp_LineChartToArea_Result> GetLineChartToArea(HttpRequestBase httpRequest)
        {
            var now = DateTime.Now;
            var rqfromDate = httpRequest["fromDate"];
            var rqtoDate = httpRequest["toDate"];
            var fromdate = !string.IsNullOrEmpty(rqfromDate)
                ? ConvertUtil.ToDate(rqfromDate)
                : new DateTime(now.Year, now.Month, 1);
            var todate = !string.IsNullOrEmpty(rqtoDate)
                ? ConvertUtil.ToDate(rqtoDate)
                : now;
            var query = from c in FDIDB.sp_LineChartToArea(fromdate, todate) select c;
            return query.ToList();
        }

    }
}
