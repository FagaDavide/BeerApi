/*====================================================================*\
Name ........ : BeerDbContext.cs
Role ........ : 
Author ...... : Davide Faga
Date ........ : 05.05.2022
\*====================================================================*/
using BeerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BeerApi.DataBase
{
    public class BeerDbContext : DbContext 
    {
        /*======================================================================*\
        |*			                     CONST            	 					*|
        \*======================================================================*/
        private const string DB_CONNECTION = "BeerDbContextConnection";

        /*======================================================================*\
        |*			                     CONSTRUCTOR       	 					*|
        \*======================================================================*/
        public BeerDbContext(DbContextOptions<BeerDbContext> options)
            : base(options)
        {

        }

        /*======================================================================*\
        |*			                     VARIABLE         	 					*|
        \*======================================================================*/
        public DbSet<BeerModel> Beers { get; set; }
        public DbSet<BreweryModel> Breweries { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<RoleModel> Roles { get; set; }

        /*======================================================================*\
        |*			                     METHODE       	 			    		*|
        \*======================================================================*/
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString(DB_CONNECTION);
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 27));

            optionsBuilder.UseMySql(connectionString, serverVersion)
                        //this three actions have to be disable on production
                        .LogTo(Console.WriteLine, LogLevel.Information)
                        .EnableSensitiveDataLogging()
                        .EnableDetailedErrors();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /* modelBuilder.Entity<BeerModel>()
                 .HasMany(left => left.Users)
                 .WithMany(right => right.Beers)
                 .UsingEntity(join => join.ToTable("BeerNote2"));
            */
            base.OnModelCreating(modelBuilder);

           
        


    }

        /*======================================================================*\
        |*			                     END            	 					*|
        \*======================================================================*/
    }
}