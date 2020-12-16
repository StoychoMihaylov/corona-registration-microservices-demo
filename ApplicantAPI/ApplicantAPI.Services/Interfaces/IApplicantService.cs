namespace ApplicantAPI.Services.Interfaces
{
    using System.Threading.Tasks;
    using ApplicantAPI.Models.BindingModels;

    public interface IApplicantService
    {
        Task CreateApplicantRegistration(RegisterNewApplicantBindingModel newApplicant);
    }
}
