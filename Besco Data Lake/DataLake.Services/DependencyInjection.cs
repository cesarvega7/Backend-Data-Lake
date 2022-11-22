using DataLake.Entities.Implementations;
using DataLake.Entities.Interfaces;
using DataLake.Services.Implementations;
using DataLake.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DataLake.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            services.AddTransient<IProyectosRepository, ProyectosRepository>()
                .AddTransient<IProyectosService, ProyectosService>();

            return services;
        }
    }
}
