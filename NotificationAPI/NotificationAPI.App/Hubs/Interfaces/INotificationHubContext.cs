namespace NotificationAPI.App.Hubs.Interfaces
{
    using System.Threading.Tasks;

    public interface INotificationHubContext
    {
        Task PushSuccessfulEventNotification(string message);
    }
}
