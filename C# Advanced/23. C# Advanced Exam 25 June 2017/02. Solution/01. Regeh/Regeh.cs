using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

internal class Regeh
{
    private static void Main()
    {
        string line = Console.ReadLine();

        Regex regex = new Regex(@"\[[^\[\s]+<(\d+)REGEH(\d+)>[^\]\s]+]");
        MatchCollection matchCollection = regex.Matches(line);

        int save = 0;

        List<int> numbers = new List<int>();

        foreach (Match match in matchCollection)
        {
            int start = int.Parse(match.Groups[1].Value) + save;
            int end = int.Parse(match.Groups[2].Value) + start;
            save = end;
            numbers.Add(start);
            numbers.Add(end);
        }
        string result = string.Empty;

        foreach (int number in numbers)
        {
            if (number > line.Length)
            {
                result += line[number % line.Length + 1];
            }
            else
            {
                result += line[number];
            }
        }

        Console.WriteLine(result);
    }
}