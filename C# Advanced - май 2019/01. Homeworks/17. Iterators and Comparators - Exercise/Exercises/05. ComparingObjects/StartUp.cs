namespace _05.ComparingObjects
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var persons = new List<Person>();

            while (true)
            {
                var input = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                if (input[0] == "END")
                {
                    break;
                }
                var person = new Person() { Age = int.Parse(input[1]), Name = input[0], Town = input[2] };
                persons.Add(person);
            }

            var personIndex = int.Parse(Console.ReadLine()) - 1;
            var samePersonCount = 0;
            foreach (var person in persons)
            {
                if (person.CompareTo(persons[personIndex]) == 0)
                {
                    samePersonCount++;
                }
            }

            if (samePersonCount == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{samePersonCount} {persons.Count - samePersonCount} {persons.Count}");
            }
        }
    }
}