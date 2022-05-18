/*====================================================================*\
Name ........ : Beer.cs
Role ........ : Beer - Model
Author ...... : Davide Faga
Date ........ : 18.05.2022
\*====================================================================*/
namespace BeerApi.Models
{
    public class Beer
    {
        public ulong Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public virtual Brewery? Brewery { get; set; }
        public virtual ICollection<BeerUser>? BeerUsers { get; set; }

        public override string ToString()
        {
            return "beerId : " +Id+ ", beerName : " +Name;
        }

    }
}
