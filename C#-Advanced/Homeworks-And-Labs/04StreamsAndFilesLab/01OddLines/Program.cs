using System;
using System.IO;

namespace _01OddLines
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "01. Odd Lines";
            string fileName = "input.txt";
            string filePath = Path.Combine(path, fileName);

            using (var reader = new StreamReader(filePath))
            {
                using (var writer = new StreamWriter("Output.txt"))
                {
                    int count = 0;

                    string line = reader.ReadLine();

                    while (line != null)
                    {
                        if (count % 2 != 0)
                        {
                            writer.WriteLine(line);
                        }

                        count++;

                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}
