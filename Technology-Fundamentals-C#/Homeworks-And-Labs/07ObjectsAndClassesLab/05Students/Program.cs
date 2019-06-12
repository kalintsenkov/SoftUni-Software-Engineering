using System;
using System.Collections.Generic;
using System.Linq;

namespace _05Students
{
    public class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string City { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var studentsList = new List<Student>();

            while (input != "end")
            {
                var tokens = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string firstName = tokens[0];
                string lastName = tokens[1];
                int age = int.Parse(tokens[2]);
                string city = tokens[3];

                var student = new Student
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Age = age,
                    City = city
                };

                studentsList.Add(student);

                input = Console.ReadLine();
            }

            string wantedCity = Console.ReadLine();

            foreach (var student in studentsList.Where(x => x.City == wantedCity))
            {
                Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
            }
        }
    }
}
