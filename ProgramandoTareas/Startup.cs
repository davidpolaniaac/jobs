using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProgramandoTareas.Startup))]
namespace ProgramandoTareas
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
