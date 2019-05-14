using System;
using System.Collections.Generic;

namespace _04.MatchingBrackets
{
    public class MatchingBrackets
    {
        private static void Main()
        {
            char[] line = Console.ReadLine().ToCharArray();
            Stack<int> indexes = new Stack<int>();

            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == '(')
                {
                    indexes.Push(i);
                }
                if (line[i] == ')')
                {
                    for (int k = indexes.Pop(); k < i + 1; k++)
                    {
                        Console.Write(line[k]);
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}