using System;
using System.Collections.Generic;
using System.Linq;
using FDI.Base;
using FDI.Simple;

namespace FDI.DA
{
    public partial class CardProcessDA : BaseDA
    {
        public List<CardProcessItem> GetAdminAllSimple()
        {
            try
            {
                var query = from c in FDIDB.tblCardProcesses
                            select new CardProcessItem
                    {
                        Date = c.Date ?? new DateTime(),
                        CardNumber = c.CardNumber,
                        Value = c.Value
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
