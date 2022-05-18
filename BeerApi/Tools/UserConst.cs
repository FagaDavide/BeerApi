/*====================================================================*\
Name ........ : UserConst.cs
Role ........ : List of users, used to seed DB 
Author ...... : Davide Faga
Date ........ : 18.05.2022
\*====================================================================*/
using BeerApi.Models;

namespace BeerApi.Tools
{
    public class UserConst
    {
        /*======================================================================*\
        |*			                     CONSTANT         	 					*|
        \*======================================================================*/
        public static List<User> Users = new List<User>()
        {
            new User()
            {
                Id = 1, Username = "john_doe", Email = "john_doe@xxx.ch", Password = "beer1291",
                Role = RoleConst.Roles.ElementAt(0)
            },
            new User()
            {
                Id = 2, Username = "jane_doe", Email = "jane_doe@xxx.ch", Password = "beer1291",
                Role = RoleConst.Roles.ElementAt(1)
            },
            new User()
            {
                Id = 3, Username = "monsieur_x", Email = "monsieur_x@xxx.ch", Password = "beer1291",
                Role = RoleConst.Roles.ElementAt(2)
            },
             new User()
            {
                Id = 4, Username = "madame_x", Email = "madame_x@xxx.ch", Password = "beer1291",
                Role = RoleConst.Roles.ElementAt(2)
            },
            new User()
            {
                Id = 5, Username = "user_test", Email = "user_test@xxx.ch", Password = "beer1291",
                Role = RoleConst.Roles.ElementAt(0)
            },
        };
    }
}
