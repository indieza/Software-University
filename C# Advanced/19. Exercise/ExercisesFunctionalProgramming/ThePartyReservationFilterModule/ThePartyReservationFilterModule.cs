namespace ThePartyReservationFilterModule
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    internal class ThePartyReservationFilterModule
    {
        private static void Main()
        {
            List<string> guestsList = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string input = Console.ReadLine();
            List<string> beforeFiltering = new List<string>(guestsList);

            while (!input.Equals("Print"))
            {
                string[] args = input.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                string command = args[0];
                string filterType = args[1];
                string parameter = args[2];
                ApplyFiltering(guestsList, beforeFiltering, command, filterType, parameter);

                input = Console.ReadLine();
            }

            StringBuilder result = new StringBuilder();

            foreach (string person in guestsList)
            {
                if (!person.Equals(string.Empty))
                {
                    result.Append(person + " ");
                }
            }

            Console.WriteLine(result);
        }

        private static void ApplyFiltering(List<string> guestsList, List<string> beforeFiltering, string command, string filterType, string parameter)
        {
            Predicate<string> predicateStarts = s => s.StartsWith(parameter);
            Predicate<string> predicateEnds = s => s.EndsWith(parameter);
            Predicate<string> predicateLength = s => s.Length == int.Parse(parameter);
            Predicate<string> predicateContains = s => s.Contains(parameter);

            if (command.Equals("Add filter"))
            {
                List<string> toBeRemoved = new List<string>();

                switch (filterType)
                {
                    case "Starts with":
                        toBeRemoved = guestsList.FindAll(predicateStarts);
                        break;

                    case "Ends with":
                        toBeRemoved = guestsList.FindAll(predicateEnds);
                        break;

                    case "Length":
                        toBeRemoved = guestsList.FindAll(predicateLength);
                        break;

                    case "Contains":
                        toBeRemoved = guestsList.FindAll(predicateContains);
                        break;
                }

                foreach (string personToBeRemoved in toBeRemoved)
                {
                    for (int i = 0; i < guestsList.Count; i++)
                    {
                        if (guestsList[i].Equals(personToBeRemoved))
                        {
                            guestsList[i] = string.Empty;
                        }
                    }
                }
            }
            else if (command.Equals("Remove filter"))
            {
                List<string> toBeAddedBack = new List<string>();

                switch (filterType)
                {
                    case "Starts with":
                        toBeAddedBack = beforeFiltering.FindAll(predicateStarts);
                        break;

                    case "Ends with":
                        toBeAddedBack = beforeFiltering.FindAll(predicateEnds);
                        break;

                    case "Length":
                        toBeAddedBack = beforeFiltering.FindAll(predicateLength);
                        break;

                    case "Contains":
                        toBeAddedBack = beforeFiltering.FindAll(predicateContains);
                        break;
                }

                foreach (string person in toBeAddedBack)
                {
                    int index = beforeFiltering.LastIndexOf(person);
                    guestsList[index] = person;
                }
            }
        }
    }
}