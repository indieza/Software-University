using System;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main()
        {
            int membersCount = int.Parse(Console.ReadLine());
            Family members = new Family();

            for (int i = 0; i < membersCount; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = input[0];
                int age = int.Parse(input[1]);
                Person person = new Person(name, age);

                members.AddMember(person);
            }

            List<Person> personThanMore30Year = members.GetMemberMoreThan30();

            foreach (var person in personThanMore30Year)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}