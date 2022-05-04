namespace BeerApi.Models
{
    public class UserBeer
    {
        public string Id { get; set; } = string.Empty;
        public string User_fk { get; set; } = string.Empty;
        public string Beer_fk { get; set; } = string.Empty;
        public string Remark { get; set; } = string.Empty;
    }
}
