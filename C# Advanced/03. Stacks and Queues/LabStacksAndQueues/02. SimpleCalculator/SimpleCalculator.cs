namespace _02.SimpleCalculator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class SimpleCalculator
    {
        private static void Main()
        {
            string[] line = Console.ReadLine().Split();

            Stack<string> st = new Stack<string>(line.Reverse());

            int result = int.Parse(st.ElementAt(0));

            for (int i = 1; i < st.Count - 1; i++)
            {
                if (st.ElementAt(i) == "+")
                {
                    result += int.Parse(st.ElementAt(i + 1));
                }
                else if (st.ElementAt(i) == "-")
                {
                    result -= int.Parse(st.ElementAt(i + 1));
                }
            }

            Console.WriteLine(result);
        }
    }
}