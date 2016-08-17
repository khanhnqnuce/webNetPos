using System.Configuration;

namespace FDI.Utils
{
    public class WebConfig
    {
        public static string AdminUrl = ConfigurationManager.AppSettings["AdminUrl"].ToLower();
        public static string ListAdmin = ConfigurationManager.AppSettings["ListAdmin"].ToLower();
        public static string UrlOriginalImage = ConfigurationManager.AppSettings["URLOriginalImage"];
        public static string UrlImagePromotion = ConfigurationManager.AppSettings["URLImagePromotion"];
        public static string UrlImage = ConfigurationManager.AppSettings["URLImage"];
        public static string RootUrlImage = ConfigurationManager.AppSettings["RootURLImage"];
        public static string Urltail = ConfigurationManager.AppSettings["URLtail"];
        public static string CustomerId = ConfigurationManager.AppSettings["customerID"];
        public static string UserName = ConfigurationManager.AppSettings["UserName"];
        public static string CustomerAvatar = ConfigurationManager.AppSettings["customerAvatar"];
        public static string SessionTimeout = ConfigurationManager.AppSettings["sessionTimeout"];
        public static string ModuleArea = ConfigurationManager.AppSettings["ModuleArea"];
        public static string DocumentDetail = ConfigurationManager.AppSettings["DocumentDetails"];
        //FQA
        public static string FaqId = ConfigurationManager.AppSettings["FAQId"];
        public static string FaqDetail = ConfigurationManager.AppSettings["FAQDetail"];
        public static string FaqQuestion = ConfigurationManager.AppSettings["FAQQuestion"];
        public static string FaqSearch = ConfigurationManager.AppSettings["FAQSearch"];
        //News
        public static string NewsId = ConfigurationManager.AppSettings["NewsId"];
        public static string NewsDetail = ConfigurationManager.AppSettings["NewsDetail"];
        public static string News = ConfigurationManager.AppSettings["News"];
        public static string NewsCate = ConfigurationManager.AppSettings["NewsCate"];
        //Products
        public static string UrlPage = ConfigurationManager.AppSettings["UrlPage"];
        public static string PageId = ConfigurationManager.AppSettings["Product"];
        public static string PageIdD = ConfigurationManager.AppSettings["ProductDetail"];
       //video
        public static string VideoId = ConfigurationManager.AppSettings["VideoId"];
        public static string VideoDetail = ConfigurationManager.AppSettings["VideoDetail"];

        public static string GetAppSettings(string name)
        {
            return ConfigurationManager.AppSettings[name];
        }
    }
}
