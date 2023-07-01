using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Audisoft.Data;
using Audisoft.Domain.Services.Interfaces;
using Audisoft.Domain.Services.Implementation;
using Audisoft.Domain.Repositories.Interfaces;
using Audisoft.Domain.Repositories.Implementations;

namespace Audisoft.Domain
{
    public static class ServiceCollectionForDomainExtension
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDataServices(configuration);

            services.AddScoped(typeof(IGenericService<,,>), typeof(GenericService<,,>));
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<INoteRepository, NoteRepository>();

            return services;
        }
    }
}
