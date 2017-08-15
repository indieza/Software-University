namespace _12.StringMatrixRotations
{
    using System;
    using System.Collections.Generic;

    internal class StringMatrixRotations
    {
        private static void Main()
        {
            string rotate = Console.ReadLine();
            string[] integer = rotate.Split('(');

            integer[1] = integer[1].Remove(integer[1].Length - 1, 1);
            int degrees = int.Parse(integer[1]);
            string text = Console.ReadLine();

            List<string> input = new List<string>();
            int longestWord = 0;

            while (text != "END")
            {
                input.Add(text);

                if (longestWord < text.Length)
                {
                    longestWord = text.Length;
                }

                text = Console.ReadLine();
            }

            for (int i = 0; i < input.Count; i++)
            {
                if (input[i].Length < longestWord)
                {
                    input[i] = input[i] + new string(' ', longestWord - input[i].Length);
                }
            }

            if (degrees == 180 || degrees % 360 == 180)
            {
                for (int i = input.Count - 1; i >= 0; i--)
                {
                    for (int j = input[i].Length - 1; j >= 0; j--)
                    {
                        Console.Write(input[i][j]);
                    }

                    Console.WriteLine();
                }
            }

            char[,] rotate90 = new char[longestWord, input.Count];

            for (int row = 0; row < longestWord; row++)
            {
                for (int col = 0; col < input.Count; col++)
                {
                    rotate90[row, col] = input[col][row];
                }
            }

            if (degrees == 270 || degrees % 360 == 270)
            {
                for (int i = rotate90.GetLength(0) - 1; i >= 0; i--)
                {
                    for (int j = 0; j < rotate90.GetLength(1); j++)
                    {
                        Console.Write(rotate90[i, j]);
                    }

                    Console.WriteLine();
                }
            }

            if (degrees == 90 || degrees % 360 == 90)
            {
                for (int i = 0; i < rotate90.GetLength(0); i++)
                {
                    for (int j = rotate90.GetLength(1) - 1; j >= 0; j--)
                    {
                        Console.Write(rotate90[i, j]);
                    }

                    Console.WriteLine();
                }
            }

            if (degrees == 0 || degrees % 360 == 0)
            {
                foreach (var rotate360 in input)
                {
                    Console.WriteLine(rotate360);
                }
            }
        }
    }
}