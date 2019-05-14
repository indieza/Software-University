using System;
using System.Collections.Generic;

namespace _09.SimpleTextEditor
{
    public class SimpleTextEditor
    {
        private static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Stack<string> texts = new Stack<string>();
            string text = string.Empty;
            texts.Push(text);

            for (int i = 0; i < n; i++)
            {
                string[] items = Console.ReadLine().Split();
                if (items[0] == "1")
                {
                    text += items[1];
                    texts.Push(text);
                }
                else if (items[0] == "2")
                {
                    int count = int.Parse(items[1]);
                    text = text.Substring(0, text.Length - count);
                    texts.Push(text);
                }
                else if (items[0] == "3")
                {
                    int index = int.Parse(items[1]);
                    Console.WriteLine(text[index - 1]);
                }
                else if (items[0] == "4")
                {
                    if (texts.Count >= 2)
                    {
                        texts.Pop();
                        text = texts.Peek();
                    }
                }
            }
        }
    }
}