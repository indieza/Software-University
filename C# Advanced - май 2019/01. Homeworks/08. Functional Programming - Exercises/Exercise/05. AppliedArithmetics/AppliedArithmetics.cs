using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.AppliedArithmetics
{
    public class AppliedArithmetics
    {
        private static void Main()
        {
            List<int> nums = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string command = Console.ReadLine();

            while (command != "end")
            {
                if (command == "add")
                {
                    nums = nums.Select(n => n + 1).ToList();
                }
                else if (command == "multiply")
                {
                    nums = nums.Select(n => n * 2).ToList();
                }
                else if (command == "subtract")
                {
                    nums = nums.Select(n => n - 1).ToList();
                }
                else if (command == "print")
                {
                    Console.WriteLine(string.Join(" ", nums));
                }
                command = Console.ReadLine();
            }
        }
    }
}