using System;
using System.Collections.Generic;
using System.Linq;

internal class CatLady
{
    private static void Main()
    {
        string line = Console.ReadLine();
        List<Cat> cats = new List<Cat>();

        while (line != "End")
        {
            string[] items = line.Split();
            string catType = items[0];
            string catName = items[1];
            decimal inicials = decimal.Parse(items[2]);

            switch (catType)
            {
                case "Siamese":
                    Cat cat1 = new Siamese
                    {
                        EarSize = inicials,
                        Name = catName
                    };

                    cats.Add(cat1);
                    break;

                case "Cymric":
                    Cat cat2 = new Cymric
                    {
                        FurLength = inicials,
                        Name = catName
                    };

                    cats.Add(cat2);
                    break;

                case "StreetExtraordinaire":
                    Cat cat3 = new StreetExtraordinaire
                    {
                        DecibelsOfMeows = inicials,
                        Name = catName
                    };

                    cats.Add(cat3);
                    break;
            }

            line = Console.ReadLine();
        }

        string name = Console.ReadLine();

        Cat result = cats.First(cat => cat.Name == name);
        Console.WriteLine(result.ToString());
    }
}