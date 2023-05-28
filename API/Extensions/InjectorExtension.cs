using Business.Entitites.Settings;
using Domain.Services;
using Infrastructure.ExternalWebServices;
using Infrastructure.Repositories;

namespace API.Extensions
{
    internal static class InjectorExtension
    {
        internal static void AddDependencys(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<GlobalAppSettings>();

            //Services
            services.AddScoped<IBasicService, BasicService>();
            services.AddScoped<IFlightService, FlightService>();

            //Infra
            services.AddScoped<IBasicRepository, BasicRepository>();
            services.AddScoped<IConsumeRepository, ConsumeRepository>();
        }
    }
}
