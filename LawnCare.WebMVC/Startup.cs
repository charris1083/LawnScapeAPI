using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LawnCare.WebMVC.Startup))]
namespace LawnCare.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
