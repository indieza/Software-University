using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.CustomMinFunction
{
    public class CustomMinFunction
    {
        private static void Main()
        {
            List<int> nums = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            Console.WriteLine(nums.Min());
        }
    }
}