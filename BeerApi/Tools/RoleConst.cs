using BeerApi.Models;

namespace BeerApi.Tools
{
    public class RoleConst
    {
        public static List<Role> Roles = new List<Role>()
        {
            new Role() { Id = 1, Name = "Administrator", Description = null },
            new Role() { Id = 2, Name = "Brewer", Description = "Brewery owner" },
            new Role() { Id = 3, Name = "Drinker", Description = "The Drinker" },
        };
    }
}
