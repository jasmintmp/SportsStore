using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //when request come from following URL: /CategoryFootballPage2
            //call ProductController.List(category="Football", page=2)
            //routes.MapRoute(
            //    name: null,
            //    url: "Category{category}Page{page}",
            //    defaults: new { controller = "Product", action = "List", category = (string)null, page = 1 }
            //    );
            routes.MapRoute(
                null,"",
                defaults: new { controller = "Product", action = "List", category = (string)null, page = 1 }
                );

            routes.MapRoute(
               null, "Page{page}",
               new { controller = "Product", action = "List", category = (string)null }, new { page = @"\d+" } );

            routes.MapRoute(
            null, "{category}",
            new { controller = "Product", action = "List", page = 1});

            routes.MapRoute(
            null, "{category}/Page{page}",
            new { controller = "Product", action = "List" }, new { page = @"\d+" });

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Product", action = "List", id = UrlParameter.Optional }
            //);
            routes.MapRoute(null, "{controller}/{action}");
            
        }
    }
}
