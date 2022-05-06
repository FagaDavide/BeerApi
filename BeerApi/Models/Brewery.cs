namespace BeerApi.Models
{
    public class Brewery
    {
        public ulong Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public User? User { get; set; }
    }
}
