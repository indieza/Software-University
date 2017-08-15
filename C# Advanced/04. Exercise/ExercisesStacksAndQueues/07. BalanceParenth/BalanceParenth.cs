namespace _07.BalanceParenth
{
    using System;
    using System.Collections.Generic;

    internal class BalanceParenth
    {
        private static void Main()
        {
            char[] input = Console.ReadLine().ToCharArray();

            Stack<char> parenthesesStack = new Stack<char>();
            Dictionary<char, char> parentheses = new Dictionary<char, char>();

            parentheses.Add('{', '}');
            parentheses.Add('[', ']');
            parentheses.Add('(', ')');

            bool isBalanced = true;

            if (input.Length % 2 != 0)
            {
                Console.WriteLine("NO");
                return;
            }

            for (int i = 0; i < input.Length; i++)
            {
                if (parentheses.ContainsKey(input[i]))
                {
                    parenthesesStack.Push(input[i]);
                }
                else if (parenthesesStack.Count == 0 || input[i] != parentheses[parenthesesStack.Peek()])
                {
                    isBalanced = false;
                    break;
                }
                else if (input[i] == parentheses[parenthesesStack.Peek()])
                {
                    parenthesesStack.Pop();
                }
            }

            Console.WriteLine(isBalanced ? "YES" : "NO");
        }
    }
}