using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Starter.Startup))]
namespace Starter
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
