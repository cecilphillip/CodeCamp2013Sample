using System.Linq;
using System.Reflection;
using System.Web.Compilation;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using CodeCamp2013.WebApi.Data;
using CodeCamp2013.WebApi.Models;
    

namespace CodeCamp2013.WebApi.App_Start
{
    public class IocConfig
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();
            var assemblies = BuildManager.GetReferencedAssemblies().Cast<Assembly>();

            // Register API controllers using assembly scanning.
            builder.RegisterApiControllers(assemblies.ToArray());

            builder.RegisterType<EventRepository>().As<IRepository<Event>>().InstancePerApiRequest();
            builder.RegisterType<EventsDemoContext>().AsSelf().InstancePerApiRequest();
            builder.RegisterType<EventsService>().As<IEventsService>().InstancePerApiRequest();


            var container = builder.Build();
            // Set the dependency resolver implementation.
            var resolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }
    }
}