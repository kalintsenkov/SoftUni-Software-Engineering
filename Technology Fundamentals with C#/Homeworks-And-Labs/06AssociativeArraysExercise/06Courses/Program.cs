using System;
using System.Linq;
using System.Collections.Generic;

namespace _06Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            var courses = new Dictionary<string, List<string>>();

            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] tokens = input
                    .Split(" : ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string courseName = tokens[0];
                string studentName = tokens[1];

                if (!courses.ContainsKey(courseName))
                {
                    courses.Add(courseName, new List<string>());
                }

                courses[courseName].Add(studentName);

                input = Console.ReadLine();
            }

            foreach (var course in courses.OrderByDescending(x => x.Value.Count()))
            {
                Console.WriteLine($"{course.Key}: {course.Value.Count}");

                foreach (var student in course.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {student}");
                }
            }
        }
    }
}
