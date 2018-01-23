using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IndetityApp.Startup))]
namespace IndetityApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
