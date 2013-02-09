using System;
using System.Data.Entity;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.SelfHost;
using Autofac;
using Autofac.Integration.WebApi;
using CodeCamp2013.WebApi.SelfHost.Data;
using CodeCamp2013.WebApi.SelfHost.Models;

namespace CodeCamp2013.WebApi.SelfHost
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var config = new HttpSelfHostConfiguration("http://localhost:8080");

            config.Routes.MapHttpRoute("API Default", "api/{controller}/{action}");
            SetupIoc(config);
            Database.SetInitializer(new EventsDemoSeedInitializer()); 
            using (var server = new HttpSelfHostServer(config))
            {
                server.OpenAsync().Wait();
                Console.WriteLine("Press Enter to quit.");
                Console.ReadLine();
            }
        }

        private static void SetupIoc(HttpSelfHostConfiguration config)
        {
            var builder = new ContainerBuilder();
            var assembly = Assembly.GetExecutingAssembly();

            // Register API controllers using assembly scanning.
            builder.RegisterApiControllers(assembly);

            builder.RegisterType<EventRepository>().As<IRepository<Event>>().InstancePerApiRequest();
            builder.RegisterType<EventsDemoContext>().AsSelf().InstancePerApiRequest();
            builder.RegisterType<EventsService>().As<IEventsService>().InstancePerApiRequest();

            var container = builder.Build();
            // Set the dependency resolver implementation.
            var resolver = new AutofacWebApiDependencyResolver(container);
            config.DependencyResolver = resolver;
        }
    }
}
