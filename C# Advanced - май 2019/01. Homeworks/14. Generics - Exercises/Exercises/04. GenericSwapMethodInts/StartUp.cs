using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethodIntegers
{
    public class StartUp
    {
        private static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Box<int> list = new Box<int>();

            for (int i = 0; i < n; i++)
            {
                list.Add(int.Parse(Console.ReadLine()));
            }

            int[] input = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int firstIndex = input[0];
            int secondIndex = input[1];

            Swap(list.Data, firstIndex, secondIndex);

            list.Data.ForEach(x => Console.WriteLine($"{x.GetType()}: {x}"));
        }

        private static void Swap<T>(List<T> list, int firstIndex, int secondIndex)
        {
            T temp = list[firstIndex];
            list[firstIndex] = list[secondIndex];
            list[secondIndex] = temp;
        }
    }
}