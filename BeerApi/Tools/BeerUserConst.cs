/*====================================================================*\
Name ........ : BeerUserConst.cs
Role ........ : List of beeruser, used to seed DB 
Author ...... : Davide Faga
Date ........ : 18.05.2022
\*====================================================================*/
using BeerApi.Models;

namespace BeerApi.Tools
{
    public class BeerUserConst
    {
        /*======================================================================*\
        |*			                     CONSTANT         	 				   *|
        \*======================================================================*/
        public static List<BeerUser> BeerUsers = new List<BeerUser>()
        {
            new BeerUser()
            {
                Id = 1,
                UserId = 3,
                BeerId = 1,
                Score = 5,
                Remark = "so goooood"
            },
            new BeerUser()
            {
                Id = 2,
                UserId = 4,
                BeerId = 1,
                Score = 4,
                Remark = "i like it"
            },
            new BeerUser()
            {
                Id = 3,
                UserId = 4,
                BeerId = 2,
                Score = 3,
                Remark = "bof-bof"
            },
            new BeerUser()
            {
                Id = 4,
                UserId = 3,
                BeerId = 3,
                Score = 2,
                Remark = "i don't like this beer"
            },
        };
    }
}
