using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GESCOM.Startup))]
namespace GESCOM
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
