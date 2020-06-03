using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Mvc_ControlePedido.Startup))]
namespace Mvc_ControlePedido
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
