using System.IO;

namespace _04.MergeFiles
{
    public class MergeFiles
    {
        private static void Main()
        {
            using (StreamReader firstReader = new StreamReader("Input1.txt"))
            {
                using (StreamReader secondReader = new StreamReader("Input2.txt"))
                {
                    using (StreamWriter writer = new StreamWriter("Output.txt"))
                    {
                        while (true)
                        {
                            string firstFileLine = firstReader.ReadLine();
                            string secondFileLine = secondReader.ReadLine();

                            if (firstFileLine == null && secondFileLine == null)
                            {
                                break;
                            }

                            if (firstFileLine != null)
                            {
                                writer.WriteLine(firstFileLine);
                            }

                            if (firstFileLine != null)
                            {
                                writer.WriteLine(secondFileLine);
                            }
                        }
                    }
                }
            }
        }
    }
}