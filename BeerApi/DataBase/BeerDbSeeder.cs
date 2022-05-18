/*====================================================================*\
Name ........ : BeerDbSeeder.cs
Role ........ : Seed the Db with the Const
Author ...... : Davide Faga
Date ........ : 18.05.2022
\*====================================================================*/
using BeerApi.Tools;

namespace BeerApi.DataBase
{
    public class BeerDbSeeder 
    {
        private readonly BeerDbContext context;
        public BeerDbSeeder(BeerDbContext ctx)
        {
            context = ctx;
        }
        public void Seed()
        {
            // Deletes the database if exists
            context.Database.EnsureDeleted();
            // Creates the database if not exists
            context.Database.EnsureCreated();

            //Add Roles
            context.Roles.AddRange(RoleConst.Roles);
            //Add Users
            context.Users.AddRange(UserConst.Users);
            //Add Breweries
            context.Breweries.AddRange(BreweryConst.Breweries);
            //Add Beers
            context.Beers.AddRange(BeerConst.Beers);
            //Add score
            context.BeerUsers.AddRange(BeerUserConst.BeerUsers);

            // Saves changes
            context.SaveChanges();
        }
    }
}
