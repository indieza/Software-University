using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.ListOfPredicates
{
    public class ListOfPredicates
    {
        private static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            List<int> deviders = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> nums = new List<int>();

            bool Check(int x, int y) => x % y != 0;

            for (int i = 1; i <= n; i++)
            {
                bool isStillSearch = true;

                foreach (var devider in deviders)
                {
                    if (Check(i, devider))
                    {
                        isStillSearch = false;
                        break;
                    }
                }

                if (isStillSearch)
                {
                    nums.Add(i);
                }
            }

            Console.WriteLine(string.Join(" ", nums));
        }
    }
}