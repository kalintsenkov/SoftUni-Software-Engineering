using System;
using System.IO;

namespace _06FolderSize
{
    class Program
    {
        static void Main(string[] args)
        {
            string folder1 = "06. Folder Size";
            string folder2 = "TestFolder";
            string path = Path.Combine(folder1, folder2);

            var files = Directory.GetFiles(path);

            double sum = 0;

            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);

                sum += fileInfo.Length;
            }

            sum = sum / 1024 / 1024;

            File.WriteAllText("Output.txt", sum.ToString());
        }
    }
}
