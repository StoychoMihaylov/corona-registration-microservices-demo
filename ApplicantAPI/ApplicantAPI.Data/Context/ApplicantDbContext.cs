namespace ApplicantAPI.Data.Context
{
    using ApplicantAPI.Data.Entities;
    using ApplicantAPI.Data.Interfaces;
    using Microsoft.EntityFrameworkCore;

    public class ApplicantDbContext : DbContext, IApplicantDbContext
    {
        public ApplicantDbContext(DbContextOptions<ApplicantDbContext> options) 
            : base(options) { }

        public DbSet<Applicant> Applicants { get; set; }
    }
}
