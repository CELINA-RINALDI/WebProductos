using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebProducts
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index"}
            );

            routes.MapRoute(
                name: "IndexByCategory",
                url: "{controller}/{action}/{category}/{name}",
                defaults: new
                {
                    controller = "Product",
                    action = "Index",
                    category = UrlParameter.Optional,
                    name = UrlParameter.Optional
                }

                );
        }
    }
}
