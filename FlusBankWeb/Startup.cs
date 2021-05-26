using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FlusBankWeb.Startup))]
namespace FlusBankWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
