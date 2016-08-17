using System;

namespace FDI.Simple
{
    public class GiaoDichItem : BaseSimple
    {
        
        public DateTime Date { get; set; }
        public string Event { get; set; }
        public decimal Value { get; set; }
        public decimal Balance { get; set; }
        public string Object { get; set; }
    }
}
