namespace BeerApi.Models
{
    public class BeerModel
    {
        public string Id { get; set; } = string.Empty;
        public string Brewery_fk { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        public override string ToString()
        {
            return "beerId : " +Id+ ", beerName : " +Name+ ", beerBrewery : " +Brewery_fk+ ", beerDescription : "+Description;
        }

    }
}
