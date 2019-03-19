using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Routing.Constraints;
using System.Web.Routing;
using AdvancedUrlsAndRoutes.Infrastructure;
using UrlsAndRoutes.Infrastructure;

namespace AdvancedUrlsAndRoutes
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.RouteExistingFiles = true; // routes evaluated before disk files checking
            routes.MapMvcAttributeRoutes();

            //routes.MapRoute("NewRoute", "App/Do{action}", new { controller = "Home" });

            //routes.MapRoute("MyRoute", "{controller}/{action}/{id}",
            //    new
            //    {
            //        controller = "Home",
            //        action = "Index",
            //        id = UrlParameter.Optional
            //    });

            // find UrlRoutingModule-4.0 in applicationhost.config (IIS config file) and replace preCondition="" to make routes works
            //routes.MapRoute("DiskFile", "Content/StaticContent.html",
            //    new
            //    {
            //        controller = "Customer",
            //        action = "List"
            //    });

            routes.IgnoreRoute("Content/{filename}.html");

            routes.Add(new Route("SayHello", new CustomRouteHandler()));

            routes.Add(new LegacyRoute(
                    "∼/articles/Windows_3.1_Overview.html",
                    "∼/old/.NET_1.0_Class_Library"));

            routes.MapRoute("MyRoute", "{controller}/{action}", null, new[] { "AdvancedUrlsAndRoutes.Controllers" });
            routes.MapRoute("MyOtherRoute", "App/{action}", new { controller = "Home" }, new[] { "AdvancedUrlsAndRoutes.Controllers" });
        }
    }
}
