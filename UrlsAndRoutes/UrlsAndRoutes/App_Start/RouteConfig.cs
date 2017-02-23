using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Mvc.Routing.Constraints;
using UrlsAndRoutes.Infrastructure;

namespace UrlsAndRoutes
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            /* - Default routing
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            */

            /* - Registering a simple Route ( тест - (1) )
            Route myRoute = new Route("{controller}/{action}", new MvcRouteHandler());
            routes.Add("MyRoute", myRoute);
            */

            // Registering a Route Using the MapRoute Method

            /* - пример окончен ( тест - (2) )
            routes.MapRoute("ShopSchema2", "Shop/OldAction",
                new { controller = "Home", action = "Index" });

            routes.MapRoute("ShopSchema", "Shop/{action}",
                new { controller = "Home" });

            routes.MapRoute("", "X{controller}/{action}");

            routes.MapRoute("", "Public/{controller}/{action}",
                new { controller = "Home", action = "Index" });

            routes.MapRoute("MyRoute", "{controller}/{action}", 
                new { controller = "Home", action = "Index" });
            */

            /* - тест (3)
            routes.MapRoute("MyRoute", "{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional });
            */

            /* - тест (4)
            routes.MapRoute("AddControllerRoute", "Home/{action}/{id}/{*catchall}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new[] { "URLsAndRoutes.AdditionalControllers" });

            routes.MapRoute("MyRoute", "{controller}/{action}/{id}/{*catchall}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new[] { "URLsAndRoutes.Controllers" });
            */

            /*
            Route myRoute = routes.MapRoute("AddControllerRoute", "Home/{action}/{id}/{*catchall}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new[] { "URLsAndRoutes.AdditionalControllers" });

            myRoute.DataTokens["UseNamespaceFallback"] = false;
            */

            /* - тест (5)
            routes.MapRoute("ChromeRoute", "{*catchall}",
                new { controller = "Home", action = "Index" },
                new { customConstraint = new UserAgentConstraint("Chrome") },
                new[] { "URLsAndRoutes.AdditionalControllers" });

            routes.MapRoute("MyRoute", "{controller}/{action}/{id}/{*catchall}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new { controller = "^H.*", action = "^Index$|^About$",
                      httpMethod = new HttpMethodConstraint("GET"),
                      id = new CompoundRouteConstraint(new IRouteConstraint[] {
                          new AlphaRouteConstraint(), new MinLengthRouteConstraint(6) })
                    },
                new[] { "URLsAndRoutes.Controllers" });
            */

            routes.MapMvcAttributeRoutes();

            routes.MapRoute("Default", "{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new[] { "URLsAndRoutes.Controllers" });
        }
    }
}
