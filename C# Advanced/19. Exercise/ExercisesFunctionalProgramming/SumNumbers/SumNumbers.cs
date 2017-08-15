namespace SumNumbers
{
    using System;
    using System.Linq;

    internal class SumNumbers
    {
        private static void Main()
        {
            int[] nums = Console.ReadLine()
                .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            Console.WriteLine(nums.Length);
            Console.WriteLine(nums.Sum());
        }
    }
}