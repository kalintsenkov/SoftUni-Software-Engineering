using System;
using System.Linq;
using System.Collections.Generic;

namespace _03CookingFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var resultList = new List<int>();

            int bestSumQuality = int.MinValue;
            double bestAverageQuality = double.MinValue;
            int bestElementsCount = int.MinValue;

            while (input != "Bake It!")
            {
                var qualityList = input
                   .Split("#", StringSplitOptions.RemoveEmptyEntries)
                   .Select(int.Parse)
                   .ToList();

                int totalQuality = qualityList.Sum();
                double averageQuality = qualityList.Average();
                int elementsCount = qualityList.Count;
                
                if(totalQuality > bestSumQuality)
                {
                    bestSumQuality = totalQuality; // bestSum
                    resultList = qualityList; // bestList
                    bestAverageQuality = averageQuality; // bestAverage
                    bestElementsCount = elementsCount; // bestCount
                }
                else if(totalQuality == bestSumQuality && averageQuality > bestAverageQuality)
                {
                    bestAverageQuality = averageQuality;
                    bestSumQuality = totalQuality;
                    resultList = qualityList;
                    bestElementsCount = elementsCount;
                }
                else if (totalQuality == bestSumQuality && averageQuality == bestAverageQuality && elementsCount < bestElementsCount)
                {
                    bestElementsCount = elementsCount;
                    bestAverageQuality = averageQuality;
                    bestSumQuality = totalQuality;
                    resultList = qualityList;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Best Batch quality: {bestSumQuality}");
            Console.WriteLine(string.Join(" ", resultList));
        }
    }
}
