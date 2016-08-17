namespace FDI.Utils
{
    public enum AdvertisingPosition
    {

        LeftRight = 2,
        BannerLayout = 1,
        SlideHome = 4,
        SlideHomeProduct = 6,
        SocialNetworking = 5,
        SupportOnline = 7,
        Advertising = 8,
        Videohome = 8,
        QuangCaoTrangChu = 9,
        SliderLogin = 10,
    }

    public enum ModuleType
    {
        News = 1,
        Product = 2,
        Document = 3,
        Gallery = 4,
        Video = 5,
        FAQ = 6,
    }

    public enum BackgroundNoiseLevel
    {
        None = 0,
        Low = 1,
        Medium = 2,
        High = 3,
        Extreme = 4,
    }

    public enum FontWarpFactor
    {
        None = 0,
        Low = 1,
        Medium = 2,
        High = 3,
        Extreme = 4,
    }

    public enum LineNoiseLevel
    {
        None = 0,
        Low = 1,
        Medium = 2,
        High = 3,
        Extreme = 4,
    }

    public enum PermisionType
    {
        NoPermission = 0,
        InheritFromParent = 1,
        PermisionItself = 2,
    }

    public enum SlideType
    {
        MainSlide = 4,
        AdvertiseRight = 5,
        AdvertiseLeft = 6,
        SliderPartner = 2,
        AdvertHome = 7,
        DanhbaWebsite = 9,
    }

    public enum MyEnum
    {
        Document = 82,
        LegalDocuments = 107
    };

    public enum MenuType
    {
        MenuTop = 1,
        MenuFooter = 2,
        MainMenu = 3,
        MenuLeft = 4,
        MenuHeader = 6,
        MenuTopFooter = 5,
    }

    // Product

    public enum OrderStatus : int
    {
        Pending = 1,    // đang chờ
        Processing = 2, // đang xư lý
        Complete = 3,   // đã hoàn thành
        Cancelled = 4,  // đã hủy
        Refunded = 5,   // trả hàng
    }

    public enum TypeSendMail : int
    {
        InfoPayment = 1,    // gửi mail cho admin thông tin mua hàng của khách
        OrderCustomer = 2    // gửi thông tin đơn hàng cho khách hàng
    }

    public enum Filter : int
    {
        age = 1,
        weight = 2,
        sex = 3
    }
}
