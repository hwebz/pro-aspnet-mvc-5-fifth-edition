using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Routing.Constraints;
using System.Web.Routing;
using UrlsAndRoutes.Infrastructure;

namespace UrlsAndRoutes
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute("ShopSchema2", "Shop/OldAction", new { controller = "Home", action = "Index" });

            //routes.MapRoute("ShopSchema", "Shop/{action}", new { controller = "Home" });

            //routes.MapRoute("", "X{controller}/{action}");

            ////routes.MapRoute(
            ////    name: "Default",
            ////    url: "{controller}/{action}/{id}",
            ////    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            ////);

            ////Route myRoute = new Route("{controller}/{action}", new MvcRouteHandler());
            ////routes.Add("MyRoute", myRoute);

            ////routes.MapRoute("MyRoute", "{controller}/{action}");
            ////routes.MapRoute("MyRoute", "{controller}/{action}", new { action = "Index" });
            //routes.MapRoute("MyRoute", "{controller}/{action}", new { controller = "Home", action = "Index" });

            //routes.MapRoute("", "Public/{controller}/{action}", new { controller = "Home", action = "Index" });

            //routes.MapRoute("MyRoute", "{controller}/{action}/{id}", new { controller = "Home", action = "Index", id = "DefaultId" });
            //routes.MapRoute("MyRoute", "{controller}/{action}/{id}", new { controller = "Home", action = "Index", id = UrlParameter.Optional });

            // default varibal-length routes
            //routes.MapRoute("MyRoute", "{controller}/{action}/{id}/{*catchall}",
            //    new
            //    {
            //        controller = "Home",
            //        action = "Index",
            //        id = UrlParameter.Optional
            //    }, new[] { "UrlsAndRoutes.AdditionalControllers", "UrlsAndRoutes.Controllers" }); // error because Route scan all namespaces

            //Route myRoute = routes.MapRoute("AddControllerRoute", "Home/{action}/{id}/{*catchall}",
            //    new
            //    {
            //        controller = "Home",
            //        action = "Index",
            //        id = UrlParameter.Optional
            //    }, new[] { "UrlsAndRoutes.AdditionalControllers" });
            //myRoute.DataTokens["UseNamespaceFallback"] = false;

            //routes.MapRoute("MyRoute", "{controller}/{action}/{id}/{*catchall}",
            //    new
            //    {
            //        controller = "Home",
            //        action = "Index",
            //        id = UrlParameter.Optional
            //    }, new[] { "UrlsAndRoutes.Controllers" });

            //routes.MapRoute("MyRoute", "{controller}/{action}/{id}/{*catchall}",
            //        new { controller = "Home", action = "Index", id = UrlParameter.Optional },
            //        new {
            //            controller = "^H.*",
            //            action = "^Index$|^About$",
            //            httpMethod = new HttpMethodConstraint("GET", "POST"),
            //            //id = new RangeRouteConstraint(10, 20)
            //            id = new CompoundRouteConstraint(new IRouteConstraint[]
            //            {
            //                new AlphaRouteConstraint(),
            //                new MinLengthRouteConstraint(6)
            //            })
            //        },
            //        new[] { "UrlsAndRoutes.Controllers" });

            //routes.MapRoute("ChromeRoute", "{*catchall}",
            //    new { controller = "Home", action = "Index" },
            //    new { customConstraint = new UserAgentConstraint("Chrome") },
            //    new[] { "UrlsAndRoutes.AdditionalControllers" });

            //routes.MapRoute("MyRoute", "{controller}/{action}/{id}/{*catchall}",
            //    new { controller = "Home", action = "Index", id = UrlParameter.Optional },
            //    new
            //    {
            //        controller = "^H.*",
            //        action = "Index|About",
            //        httpMethod = new HttpMethodConstraint("GET"),
            //        id = new CompoundRouteConstraint(new IRouteConstraint[]
            //        {
            //            new AlphaRouteConstraint(),
            //            new MinLengthRouteConstraint(6)
            //        })
            //    },
            //    new[] { "UrlsAndRoutes.Controllers" });

            // enable attribute routing
            routes.MapMvcAttributeRoutes();

            routes.MapRoute("Default", "{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new[] { "UrlsAndRoutes.Controllers" });
        }
    }
}
