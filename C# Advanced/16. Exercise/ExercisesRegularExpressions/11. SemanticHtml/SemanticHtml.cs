namespace _11.SemanticHTML
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    internal class SemanticHtml
    {
        private const string OpeningTags = @"<div.*?\b((id|class)\s*=\s*""(.*?)"").*?>";

        private static void Main()
        {
            List<string> results = new List<string>();

            string inputLine;

            string[] semanticTags = { "main", "header", "nav", "article", "section", "aside", "footer" };

            Regex users = new Regex(OpeningTags);
            string closeTagsPattern = @"<\/div>\s.*?(\w+)\s*-->";
            Regex closers = new Regex(closeTagsPattern);

            while ((inputLine = Console.ReadLine()) != "END")
            {
                MatchCollection matchesOp = users.Matches(inputLine);

                foreach (Match match in matchesOp)
                {
                    string attrName = match.Groups[1].Value;
                    string attrValue = match.Groups[3].Value;

                    if (semanticTags.Contains(attrValue))
                    {
                        string replaceTag = Regex.Replace(match.ToString(), "div", word => attrValue);
                        replaceTag = Regex.Replace(replaceTag, attrName, string.Empty);
                        replaceTag = Regex.Replace(replaceTag, "\\s*>", ">");
                        replaceTag = Regex.Replace(replaceTag, "\\s{2,}", " ");
                        inputLine = Regex.Replace(inputLine, match.ToString(), replaceTag);
                    }
                }

                MatchCollection matchesCl = closers.Matches(inputLine);

                foreach (Match match in matchesCl)
                {
                    string commentValue = match.Groups[1].Value;

                    if (semanticTags.Contains(commentValue))
                    {
                        inputLine = Regex.Replace(inputLine, match.ToString(), string.Format("</" + commentValue + ">"));
                    }
                }

                results.Add(inputLine);
            }

            foreach (var t in results)
            {
                Console.WriteLine(t);
            }
        }
    }
}