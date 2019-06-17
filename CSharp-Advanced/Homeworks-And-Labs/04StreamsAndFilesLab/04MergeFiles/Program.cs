using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _04MergeFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            string folderPath = "04. Merge Files";
            string firstFileName = "FileOne.txt";
            string secondFileName = "FileTwo.txt";

            string firstFilePath = Path.Combine(folderPath, firstFileName);
            string secondFilePath = Path.Combine(folderPath, secondFileName);

            var mergedList = new List<string>();

            var firstFileLines = File.ReadAllLines(firstFilePath);
            var secondFileLines = File.ReadAllLines(secondFilePath);

            foreach (var line in firstFileLines)
            {
                mergedList.Add(line);
            }

            foreach (var line in secondFileLines)
            {
                mergedList.Add(line);
            }

            string outputFilePath = "Output.txt";

            File.WriteAllLines(outputFilePath, mergedList.OrderBy(x => x));
        }
    }
}
