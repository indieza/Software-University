using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.MaxAndMinElement
{
    public class MaxAndMinElement
    {
        private static void Main()
        {
            Stack<int> nums = new Stack<int>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int[] items = Console.ReadLine().Split().Select(int.Parse).ToArray();
                if (items.Length == 2)
                {
                    nums.Push(items[1]);
                }
                else
                {
                    if (items[0] == 2 && nums.Count != 0)
                    {
                        nums.Pop();
                    }
                    else if (items[0] == 3 && nums.Count != 0)
                    {
                        Console.WriteLine(nums.Max());
                    }
                    else if (items[0] == 4 && nums.Count != 0)
                    {
                        Console.WriteLine(nums.Min());
                    }
                }
            }

            if (nums.Count != 0)
            {
                Console.WriteLine(string.Join(", ", nums));
            }
        }
    }
}