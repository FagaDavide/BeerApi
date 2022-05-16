namespace BeerApi.Models
{
    public class Brewery
    {
        public ulong Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public virtual User? UserOwner { get; set; }
        public virtual ICollection<Beer>? Beers { get; set; }
    }
}
