namespace _10.SimpleTextEditor
{
    using System;
    using System.Collections.Generic;

    internal class SimpleTextEditor
    {
        private static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Stack<string> previousCommands = new Stack<string>();

            string text = string.Empty;

            for (int i = 0; i < n; i++)
            {
                string[] commands = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                switch (commands[0])
                {
                    case "1":
                        previousCommands.Push(text);
                        text += commands[1];
                        break;

                    case "2":
                        previousCommands.Push(text);
                        text = text.Substring(0, text.Length - int.Parse(commands[1]));
                        break;

                    case "3":
                        Console.WriteLine(text[int.Parse(commands[1]) - 1]);
                        break;

                    case "4":
                        text = previousCommands.Pop();
                        break;
                }
            }
        }
    }
}