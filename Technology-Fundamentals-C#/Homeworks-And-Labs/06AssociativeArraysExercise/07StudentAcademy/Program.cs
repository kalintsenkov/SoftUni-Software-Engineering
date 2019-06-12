using System;
using System.Linq;
using System.Collections.Generic;

namespace _07StudentAcademy
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var dictionary = new Dictionary<string, List<double>>();

            for (int i = 0; i < n; i++)
            {
                string studentName = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!dictionary.ContainsKey(studentName))
                {
                    dictionary.Add(studentName, new List<double>());
                }

                dictionary[studentName].Add(grade);
            }

            foreach (var kvp in dictionary
                .Where(x => x.Value.Average() >= 4.50)
                .OrderByDescending(x => x.Value.Average()))
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value.Average():f2}");
            }
        }
    }
}
