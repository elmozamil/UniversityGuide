using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UniGuide.Startup))]
//[assembly: OwinStartup(typeof(UniGuide.Startup))]
namespace UniGuide
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
