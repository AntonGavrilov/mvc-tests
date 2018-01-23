using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Principal;

namespace mvc.Filters
{
    public class MyAuthorizeAttribute : AuthorizeAttribute
    {
        private List<string> allowedUsers = new List<string>();
        private List<string> allowedRoles = new List<string>();

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            this.FillAllowedData();

            return httpContext.Request.IsAuthenticated
                && IsUserAllowed(httpContext.User)
                && IsRoleAllowed(httpContext.User);      
        }

        private bool IsRoleAllowed(IPrincipal user)
        {
            bool check = false;

            check = (allowedRoles
                .Where(e => user.IsInRole(e))
                .Count() > 0);

            return check;
        }

        private bool IsUserAllowed(IPrincipal user)
        {
            if (allowedUsers.Count > 0)
            {
                return allowedUsers.Contains(user.Identity.Name);
            }

            return true;
        }

        private void FillAllowedData()
        {
            if (!String.IsNullOrEmpty(base.Users))
            {
                allowedUsers = base.Users.Split(new char[] { ',' }).ToList();
                allowedUsers.ForEach(e => e.Trim());
            }

            if (!String.IsNullOrEmpty(base.Roles))
            {
                allowedRoles = base.Roles.Split(',').ToList();
                allowedRoles.ForEach(e => e.Trim());
            }
        }

    }
}