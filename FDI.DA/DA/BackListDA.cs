using System;
using System.Collections.Generic;
using System.Linq;
using FDI.Base;
using FDI.Simple;

namespace FDI.DA
{
    public class BackListDA : BaseDA
    {
        public List<BackListItem> GetAll()
        {
            try
            {
                var query = from c in FDIDB.sp_GetBackList()
                            select new BackListItem
                            {
                                CardNumber = c.CardNumber,
                                CardTypeCode = c.CardTypeCode,
                                CustomerID = c.CustomerID,
                                SchoolYear = c.SchoolYear,
                                ID = c.id,
                                Date = c.Date??new DateTime(),
                                Desc = c.Desc,
                                CardStatus = c.CardStatus == "00" ? "Chưa phát hành" : (c.CardStatus == "01" ? "Đã phát hành" : "Đã khóa"),
                                CardType = c.CardType,
                                CustomerClass = c.CustomerClass??0,
                                CustomerName = c.CustomerName
                            };

                return query.ToList();
            }
            catch (Exception)
            {
                return new List<BackListItem>();
            }

        }

        public tblBlackList Get(string card)
        {
            var query = from c in FDIDB.tblBlackLists where  c.CardNumber == card select c;
            return query.FirstOrDefault();
        }

        public void Add(tblBlackList item)
        {
            FDIDB.tblBlackLists.Add(item);
        }

        public int Count()
        {
            return FDIDB.tblBlackLists.Count();
        }

        public void Delete(tblBlackList item)
        {
            FDIDB.tblBlackLists.Remove(item);
        }

        public void Save()
        {

            FDIDB.SaveChanges();
        }

    }
}
