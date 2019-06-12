using System;
using System.IO;

namespace _02LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string folderName = "02. Line Numbers";
            string fileName = "Input.txt";
            string filePath = Path.Combine(folderName, fileName);

            using (var reader = new StreamReader(filePath))
            {
                using (var writer = new StreamWriter("Output.txt"))
                {
                    int number = 1;

                    string line = reader.ReadLine();

                    while (line != null)
                    {
                        writer.WriteLine($"{number}. {line}");

                        number++;
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}
