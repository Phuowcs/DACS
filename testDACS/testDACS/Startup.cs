using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(testDACS.Startup))]
namespace testDACS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
