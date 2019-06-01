using System.IO;

namespace _01.OddLines
{
    public class OddLines
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
                    int count = 0;

                    string line = reader.ReadLine();

                    while (line != null)
                    {
                        if (count % 2 == 1)
                        {
                            writer.WriteLine(line);
                        }

                        count++;
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}