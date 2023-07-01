using Audisoft.Domain;

namespace Audisoft.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDomainServices(Configuration);

            services.AddAutoMapper(typeof(Startup));

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

        }

        public void ConfigureApplication(IApplicationBuilder app, IHostEnvironment env)
        {
            app.UseCors(x =>
            {
                x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            });

            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(x =>
            {
                x.MapControllers();
            });
        }
    }
}
