using System;

namespace _07.PascalTriangle
{
    public class PascalTriangle
    {
        private static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                long number = 1;

                for (int j = 0; j <= i; j++)
                {
                    Console.Write(number + " ");
                    number = number * (i - j) / (j + 1);
                }

                Console.WriteLine();
            }
        }
    }
}