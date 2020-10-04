using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MagicEnglish.Startup))]
namespace MagicEnglish
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
