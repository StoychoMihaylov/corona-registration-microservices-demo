namespace NotificationAPI.App.Hubs.NotificationHub
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.SignalR;

    public class NotificationHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            var connectionId = this.Context.ConnectionId;
            await this.Groups.AddToGroupAsync(connectionId, "event-notification");
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            var connectionId = this.Context.ConnectionId;
            await this.Groups.RemoveFromGroupAsync(connectionId, "event-notification");
        }
    }
}
