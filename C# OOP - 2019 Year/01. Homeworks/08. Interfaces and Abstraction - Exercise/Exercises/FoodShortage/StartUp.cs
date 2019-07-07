using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodShortage
{
    public class StartUp
    {
        private static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            List<IBuyer> people = new List<IBuyer>();

            for (int i = 0; i < n; i++)
            {
                string[] items = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string name = items[0];
                int age = int.Parse(items[1]);

                if (items.Length == 3)
                {
                    string group = items[2];

                    Rebel rebel = new Rebel(name, age, group);
                    people.Add(rebel);
                }
                else if (items.Length == 4)
                {
                    string id = items[2];
                    string birthdate = items[3];

                    Citizen citizen = new Citizen(name, age, id, birthdate);
                    people.Add(citizen);
                }
            }

            string person = Console.ReadLine();

            while (person != "End")
            {
                if (people.FirstOrDefault(p => p.Name == person) != null)
                {
                    people.FirstOrDefault(p => p.Name == person).BuyFood();
                }

                person = Console.ReadLine();
            }

            Console.WriteLine(people.Sum(p => p.Food));
        }
    }
}