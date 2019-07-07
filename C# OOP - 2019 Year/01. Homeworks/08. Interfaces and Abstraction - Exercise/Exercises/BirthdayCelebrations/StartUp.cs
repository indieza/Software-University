using System;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayCelebrations
{
    public class StartUp
    {
        private static void Main()
        {
            List<IBirthable> entered = new List<IBirthable>();

            string line = Console.ReadLine();

            while (line != "End")
            {
                string[] items = line.Split();

                string type = items[0];
                string name = items[1];

                if (type == nameof(Citizen))
                {
                    int age = int.Parse(items[2]);
                    string id = items[3];
                    string birthdate = items[4];

                    Citizen citizen = new Citizen(name, age, id, birthdate);

                    entered.Add(citizen);
                }
                else if (type == nameof(Pet))
                {
                    string birthdate = items[2];

                    Pet pet = new Pet(name, birthdate);

                    entered.Add(pet);
                }
                else if (type == nameof(Robot))
                {
                }

                line = Console.ReadLine();
            }

            string key = Console.ReadLine();

            foreach (var item in entered.Where(e => e.Birthdate.EndsWith(key)))
            {
                Console.WriteLine(item.Birthdate);
            }
        }
    }
}