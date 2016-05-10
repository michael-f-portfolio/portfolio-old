using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Portfolio
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("Home", "", new {controller = "Home", action = "Index"});
            routes.MapRoute("About", "about", new {controller = "Home", action = "About"});
            routes.MapRoute("Contact", "contact", new {controller = "Home", action = "contact"});

            routes.MapRoute("Long-Page-Layout", "long-page-layout", new {controller = "Home", action = "LongPageLayout"});
            routes.MapRoute("Three-Column-Layout", "three-column-layout", new {controller = "Home", action = "ThreeColumnLayout"});
        }
    }
}
