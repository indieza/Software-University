using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _03.WordCount
{
    public class WordCount
    {
        private static void Main()
        {
            var listOfWords = new Dictionary<string, int>();
            using (var reader = new StreamReader("../../words.txt"))
            {
                while (true)
                {
                    var line = reader.ReadLine();

                    if (line == null)
                    {
                        break;
                    }

                    var words = line.Split();

                    foreach (var word in words)
                    {
                        if (!listOfWords.ContainsKey(word))
                        {
                            listOfWords.Add(word.ToLower(), 0);
                        }
                    }
                }
            }

            using (var reader = new StreamReader("../../text.txt"))
            {
                while (true)
                {
                    var line = reader.ReadLine();

                    if (line == null)
                    {
                        break;
                    }

                    var words = line.Split(new char[] { ' ', ',', '?', ';', '-', '.' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var word in words)
                    {
                        if (listOfWords.ContainsKey(word.ToLower()))
                        {
                            listOfWords[word.ToLower()]++;
                        }
                    }
                }
            }

            using (var writer = new StreamWriter("../../Output.txt"))
            {
                foreach (var words in listOfWords.OrderByDescending(x => x.Value))
                {
                    var line = (words.Key + " - " + words.Value);

                    writer.WriteLine(line);
                }
            }

            using (StreamReader firstReader = new StreamReader("../../Output.txt"))
            {
                using (StreamReader secondReader = new StreamReader("../../ExpectedResult.txt"))
                {
                    string firstFileLine = firstReader.ReadLine();
                    string secondFileLine = secondReader.ReadLine();

                    while (firstFileLine == null && secondFileLine == null)
                    {
                        break;
                    }

                    if (firstFileLine != secondFileLine)
                    {
                        Console.WriteLine("Files aren't the same.");
                        return;
                    }
                }
            }

            Console.WriteLine("Files are the same.");
        }
    }
}