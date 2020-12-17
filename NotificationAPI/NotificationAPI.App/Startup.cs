namespace NotificationAPI.App
{
    using System;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Hosting;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using NotificationAPI.App.Infrastructure;
    using NotificationAPI.App.Hubs.Interfaces;
    using Microsoft.Extensions.DependencyInjection;
    using NotificationAPI.App.Hubs.NotificationHub;

    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddSignalR(s =>
               s.EnableDetailedErrors = true
            );

            services.AddSingleton<INotificationHubContext, NotificationHubContext>(); //DI

            services.AddMassTransitServiceBus(); // MassTransite Configuration
        }


        [Obsolete]
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(builder =>
            {
                builder.WithOrigins("http://localhost:3001")
                    .AllowAnyHeader()
                    .WithMethods("GET", "POST")
                    .AllowCredentials();
            });

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

            app.UseSignalR(routes => routes.MapHub<NotificationHub>("/hubs/web-event-notification")); // Obsolete
        }
    }
}
