namespace ApplicantAPI.App.Infrastructure
{
    using GreenPipes;
    using MassTransit;
    using System.Diagnostics;
    using MassTransit.MessageData;
    using MessageExchangeContract;
    using ApplicantAPI.Messaging.Consumers;
    using Microsoft.Extensions.DependencyInjection;

    public static class ServiceBusConfigExtensions
    {
        public static IServiceCollection AddMassTransitServiceBus(this IServiceCollection services)
        {
            return services.AddMassTransit(mt =>
            {
                // Register Consumers
                mt.AddConsumer<RegisterNewApplicantConsumer>();

                mt.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(rmq =>
                {
                    if (Debugger.IsAttached)
                    {
                        rmq.Host("localhost", "/", host =>
                        {
                            host.Username("guest");
                            host.Password("guest");
                        });
                    }
                    else
                    {
                        rmq.Host("rabbitmq", host =>
                        {
                            host.Username("guest");
                            host.Password("guest");
                        });
                    }

                    rmq.UseHealthCheck(provider);
                    rmq.UseMessageData(new InMemoryMessageDataRepository());

                    // Register Exhanges
                    rmq.Message<IRegisterNewApplicant>(m => m.SetEntityName("register-new-applicant-exchange"));
                    rmq.Message<IEventNotificationMessage>(m => m.SetEntityName("event-notification-exchange"));

                    // Register Endpoints
                    rmq.ReceiveEndpoint("register-new-applicant-queue", endpoint =>
                    {
                        endpoint.PrefetchCount = 20;
                        endpoint.UseMessageRetry(retry => retry.Interval(5, 200));
                        endpoint.Bind<IRegisterNewApplicant>();
                        endpoint.ConfigureConsumer<RegisterNewApplicantConsumer>(provider);
                    });
                }));
            })
            .AddMassTransitHostedService();
        }
    }
}
