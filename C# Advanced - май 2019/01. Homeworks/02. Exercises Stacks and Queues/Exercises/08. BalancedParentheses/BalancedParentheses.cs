using System;
using System.Collections.Generic;

namespace _08.BalancedParentheses
{
    public class BalancedParentheses
    {
        private static void Main()
        {
            char[] items = Console.ReadLine().ToCharArray();
            Stack<char> brackets = new Stack<char>();

            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] == '[' || items[i] == '(' || items[i] == '{')
                {
                    brackets.Push(items[i]);
                }
                else
                {
                    if (brackets.Count == 0)
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                    else if (items[i] == ')')
                    {
                        char check = brackets.Pop();

                        if (check != '(')
                        {
                            Console.WriteLine("NO");
                            return;
                        }
                    }
                    else if (items[i] == '}')
                    {
                        char check = brackets.Pop();

                        if (check != '{')
                        {
                            Console.WriteLine("NO");
                            return;
                        }
                    }
                    else if (items[i] == ']')
                    {
                        char check = brackets.Pop();

                        if (check != '[')
                        {
                            Console.WriteLine("NO");
                            return;
                        }
                    }
                }
            }

            if (brackets.Count == 0)
            {
                Console.WriteLine("YES");
            }
        }
    }
}