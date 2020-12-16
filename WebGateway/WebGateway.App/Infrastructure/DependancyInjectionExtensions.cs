namespace WebGateway.App.Infrastructure
{
    using System.Net.Http;
    using WebGateway.Messaging.Interfaces;
    using WebGateway.NetworkServices.Services;
    using WebGateway.NetworkServices.Interfaces;
    using WebGateway.Messaging.MessagingServices;
    using Microsoft.Extensions.DependencyInjection;

    public static class DependancyInjectionExtensions
    {
        public static IServiceCollection AddDependancyInjectionResolver(this IServiceCollection services)
        {
            services.AddSingleton<HttpClient>(new HttpClient());
            services.AddTransient<IApplicantService, ApplicantService>();
            services.AddTransient<IApplicantBusService, ApplicantBusService>();

            return services;
        }
    }
}
