namespace WritingToFiles
{
    using System.IO;
    using System.Text;

    internal class Program
    {
        private static void Main()
        {
            string text = "Кирилица";

            var fileStream = new FileStream("../../log.txt", FileMode.Create);

            try
            {
                byte[] bytes = Encoding.UTF8.GetBytes(text);
                fileStream.Write(bytes, 0, bytes.Length);
            }
            finally
            {
                fileStream.Close();
            }
        }
    }
}