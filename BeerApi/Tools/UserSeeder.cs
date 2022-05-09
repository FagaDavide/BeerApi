namespace BeerApi.Models
{
    public class UserSeeder
    {
        public static List<User> Users = new List<User>()
        {
            new User()
            {
                Username = "john_doe", Email = "john_doe@xxx.ch", Password = "beer1291", 
                Role = new Role(){ Name = "Administrator" }
            },
            new User()
            {
                Username = "jane_doe", Email = "jane_doe@xxx.ch", Password = "beer1291",
                Role = new Role(){ Name = "Brewer" }
            },
            new User()
            {
                Username = "monsieur_x", Email = "monsieur_x@xxx.ch", Password = "beer1291",
                Role = new Role(){ Name = "Drinker" }
            },
             new User()
            {
                Username = "madame_x", Email = "madame_x@xxx.ch", Password = "beer1291",
                Role = new Role(){ Name = "Drinker" }
            }
        };
    }
}
