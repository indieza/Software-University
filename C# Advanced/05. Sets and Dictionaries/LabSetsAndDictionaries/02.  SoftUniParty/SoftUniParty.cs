namespace _02.SoftUniParty
{
    using System;
    using System.Collections.Generic;

    internal class SoftUniParty
    {
        private static void Main()
        {
            var line = Console.ReadLine();
            var party = new SortedSet<string>();

            while (line != "PARTY")
            {
                party.Add(line);
                line = Console.ReadLine();
            }

            while (line != "END")
            {
                party.Remove(line);
                line = Console.ReadLine();
            }

            Console.WriteLine(party.Count);

            foreach (var person in party)
            {
                Console.WriteLine(person);
            }
        }
    }
}