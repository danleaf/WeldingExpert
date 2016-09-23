using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WeldingExpertSystem.Startup))]
namespace WeldingExpertSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
