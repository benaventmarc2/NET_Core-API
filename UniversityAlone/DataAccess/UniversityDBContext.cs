namespace UniversityDB.DataAccess
{
    using Microsoft.EntityFrameworkCore;
    using UniversityDB.Models.DataModels;

    public class UniversityDBContext : DbContext
    {
        private readonly ILoggerFactory _loggerFactory;
        public UniversityDBContext(DbContextOptions<UniversityDBContext> options, ILoggerFactory loggerFactory) : base(options)
        {
            _loggerFactory = loggerFactory;
        }

        // TODO: Add DbSets(Tables of our data base)
        public DbSet<User>? Users { get; set; }
        public DbSet<Course>? Courses { get; set; }
        public DbSet<Category>? Categorys { get; set; }
        public DbSet<Student>? Students { get; set; }
        public DbSet<Chapter>? Chapters { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var logger = _loggerFactory.CreateLogger<UniversityDBContext>();

            //Logs For Everything
            //optionsBuilder.LogTo(o => logger.Log(LogLevel.Information, o, new[] { DbLoggerCategory.Database.Name}));
            //optionsBuilder.EnableSensitiveDataLogging();

            // Filter logs, if err make detailed logs
            optionsBuilder.LogTo(o => logger.Log(LogLevel.Information, o, new[] { DbLoggerCategory.Database.Name }), LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors(); 
        }
    }
}