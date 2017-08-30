using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

internal class BasicMasrupLanguage
{
    private static int count = 1;

    private static void Main()
    {
        Regex pattern = new Regex(@"\s*<\s*([a-z]+)\s+(?:value\s*=\s*""\s*(\d+)\s*""\s+)?[a-z]+\s*=\s*""([^""]*)""\s*\/>\s*");

        string line = Console.ReadLine();

        while (line != "<stop/>")
        {
            Match match = pattern.Match(line);
            string tag = match.Groups[1].Value;

            switch (tag)
            {
                case "inverse":
                    Inverse(match.Groups[3].Value);
                    break;

                case "reverse":
                    Reverse(match.Groups[3].Value);
                    break;

                case "repeat":
                    Repeat(match.Groups[3].Value, int.Parse(match.Groups[2].Value));
                    break;
            }

            line = Console.ReadLine();
        }
    }

    private static void Inverse(string input)
    {
        if (input.Length > 0)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char ch in input)
            {
                if (char.IsUpper(ch))
                {
                    sb.Append(char.ToLower(ch));
                }
                else if (char.IsLower(ch))
                {
                    sb.Append(char.ToUpper(ch));
                }
                else
                {
                    sb.Append(ch);
                }
            }

            Console.WriteLine($"{count++}. {sb}");
        }
    }

    private static void Reverse(string input)
    {
        if (input.Length > 0)
        {
            Console.WriteLine($"{count++}. {string.Join(string.Empty, input.Reverse())}");
        }
    }

    private static void Repeat(string input, int repetitions)
    {
        if (repetitions > 0 && input.Length > 0)
        {
            for (int i = 0; i < repetitions; i++)
            {
                Console.WriteLine($"{count++}. {input}");
            }
        }
    }
}