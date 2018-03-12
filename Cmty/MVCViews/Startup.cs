using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCViews.Startup))]
namespace MVCViews
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
