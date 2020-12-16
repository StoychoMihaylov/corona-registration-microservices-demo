namespace WebGateway.App.Infrastructure
{
    using MassTransit;
    using System.Diagnostics;
    using MassTransit.MessageData;
    using WebGateway.Messaging.Messages;
    using Microsoft.Extensions.DependencyInjection;

    public static class ServiceBusConfigurationExtensions
    {
        public static IServiceCollection AddMassTransitServiceBus(this IServiceCollection services)
        {
            return services.AddMassTransit(mt =>
            {
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

                    // ApplicantAPI
                    rmq.Message<IRegisterNewApplicant>(m => m.SetEntityName("register-new-applicant-exchange"));
                }));
            })
            .AddMassTransitHostedService();
        }
    }
}
