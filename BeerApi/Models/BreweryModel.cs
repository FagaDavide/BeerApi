namespace BeerApi.Models
{
    public class BreweryModel
    {
        public string Id { get; set; } = string.Empty;
        public string User_fk { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
