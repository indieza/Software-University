namespace CustomComparator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class EvenOrOddComparer : IComparer<int>
    {
        public int Compare(int a, int b)
        {
            if (a % 2 == 0 && b % 2 != 0)
            {
                return -1;
            }

            if (b % 2 == 0 && a % 2 != 0)
            {
                return 1;
            }

            if (a < b)
            {
                return -1;
            }

            return 1;
        }
    }

    internal class CustomComparator
    {
        private static void Main()
        {
            int[] nums = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Array.Sort(nums, new EvenOrOddComparer());

            Console.WriteLine(string.Join(" ", nums));
        }
    }
}