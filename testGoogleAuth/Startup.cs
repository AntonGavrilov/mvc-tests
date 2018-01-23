using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(testGoogleAuth.Startup))]
namespace testGoogleAuth
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
