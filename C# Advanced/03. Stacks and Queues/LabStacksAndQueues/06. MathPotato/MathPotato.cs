namespace _06.MathPotato
{
    using System;
    using System.Collections.Generic;

    internal class MathPotato
    {
        public static bool PrimeTool { get; private set; }

        private static void Main()
        {
            string[] names = Console.ReadLine().Split(' ');
            int number = int.Parse(Console.ReadLine());

            Queue<string> queue = new Queue<string>(names);

            int cycle = 1;

            while (queue.Count > 1)
            {
                for (int i = 0; i < number - 1; i++)
                {
                    string reminder = queue.Dequeue();
                    queue.Enqueue(reminder);
                }

                if (IsPrime(cycle))
                {
                    Console.WriteLine("Prime {0}", queue.Peek());
                }
                else
                {
                    Console.WriteLine("Removed {0}", queue.Dequeue());
                }

                cycle++;
            }

            Console.WriteLine("Last is {0}", queue.Dequeue());
        }

        private static bool IsPrime(int candidate)
        {
            if ((candidate & 1) == 0)
            {
                if (candidate == 2)
                {
                    return true;
                }

                return false;
            }

            for (int i = 3; i * i <= candidate; i += 2)
            {
                if (candidate % i == 0)
                {
                    return false;
                }
            }

            return candidate != 1;
        }
    }
}