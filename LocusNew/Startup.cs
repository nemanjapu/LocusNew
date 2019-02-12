using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LocusNew.Startup))]
namespace LocusNew
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
