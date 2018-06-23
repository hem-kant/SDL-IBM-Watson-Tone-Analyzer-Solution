using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SDL.IBM.Tone.Analyzer.WEBApp.Startup))]
namespace SDL.IBM.Tone.Analyzer.WEBApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
