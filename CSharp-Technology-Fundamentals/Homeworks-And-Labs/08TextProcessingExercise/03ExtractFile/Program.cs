using System;
using System.Linq;
using System.Text;

namespace _03ExtractFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();

            int startIndexOfFile = path.LastIndexOf('\\') + 1;
            string file = path.Substring(startIndexOfFile);

            int startIndexOfExtension = file.IndexOf('.') + 1;

            string fileName = file.Substring(0, startIndexOfExtension - 1);
            string fileExtension = file.Substring(startIndexOfExtension);

            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine($"File extension: {fileExtension}");
        }
    }
}
