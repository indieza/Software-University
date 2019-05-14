using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.BasicStackOperations
{
    public class BasicStackOperations
    {
        private static void Main()
        {
            int[] initials = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int n = initials[0];
            int s = initials[1];
            int x = initials[2];

            Stack<int> nums = new Stack<int>();
            int[] items = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < n; i++)
            {
                nums.Push(items[i]);
            }

            for (int i = 0; i < s; i++)
            {
                nums.Pop();
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