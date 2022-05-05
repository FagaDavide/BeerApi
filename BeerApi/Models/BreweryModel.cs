namespace BeerApi.Models
{
    public class BreweryModel
    {
        public ulong Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public UserModel? User { get; set; }
    }
}
