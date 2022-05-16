using BeerApi.Models;

namespace BeerApi.Tools
{
    public class BeerConst
    {
        public static List<Beer> Beers = new List<Beer>()
        {
            new Beer()
            {
                Id = 1,
                Name = "White Beer",
                Brewery = BreweryConst.Breweries.ElementAt(0)
            },
            new Beer()
            {
                Id = 2,
                Name = "Red Beer",
                Brewery = BreweryConst.Breweries.ElementAt(1),
            },
            new Beer() 
            { 
                Id = 3,
                Name = "Green Beer",
                Brewery = BreweryConst.Breweries.ElementAt(2),
            }
        };
    }
}
