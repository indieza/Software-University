namespace Memory_Stream
{
    using System;
    using System.IO;
    using System.Text;

    internal class InMemoryString
    {
        private static void Main()
        {
            string text = "Two households, both alike in dignity,In fair Verona, where we lay our scene";

            byte[] bytes = Encoding.UTF8.GetBytes(text);

            using (var memoryStream = new MemoryStream(bytes))
            {
                while (true)
                {
                    int readByte = memoryStream.ReadByte();
                    if (readByte == -1)
                    {
                        break;
                    }

                    Console.WriteLine(readByte);
                }
            }
        }
    }
}