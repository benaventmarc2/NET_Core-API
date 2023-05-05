namespace UniversityDB
{
    // 1. Using Microsoft directories
    using Microsoft.EntityFrameworkCore;
    using UniversityDB.DataAccess;
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // 2.  Connection path with SQL Server Express
            const string CONNECTION_NAME = "DefaultConnection";
            // 3. Create Connection
            var connectionString = builder.Configuration.GetConnectionString(CONNECTION_NAME);

            // 4. Add Context  
            builder.Services.AddDbContext<UniversityDBContext>(options => options.UseSqlServer(connectionString));

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}