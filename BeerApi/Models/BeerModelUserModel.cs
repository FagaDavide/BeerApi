namespace BeerApi.Models
{
    public class BeerModelUserModel
    {
        public ulong Id { get; set; }
        public int Score { get; set; }
        public string Description { get; set; }
        public BeerModel Beer { get; set; }
        public UserModel User { get; set; }
    }
}
