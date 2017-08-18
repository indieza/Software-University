using System;

namespace _02.GenericBoxOfInteger
{
    internal class GenericBoxOfInteger
    {
        private static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int line = int.Parse(Console.ReadLine());
                Box<int> element = new Box<int>(line);
                Console.WriteLine(element);
            }
        }
    }
}