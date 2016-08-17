using System.Drawing;
using System.Web;

namespace FDI.Utils
{
    public static class ConfigData
    {
        public static int USERGUIDE_PERPAGE = 30;
        public static int USERGUIDE_OTHER = 10;
        public static int USERGUIDE_PAGE_STEP;

        public static Size IMAGE_FULL_FILE = new Size(1920, 1920);
        public static Size IMAGE_RESIZE_FILE = new Size(100, 100);
        public static Size IMAGE_THUMBS_SIZE_AVARTAR = new Size(200, 200);
        public static Size IMAGE_MEDIUM_FILE = new Size(100, 640);
        public static Size IMAGE_AVARTAR_FILE = new Size(300, 300);
        public static Size IMAGE_IMAGES_FILE = new Size(640, 640);
        public static Size IMAGE_THUMBS_SIZE = new Size(192, 192);

        public static string IMAGE_UPLOAD_FOLDER = HttpContext.Current.Server.MapPath("/Uploads/");
        public static string IMAGE_UPLOAD_TEMP_FOLDER = HttpContext.Current.Server.MapPath("/Uploads/Temp/");
        public static string IMAGE_UPLOAD_ROOT_FOLDER = HttpContext.Current.Server.MapPath("/Uploads/Root/");
        public static string IMAGE_UPLOAD_THUMBS_FOLDER = HttpContext.Current.Server.MapPath("/Uploads/Thumbs/");
        public static string IMAGE_UPLOAD_AVATAR_FOLDER = HttpContext.Current.Server.MapPath("/Uploads/Avatar/");
        public static string IMAGE_UPLOAD_ORIGINAL_FOLDER = HttpContext.Current.Server.MapPath("/Uploads/Originals/");
        public static string IMAGE_UPLOAD_MEDIUM_FOLDER = HttpContext.Current.Server.MapPath("/Uploads/Mediums/");
        public static string IMAGE_UPLOAD_IMAGES_FOLDER = HttpContext.Current.Server.MapPath("/Uploads/images/");
        public static string IMAGE_UPLOAD_OUTOFSOTCK_FOLDER = HttpContext.Current.Server.MapPath("/Uploads/OutOfStocks/");
        public static string IMAGE_UPLOAD_FOLDER_DOCUMENT = HttpContext.Current.Server.MapPath("/Uploads/Document/");

        public static string IMAGE_UPLOAD_URL = "/Uploads/";
        public static string IMAGE_UPLOAD_TEMP_URL = "/Uploads/Temp/";
        public static string IMAGE_UPLOAD_THUMBS_URL = "/Uploads/Thumbs/";
        public static string IMAGE_UPLOAD_ORIGINAL_URL = "/Uploads/Originals/";
        public static string IMAGE_UPLOAD_MEDIUM_URL = "/Uploads/Mediums/";
        public static string IMAGE_UPLOAD_IMAGES_URL = "/Uploads/images/";
        public static string IMAGE_UPLOAD_OUTOFSOTCK_URL = "/Uploads/OutOfStocks/";
        public static string IMAGE_WATERMARK = "Hoàng Hà Mobile";

        public static string COPY_RIGHT = "Copyright © 2014  ";
        public static string WEB_TITLE = " .com.vn";
        public static string WEB_DESCRIPTION = " .com.vn - ĐTDD, Laptop, Máy tính bảng, ...Chính hãng.";
        public static string WEB_VERSION = " ";

        public static int ROW_PER_PAGE = 25;
        public static int PAGE_STEP = 3;

        public static int NEWS_PER_PAGE = 10;
        public static int NEWS_PAGE_STEP = 3;
        public static int NEWS_HOT_BOX = 10;
        public static int NEWS_OTHER_BOX = 10;
        public static int NEWS_RIGHT_BOX = 8;

        public static int MOBILE_PER_PAGE = 15;
        public static int MOBILE_PAGE_STEP = 3;
        public static int MOBILE_HOT_BOX = 5;
        public static int MOBILE_HOT_BOX_LEVEL2 = 3;
        public static int MOBILE_OTHER = 10;
        public static int MOBILE_OTHER_BOX = 10;


        public static int DEVICE_PER_PAGE = 10;
        public static int DEVICE_PAGE_STEP = 3;
        public static int DEVICE_HOT_BOX = 10;
        public static int DEVICE_OTHER_BOX = 10;

        public static int COMMENT_PER_PAGE = 10;
        public static int COMMENT_PAGE_STEP = 3;


        public static string URLR_REWRITE_EXT = ".aspx";

        public static string HEADER_FORM_REQUIRED = "Các trường có dấu <span class=\"star\">*</span> bắt buộc phải nhập.";
    }
}