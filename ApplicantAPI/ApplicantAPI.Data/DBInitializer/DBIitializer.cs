namespace ApplicantAPI.Data.DBInitializer
{
    using ApplicantAPI.Data.Context;
    using Microsoft.EntityFrameworkCore;

    public class DbIitializer
    {
        public static void SeedDb(ApplicantDbContext context)
        {
            context.Database.Migrate();
        }
    }
}
