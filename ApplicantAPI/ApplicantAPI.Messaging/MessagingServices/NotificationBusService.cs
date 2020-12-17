namespace ApplicantAPI.Messaging.MessagingServices
{
    using System;
    using MassTransit;
    using MessageExchangeContract;
    using ApplicantAPI.Messaging.Interfaces;

    public class NotificationBusService : INotificationBusService
    {
        private readonly IBus bus;

        public NotificationBusService(IBus bus)
        {
            this.bus = bus;
        }

        public async void MessageNotificationAPI_SendEventNotification(string message)
        {
            var endpoint = await this.bus.GetSendEndpoint(new Uri("queue:event-notification-queue"));
            await endpoint.Send<IEventNotificationMessage>(new
            {
                NotificationType = (int)MessageType.Success,
                Message = message
            });
        }
    }
}
