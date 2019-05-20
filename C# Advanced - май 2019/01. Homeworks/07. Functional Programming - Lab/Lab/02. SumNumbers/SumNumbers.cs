using System;
using System.Linq;

namespace _02.SumNumbers
{
    public class SumNumbers
    {
        private static void Main()
        {
            int[] nums = Console.ReadLine()
                .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine(nums.Count());
            Console.WriteLine(nums.Sum());
        }
    }
}