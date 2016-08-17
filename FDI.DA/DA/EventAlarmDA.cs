using System;
using System.Collections.Generic;
using System.Linq;
using FDI.Base;
using FDI.Simple;

namespace FDI.DA
{
    public partial class EventAlarmDA : BaseDA
    {
        public List<EventAlarmItem> GetAdminAllSimple()
        {
            try
            {
                var query = from c in FDIDB.tblEventAlarms
                            select new EventAlarmItem
                    {
                        Date = c.Date ?? new DateTime(),
                        BuidingCode = c.BuidingCode,
                        Object = c.Object,
                        EventCode = c.EventCode
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
