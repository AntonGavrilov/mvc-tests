using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAppTestSMS.Startup))]
namespace WebAppTestSMS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
