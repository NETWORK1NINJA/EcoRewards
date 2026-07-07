using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EcoRewards.Startup))]
namespace EcoRewards
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
