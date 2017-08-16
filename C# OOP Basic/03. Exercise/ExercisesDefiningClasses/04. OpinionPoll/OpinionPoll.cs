using System;
using System.Collections.Generic;
using System.Linq;

internal class OpinionPoll
{
    private static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        List<Person> people = new List<Person>();

        for (int i = 0; i < n; i++)
        {
            string[] items = Console.ReadLine().Split();
            string name = items[0];
            int age = int.Parse(items[1]);
            people.Add(new Person(name, age));
        }

        List<Person> sorted = people
            .Where(person => person.Age > 30)
            .OrderBy(person => person.Name).ToList();

        foreach (var person in sorted)
        {
            Console.WriteLine($"{person.Name} - {person.Age}");
        }
    }
}