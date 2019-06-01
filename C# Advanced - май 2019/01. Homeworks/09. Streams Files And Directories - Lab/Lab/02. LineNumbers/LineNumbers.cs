using System.IO;

namespace _02.LineNumbers
{
    public class LineNumbers
    {
        private static void Main()
        {
            string filePath = Path.Combine("Files", "Input.txt");

            StreamReader reader = new StreamReader(filePath);

            using (reader)
            {
                StreamWriter writer = new StreamWriter("Output.txt");

                using (writer)
                {
                    int counter = 1;

                    string line = reader.ReadLine();

                    while (line != null)
                    {
                        writer.WriteLine($"{counter}. {line}");
                        counter++;
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}