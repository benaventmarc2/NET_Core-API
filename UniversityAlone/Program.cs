namespace UniversityDB
{
    // 1. Using Microsoft directories
    using Microsoft.EntityFrameworkCore;
    using Microsoft.OpenApi.Models;
    using UniversityDB.DataAccess;
    using UniversityDB.Services;
    using Serilog;
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // 10. Config Serilog
            builder.Host.UseSerilog((hostBuilderCtx, loggerConf) =>
            {
                loggerConf.WriteTo.Console().WriteTo.Debug()
                .ReadFrom.Configuration(hostBuilderCtx.Configuration);
            });


            // 2.  Connection path with SQL Server Express
            const string CONNECTION_NAME = "DefaultConnection";
            // 3. Create Connection
            var connectionString = builder.Configuration.GetConnectionString(CONNECTION_NAME);

            // 4. Add Context  
            builder.Services.AddDbContext<UniversityDBContext>(options => options.UseSqlServer(connectionString));

            // 7. Add Service of JWT Autorization
            builder.Services.AddJwtTokenServices(builder.Configuration);

            // Add services to the container.
            builder.Services.AddControllers();

            // 5. Add Custom Services (folder Services)
            builder.Services.AddScoped<IStudentsService, StudentsService>();


            // 8. Add Authorization 
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("UserOnlyPolicy", policy => policy.RequireClaim("UserOnly", "User1"));
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            // 9. Config Swagger to take care of Autorization of JWT
            builder.Services.AddSwaggerGen(options =>
            {
                // We define the Security for authorization
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization Header using Bearer Scheme",
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer",

                            }
                        },
                        new string[]{}
                    }
                });
            });

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

            // 11. Tell ap to use Serilog
            app.UseSerilogRequestLogging();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            // 7. Tell app to use CORS
            app.UseCors("CorsPolicy");

            app.Run();
        }
    }
}