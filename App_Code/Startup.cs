using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Stock_Trade.Startup))]
namespace Stock_Trade
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
