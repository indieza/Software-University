using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _06.ZipAndExtract
{
    public class ZipAndExtract
    {
        private static void Main()
        {
            var path = Console.ReadLine();
            var filesInfo = new Dictionary<string, List<FileInfo>>();
            var files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);

            foreach (var file in files)
            {
                var info = new FileInfo(file);

                if (!filesInfo.ContainsKey(info.Extension))
                {
                    filesInfo.Add(info.Extension, new List<FileInfo>());
                }
                filesInfo[info.Extension].Add(info);
            }

            var pathToDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/Report.txt";

            using (var writer = new StreamWriter(pathToDesktop))
            {
                foreach (var fileInfo in filesInfo.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
                {
                    writer.WriteLine(fileInfo.Key);

                    foreach (var info in fileInfo.Value.OrderBy(x => x.Length))
                    {
                        writer.WriteLine($"--{info.Name} - {(info.Length / 1024):F3}kb");
                    }
                }
            }
        }
    }
}