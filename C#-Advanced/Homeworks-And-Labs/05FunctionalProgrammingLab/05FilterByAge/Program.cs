using System;
using System.Collections.Generic;
using System.Linq;

namespace _05FilterByAge
{
    public class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int peopleCount = int.Parse(Console.ReadLine());

            var people = new List<Person>();

            for (int i = 0; i < peopleCount; i++)
            {
                var tokens = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string personName = tokens[0];
                int personAge = int.Parse(tokens[1]);

                var person = new Person()
                {
                    Age = personAge,
                    Name = personName
                };

                people.Add(person);
            }

            string condition = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            Func<Person, bool> filterFunc = GetFilter(condition, age);

            string format = Console.ReadLine();

            Func<Person, string> selectFunc = GetSelector(format);

            var result = people
                .Where(filterFunc)
                .Select(selectFunc)
                .ToList();

            foreach (var person in result)
            {
                Console.WriteLine(person);
            }
        }

        private static Func<Person, string> GetSelector(string format)
        {
            if (format == "name age")
            {
                return p => $"{p.Name} - {p.Age}";
            }
            else if (format == "age")
            {
                return p => $"{p.Age}";
            }
            else
            {
                return p => $"{p.Name}";
            }
        }

        private static Func<Person, bool> GetFilter(string condition, int age)
        {
            if (condition == "older")
            {
                return x => x.Age >= age;
            }
            else
            {
                return x => x.Age < age;
            }
        }
    }
}
