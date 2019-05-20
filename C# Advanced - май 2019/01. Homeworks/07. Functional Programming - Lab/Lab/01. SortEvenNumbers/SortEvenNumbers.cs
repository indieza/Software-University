using System;
using System.Linq;

namespace _01.SortEvenNumbers
{
    public class SortEvenNumbers
    {
        private static void Main()
        {
            int[] nums = Console.ReadLine()
                .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            nums = nums.Where(n => n % 2 == 0).OrderBy(n => n).ToArray();

            Console.WriteLine(string.Join(", ", nums));
        }
    }
}