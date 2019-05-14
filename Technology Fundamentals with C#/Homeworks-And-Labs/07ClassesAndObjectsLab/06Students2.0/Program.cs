using System;
using System.Linq;
using System.Collections.Generic;

namespace _06Students2._0
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

                if (IsExisting(studentsList, firstName, lastName))
                {
                    foreach (var currentStudent in studentsList)
                    {
                        if(currentStudent.FirstName == firstName && currentStudent.LastName == lastName)
                        {
                            currentStudent.Age = age;
                            currentStudent.City = city;
                        }
                    }
                }
                else
                {
                    studentsList.Add(new Student
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Age = age,
                        City = city
                    });
                }

                input = Console.ReadLine();
            }

            string wantedCity = Console.ReadLine();

            foreach (var student in studentsList.Where(x => x.City == wantedCity))
            {
                Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
            }
        }

        public static bool IsExisting(List<Student> studentsList, string firstName, string lastName)
        {
            foreach (var currentStudent in studentsList)
            {
                if (currentStudent.FirstName == firstName && currentStudent.LastName == lastName)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
