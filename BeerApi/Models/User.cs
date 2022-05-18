/*====================================================================*\
Name ........ : User.cs
Role ........ : User - Model
Author ...... : Davide Faga
Date ........ : 18.05.2022
\*====================================================================*/
namespace BeerApi.Models
{
    public class User
    {
        public ulong Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public virtual Role? Role { get; set; }
        public virtual ICollection<BeerUser>? BeerUsers { get; set; }
        public virtual ICollection<Brewery>? Breweries { get; set; }
    }
}
