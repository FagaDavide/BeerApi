
namespace BeerApi.Models
{
    public class User
    {
        public ulong Id { get; set; }
        public string Nickname { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public Role? Role { get; set; }
        public ICollection<BeerUser>? Beers { get; set; }
    }
}
