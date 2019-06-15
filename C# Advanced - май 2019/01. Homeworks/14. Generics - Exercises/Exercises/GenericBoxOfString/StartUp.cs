using System;
using System.Collections.Generic;

namespace GenericBoxOfString
{
    public class StartUp
    {
        private static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            List<Box<string>> list = new List<Box<string>>();

            for (int i = 0; i < n; i++)
            {
                var line = new Box<string>() { Value = Console.ReadLine() };
                list.Add(line);
            }

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}