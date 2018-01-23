using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Claims;


namespace WebApplicationClaimsBasedAuth.Util
{
    public class ClaimsAuthorizeAttribure : AuthorizeAttribute
    {
        public int Age { get; set; }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            ClaimsIdentity claimsIdentity;

            if (!httpContext.User.Identity.IsAuthenticated)
                return false;

            claimsIdentity = httpContext.User.Identity as ClaimsIdentity;

            var yearClaims = claimsIdentity.FindFirst("Year");

            int  year;

            if (!Int32.TryParse(yearClaims.Value, out year))
                return false;

            if ((DateTime.Now.Year - year) < this.Age)
            {
                httpContext.Response.StatusCode = 403;
                return false;
            }

            return base.AuthorizeCore(httpContext);
        }
    }
}