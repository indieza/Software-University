using System.IO;

namespace _02.LineNumbers
{
    public class LineNumbers
    {
        private static void Main()
        {
            int lineCounter = 1;

            using (StreamReader reader = new StreamReader("../../Text.txt"))
            {
                using (StreamWriter writer = new StreamWriter("../../Output.txt"))
                {
                    while (true)
                    {
                        var line = reader.ReadLine();
                        if (line == null)
                        {
                            break;
                        }

                        int specialSymbolCount = 0;
                        int space = 0;

                        foreach (var symbol in line)
                        {
                            if (symbol == ' ')
                            {
                                space++;
                            }
                            else if (!char.IsLetter(symbol))
                            {
                                specialSymbolCount++;
                            }
                        }

                        int symbolCount = line.Length - specialSymbolCount - space;

                        writer.WriteLine($"Line {lineCounter}:{line}({symbolCount})({specialSymbolCount})");
                        lineCounter++;
                    }
                }
            }
        }
    }
}