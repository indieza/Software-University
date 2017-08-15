namespace _08.Fibonacci
{
    using System;

    internal class Fibonacci
    {
        private static long[] fibonacci;

        private static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            fibonacci = new long[n];
            fibonacci[0] = 1;
            fibonacci[1] = 1;

            if (n > 1)
            {
                Console.WriteLine(GetFibonacci(n - 1));
            }
        }

        private static long GetFibonacci(int n)
        {
            if (fibonacci[n] == 0)
            {
                fibonacci[n] = GetFibonacci(n - 1) + GetFibonacci(n - 2);
            }

            return fibonacci[n];
        }
    }
}