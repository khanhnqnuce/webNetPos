using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FDI.Simple;

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

    }
}
