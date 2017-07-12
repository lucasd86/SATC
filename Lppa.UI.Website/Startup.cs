using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lppa.UI.Website.Startup))]
namespace Lppa.UI.Website
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
