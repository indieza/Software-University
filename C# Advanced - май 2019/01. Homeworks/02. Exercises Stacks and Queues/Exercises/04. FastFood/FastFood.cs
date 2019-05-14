using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FastFood
{
    public class FastFood
    {
        private static void Main()
        {
            int quality = int.Parse(Console.ReadLine());
            Queue<int> orders = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));

            Console.WriteLine(orders.Max());

            while (orders.Count != 0)
            {
                int currentOrder = orders.Peek();

                if (currentOrder <= quality)
                {
                    quality -= orders.Dequeue();
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine(orders.Count == 0 ? "Orders complete" : $"Orders left: {string.Join(" ", orders)}");
        }
    }
}