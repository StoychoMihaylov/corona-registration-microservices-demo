namespace ApplicantAPI.App.Infrastructure
{
    using ApplicantAPI.Data.Context;
    using ApplicantAPI.Data.Interfaces;
    using ApplicantAPI.Services.Services;
    using ApplicantAPI.Services.Interfaces;
    using Microsoft.Extensions.DependencyInjection;

    public static class DependancyInjectionExtensions
    {
        public static IServiceCollection AddDependancyInjectionResolver(this IServiceCollection services)
        {
            services.AddTransient<IApplicantService, ApplicantService>();
            services.AddTransient<IApplicantDbContext, ApplicantDbContext>();

            return services;
        }
    }
}
