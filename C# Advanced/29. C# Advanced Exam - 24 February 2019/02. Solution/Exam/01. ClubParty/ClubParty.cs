using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _01.ClubParty
{
    public class ClubParty
    {
        private static readonly Regex AlphaPattern = new Regex(@"[a-zA-Z]");
        private static readonly Regex NumsPattern = new Regex(@"[0-9]");

        private static void Main()
        {
            int hallsCapacity = int.Parse(Console.ReadLine());
            string[] items = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            List<string> halls = new List<string>();
            List<int> capacity = new List<int>();

            for (int i = items.Length - 1; i >= 0; i--)
            {
                string item = items[i];

                if (AlphaPattern.IsMatch(item))
                {
                    halls.Add(item);
                }
                else if (NumsPattern.IsMatch(item))
                {
                    capacity.Add(int.Parse(item.ToString()));
                }
            }

            int saveCapacity = 0;

            while (halls.Count != 0 || capacity.Count != 0)
            {
                int currentCapacity = capacity[0];

                if (currentCapacity > hallsCapacity)
                {
                    capacity.RemoveAt(0);
                }
                else
                {
                    saveCapacity += currentCapacity;
                }
            }
        }
    }
}
