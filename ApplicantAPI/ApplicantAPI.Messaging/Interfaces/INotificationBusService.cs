namespace ApplicantAPI.Messaging.Interfaces
{
    public interface INotificationBusService
    {
        void MessageNotificationAPI_SendEventNotification(string message);
    }
}
