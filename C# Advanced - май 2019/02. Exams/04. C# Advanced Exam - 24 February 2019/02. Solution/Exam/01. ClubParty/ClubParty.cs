using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.ClubParty
{
    public class ClubParty
    {
        private static void Main()
        {
            int hallsCapacity = int.Parse(Console.ReadLine());
            Stack<string> items = new Stack<string>(Console.ReadLine().Split());

            List<string> halls = new List<string>();
            List<int> people = new List<int>();

            while (items.Count != 0)
            {
                string currentItem = items.Pop();

                if (int.TryParse(currentItem, out int person))
                {
                    if (halls.Count != 0)
                    {
                        if (people.Sum() + person <= hallsCapacity)
                        {
                            people.Add(person);
                        }
                        else
                        {
                            Console.WriteLine($"{halls[0]} -> {string.Join(", ", people)}");
                            people.Clear();
                            halls.RemoveAt(0);

                            if (halls.Count != 0)
                            {
                                people.Add(person);
                            }
                        }
                    }
                }
                else
                {
                    halls.Add(currentItem);
                }
            }
        }
    }
}