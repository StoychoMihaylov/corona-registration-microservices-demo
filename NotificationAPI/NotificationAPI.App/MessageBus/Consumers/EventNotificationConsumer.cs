namespace NotificationAPI.App.MessageBus.Consumers
{
    using MassTransit;
    using System.Threading.Tasks;
    using MessageExchangeContract;
    using NotificationAPI.App.Hubs.Interfaces;

    public class EventNotificationConsumer : IConsumer<IEventNotificationMessage>
    {
        private readonly INotificationHub notificationHub;

        public EventNotificationConsumer(INotificationHub notificationHub)
        {
            this.notificationHub = notificationHub;
        }

        public async Task Consume(ConsumeContext<IEventNotificationMessage> context)
        {
            var message = context.Message;

            System.Console.WriteLine("NOTIFICATIONNNNNNN HERE!!!!!");

            if (message.NotificationType == (int)MessageType.Info)
            {

            }
            else if (message.NotificationType == (int)MessageType.Success)
            {
                await this.notificationHub.PushSuccessfulEventNotification(message.Message);
            }
            else if (message.NotificationType == (int)MessageType.Error)
            {

            }
        }
    }
}
