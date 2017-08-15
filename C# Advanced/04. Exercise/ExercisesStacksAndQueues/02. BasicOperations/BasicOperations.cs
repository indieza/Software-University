namespace _02.BasicOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class BasicOperations
    {
        private static void Main()
        {
            int[] inputParameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int elementsToPush = inputParameters[0];
            int elementsToPop = inputParameters[1];
            int element = inputParameters[2];
            int[] numbersInput = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            Stack<int> numbers = new Stack<int>();

            for (int i = 0; i < elementsToPush; i++)
            {
                numbers.Push(numbersInput[i]);
            }

            for (int i = 0; i < elementsToPop; i++)
            {
                numbers.Pop();
            }

            if (numbers.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (numbers.Contains(element))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(numbers.Min());
            }
        }
    }
}