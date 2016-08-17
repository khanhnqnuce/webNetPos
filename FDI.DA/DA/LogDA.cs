using System;
using System.Collections.Generic;
using System.Linq;
using FDI.Base;
using FDI.Simple;

namespace FDI.DA
{
    public partial class LogDA : BaseDA
    {
        public List<LogItem> GetAdminAllSimple()
        {
            try
            {
                var query = from c in FDIDB.tblLogs
                            select new LogItem
                            {
                                Datetime = c.Datetime ?? new DateTime(),
                                Object = c.Object,
                                Message = c.Message
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
