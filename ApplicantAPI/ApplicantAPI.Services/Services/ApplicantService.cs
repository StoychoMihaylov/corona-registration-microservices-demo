namespace ApplicantAPI.Services.Services
{
    using System;
    using System.Threading.Tasks;
    using ApplicantAPI.Data.Entities;
    using ApplicantAPI.Data.Interfaces;
    using ApplicantAPI.Services.Interfaces;
    using ApplicantAPI.Models.BindingModels;

    public class ApplicantService : Service, IApplicantService
    {
        public ApplicantService(IApplicantDbContext context)
         : base(context) { }

        public async Task CreateApplicantRegistration(RegisterNewApplicantBindingModel bm)
        {
            // let's assume that the object is much bigger, so we can use automapper here to map the binding model to entity model

            var newApplicant = new Applicant()
            {
                FirstName = bm.FirstName,
                LastName = bm.LastName,
                Email = bm.Email,
                Age = bm.Age,
                Symptoms = bm.Symptoms,
                RegisteredOn = DateTime.UtcNow
            };

            this.Context.Applicants.Add(newApplicant);
            await this.Context.SaveChangesAsync();
        }
    }
}
