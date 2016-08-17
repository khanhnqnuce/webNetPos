using System;

namespace FDI.Simple
{
    public class RecordItem : BaseSimple
    {
        public string CardNumber { get; set; }
        public DateTime Date { get; set; }
        public decimal Value { get; set; }
        //public int Bonus { get; set; }
        public int Balance { get; set; }
        public string Action { get; set; }
        public string AccountName { get; set; }
        public string CardType { get; set; }
        public string Buiding { get; set; }
        public string Area { get; set; }
        public string UserName { get; set; }
        public string EventId { get; set; }
        public string ProductCode { get; set; }
    }
    
      public class EventItem
        {
            public DateTime Date { get; set; }
            public string OwnerCode { get; set; }
            public string CardNumber { get; set; }
            public string Event { get; set; }
            public string EventCode { get; set; }
            public decimal Value { get; set; }
            public decimal Balance { get; set; }
            public string Object { get; set; }
            public string Area { get; set; }
        }
   
}
