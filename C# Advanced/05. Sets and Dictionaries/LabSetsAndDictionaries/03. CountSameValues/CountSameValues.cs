namespace _03.CountSameValues
{
    using System;
    using System.Collections.Generic;

    internal class CountSameValues
    {
        private static void Main()
        {
            var numbers = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var sortedDictionary = new SortedDictionary<double, int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                var currentNumber = double.Parse(numbers[i]);

                if (!sortedDictionary.ContainsKey(currentNumber))
                {
                    sortedDictionary[currentNumber] = 1;
                }
                else
                {
                    sortedDictionary[currentNumber]++;
                }
            }

            foreach (var number in sortedDictionary)
            {
                Console.WriteLine($"{number.Key} - {number.Value} times");
            }
        }
    }
}