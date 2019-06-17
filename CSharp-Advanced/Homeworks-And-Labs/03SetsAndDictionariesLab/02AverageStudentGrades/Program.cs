using System;
using System.Collections.Generic;
using System.Linq;

namespace _02AverageStudentGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var students = new Dictionary<string, List<double>>();

            for (int i = 0; i < n; i++)
            {
                var namesAndMarks = Console.ReadLine()
                    .Split()
                    .ToArray();

                string name = namesAndMarks[0];
                double mark = double.Parse(namesAndMarks[1]);

                if (!students.ContainsKey(name))
                {
                    students.Add(name, new List<double>());
                }

                students[name].Add(mark);
            }

            foreach (var kvp in students)
            {
                Console.Write($"{kvp.Key} -> ");

                foreach (var student in kvp.Value)
                {
                    Console.Write($"{student:f2} ");
                }

                Console.WriteLine($"(avg: {kvp.Value.Average():f2})");
            }
        }
    }
}
