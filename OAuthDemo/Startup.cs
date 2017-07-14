using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OAuthDemo.Startup))]
namespace OAuthDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
