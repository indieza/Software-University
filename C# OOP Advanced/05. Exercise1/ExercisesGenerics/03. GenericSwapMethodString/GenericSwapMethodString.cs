using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.GenericSwapMethodString
{
    internal class GenericSwapMethodString
    {
        private static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            List<Box<string>> box = new List<Box<string>>();

            for (int i = 0; i < n; i++)
            {
                box.Add(new Box<string>(Console.ReadLine()));
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

        private static void Swap(int firsIndex, int secondIndex, List<Box<string>> box)
        {
            Box<string> save = box[secondIndex];
            box[secondIndex] = box[firsIndex];
            box[firsIndex] = save;
        }
    }
}