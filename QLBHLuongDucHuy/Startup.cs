using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QLBHLuongDucHuy.Startup))]
namespace QLBHLuongDucHuy
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
