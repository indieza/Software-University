using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03.TicketTrouble
{
    public class TicketTrouble
    {
        private static void Main()
        {
            string location = Console.ReadLine();

            string pattern = @"((?<opener>\[)|{)(?(opener)[^\[\]]*?|[^{}]*?)(?(opener){|\[)" + location +
                @"(?(opener)}|\])(?(opener)[^\[\]]*?|[^{}]*?)(?(opener){|\[)(?<seat>[A-Z][0-9]{1,2})(?(opener)}|\])(?(opener)[^\[\]]*?|[^{}]*?)(?(opener)\]|})";

            string input = Console.ReadLine();

            MatchCollection matches = Regex.Matches(input, pattern);
            string[] seats = matches.Select(m => m.Groups["seat"].Value).ToArray();

            if (seats.Length > 2)
            {
                seats = seats.GroupBy(s => s.Substring(1))
                    .Where(g => g.Count() > 1)
                    .Select(g => g.ToArray())
                    .First();
            }

            Console.WriteLine($"You are traveling to {location} on seats {seats[0]} and {seats[1]}.");
        }
    }
}