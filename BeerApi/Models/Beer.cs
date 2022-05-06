namespace BeerApi.Models
{
    public class Beer
    {
        public ulong Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public Brewery? Brewery { get; set; }
        public ICollection<BeerUser>? Users { get; set; }

        public override string ToString()
        {
            return "beerId : " +Id+ ", beerName : " +Name;
        }

    }
}
