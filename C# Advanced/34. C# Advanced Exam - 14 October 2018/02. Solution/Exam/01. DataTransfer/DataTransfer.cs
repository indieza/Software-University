using System;
using System.Text.RegularExpressions;

namespace _01.DataTransfer
{
    public class DataTransfer
    {
        private static readonly string PatternText = $"s:([^;]+);r:([^;]+);m--\"([a-zA-Z ]+)\"";
        private static readonly string PatternNames = $"[^a-zA-Z ]+";
        private static readonly string PatternData = $"[^0-9]+";

        private static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int data = 0;

            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                Match matchLine = Regex.Match(line, PatternText);

                while (matchLine.Success)
                {
                    string sender = string.Join(string.Empty, Regex.Split(matchLine.Groups[1].Value, PatternNames));
                    string receiver = string.Join(string.Empty, Regex.Split(matchLine.Groups[2].Value, PatternNames));

                    char[] senderData = string.Join(string.Empty, Regex.Split(matchLine.Groups[1].Value, PatternData)).ToCharArray();
                    char[] recieverData = string.Join(string.Empty, Regex.Split(matchLine.Groups[2].Value, PatternData)).ToCharArray();

                    foreach (var item in senderData)
                    {
                        data += int.Parse(item.ToString());
                    }

                    foreach (var item in recieverData)
                    {
                        data += int.Parse(item.ToString());
                    }

                    string message = matchLine.Groups[3].Value;

                    Console.WriteLine($"{sender} says \"{message}\" to {receiver}");

                    matchLine = matchLine.NextMatch();
                }
            }

            Console.WriteLine($"Total data transferred: {data}MB");
        }
    }
}