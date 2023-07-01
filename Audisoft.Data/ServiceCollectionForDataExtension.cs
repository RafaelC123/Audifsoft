using Audisoft.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Audisoft.Data
{
    public static class ServiceCollectionForDataExtension
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), x =>
                {
                    x.MigrationsAssembly("Audisoft.Api");
                });
            });

            return services;
        }
    }
}
