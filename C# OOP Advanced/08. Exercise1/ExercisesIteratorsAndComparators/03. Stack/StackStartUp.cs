namespace _03.Stack
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class StackStartUp
    {
        private static void Main()
        {
            string line = Console.ReadLine();

            Stack<int> stack = new Stack<int>();

            while (line != "END")
            {
                string[] items = line.Split(new[] { ", ", " " }, StringSplitOptions.RemoveEmptyEntries);

                switch (items[0])
                {
                    case "Push":
                        List<int> numbers = items.Skip(1).Select(int.Parse).ToList();

                        foreach (var number in numbers)
                        {
                            stack.Push(number);
                        }

                        break;

                    case "Pop":
                        try
                        {
                            stack.Pop();
                        }
                        catch (Exception exception)
                        {
                            Console.WriteLine(exception.Message);
                        }

                        break;
                }

                line = Console.ReadLine();
            }

            Print(stack);
            Print(stack);
        }

        private static void Print<T>(IEnumerable<T> stack)
        {
            foreach (var i in stack)
            {
                Console.WriteLine(i);
            }
        }
    }
}