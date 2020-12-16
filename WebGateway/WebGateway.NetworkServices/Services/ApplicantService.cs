namespace WebGateway.NetworkServices.Services
{
    using System.Net.Http;
    using WebGateway.NetworkServices.Interfaces;

    public class ApplicantService : Service, IApplicantService
    {
        public ApplicantService(HttpClient httpClient)
           : base(httpClient)
        { }


    }
}
