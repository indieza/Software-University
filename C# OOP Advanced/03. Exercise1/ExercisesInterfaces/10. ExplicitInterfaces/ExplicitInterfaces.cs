using System;
using System.Collections.Generic;

namespace _10.ExplicitInterfaces
{
    internal class ExplicitInterfaces
    {
        private static void Main()
        {
            var residents = new List<IResident>();
            var persons = new List<IPerson>();

            var input = Console.ReadLine();
            while (input != "End")
            {
                var personTokens = input.Split();
                var name = personTokens[0];
                var country = personTokens[1];
                var age = int.Parse(personTokens[2]);
                IResident currentResident = new Citizen(name, country, age);
                IPerson currentPerson = new Citizen(name, country, age);

                residents.Add(currentResident);
                persons.Add(currentPerson);

                input = Console.ReadLine();
            }

            for (int i = 0; i < residents.Count; i++)
            {
                Console.WriteLine(persons[i].GetName());
                Console.WriteLine(residents[i].GetName());
            }
        }
    }
}