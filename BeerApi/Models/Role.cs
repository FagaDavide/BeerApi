/*====================================================================*\
Name ........ : Role.cs
Role ........ : Role - Model
Author ...... : Davide Faga
Date ........ : 18.05.2022
\*====================================================================*/
namespace BeerApi.Models
{
    public class Role
    {
        public ulong Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
