using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Videop.Startup))]
namespace Videop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
