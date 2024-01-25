
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using MySqlConnector;
using System.Security.Claims;

namespace TodoPeople;

public class Program
{
    public static void Main(string[] args)
    {

        

        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddAuthorization();
        builder.Services.AddAuthentication("Bearer").AddBearerToken();

        // Add services to the container.

        //Configure DbContext into the BE deployment -> dependency injection
        //Register a database connection
        //var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        //builder.Services.AddDbContext<DatabaseContext>(options =>
        //        builder.Services.AddDbContext<DatabaseContext>(options =>
        //options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

        //Create a Swagger Endpoint
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
        });
        builder.Services.AddDbContext<DatabaseContext>();

        //Add CORS policy to access API with Localhost FE and Vercel
        //builder.Services.AddCors(options =>
        //{
        //    options.AddDefaultPolicy(
        //        policy =>
        //        {
        //            policy.WithOrigins("http://localhost:3000");
        //            policy.WithOrigins("https://learning03.vercel.app");
        //        });

        //}
        //);
        //builder.Services.AddCors(options =>
        //{
        //    options.AddPolicy("AllowSpecificHeaders",
        //        builder =>
        //        {
        //            builder.WithOrigins("http://localhost:3000")
        //                   .WithMethods("GET", "POST", "PUT", "DELETE")
        //                   .WithHeaders("Content-Type", "Authorization"); // Specify the allowed headers here
        //            builder.WithOrigins("https://learning03.vercel.app")
        //                   .WithMethods("GET", "POST", "PUT", "DELETE")
        //                   .WithHeaders("Content-Type", "Authorization"); // Specify the allowed headers here
        //        });
        //});
        //builder.Services.AddControllers();
        //


        var app = builder.Build();
        //Disable All CORS policy => Does not recommended on real practice!!!
        app.UseCors(builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });

        //app.UseCors();
        //app.UseCors("AllowSpecificHeaders");
        // Configure the HTTP request pipeline.
        //if (app.Environment.IsDevelopment())
        //{
        app.UseSwagger();
            app.UseSwaggerUI();
        //}

        // specifying the Swagger JSON endpoint.
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        });

        app.MapSwagger().RequireAuthorization();
       

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}

