namespace ApplicantAPI.Data.Interfaces
{
    using System.Threading;
    using System.Threading.Tasks;
    using ApplicantAPI.Data.Entities;
    using Microsoft.EntityFrameworkCore;

    public interface IApplicantDbContext
    {
        DbSet<Applicant> Applicants { get; set; }

        int SaveChanges();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
