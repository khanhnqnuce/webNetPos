using System.Collections.Generic;

namespace FDI.Simple
{
    public class Datum
    {
        public string name { get; set; }
        public decimal? y { get; set; }
        public string drilldown { get; set; }
        public List<decimal> data { get; set; }
    }
}
