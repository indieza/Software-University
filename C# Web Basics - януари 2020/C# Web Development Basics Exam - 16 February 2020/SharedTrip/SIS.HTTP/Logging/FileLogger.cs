using System.IO;

namespace SIS.HTTP.Logging
{
    public class FileLogger : ILogger
    {
        public void Log(string message)
        {
            File.AppendAllLines("log.txt", new[] { message });
        }
    }
}