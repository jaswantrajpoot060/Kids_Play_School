using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ipschool.Startup))]
namespace Ipschool
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
