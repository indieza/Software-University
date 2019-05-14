using System;
using System.Collections.Generic;

namespace _06.Supermarket
{
    public class Supermarket
    {
        private static void Main()
        {
            string line = Console.ReadLine();
            Queue<string> people = new Queue<string>();
            Queue<string> paid = new Queue<string>();

            while (line != "End")
            {
                if (line == "Paid")
                {
                    foreach (var person in people)
                    {
                        paid.Enqueue(person);
                        Console.WriteLine(person);
                    }

                    people.Clear();
                }
                else
                {
                    people.Enqueue(line);
                }

                line = Console.ReadLine();
            }

            Console.WriteLine($"{people.Count} people remaining.");
        }
    }
}