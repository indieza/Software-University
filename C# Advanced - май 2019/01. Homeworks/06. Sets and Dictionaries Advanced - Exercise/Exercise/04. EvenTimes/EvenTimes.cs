using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.EvenTimes
{
    public class EvenTimes
    {
        private static void Main()
        {
            Dictionary<int, int> numbers = new Dictionary<int, int>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (!numbers.ContainsKey(number))
                {
                    numbers.Add(number, 0);
                }

                numbers[number]++;
            }

            foreach (var number in numbers.Where(x => x.Value % 2 == 0))
            {
                Console.WriteLine(number.Key);
            }
        }
    }
}