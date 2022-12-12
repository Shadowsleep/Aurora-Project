using AuroraProject.Core.Data;
using AuroraProject.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace AuroraProject.WebApi.Extensions
{
    public static class DependenceInjectionExtension
    {
        /// <summary>
        /// Adiciona Injeções de dependencias usadas no projeto Aurora.
        /// </summary>
        /// <param name="services"></param>
        public static void InjectServicesBase(this IServiceCollection services)
        {
            services.AddScoped(typeof(IAsyncRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IReadOnlyAsyncRepository<>), typeof(ReadOnlyRepository<>));
        }
    }
}

