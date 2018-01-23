using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RoleTest.Startup))]
namespace RoleTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
