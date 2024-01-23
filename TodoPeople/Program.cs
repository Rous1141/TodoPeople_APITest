
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MySqlConnector;

namespace TodoPeople;

public class Program
{
    public static void Main(string[] args)
    {

        

        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddAuthorization();
        builder.Services.AddAuthentication("Bearer").AddJwtBearer();

        // Add services to the container.

        //Configure DbContext into the BE deployment -> dependency injection
        //Register a database connection
        //var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        //builder.Services.AddDbContext<DatabaseContext>(options =>
        //        builder.Services.AddDbContext<DatabaseContext>(options =>
        //options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));


        builder.Services.AddDbContext<DatabaseContext>();

        //Add CORS policy to access API with Localhost FE
        builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(
                policy =>
                {
                    policy.WithOrigins("http://localhost:3000");
                });
        });
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        app.UseCors();
        // Configure the HTTP request pipeline.
        //if (app.Environment.IsDevelopment())
        //{
            app.UseSwagger();
            app.UseSwaggerUI();
       //}

        app.MapSwagger().RequireAuthorization();

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}

