using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MinistrySuite.Web.Startup))]
namespace MinistrySuite.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
