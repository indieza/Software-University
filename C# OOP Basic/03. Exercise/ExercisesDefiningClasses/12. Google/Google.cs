using System;
using System.Collections.Generic;

internal class Google
{
    private static void Main()
    {
        string line = Console.ReadLine();
        Dictionary<string, Person> persons = new Dictionary<string, Person>();

        while (line != "End")
        {
            string[] items = line.Split();
            string personName = items[0];
            string type = items[1];

            if (!persons.ContainsKey(personName))
            {
                persons.Add(personName, new Person(personName));
            }

            switch (type)
            {
                case "company":
                    persons[personName].Companies.Add(new Company(items[2], items[3], decimal.Parse(items[4])));
                    break;

                case "pokemon":
                    persons[personName].Pokemons.Add(new Pokemon(items[2], items[3]));
                    break;

                case "parents":
                    persons[personName].Parents.Add(new Parent(items[2], items[3]));
                    break;

                case "children":
                    persons[personName].Children.Add(new Children(items[2], items[3]));
                    break;

                case "car":
                    persons[personName].Car.Add(new Car(items[2], long.Parse(items[3])));
                    break;
            }

            line = Console.ReadLine();
        }

        string name = Console.ReadLine();

        Console.WriteLine(persons[name].ToString());
    }
}