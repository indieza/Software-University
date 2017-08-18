using System;
using System.Linq;

namespace _10.Tuple
{
    internal class StartUp
    {
        private static void Main()
        {
            var firstLine = Console.ReadLine().Split();
            var nameTokens = firstLine.Take(firstLine.Length - 1).ToList();
            var name = string.Join(" ", nameTokens);
            var adress = firstLine.LastOrDefault();
            var firstTuple = new Tuple<string, string>(name, adress);
            Console.WriteLine(firstTuple);

            var secondLine = Console.ReadLine().Split();
            name = secondLine[0];
            var amountOfBeer = int.Parse(secondLine[1]);
            var secondTuple = new Tuple<string, int>(name, amountOfBeer);
            Console.WriteLine(secondTuple);

            var thirdLine = Console.ReadLine().Split();
            var intItem = int.Parse(thirdLine[0]);
            var doubleItem = double.Parse(thirdLine[1]);
            var thirdTuple = new Tuple<int, double>(intItem, doubleItem);
            Console.WriteLine(thirdTuple);
        }
    }
}