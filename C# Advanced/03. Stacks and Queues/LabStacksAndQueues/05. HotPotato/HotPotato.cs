namespace _05.HotPotato
{
    using System;
    using System.Collections.Generic;

    internal class HotPotato
    {
        private static void Main()
        {
            string[] names = Console.ReadLine().Split(' ');
            int number = int.Parse(Console.ReadLine());

            Queue<string> queue = new Queue<string>(names);

            while (queue.Count > 1)
            {
                for (int i = 0; i < number - 1; i++)
                {
                    string reminder = queue.Dequeue();
                    queue.Enqueue(reminder);
                }

                Console.WriteLine("Removed {0}", queue.Dequeue());
            }

            Console.WriteLine("Last is {0}", queue.Dequeue());
        }
    }
}