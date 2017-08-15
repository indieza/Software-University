namespace _03.MaxElement
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class MaxElement
    {
        private static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Stack<int> sequence = new Stack<int>();
            Stack<int> maxValues = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                int[] input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

                switch (input[0])
                {
                    case 1:
                        sequence.Push(input[1]);

                        if (maxValues.Count == 0 || maxValues.Peek() < input[1])
                        {
                            maxValues.Push(input[1]);
                        }

                        break;

                    case 2:
                        if (sequence.Count > 0)
                        {
                            if (maxValues.Count == 0)
                            {
                                sequence.Pop();
                            }
                            else if (maxValues.Peek() == sequence.Pop())
                            {
                                maxValues.Pop();
                            }
                        }

                        break;

                    case 3:
                        if (sequence.Count > 0)
                        {
                            Console.WriteLine(maxValues.Peek());
                        }

                        break;
                }
            }
        }
    }
}