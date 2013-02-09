using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using CodeCamp2013.WebApi.Formatters;
using CodeCamp2013.WebApi.Mesagehandlers;

namespace CodeCamp2013.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{action}");
            config.Formatters.Add(new EventCsvFormatter());
            config.MessageHandlers.Add(new CustomHeaderHandler());

            //config.EnableQuerySupport();
            config.EnableSystemDiagnosticsTracing();
        }
    }
}
