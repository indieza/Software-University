using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.SoftUniParty
{
    public class SoftUniParty
    {
        private static void Main()
        {
            HashSet<string> people = new HashSet<string>();

            string line = Console.ReadLine();

            while (line != "PARTY")
            {
                people.Add(line);

                line = Console.ReadLine();
            }

            line = Console.ReadLine();

            while (line != "END")
            {
                people.Remove(line);

                line = Console.ReadLine();
            }

            Console.WriteLine(people.Count);
            if (people.Where(p => char.IsDigit(p.ToCharArray()[0])).Count() != 0)
            {
                Console.WriteLine(string.Join("\n", people.Where(p => char.IsDigit(p.ToCharArray()[0]))));
            }
            if (people.Where(p => !char.IsDigit(p.ToCharArray()[0])).Count() != 0)
            {
                Console.WriteLine(string.Join("\n", people.Where(p => !char.IsDigit(p.ToCharArray()[0]))));
            }
        }
    }
}