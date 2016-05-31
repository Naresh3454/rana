using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebApiRouting.Startup))]
namespace WebApiRouting
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
