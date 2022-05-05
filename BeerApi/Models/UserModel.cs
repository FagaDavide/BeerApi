
namespace BeerApi.Models
{
    public class UserModel
    {
        public ulong Id { get; set; }
        public string Nickname { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public RoleModel? Role { get; set; }
        public ICollection<BeerModelUserModel>? Beers { get; set; }
    }
}
