using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

internal class JediCodeX
{
    private static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        StringBuilder sb = new StringBuilder();

        for (int item = 0; item < n; item++)
        {
            sb.Append(Console.ReadLine());
        }

        string patternName = Console.ReadLine();
        string patternMessage = Console.ReadLine();

        string patternNameForRegex = Regex.Escape(patternName) + @"([a-zA-Z]{" + patternName.Length + @"})(?![a-zA-Z])";
        string patternMessageForRegex = Regex.Escape(patternMessage) + @"([a-zA-Z0-9]{" + patternMessage.Length + @"})(?![a-zA-Z0-9])";

        Regex nameRegex = new Regex(patternNameForRegex);
        Regex messageRegex = new Regex(patternMessageForRegex);

        MatchCollection nameCollection = nameRegex.Matches(sb.ToString());
        MatchCollection messageCollection = messageRegex.Matches(sb.ToString());

        List<string> messages = new List<string>();
        List<Jedi> jediMessages = new List<Jedi>();

        foreach (Match match in nameCollection)
        {
            jediMessages.Add(new Jedi(match.Groups[1].Value));
        }

        foreach (Match match in messageCollection)
        {
            messages.Add(match.Groups[1].Value);
        }

        Queue<int> indexes = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).Where(x => x <= messages.Count));

        var limit = Math.Min(jediMessages.Count, indexes.Count);

        for (int j = 0; j < limit; j++)
        {
            jediMessages[j].Message += messages[indexes.Dequeue() - 1];
        }

        foreach (var jed in jediMessages.Where(x => x.Message.Length > 0))
        {
            Console.WriteLine($"{jed.Name} - {jed.Message}");
        }
    }
}

internal class Jedi
{
    public Jedi(string name, string message = "")
    {
        this.Name = name;
        this.Message = message;
    }

    public string Name { get; set; }

    public string Message { get; set; }
}