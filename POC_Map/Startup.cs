using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(POC_Map.Startup))]
namespace POC_Map
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
