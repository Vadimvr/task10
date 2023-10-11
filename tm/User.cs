using System.Collections.Generic;

namespace tm
{

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public ICollection<Game> Games { get; set; }

        public static List<User> GetUser()
        {
            return new List<User>()
            {
                new User () { Name ="Vadim", Email ="Vadim@email.com" },
                new User () { Name ="Bob", Email ="Bob@email.com" },
                new User () { Name ="Jun", Email ="Jun@email.com" },
                new User () { Name ="Au", Email ="Au@email.com" },
                new User () { Name ="Lila", Email ="Lila@email.com" },
                new User () { Name ="Jack", Email ="Jack@email.com" },
                new User () { Name ="Sam", Email ="Sam@email.com" },
                new User () { Name ="Jessika", Email ="Jessika@email.com" },
            };
        }
    }

    public class Game
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
        public string Name { get; set; }

        public static List<Game> GetGame()
        {
            return new List<Game>()
            {
                new Game () { Name ="Vadim" },
                new Game () { Name ="Bob"   },
                new Game () { Name ="Jun"   },
                new Game () { Name ="Au"    },
                new Game () { Name ="Lila"  },
                new Game () { Name ="Jack"  },
                new Game () { Name ="Sam"   },
                new Game () { Name ="Jessika" },
            };
        }
    }

}
