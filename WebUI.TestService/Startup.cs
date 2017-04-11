using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebUI.TestService.Startup))]
namespace WebUI.TestService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
