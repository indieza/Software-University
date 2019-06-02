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
            Dictionary<string, int> listOfWords = new Dictionary<string, int>();

            using (var reader = new StreamReader("words.txt"))
            {
                while (true)
                {
                    string line = reader.ReadLine();

                    if (line == null)
                    {
                        break;
                    }

                    string[] words = line.Split();

                    foreach (var word in words)
                    {
                        if (!listOfWords.ContainsKey(word))
                        {
                            listOfWords.Add(word.ToLower(), 0);
                        }
                    }
                }
            }

            using (StreamReader reader = new StreamReader("Input.txt"))
            {
                while (true)
                {
                    string line = reader.ReadLine();

                    if (line == null)
                    {
                        break;
                    }

                    var words = line
                        .Split(new char[] { ' ', ',', '?', ';', '-', '.' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var word in words)
                    {
                        if (listOfWords.ContainsKey(word.ToLower()))
                        {
                            listOfWords[word.ToLower()]++;
                        }
                    }
                }
            }

            using (StreamWriter writer = new StreamWriter("Output.txt"))
            {
                foreach (var words in listOfWords.OrderByDescending(x => x.Value))
                {
                    string line = (words.Key + " - " + words.Value);

                    writer.WriteLine(line);
                }
            }
        }
    }
}