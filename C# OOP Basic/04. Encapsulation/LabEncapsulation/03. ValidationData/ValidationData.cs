using System;
using System.Collections.Generic;

namespace _03.ValidationData
{
    internal class ValidationData
    {
        private static void Main()
        {
            var lines = int.Parse(Console.ReadLine());
            var persons = new List<Person>();
            for (int i = 0; i < lines; i++)
            {
                var cmdArgs = Console.ReadLine().Split();
                var person = new Person(cmdArgs[0],
                    cmdArgs[1],
                    int.Parse(cmdArgs[2]),
                    decimal.Parse(cmdArgs[3]));

                persons.Add(person);
            }
            var bonus = decimal.Parse(Console.ReadLine());
            persons.ForEach(person => person.IncreaseSalary(bonus));
            persons.ForEach(p => Console.WriteLine(p.ToString()));
        }
    }
}