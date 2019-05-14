using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.HotPotato
{
    public class HotPotato
    {
        private static void Main()
        {
            Queue<string> children = new Queue<string>(Console.ReadLine().Split());
            int n = int.Parse(Console.ReadLine());

            while (children.Count != 1)
            {
                for (int i = 1; i < n; i++)
                {
                    children.Enqueue(children.Dequeue());
                }

                Console.WriteLine($"Removed {children.Dequeue()}");
            }

            Console.WriteLine($"Last is {children.Last()}");
        }
    }
}