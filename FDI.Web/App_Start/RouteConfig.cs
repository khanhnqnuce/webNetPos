using System.Web.Mvc;
using System.Web.Routing;

namespace FDI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("login", "dang-nhap", new { controller = "Login", action = "Index" });
            routes.MapRoute("naptien", "nap-tien", new { controller = "Home", action = "Xemdiem" });
            routes.MapRoute("trutien", "tru-tien", new { controller = "Home", action = "Dangky" });
            routes.MapRoute("doimatkhau", "doi-mat-khau", new { controller = "Home", action = "ChangePass" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute("Ajax", "Ajax/{Controller}/{action}", new { controller = "Home", action = "Index" }, new[] { "QLSV.Controllers" });
        }
    }
}