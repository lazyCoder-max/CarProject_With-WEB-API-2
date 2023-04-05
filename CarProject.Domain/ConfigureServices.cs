using CarProject.Domain;
using CarProject.Domain.Entities;

namespace SimpleInjector.Integration.WebApi
{
    public static class ConfigureServices
    {
        public static Container AddDomainServices(this Container services)
        {
            services.Register<ICar, Car>();
            return services;
        }
    }
}
