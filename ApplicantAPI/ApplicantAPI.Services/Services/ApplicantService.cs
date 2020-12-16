namespace ApplicantAPI.Services.Services
{
    using ApplicantAPI.Data.Interfaces;
    using ApplicantAPI.Services.Interfaces;

    public class ApplicantService : Service, IApplicantService
    {
        public ApplicantService(IApplicantDbContext context)
         : base(context) { }
    }
}
