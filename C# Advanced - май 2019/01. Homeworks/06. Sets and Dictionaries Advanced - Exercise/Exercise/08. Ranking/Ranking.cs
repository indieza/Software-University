using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Ranking
{
    public class Ranking
    {
        private static void Main()
        {
            string line = Console.ReadLine();

            Dictionary<string, string> contests = new Dictionary<string, string>();

            while (line!= "end of contests")
            {
                string[] items = line.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

                string contest = items[0];
                string password = items[1];

                contests.Add(contest, password);

                line = Console.ReadLine();
            }
        }
    }
}
