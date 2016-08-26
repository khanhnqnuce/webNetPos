using System;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace FDI.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            //RegisterRoutesStart(RouteTable.Routes);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();

            //Application["count_visit"] = 0;
            //Application["online"] = 0;

        }

        void Session_Start(object sender, EventArgs e)
        {
            //var countVisit = 0;
            //Application["online"] = (int)Application["online"] + 1;

            ////Kiểm tra file count_visit.txt nếu không tồn  tại thì
            //if (System.IO.File.Exists(Server.MapPath("~/count.txt")) == false)
            //{
            //    countVisit = 1;
            //}
            //// Ngược lại thì
            //else
            //{
            //    // Đọc dử liều từ file count_visit.txt
            //    var read = new System.IO.StreamReader(Server.MapPath("~/count.txt"));
            //    countVisit = int.Parse(read.ReadLine());
            //    read.Close();
            //    // Tăng biến count_visit thêm 1
            //    countVisit++;
            //}
            //// khóa website
            //Application.Lock();

            //// gán biến Application count_visit
            //Application["count_visit"] = countVisit;

            //// Mở khóa website
            //Application.UnLock();

            //// Lưu dử liệu vào file  count_visit.txt
            //var writer = new System.IO.StreamWriter(Server.MapPath("~/count.txt"));
            //writer.WriteLine(countVisit);
            //writer.Close();

        }

        void Session_End(object sender, EventArgs e)
        {
            //Application["online"] = (int)Application["online"] - 1;
        }


        
        //protected void Application_BeginRequest(object sender, EventArgs e)
        //{
        //    //RegisterRoutes(RouteTable.Routes);

        //    //AreaRegistration.RegisterAllAreas();

        //    var culture = "vi";//ngon ngu mac dinh
        //    var httpCookie = Request.Cookies["LanguageId"];
        //    if (httpCookie != null)
        //    {
        //        culture = httpCookie.Value;
        //    }
        //    else
        //    {
        //        var language = new HttpCookie("LanguageId") { Value = culture, Expires = DateTime.Now.AddDays(1) };
        //        Response.Cookies.Add(language);
        //    }
        //    System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo(culture);
        //    System.Threading.Thread.CurrentThread.CurrentUICulture = System.Threading.Thread.CurrentThread.CurrentCulture;
        //}

    }

}