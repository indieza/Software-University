namespace _03.DecimalToBinaryConverter
{
    using System;
    using System.Collections.Generic;

    internal class DecimalToBinaryConverter
    {
        private static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            Stack<int> binary = new Stack<int>();

            if (number == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                int remainder = 0;

                while (number > 0)
                {
                    remainder = number % 2;
                    number /= 2;
                    binary.Push(remainder);
                }

                foreach (var i in binary)
                {
                    Console.Write(i);
                }
            }
        }
    }
}