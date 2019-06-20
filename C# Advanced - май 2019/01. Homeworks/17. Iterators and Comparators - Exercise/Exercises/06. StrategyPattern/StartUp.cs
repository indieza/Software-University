namespace _06.StrategyPattern
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var sortedByName = new SortedSet<Person>(new PersonComparerByName());
            var sortedByAge = new SortedSet<Person>(new PersonComparerByAge());

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                var name = input[0];
                var age = int.Parse(input[1]);
                var person = new Person() { Age = age, Name = name };
                sortedByName.Add(person);
                sortedByAge.Add(person);
            }

            foreach (var person in sortedByName)
            {
                Console.WriteLine(person);
            }

            foreach (var person in sortedByAge)
            {
                Console.WriteLine(person);
            }
        }
    }
}