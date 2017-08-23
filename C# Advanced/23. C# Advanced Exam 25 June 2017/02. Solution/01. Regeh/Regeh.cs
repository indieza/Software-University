using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

internal class Regeh
{
    private const string Template = @"\[[^\s\[]+<(\d+)REGEH(\d+)>[^]\s]+]";

    private static void Main()
    {
        string line = Console.ReadLine();
        Regex pattern = new Regex(Template);
        MatchCollection matchCollection = pattern.Matches(line);

        string resultText = string.Empty;
        List<int> numbers = new List<int>();

        int save = 0;

        foreach (Match match in matchCollection)
        {
            int start = int.Parse(match.Groups[1].Value) + save;
            int end = int.Parse(match.Groups[2].Value) + start;
            save = end;
            numbers.Add(start);
            numbers.Add(end);
        }

        foreach (var number in numbers)
        {
            if (number > line.Length)
            {
                resultText += line[number % line.Length + 1];
            }
            else
            {
                resultText += line[number % line.Length];
            }
        }

        Console.WriteLine(resultText);
    }
}