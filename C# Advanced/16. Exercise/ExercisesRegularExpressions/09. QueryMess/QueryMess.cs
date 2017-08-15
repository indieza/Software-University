namespace _09.QueryMess
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    internal class QueryMess
    {
        private static void Main()
        {
            string pattern = @"([^&=?\s]*)(?=\=)=(?<=\=)([^&=\s]*)";
            string regex = @"((%20|\+)+)";

            string inputLine;

            while ((inputLine = Console.ReadLine()) != "END")
            {
                Regex pairs = new Regex(pattern);
                MatchCollection matches = pairs.Matches(inputLine);

                Dictionary<string, List<string>> results = new Dictionary<string, List<string>>();
                for (int i = 0; i < matches.Count; i++)
                {
                    string field = matches[i].Groups[1].Value;
                    field = Regex.Replace(field, regex, word => " ").Trim();

                    string value = matches[i].Groups[2].Value;
                    value = Regex.Replace(value, regex, word => " ").Trim();

                    if (!results.ContainsKey(field))
                    {
                        List<string> values = new List<string> { value };
                        results.Add(field, values);
                    }
                    else if (results.ContainsKey(field))
                    {
                        results[field].Add(value);
                    }
                }

                foreach (var pair in results)
                {
                    Console.Write("{0}=[{1}]", pair.Key, string.Join(", ", pair.Value));
                }

                Console.WriteLine();
            }
        }
    }
}