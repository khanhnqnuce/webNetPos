namespace FDI.Simple
{
    public class CardTypeItem : BaseSimple
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int Discount { get; set; }
        public string Desc { get; set; }
        public bool IsMemberCard { get; set; }
        public int PointLevel { get; set; }
    }
}
