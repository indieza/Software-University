using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TheVLogger
{
    public class TheVLogger
    {
        private static void Main()
        {
            List<User> users = new List<User>();

            string line = Console.ReadLine();

            while (line != "Statistics")
            {
                string[] items = line.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                string command = items[1];

                switch (command)
                {
                    case "joined":
                        string name = items[0];
                        User currentUser = new User(name);

                        if (users.FirstOrDefault(u => u.Name == currentUser.Name) == null)
                        {
                            users.Add(currentUser);
                        }
                        break;

                    case "followed":
                        string followerName = items[0];

                        string vloggerName = items[2];

                        if (users.FirstOrDefault(u => u.Name == followerName) != null &&
                            users.FirstOrDefault(u => u.Name == vloggerName) != null)
                        {
                            User follower = users.FirstOrDefault(u => u.Name == followerName);
                            User vlogger = users.FirstOrDefault(u => u.Name == vloggerName);
                            string s = follower.Following.FirstOrDefault(f => f == vlogger.Name);

                            if (s != vlogger.Name && vlogger.Name != follower.Name)
                            {
                                follower.Following.Add(vlogger.Name);
                                vlogger.Followers.Add(follower.Name);
                            }
                        }
                        break;

                    default:
                        break;
                }

                line = Console.ReadLine();
            }

            Console.WriteLine($"The V-Logger has a total of {users.Count} vloggers in its logs.");

            int index = 0;

            foreach (var user in users
                .OrderByDescending(x => x.Followers.Count)
                .ThenBy(x => x.Following.Count))
            {
                Console.WriteLine(
                    $"{++index}. {user.Name} : {user.Followers.Count} followers, {user.Following.Count} following");

                if (index == 1)
                {
                    foreach (var follower in user.Followers.OrderBy(x => x))
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }
            }
        }
    }

    public class User
    {
        public User(string name)
        {
            this.Name = name;
            this.Followers = new List<string>();
            this.Following = new List<string>();
        }

        public string Name { get; private set; }

        public List<string> Followers { get; private set; }

        public List<string> Following { get; private set; }
    }
}