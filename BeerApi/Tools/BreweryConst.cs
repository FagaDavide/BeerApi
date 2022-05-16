using BeerApi.Models;

namespace BeerApi.Tools
{
    public class BreweryConst
    {
        public static List<Brewery> Breweries = new List<Brewery>()
        {
            new Brewery() 
            { 
                Id = 1,
                Name = "White Brewery",
                UserOwner = UserConst.Users.ElementAt(1),
            },
            new Brewery()
            { 
                Id = 2,
                Name = "Red Brewery", 
                Description = "the most red brewery",
                UserOwner = UserConst.Users.ElementAt(1),
            },
            new Brewery()
            { 
                Id = 3,
                Name = "Green Brewery",
                Description = "the bio brewery",
                UserOwner = UserConst.Users.ElementAt(1),
            },
        };
    }
}
