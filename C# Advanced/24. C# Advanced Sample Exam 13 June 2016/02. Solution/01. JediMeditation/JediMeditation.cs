using System;
using System.Collections.Generic;

internal class JediMeditation
{
    private static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        List<string> jediMaster = new List<string>();
        List<string> jediKnight = new List<string>();
        List<string> jediPadawan = new List<string>();
        List<string> toshkoAndSlavPadawan = new List<string>();
        bool isYodaHere = false;

        for (int i = 0; i < n; i++)
        {
            string[] items = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string item in items)
            {
                string id = item[0].ToString();
                if (id == "y")
                {
                    isYodaHere = true;
                    continue;
                }

                switch (id)
                {
                    case "m":
                        jediMaster.Add(item);
                        break;

                    case "k":
                        jediKnight.Add(item);
                        break;

                    case "p":
                        jediPadawan.Add(item);
                        break;

                    case "t":
                        toshkoAndSlavPadawan.Add(item);
                        break;

                    case "s":
                        toshkoAndSlavPadawan.Add(item);
                        break;
                }
            }
        }

        List<string> result = new List<string>();

        if (isYodaHere)
        {
            result.AddRange(jediMaster);
            result.AddRange(jediKnight);
            result.AddRange(toshkoAndSlavPadawan);
            result.AddRange(jediPadawan);
        }
        else
        {
            result.AddRange(toshkoAndSlavPadawan);
            result.AddRange(jediMaster);
            result.AddRange(jediKnight);
            result.AddRange(jediPadawan);
        }

        Console.WriteLine(string.Join(" ", result));
    }
}