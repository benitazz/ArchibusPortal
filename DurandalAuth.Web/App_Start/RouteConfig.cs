#region

using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

#endregion

namespace DurandalAuth.Web
{
    public static class RouteConfig
    {
        public static void RegisterWebApiRoutes(HttpConfiguration config)
        {
            //Use web api routing
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new { id = RouteParameter.Optional });

            config.Routes.MapHttpRoute("BreezeDefault", "breeze/{action}", new { Controller = "Metadata" });

            config.Routes.MapHttpRoute("BreezeModule", "breeze/{controller}/{action}");

            config.EnableQuerySupport();
        }

        public static void RegisterMVCRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("Sitemap", "sitemap", new { controller = "Sitemap", action = "Sitemap" });

            routes.MapRoute("Default", "{*url}", new { controller = "Home", action = "Index" });
        }
    }
}