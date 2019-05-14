using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.BasicQueueOperations
{
    public class BasicQueueOperations
    {
        private static void Main()
        {
            int[] initials = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int n = initials[0];
            int s = initials[1];
            int x = initials[2];

            Queue<int> nums = new Queue<int>();
            int[] items = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < n; i++)
            {
                nums.Enqueue(items[i]);
            }

            for (int i = 0; i < s; i++)
            {
                nums.Dequeue();
            }

            if (nums.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (nums.Contains(x))
            {
                Console.WriteLine(true.ToString().ToLower());
            }
            else
            {
                Console.WriteLine(nums.Min());
            }
        }
    }
}