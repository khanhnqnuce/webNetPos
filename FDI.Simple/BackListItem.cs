using System;

namespace FDI.Simple
{
    public class BackListItem : BaseSimple
    {
        public DateTime Date { get; set; }
        public string CardNumber { get; set; }
        public string CustomerID { get; set; }
        public string CustomerName { get; set; }
        public int CustomerClass { get; set; }
        public string CardType { get; set; }
        public string CardTypeCode { get; set; }
        public string SchoolYear { get; set; }
        public string CardStatus { get; set; }
        public string Desc { get; set; }
    }
}