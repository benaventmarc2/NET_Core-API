namespace UniversityDB.DataAccess
{
    using Microsoft.EntityFrameworkCore;
    using UniversityDB.Models.DataModels;

    public class UniversityDBContext : DbContext
    {
        public UniversityDBContext(DbContextOptions<UniversityDBContext> options) : base(options)
        {

        }

        // TODO: Add DbSets(Tables of our data base)
        public DbSet<User>? Users { get; set; }
        public DbSet<Course>? Courses { get; set; }
        public DbSet<Category>? Categorys { get; set; }
        public DbSet<Student>? Students { get; set; }
        public DbSet<Chapter>? Chapters { get; set; }
    }
}