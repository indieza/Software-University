namespace _01.ReverseNumbersWithStack
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class ReverseNumbersWithStack
    {
        private static void Main()
        {
            int[] numbers = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                stack.Push(numbers[i]);
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write("{0} ", stack.Pop());
            }
        }
    }
}