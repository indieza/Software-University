namespace _12.Google
{
    using System;
    using System.Collections.Generic;
    using _12.Google.Classes;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            List<People> peoples = new List<People>();

            while (true)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (input[0] == "End")
                {
                    break;
                }

                string peopleName = input[0];

                if (!peoples.Exists(x => x.Name == peopleName))
                {
                    People people = new People { Name = peopleName };
                    peoples.Add(people);
                }

                switch (input[1])
                {
                    case "company":
                        {
                            string companyName = input[2];
                            string department = input[3];
                            double salary = double.Parse(input[4]);
                            Company company = new Company(companyName, department, salary);
                            int currentPeopleIndex = peoples.FindIndex(x => x.Name == peopleName);
                            peoples[currentPeopleIndex].Company = company;
                            break;
                        }
                    case "pokemon":
                        {
                            string pokemonName = input[2];
                            string pokemonType = input[3];
                            Pokemon pokemon = new Pokemon(pokemonName, pokemonType);
                            int currentPeopleIndex = peoples.FindIndex(x => x.Name == peopleName);
                            peoples[currentPeopleIndex].Pokemons.Add(pokemon);
                            break;
                        }
                    case "parents":
                        {
                            string parentName = input[2];
                            string parentBirthday = input[3];
                            Parent parent = new Parent(parentName, parentBirthday);
                            int currentPeopleIndex = peoples.FindIndex(x => x.Name == peopleName);
                            peoples[currentPeopleIndex].Parents.Add(parent);
                            break;
                        }
                    case "children":
                        {
                            string childName = input[2];
                            string childBirthday = input[3];
                            Child child = new Child(childName, childBirthday);
                            int currentPeopleIndex = peoples.FindIndex(x => x.Name == peopleName);
                            peoples[currentPeopleIndex].Children.Add(child);
                            break;
                        }
                    default:
                        {
                            string carModel = input[2];
                            double carSpeed = double.Parse(input[3]);
                            Car car = new Car(carModel, carSpeed);
                            int currentPeopleIndex = peoples.FindIndex(x => x.Name == peopleName);
                            peoples[currentPeopleIndex].Car = car;
                            break;
                        }
                }
            }

            string name = Console.ReadLine();
            Console.WriteLine(peoples.FirstOrDefault(x => x.Name == name).ToString());
        }
    }
}