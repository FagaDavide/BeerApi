/*====================================================================*\
Name ........ : UserLogin.cs
Role ........ : username - password, model to start the authentification
Author ...... : Davide Faga
Date ........ : 18.05.2022
\*====================================================================*/
namespace BeerApi.Models
{
    public class UserLogin
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
