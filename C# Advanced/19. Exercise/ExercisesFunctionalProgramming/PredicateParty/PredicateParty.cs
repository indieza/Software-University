namespace PredicateParty
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class PredicateParty
    {
        private static void Main()
        {
            List<string> names = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            string input = Console.ReadLine();

            while (!input.Equals("Party!"))
            {
                string[] args = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string command = args[0];
                string startsEndsOrLength = args[1];
                string strOrLength = args[2];

                Predicate<string> predicateStarts = s => s.StartsWith(strOrLength);
                Predicate<string> predicateEnds = s => s.EndsWith(strOrLength);
                Predicate<string> predicateLength = s => s.Length == int.Parse(strOrLength);

                if (command.Equals("Remove"))
                {
                    switch (startsEndsOrLength)
                    {
                        case "StartsWith":
                            names.RemoveAll(predicateStarts);
                            break;

                        case "EndsWith":
                            names.RemoveAll(predicateEnds);
                            break;

                        case "Length":
                            names.RemoveAll(predicateLength);
                            break;
                    }
                }
                else if (command.Equals("Double"))
                {
                    List<string> toBeAdded;

                    switch (startsEndsOrLength)
                    {
                        case "StartsWith":
                            toBeAdded = names.FindAll(predicateStarts);
                            names.AddRange(toBeAdded);
                            break;

                        case "EndsWith":
                            toBeAdded = names.FindAll(predicateEnds);
                            names.AddRange(toBeAdded);
                            break;

                        case "Length":

                            toBeAdded = names.FindAll(predicateLength);

                            foreach (string person in toBeAdded)
                            {
                                int index = names.LastIndexOf(person);
                                names.Insert(index, person);
                            }

                            break;
                    }
                }

                input = Console.ReadLine();
            }

            if (names.Count > 0)
            {
                Console.WriteLine($"{string.Join(", ", names)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }
    }
}