namespace NotificationAPI.App
{
    using System;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Hosting;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using NotificationAPI.App.Middlewares;
    using NotificationAPI.App.Infrastructure;
    using NotificationAPI.App.Hubs.Interfaces;
    using Microsoft.Extensions.DependencyInjection;
    using NotificationAPI.App.Hubs.NotificationHub;

    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSignalR(s =>
               s.EnableDetailedErrors = true
            );

            services.AddSingleton<INotificationHub, NotificationHub>(); //DI

            services.AddMassTransitServiceBus(); // MassTransite Configuration
        }


        [Obsolete]
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });

            app.UseCorsMiddleware();
            app.UseSignalR(routes => routes.MapHub<NotificationHub>("/hubs/web-event-notification")); // Obsolete
        }
    }
}
