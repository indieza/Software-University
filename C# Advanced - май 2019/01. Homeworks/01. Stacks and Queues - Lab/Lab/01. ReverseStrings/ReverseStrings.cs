using System;
using System.Collections.Generic;

namespace _01.ReverseStrings
{
    public class ReverseStrings
    {
        private static void Main()
        {
            char[] line = Console.ReadLine().ToCharArray();
            Stack<char> items = new Stack<char>(line);
            int count = items.Count;

            for (int i = 0; i < count; i++)
            {
                Console.Write(items.Pop());
            }
        }
    }
}