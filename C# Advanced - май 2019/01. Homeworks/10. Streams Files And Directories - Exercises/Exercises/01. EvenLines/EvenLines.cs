using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _01.EvenLines
{
    public class EvenLines
    {
        private static void Main()
        {
            string[] symbols = new string[] { "-", ",", ".", "!", "?" };

            using (StreamReader reader = new StreamReader("../../text.txt"))
            {
                var counter = 0;
                using (StreamWriter writer = new StreamWriter("../../Output.txt"))
                {
                    while (true)
                    {
                        string line = reader.ReadLine();

                        if (line == null)
                        {
                            break;
                        }

                        if (counter % 2 == 0)
                        {
                            string currentLine = string.Empty;

                            foreach (var character in line)
                            {
                                if (symbols.Contains(character.ToString()))
                                {
                                    currentLine += "@";
                                }
                                else
                                {
                                    currentLine += character;
                                }
                            }

                            string[] wordsArray = currentLine
                                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                            Stack<string> words = new Stack<string>(wordsArray);

                            writer.WriteLine(string.Join(" ", words));
                        }

                        counter++;
                    }
                }
            }
        }
    }
}