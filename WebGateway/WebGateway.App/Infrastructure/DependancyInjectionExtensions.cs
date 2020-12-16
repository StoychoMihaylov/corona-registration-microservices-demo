namespace WebGateway.App.Infrastructure
{
    using System.Net.Http;
    using WebGateway.NetworkServices.Services;
    using WebGateway.NetworkServices.Interfaces;
    using Microsoft.Extensions.DependencyInjection;

    public static class DependancyInjectionExtensions
    {
        public static IServiceCollection AddDependancyInjectionResolver(this IServiceCollection services)
        {
            services.AddSingleton<HttpClient>(new HttpClient());
            services.AddTransient<IApplicantService, ApplicantService>();

            return services;
        }
    }
}
