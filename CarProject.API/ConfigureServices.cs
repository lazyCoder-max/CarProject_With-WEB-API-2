

using System.Web.Http;

namespace SimpleInjector.Integration.WebApi
{
    public static class ConfigureServices
    {
        public static Container AddAPIServices(this Container container)
        {
            container.AddCarServices();

            // Register Web API controllers
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            // Verify the container's configuration
            container.Verify();

            // Set the dependency resolver for Web API
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);

            return container;
        }
    }
}
