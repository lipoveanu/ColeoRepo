using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ColeoWeb.Startup))]
namespace ColeoWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
