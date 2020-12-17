namespace ApplicantAPI.App.Infrastructure
{
    using ApplicantAPI.Data.Context;
    using ApplicantAPI.Data.Interfaces;
    using ApplicantAPI.Services.Services;
    using ApplicantAPI.Services.Interfaces;
    using ApplicantAPI.Messaging.Interfaces;
    using Microsoft.Extensions.DependencyInjection;
    using ApplicantAPI.Messaging.MessagingServices;

    public static class DependancyInjectionExtensions
    {
        public static IServiceCollection AddDependancyInjectionResolver(this IServiceCollection services)
        {
            services.AddTransient<IApplicantService, ApplicantService>();
            services.AddTransient<IApplicantDbContext, ApplicantDbContext>();
            services.AddTransient<INotificationBusService, NotificationBusService>();

            return services;
        }
    }
}
