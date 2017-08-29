using System;
using System.Collections.Generic;

internal class JediMeditation
{
    private static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        List<string> jediMasters = new List<string>();
        List<string> jediKnights = new List<string>();
        List<string> jediPadavans = new List<string>();
        List<string> toshkoAndSlavPadavans = new List<string>();

        bool isYodaHere = false;

        for (int item = 0; item < n; item++)
        {
            string[] items = Console.ReadLine().Split();
            foreach (string jedi in items)
            {
                string indicator = jedi[0].ToString();

                switch (indicator)
                {
                    case "m":
                        jediMasters.Add(jedi);
                        break;

                    case "k":
                        jediKnights.Add(jedi);
                        break;

                    case "p":
                        jediPadavans.Add(jedi);
                        break;

                    case "t":
                        toshkoAndSlavPadavans.Add(jedi);
                        break;

                    case "s":
                        toshkoAndSlavPadavans.Add(jedi);
                        break;

                    case "y":
                        isYodaHere = true;
                        break;
                }
            }
        }

        List<string> result = new List<string>();

        if (!isYodaHere)
        {
            result.AddRange(toshkoAndSlavPadavans);
            result.AddRange(jediMasters);
            result.AddRange(jediKnights);
            result.AddRange(jediPadavans);
        }
        else
        {
            result.AddRange(jediMasters);
            result.AddRange(jediKnights);
            result.AddRange(toshkoAndSlavPadavans);
            result.AddRange(jediPadavans);
        }

        Console.WriteLine(string.Join(" ", result));
    }
}