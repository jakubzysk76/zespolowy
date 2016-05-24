using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(zapisy.Startup))]
namespace zapisy
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
