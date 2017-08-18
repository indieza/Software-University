namespace _04.Froggy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class FroggyStartUp
    {
        private static void Main()
        {
            IList<int> numbers = Console.ReadLine().Split(new[] { ", ", " ", "," }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();

            Lake<int> lake = new Lake<int>(numbers);

            lake.Move();

            Console.WriteLine(string.Join(", ", lake));
        }
    }
}