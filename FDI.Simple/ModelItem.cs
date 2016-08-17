using System;

namespace FDI.Simple
{
    public class ModelItem
    {

        public DateTime? StartDate{get; set;}
        public DateTime? EndDate{get;set;}
        public string BuidingCode { get; set; }
        public string AreaCode { get; set; }
        public string ObjectCode { get; set; }
        public string BuidingName { get; set; }
        public string AreaName { get; set; }
        public string ObjectName { get; set; }
    }
}
