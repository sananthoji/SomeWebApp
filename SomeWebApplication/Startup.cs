using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SomeWebApplication.Startup))]
namespace SomeWebApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
