using System;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Hosting;
using System.Web.Http.Routing;

namespace CodeCamp2013.WebApi.Tests
{
    public class WebApiTestHelper
    {
        public static void SetupController(ApiController controller, string endpoint)
        {
            var config = new HttpConfiguration();
            var controllerName = controller.ControllerContext.ControllerDescriptor.ControllerName;
            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost/api/" + endpoint);
            var route = config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{action}");
            var routeData = new HttpRouteData(route, new HttpRouteValueDictionary { { "controller", controllerName } });

            controller.ControllerContext = new HttpControllerContext(config, routeData, request);
            controller.Request = request;
            controller.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = config;
        }


        public static void SetupController(ApiController controller, HttpRequestMessage req, string endpoint)
        {
            var config = new HttpConfiguration();
            var request = req;
            var controllerName = controller.ControllerContext.ControllerDescriptor.ControllerName;
            var route = config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{action}");
            var routeData = new HttpRouteData(route, new HttpRouteValueDictionary { { "controller", controllerName } });

            controller.ControllerContext = new HttpControllerContext(config, routeData, request);
            controller.Request = request;
            controller.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = config;
        }

        public static HttpServer ConfigureServer()
        {
            var config = new HttpConfiguration();
            return ConfigureServer(config);
        }

        public static HttpServer ConfigureServer(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{action}");
            config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
            return new HttpServer(config);
        }


        public static HttpRequestMessage CreateRequest(string url, string mediaType, HttpMethod method)
        {
            var request = new HttpRequestMessage { RequestUri = new Uri("http://localhost/" + url) };
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));
            request.Method = method;

            return request;
        }

        public static HttpRequestMessage CreateRequest<T>(string url, string mediaType, HttpMethod method, T content, MediaTypeFormatter formatter) where T : class
        {
            HttpRequestMessage request = CreateRequest(url, mediaType, method);
            request.Content = new ObjectContent<T>(content, formatter);

            return request;
        }
    }
}
