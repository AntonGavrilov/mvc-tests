using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Mvc;

namespace Students
{
    public class CustomConstraint : IRouteConstraint
    {
        private string uri;


        public CustomConstraint(string uri)
        {

        }

        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            return !(uri == httpContext.Request.Url.AbsolutePath);
        }
    }
}