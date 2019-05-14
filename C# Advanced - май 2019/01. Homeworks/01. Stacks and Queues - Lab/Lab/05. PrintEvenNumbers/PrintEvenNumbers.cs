using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.PrintEvenNumbers
{
    public class PrintEvenNumbers
    {
        private static void Main()
        {
            Queue<int> nums = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            Queue<int> result = new Queue<int>();

            foreach (var num in nums.Where(n => n % 2 == 0))
            {
                result.Enqueue(num);
            }

            Console.WriteLine(string.Join(", ", result));
        }
    }
}