using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ImageServices.Startup))]
namespace ImageServices
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
