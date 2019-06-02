using System.IO;

namespace _04.CopyBinFile
{
    public class CopyBinaryFile
    {
        private static void Main()
        {
            using (var reader = new FileStream("../../copyMe.png", FileMode.Open))
            {
                var buffer = new byte[4096];

                using (var writer = new FileStream("../../copied.png", FileMode.Create))
                {
                    while (true)
                    {
                        var totalByte = reader.Read(buffer, 0, buffer.Length);

                        if (totalByte == 0)
                        {
                            break;
                        }

                        writer.Write(buffer, 0, totalByte);
                    }
                }
            }
        }
    }
}