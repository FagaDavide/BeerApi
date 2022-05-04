namespace BeerApi.Models
{
    public class UserModel
    {
        public string Id { get; set; } = string.Empty;
        public string Nickname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Role_fk { get; set; } = string.Empty;
    }
}
