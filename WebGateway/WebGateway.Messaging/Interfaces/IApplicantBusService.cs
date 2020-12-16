namespace WebGateway.Messaging.Interfaces
{
    using System.Threading.Tasks;
    using WebGateway.Models.BindingModels;

    public interface IApplicantBusService
    {
        Task MessageApplicantAPI_RegisterNewApplicant(RegisterNewApplicantBindingModel bm);
    }
}
