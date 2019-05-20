using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.ReverseAndExclude
{
    public class ReverseAndExclude
    {
        private static void Main()
        {
            List<int> nums = Console.ReadLine()
               .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToList();

            int n = int.Parse(Console.ReadLine());

            Predicate<int> result;
            result = x => x % n != 0;

            Console.Write(string.Join(" ", nums.Where(x => result(x)).Reverse()));
        }
    }
}