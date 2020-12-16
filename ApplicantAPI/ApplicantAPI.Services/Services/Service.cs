namespace ApplicantAPI.Services.Services
{
    using ApplicantAPI.Data.Interfaces;

    public class Service
    {
        public Service(IApplicantDbContext context)
        {
            this.Context = context;
        }

        protected IApplicantDbContext Context { get; set; }
    }
}
