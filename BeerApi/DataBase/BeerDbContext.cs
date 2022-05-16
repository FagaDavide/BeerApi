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
        public DbSet<Beer> Beers { get; set; }
        public DbSet<Brewery> Breweries { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<BeerUser> BeerUsers { get; set; }

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

            base.OnModelCreating(modelBuilder);

            //ROLE
            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(r => r.Id);
                entity.Property(r => r.Name).IsRequired();
            });

            //USER
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id);
                entity.Property(u => u.Username).IsRequired();
                entity.HasOne(u => u.Role)
                    .WithMany(r => r.Users);
            });

            //BREWERY
            modelBuilder.Entity<Brewery>(entity =>
            {
                entity.HasKey(b => b.Id);
                entity.Property(b => b.Name).IsRequired();
                entity.HasOne(b => b.UserOwner)
                    .WithMany(u => u.Breweries);
            });

            //BEER
            modelBuilder.Entity<Beer>(entity =>
            {
                entity.HasKey(b => b.Id);
                entity.Property(b => b.Name).IsRequired();
                entity.HasOne(b => b.Brewery)
                    .WithMany(br => br.Beers);
            });

            //BEERUSER
            modelBuilder.Entity<BeerUser>(entity =>
            {
                entity.HasKey(bu => bu.Id);
                entity.Property(bu => bu.BeerId).IsRequired();
                entity.Property(bu => bu.UserId).IsRequired();
                entity.Property(bu => bu.Score).IsRequired();
                entity.HasIndex(bu => new { bu.BeerId, bu.UserId }).IsUnique();
            });
            modelBuilder.Entity<BeerUser>()
                .HasOne(bu => bu.Beer)
                .WithMany(b => b.BeerUsers)
                .HasForeignKey(bu => bu.BeerId);
            modelBuilder.Entity<BeerUser>()
                .HasOne(bu => bu.User)
                .WithMany(u => u.BeerUsers)
                .HasForeignKey(bu => bu.UserId);
        }
        
        /*======================================================================*\
        |*			                     END            	 					*|
        \*======================================================================*/
    }
}