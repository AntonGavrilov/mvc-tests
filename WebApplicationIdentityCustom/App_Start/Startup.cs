using Microsoft.Owin;
using Owin;
using WebApplicationIdentityCustom.Models;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity;


[assembly: Microsoft.Owin.OwinStartup(typeof(WebApplicationIdentityCustom.App_Start.Startup))]

namespace WebApplicationIdentityCustom.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext<ApplicationContext>(ApplicationContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);

            app.CreatePerOwinContext<ApplicationRoleManager>(ApplicationRoleManager.Create);

            app.UseCookieAuthentication(new CookieAuthenticationOptions {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });
        }
    }
}