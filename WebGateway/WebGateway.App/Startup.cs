namespace WebGateway.App
{
    using Microsoft.AspNetCore.Builder;
    using WebGateway.App.Infrastructure;
    using Microsoft.Extensions.DependencyInjection;

    public class Startup
    {
        private readonly string apiCorsPolicy = "ApiCorsPolicy";

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers();
            services.AddSwaggerDocument(); // Swagger
            services.AddMemoryCache();
            services.AddCorsPolicy(apiCorsPolicy);
            services.AddDependancyInjectionResolver(); // DI
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();
            app.UseControllerEndpoints();
            app.UseCors(apiCorsPolicy);    
            app.UseOpenApi(); // Swagger
            app.UseSwaggerUi3(); // Swagger
        }
    }
}
