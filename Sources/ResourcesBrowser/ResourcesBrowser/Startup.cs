using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ResourcesBrowser.Startup))]
namespace ResourcesBrowser
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
