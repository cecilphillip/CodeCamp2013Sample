using System.Web.Http;
using System.Web.Optimization;
using CodeCamp2013.WebApi.App_Start;
using CodeCamp2013.WebApi.Data;

namespace CodeCamp2013.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            EventData.Initialize();
            IocConfig.Configure();
        }
    }
}