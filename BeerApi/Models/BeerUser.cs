/*====================================================================*\
Name ........ : BeerUser.cs
Role ........ : BeerUser - Model
Author ...... : Davide Faga
Date ........ : 18.05.2022
\*====================================================================*/
namespace BeerApi.Models
{
    public class BeerUser
    {
        public ulong Id { get; set; }
        public ulong BeerId { get; set; }
        public ulong UserId { get; set; }
        public int Score { get; set; }
        public string Remark { get; set; }
        public Beer Beer { get; set; }
        public User User { get; set; }
    }
}
