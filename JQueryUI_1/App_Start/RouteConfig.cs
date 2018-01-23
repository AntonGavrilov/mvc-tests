using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace JQueryUI_1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

           // routes.MapMvcAttributeRoutes();
           
            routes.MapRoute(
                name: "UserPassword",
                url: "users/{id}/password",
                defaults: new { controller = "Users", action = "getPassword" }
            );

            routes.MapRoute(
                name: "UserRoles",
                url: "users/{id}/roles",
                defaults: new { controller = "Users", action = "getRoles" }
            );


            routes.MapRoute(
                name: "userById",
                url: "users/{id}",
                defaults: new { controller = "Users", action = "GetUser" }
            );

            routes.MapRoute(
                name: "AllUsers",
                url: "users",
                defaults: new { controller = "Users", action = "getUsers", id = UrlParameter.Optional }
            );
            
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index" }
                );
        }
    }
}
