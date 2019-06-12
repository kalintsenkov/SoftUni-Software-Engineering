using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _05DirectoryTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            var dirInfo = new Dictionary<string, Dictionary<string, double>>();

            var directoryInfo = new DirectoryInfo(".");

            var allFiles = directoryInfo.GetFiles();

            foreach (var currentFile in allFiles)
            {
                double size = (double)currentFile.Length / 1024;
                string fileName = currentFile.Name;
                string extension = currentFile.Extension;

                if (!dirInfo.ContainsKey(extension))
                {
                    dirInfo.Add(extension, new Dictionary<string, double>());
                }

                if (!dirInfo[extension].ContainsKey(fileName))
                {
                    dirInfo[extension].Add(fileName, size);
                }
            }

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"/report.txt";

            var sortedDir = dirInfo
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key)
                .ToDictionary(k => k.Key, v => v.Value);

            foreach (var kvp in sortedDir)
            {
                File.AppendAllText(path, kvp.Key + Environment.NewLine);

                foreach (var file in kvp.Value.OrderBy(x => x.Value))
                {
                    File.AppendAllText(path, $"-- {file.Key} - {Math.Round(file.Value, 3)}kb" + Environment.NewLine);
                }
            }
        }
    }
}
