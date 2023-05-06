namespace UniversityDB
{
    // 1. Using Microsoft directories
    using Microsoft.EntityFrameworkCore;
    using UniversityDB.DataAccess;
    using UniversityDB.Services;

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

            // 5. Add Custom Services (folder Services)
            builder.Services.AddScoped<IStudentsService, StudentsService>();

            // 7. Add Service of JWT Autorization
            //builder.Services.AddJwtTokenServices(builder.Configuration);
            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            // 8. Config Swagger to take care of Autorization of JWT
            builder.Services.AddSwaggerGen();

            // 6. CORS Configuration
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: "CorsPolicy", builder =>
                {
                    builder.AllowAnyOrigin();
                    builder.AllowAnyMethod();
                    builder.AllowAnyHeader();
                });
            });

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

            // 7. Tell app to use CORS
            app.UseCors("CorsPolicy");

            app.Run();
        }
    }
}