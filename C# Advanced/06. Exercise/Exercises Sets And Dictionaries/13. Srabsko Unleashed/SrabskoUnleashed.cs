namespace _13_Srabsko_Unleashed
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class SrabskoUnleashed
    {
        private static void Main()
        {
            Dictionary<string, Dictionary<string, long>> sales = new Dictionary<string, Dictionary<string, long>>();

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] data = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (data.Length < 4 || data.Length > 8 || !input.Contains(" @"))
                {
                    continue;
                }

                int ticketsCount;
                int ticketPrice;

                try
                {
                    ticketPrice = int.Parse(data[data.Length - 2]);
                    ticketsCount = int.Parse(data[data.Length - 1]);
                }
                catch (Exception)
                {
                    continue;
                }

                string venue = string.Empty;
                string singer = string.Empty;

                for (int venueIndex = 1; venueIndex < data.Length - 2; venueIndex++)

                {
                    if (data[venueIndex][0] == '@')
                    {
                        for (int i = 0; i < venueIndex; i++)
                        {
                            singer += data[i] + " ";
                        }

                        singer = singer.Trim();

                        for (int i = venueIndex; i < data.Length - 2; i++)
                        {
                            venue += " " + data[i];
                        }

                        venue = venue.Substring(2);

                        break;
                    }
                }

                if (!sales.ContainsKey(venue))
                {
                    sales[venue] = new Dictionary<string, long>();
                }

                if (!sales[venue].ContainsKey(singer))
                {
                    sales[venue][singer] = 0;
                }

                sales[venue][singer] += ticketPrice * ticketsCount;
            }

            foreach (var venuePair in sales)
            {
                Console.WriteLine(venuePair.Key);

                foreach (var singerSalesPair in venuePair.Value.OrderBy(x => -x.Value))
                {
                    Console.WriteLine("#  {0}", string.Join(" -> ", singerSalesPair.Key, singerSalesPair.Value));
                }
            }
        }
    }
}