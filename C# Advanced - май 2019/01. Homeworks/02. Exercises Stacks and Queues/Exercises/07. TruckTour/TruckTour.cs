using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TruckTour
{
    public class TruckTour
    {
        private static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Queue<int[]> pumps = new Queue<int[]>();

            for (int i = 0; i < n; i++)
            {
                int[] items = Console.ReadLine().Split().Select(int.Parse).ToArray();
                pumps.Enqueue(items);
            }

            int count = 0;

            while (true)
            {
                int sum = 0;
                foreach (var pump in pumps)
                {
                    int first = pump[0];
                    int second = pump[1];
                    sum += first - second;

                    if (sum < 0)
                    {
                        count++;
                        int[] currentPump = pumps.Dequeue();
                        pumps.Enqueue(currentPump);
                        break;
                    }
                }

                if (sum >= 0)
                {
                    break;
                }
            }

            Console.WriteLine(count);
        }
    }
}