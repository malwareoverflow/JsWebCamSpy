using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JsWebCamCapture.Startup))]
namespace JsWebCamCapture
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
