using System;

namespace _01.GenericBoxOfStrings
{
    internal class GenericBoxOfStrings
    {
        private static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                Box<string> element = new Box<string>(line);
                Console.WriteLine(element);
            }
        }
    }
}