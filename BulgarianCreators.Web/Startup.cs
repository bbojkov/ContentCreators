using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BulgarianCreators.Web.Startup))]
namespace BulgarianCreators.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
