using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PageList.Startup))]
namespace PageList
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
