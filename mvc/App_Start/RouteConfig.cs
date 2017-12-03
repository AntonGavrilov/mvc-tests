using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using mvc.RouteHandlers;

namespace mvc
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            /*            
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "mvc.Controllers" }
            );
            */
            /*
            routes.MapRoute(
                name: "Default2",
                url: "{id}/{name}",
                defaults: new { controller = "Home", action = "Test" },
                constraints: new { id=@"\d+" }
                );
            */

            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "author",
                url: "book/{id}/author",
                defaults: new { controller = "Home", action = "GetAuthor" }
                );

            routes.MapRoute(
                name: "book",
                url: "book/{id}",
                defaults: new { controller = "Home", action = "GetBook" }
                );

            routes.MapRoute(
                name: "Default1",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "index", id = UrlParameter.Optional }
                );



            /*
            Route newRoute = new Route("{contriller}/{action}", new MyRouteHandler());
            routes.Add(newRoute);
            */
        }
    }
}
