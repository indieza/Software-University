using System;
using System.Collections.Generic;

namespace GenericBoxOfInteger
{
    public class StartUp
    {
        private static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            List<Box<int>> list = new List<Box<int>>();

            for (int i = 0; i < n; i++)
            {
                Box<int> line = new Box<int>() { Value = int.Parse(Console.ReadLine()) };
                list.Add(line);
            }

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}