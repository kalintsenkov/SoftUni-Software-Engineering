using System;
using System.IO;

namespace _05SliceAFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string folderName = "05. Slice File";
            string fileName = "sliceMe.txt";
            string filePath = Path.Combine(folderName, fileName);

            using (var inputFile = new FileStream(filePath, FileMode.Open))
            {
                long size = inputFile.Length;
                int partSize = (int)Math.Ceiling((double)size / 4);

                var buffer = new byte[partSize];

                for (int i = 1; i <= 4; i++)
                {
                    using (var outputFile = new FileStream($@"05. Slice File\Part-{i}.txt", FileMode.Create))
                    {
                        int readBytes = inputFile.Read(buffer, 0, partSize);
                        outputFile.Write(buffer, 0, readBytes);
                    }
                }
            }
        }
    }
}
