using System;

namespace FDI.Simple
{
    public class CardProcessItem : BaseSimple
    {
        public DateTime Date { get; set; }
        public string CardNumber { get; set; }
        public int Value { get; set; }
    }
}
