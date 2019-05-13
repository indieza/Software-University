using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.StackSum
{
    public class StackSum
    {
        private static void Main()
        {
            Stack<int> nums = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

            string command = Console.ReadLine();

            while (command.ToLower() != "end")
            {
                string[] items = command.Split();
                switch (items[0].ToLower())
                {
                    case "add":
                        nums.Push(int.Parse(items[1]));
                        nums.Push(int.Parse(items[2]));
                        break;

                    case "remove":
                        if (int.Parse(items[1]) > nums.Count)
                        {
                            command = Console.ReadLine();
                            continue;
                        }

                        for (int i = 0; i < int.Parse(items[1]); i++)
                        {
                            nums.Pop();
                        }
                        break;

                    default:
                        break;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Sum: {nums.Sum()}");
        }
    }
}