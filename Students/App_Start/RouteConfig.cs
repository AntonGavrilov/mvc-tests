using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Students
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.IgnoreRoute("Home/Edit/");
            /*
            routes.MapRoute(
                name: "Default123123",
                url: "students/list",
                defaults: new { controller = "Home", action = "index" });
            */
            routes.MapRoute(
                            name: "Default",
                            url: "{controller}/{action}/{id}",
                            defaults: new { controller = "Home", action = "Index" },
                            constraints: new { id = @"\d{2}", myConstraint = new CustomConstraint("/Home/Edit/1") });

            routes.MapRoute(
                name: "Default334",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "index", id = UrlParameter.Optional});
            
            routes.MapRoute(
                name: "Default33",
                url: "{controller}/{action}/{id}/{name}",
                defaults: new {id = UrlParameter.Optional, name = UrlParameter.Optional });
               
            routes.MapRoute(
                name: "Default2",
                url: "Ru{controller}/{action}/{Id}",
                defaults: new { id = UrlParameter.Optional });
            

            /*
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{Id}",
                defaults: new { id = UrlParameter.Optional });
           */


        }
    }
}
