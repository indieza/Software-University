using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FindEvensOrOdds
{
    public class FindEvensOrOdds
    {
        private static void Main()
        {
            List<int> range = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            string condition = Console.ReadLine();
            List<int> listOfNumbers = new List<int>();
            Predicate<int> evenOrOdds;

            for (int i = range[0]; i <= range[1]; i++)
            {
                listOfNumbers.Add(i);
            }
            if (condition == "even")
            {
                evenOrOdds = x => x % 2 == 0;
            }
            else
            {
                evenOrOdds = x => x % 2 != 0;
            }

            Console.Write(string.Join(" ", listOfNumbers.Where(x => evenOrOdds(x))));
        }
    }
}