namespace _05.ComparingObjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class ComparingObjects
    {
        private static void Main()
        {
            var input = Console.ReadLine();
            var peoples = new List<Person>();

            while (input != "END")
            {
                var tokens = input.Split();
                var name = tokens[0];
                var age = int.Parse(tokens[1]);
                var town = tokens[2];
                var person = new Person(name, age, town);
                peoples.Add(person);

                input = Console.ReadLine();
            }

            int index = int.Parse(Console.ReadLine());
            Person comparePeople = peoples[index - 1];

            IEnumerable<Person> numberOfEqualPeople = peoples.Where(people => people.CompareTo(comparePeople) == 0);
            int numberOfNotEqualPeople = peoples.Count - numberOfEqualPeople.Count();

            if (numberOfEqualPeople.Count() < 2)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{numberOfEqualPeople.Count()} {numberOfNotEqualPeople} {peoples.Count}");
            }
        }
    }
}