using System;
using System.Collections.Generic;

namespace GenericCountMethodStrings
{
    public class StartUp
    {
        private static void Main()
        {
            Box<string> box = new Box<string>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                box.Add(Console.ReadLine());
            }

            string element = Console.ReadLine();
            Console.WriteLine(CompareElement(box.Data, element));
        }

        private static object CompareElement<T>(List<T> boxData, string element)
        {
            int count = 0;

            foreach (var item in boxData)
            {
                if (element.CompareTo(item) < 0)
                {
                    count++;
                }
            }

            return count;
        }
    }
}