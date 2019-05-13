using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.SimpleCalculator
{
    public class SimpleCalculator
    {
        private static void Main()
        {
            Stack<string> items = new Stack<string>(Console.ReadLine().Split().Reverse());
            int result = int.Parse(items.Pop());

            while (items.Count != 0)
            {
                if (items.Peek() == "+")
                {
                    items.Pop();
                    result += int.Parse(items.Pop());
                }
                else
                {
                    items.Pop();
                    result -= int.Parse(items.Pop());
                }
            }

            Console.WriteLine(result);
        }
    }
}