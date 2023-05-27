using Business.Entitites.Settings;
using Domain.Services.Basic;
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

            //Infra
            services.AddScoped<IBasicRepository, BasicRepository>();
            services.AddScoped<IConsumeRepository, ConsumeRepository>();
        }
    }
}
