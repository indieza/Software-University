using System;
using System.Linq;

namespace _04.AddVAT
{
    public class AddVAT
    {
        private static void Main()
        {
            double[] nums = Console.ReadLine()
                .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            nums = nums.Select(n => n * 0.20 + n).ToArray();

            foreach (var num in nums)
            {
                Console.WriteLine($"{num:F2}");
            }
        }
    }
}