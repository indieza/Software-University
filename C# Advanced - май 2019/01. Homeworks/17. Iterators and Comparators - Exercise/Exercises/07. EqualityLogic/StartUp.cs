using System;
using System.Collections.Generic;

namespace _07.EqualityLogic
{
    public class StartUp
    {
        public static void Main()
        {
            var people = new HashSet<Person>();
            var sortedPeople = new SortedSet<Person>();

            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.None);
                var person = new Person() { Age = int.Parse(input[1]), Name = input[0] };
                people.Add(person);
                sortedPeople.Add(person);
            }

            Console.WriteLine(sortedPeople.Count);
            Console.WriteLine(people.Count);
        }
    }
}