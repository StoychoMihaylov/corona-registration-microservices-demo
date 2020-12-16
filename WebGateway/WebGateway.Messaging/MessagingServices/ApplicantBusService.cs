namespace WebGateway.Messaging.MessagingServices
{
    using System;
    using MassTransit;
    using System.Threading.Tasks;
    using WebGateway.Messaging.Messages;
    using WebGateway.Models.BindingModels;
    using WebGateway.Messaging.Interfaces;

    public class ApplicantBusService : IApplicantBusService
    {
        private readonly IBus bus;

        public ApplicantBusService(IBus bus)
        {
            this.bus = bus;
        }

        public async Task MessageApplicantAPI_RegisterNewApplicant(RegisterNewApplicantBindingModel bm)
        {
            var endpoint = await this.bus.GetSendEndpoint(new Uri("queue:register-new-applicant-queue"));
            await endpoint.Send<IRegisterNewApplicant>(bm);
        }
    }
}
