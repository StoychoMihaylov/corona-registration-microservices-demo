namespace NotificationAPI.App.Hubs.Interfaces
{
    using System.Threading.Tasks;

    public interface INotificationHub
    {
        Task PushSuccessfulEventNotification(string message);
    }
}
