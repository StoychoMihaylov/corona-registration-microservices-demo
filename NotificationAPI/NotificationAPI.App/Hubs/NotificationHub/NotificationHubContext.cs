namespace NotificationAPI.App.Hubs.NotificationHub
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.SignalR;
    using NotificationAPI.App.Hubs.Interfaces;

    public class NotificationHubContext : INotificationHubContext
    {
        private readonly IHubContext<NotificationHub> notificationHub;

        public NotificationHubContext(IHubContext<NotificationHub> notificationHub)
        {
            this.notificationHub = notificationHub;
        }

        public async Task PushSuccessfulEventNotification(string message)
        {
            await this.notificationHub.Clients.Group("event-notification").SendAsync("ReceiveNotificationMessage", message);
        }
    }
}
