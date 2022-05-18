/*====================================================================*\
Name ........ : RoleConst.cs
Role ........ : List of roles, used to seed DB 
Author ...... : Davide Faga
Date ........ : 18.05.2022
\*====================================================================*/
using BeerApi.Models;

namespace BeerApi.Tools
{
    public class RoleConst
    {
        /*======================================================================*\
        |*			                     CONSTANT         	 				    *|
        \*======================================================================*/
        public static List<Role> Roles = new List<Role>()
        {
            new Role() { Id = 1, Name = "Administrator", Description = null },
            new Role() { Id = 2, Name = "Brewer", Description = "Brewery owner" },
            new Role() { Id = 3, Name = "Drinker", Description = "The Drinker" },
        };
    }
}
