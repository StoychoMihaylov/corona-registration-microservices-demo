namespace ApplicantAPI.App
{
    using ApplicantAPI.Data.Context;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using ApplicantAPI.App.Infrastructure;
    using ApplicantAPI.Data.DBInitializer;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerDocument(); // Swagger
            services.AddDependancyInjectionResolver(); // DI
            services.AddPosgreSQLWithEntityFramework(Configuration);
            services.AddMassTransitServiceBus(); // MassTransite Configuration
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ApplicantDbContext context)
        {
            app.UseRouting();
            app.UseControllerEndpoints();
            app.UseExceptionHandling(env);
            app.UseOpenApi(); // Swagger
            app.UseSwaggerUi3(); // Swagger

            DbIitializer.SeedDb(context); // Seed/Migrate DB on start
        }
    }
}
