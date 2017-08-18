using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.GenericSwapMethodInteger
{
    internal class GenericSwapMethodInteger
    {
        private static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            List<Box<int>> box = new List<Box<int>>();

            for (int i = 0; i < n; i++)
            {
                box.Add(new Box<int>(int.Parse(Console.ReadLine())));
            }

            int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int firsIndex = indexes[0];
            int secondIndex = indexes[1];

            Swap(firsIndex, secondIndex, box);

            for (int i = 0; i < box.Count; i++)
            {
                Console.WriteLine(box[i]);
            }
        }

        private static void Swap(int firsIndex, int secondIndex, List<Box<int>> box)
        {
            Box<int> save = box[secondIndex];
            box[secondIndex] = box[firsIndex];
            box[firsIndex] = save;
        }
    }
}