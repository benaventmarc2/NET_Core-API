namespace UniversityAlone.DataAccess
{
    using Microsoft.EntityFrameworkCore;
    using UniversityAlone.Models.DataModels;

    public class UniversityContext : DbContext
    {
        public UniversityContext(DbContextOptions<UniversityContext> options) : base(options)
        {

        }

        // TODO: Add DbSets(Tables of our data base)
        public DbSet<User>? Users { get; set; }
    } 
}
