using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UnitTestApp.Startup))]
namespace UnitTestApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
