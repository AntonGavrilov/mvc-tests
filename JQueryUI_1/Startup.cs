using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JQueryUI_1.Startup))]
namespace JQueryUI_1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
