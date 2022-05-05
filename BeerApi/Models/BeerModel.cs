namespace BeerApi.Models
{
    public class BeerModel
    {
        public ulong Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public BreweryModel? Brewery { get; set; }
        public ICollection<BeerModelUserModel>? Users { get; set; }

        public override string ToString()
        {
            return "beerId : " +Id+ ", beerName : " +Name;
        }

    }
}
