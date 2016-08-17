using System;

namespace FDI.Simple
{
    [Serializable]
    public class BaseSimple
    {
        public int ID { get; set; }        
    }

    public class BaseModelSimple
    {
        public string PageHtml { get; set; }
        public string Container { get; set; }
        public string StbHtml { get; set; }
        public bool SelectMutil { get; set; }
        public int Type { get; set; }
        public int pageId { get; set; }

        public string ValuesSelected { get; set; }
        public SystemActionItem SystemActionItem { get; set; }
    }

}
