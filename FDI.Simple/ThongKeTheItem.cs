using System;

namespace FDI.Simple
{
    public class ThongKeTheItem:BaseSimple
    {
        public string NameType { get; set; }
        public decimal TotalCard { get; set; }
        public decimal TotalUsed { get; set; }
        public decimal TotalNotUsed { get; set; }
        public decimal TotalBlock { get; set; }
        public decimal TotalBalance { get; set; }
    }
}
