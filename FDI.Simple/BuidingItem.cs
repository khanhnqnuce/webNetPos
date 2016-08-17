using System.Collections.Generic;

namespace FDI.Simple
{
    public class BuidingItem : BaseSimple
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
    }

    public class ModelBuidingItem
    {
        public List<BuidingItem> LstBuidingItems { get; set; }
        public List<AreaItem> LstAreaItems { get; set; }
        public List<ObjectItem> LstObjectItems { get; set; }
    }
}
