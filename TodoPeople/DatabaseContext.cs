using System;
using Microsoft.EntityFrameworkCore;
using TodoPeople.Models;

namespace TodoPeople
{
	public class DatabaseContext : DbContext
	{
        protected readonly IConfiguration Configuration;

        public DatabaseContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to mysql with connection string from app settings
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        public DbSet<PeopleDTO> People { get; set; }
	}
	//this will set up the context of the database. This instance is about the People table.
}

