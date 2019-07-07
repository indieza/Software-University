using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class StartUp
    {
        private static void Main()
        {
            List<Entered> entered = new List<Entered>();

            string line = Console.ReadLine();

            while (line != "End")
            {
                string[] items = line.Split();

                if (items.Length == 2)
                {
                    string model = items[0];
                    string id = items[1];
                    Robot robot = new Robot(model, id);
                    entered.Add(robot);
                }
                else if (items.Length == 3)
                {
                    string name = items[0];
                    int age = int.Parse(items[1]);
                    string id = items[2];
                    Citizen citizen = new Citizen(name, age, id);
                    entered.Add(citizen);
                }

                line = Console.ReadLine();
            }

            string key = Console.ReadLine();

            foreach (var item in entered.Where(e => e.Id.EndsWith(key)))
            {
                Console.WriteLine(item.Id);
            }
        }
    }
}