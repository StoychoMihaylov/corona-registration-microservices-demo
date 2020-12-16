namespace ApplicantAPI.App.Infrastructure
{
    using System.Diagnostics;
    using ApplicantAPI.Data.Context;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class EntityFrameworkConfigExtensions
    {
        public static IServiceCollection AddPosgreSQLWithEntityFramework(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddEntityFrameworkNpgsql()
                .AddDbContext<ApplicantDbContext>((sp, opt) =>
                {
                    if (Debugger.IsAttached)
                    {
                        opt.UseNpgsql(configuration.GetConnectionString("ApplicantDbDebug"))
                           .UseInternalServiceProvider(sp);
                    }
                    else
                    {
                        opt.UseNpgsql(configuration.GetConnectionString("ApplicantDbRelease"))
                           .UseInternalServiceProvider(sp);
                    }
                });

            return services;
        }
    }
}
