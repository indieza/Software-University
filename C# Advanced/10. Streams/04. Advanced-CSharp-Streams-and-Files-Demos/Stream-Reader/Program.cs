namespace Stream_Reader
{
    using System;
    using System.IO;

    internal class Program
    {
        private static void Main()
        {
            using (StreamReader reader = new StreamReader("somefile.txt"))
            {
                int lineNumber = 0;
                string line = reader.ReadLine();

                while (line != null)
                {
                    lineNumber++;
                    Console.WriteLine("Line {0}: {1}", lineNumber, line);
                    line = reader.ReadLine();
                }
            }
        }
    }
}