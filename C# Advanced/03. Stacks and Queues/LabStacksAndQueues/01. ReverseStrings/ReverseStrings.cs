namespace _01.ReverseStrings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class ReverseStrings
    {
        private static void Main()
        {
            char[] text = Console.ReadLine().ToArray();

            Stack<char> st = new Stack<char>();

            for (int i = 0; i < text.Length; i++)
            {
                st.Push(text[i]);
            }

            foreach (var i in st)
            {
                Console.Write(i);
            }
        }
    }
}