namespace BeerApi.Models
{
    public class RoleModel
    {
        public ulong Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
