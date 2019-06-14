using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.ClubParty
{
    public class ClubParty
    {
        private static void Main()
        {
            int hallsMaxCapacity = int.Parse(Console.ReadLine());
            Stack<string> symbols = new Stack<string>(Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));

            List<string> halls = new List<string>();
            List<int> people = new List<int>();

            while (symbols.Count != 0)
            {
                string currentSymbols = symbols.Pop();

                if (int.TryParse(currentSymbols, out int capacityNeeded))
                {
                    if (halls.Count != 0)
                    {
                        if (people.Sum() + capacityNeeded <= hallsMaxCapacity)
                        {
                            people.Add(capacityNeeded);
                        }
                        else
                        {
                            Console.WriteLine($"{halls[0]} -> {string.Join(", ", people)}");
                            halls.RemoveAt(0);
                            people.Clear();

                            if (halls.Count != 0)
                            {
                                people.Add(capacityNeeded);
                            }
                        }
                    }
                }
                else
                {
                    halls.Add(currentSymbols);
                }
            }
        }
    }
}