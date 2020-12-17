namespace ApplicantAPI.Messaging.Consumers
{
    using MassTransit;
    using System.Threading.Tasks;
    using MessageExchangeContract;
    using ApplicantAPI.Services.Interfaces;
    using ApplicantAPI.Models.BindingModels;
    using ApplicantAPI.Messaging.Interfaces;

    public class RegisterNewApplicantConsumer : IConsumer<IRegisterNewApplicant>
    {
        private readonly IApplicantService applicantService;
        private readonly INotificationBusService notificationBusService;

        public RegisterNewApplicantConsumer(IApplicantService applicantService, INotificationBusService notificationBusService)
        {
            this.applicantService = applicantService;
            this.notificationBusService = notificationBusService;
        }

        public async Task Consume(ConsumeContext<IRegisterNewApplicant> context)
        {
            var message = context.Message;

            // assume the object is bigger.. we can use automapper in this case
            var newApplicant = new RegisterNewApplicantBindingModel()
            {
                FirstName = message.FirstName,
                LastName = message.LastName,
                Email = message.Email,
                Age = message.Age,
                Symptoms = message.Symptoms
            };

            await this.applicantService.CreateApplicantRegistration(newApplicant);
            this.notificationBusService.MessageNotificationAPI_SendEventNotification($"Congrats {newApplicant.FirstName}, you are successfully registered!");
        }
    }
}
