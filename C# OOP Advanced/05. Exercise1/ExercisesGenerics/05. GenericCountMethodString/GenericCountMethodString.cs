using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.GenericCountMethodString
{
    internal class GenericCountMethodString
    {
        private static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var boxes = new List<Box<string>>();

            for (int i = 0; i < n; i++)
            {
                var box = new Box<string>(Console.ReadLine());
                boxes.Add(box);
            }

            var comparableElement = Console.ReadLine();

            var count = GetCountOfGreatherElements(boxes, comparableElement);
            Console.WriteLine(count);
        }

        private static int GetCountOfGreatherElements<T>(List<Box<T>> boxes, T comparableElement)
        where T : IComparable<T>
        {
            var count = boxes.Count(b => b.Value.CompareTo(comparableElement) > 0);
            return count;
        }
    }
}