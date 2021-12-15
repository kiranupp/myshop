using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyShops.WebUI.Startup))]
namespace MyShops.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
