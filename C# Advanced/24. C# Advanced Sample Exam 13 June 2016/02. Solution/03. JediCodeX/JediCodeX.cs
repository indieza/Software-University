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

        for (int i = 0; i < n; i++)
        {
            sb.Append(Console.ReadLine());
        }

        string nPat = Console.ReadLine();
        string mPat = Console.ReadLine();

        string patternName = Regex.Escape(nPat) + @"([a-zA-Z]{" + nPat.Length + @"})(?![a-zA-Z])";
        string patternMsg = Regex.Escape(mPat) + @"([a-zA-Z0-9]{" + mPat.Length + @"})(?![a-zA-Z0-9])";

        Regex nRgx = new Regex(patternName);
        Regex mRgx = new Regex(patternMsg);

        var names = nRgx.Matches(sb.ToString());
        var messagesRaw = mRgx.Matches(sb.ToString());

        var messages = new List<string>();
        var jedisMsgs = new List<Jedi>();

        foreach (Match name in names)
        {
            jedisMsgs.Add(new Jedi(name.Groups[1].Value));
        }

        foreach (Match msg in messagesRaw)
        {
            messages.Add(msg.Groups[1].Value);
        }

        Queue<int> indexes = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).Where(x => x <= messages.Count));

        var limit = Math.Min(jedisMsgs.Count, indexes.Count);

        for (int j = 0; j < limit; j++)
        {
            jedisMsgs[j].Message += messages[indexes.Dequeue() - 1];
        }

        foreach (var jed in jedisMsgs.Where(x => x.Message.Length > 0))
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